using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EnrollmentFileOrganizer
{
    public static class FileOperations
    {
        public static MasterEnrollmentFile  LoadMasterEnrollmentFile(string filePath)
        {
            MasterEnrollmentFile masterFile = null;
            int counter = 0;
            string line;
            bool isFirstLine = true;
            try
            {
                masterFile = new MasterEnrollmentFile();
                using (StreamReader file = new StreamReader(filePath))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (isFirstLine)
                        {
                            //skip header line;
                            isFirstLine = false;
                            continue;
                        }

                        LineParser parser = new LineParser(line);
                        EnrollmentRecord record = parser.Parse();
                        masterFile.EnrollmentRecords.Add(record);

                        counter++;
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception(string.Format("Error attempting to load MasterEnrollmentFile: {0}", exc.Message));
            }

            return masterFile;
        }

        public static bool CreateNewInsuranceEnrollmentFile(List<EnrollmentRecord> enrollmentRecords, string destinationFolder)
        {
            bool wasSuccess = true;
            try {
                //loop through and add to dictionary
                Dictionary<string, EnrollmentRecord> userIdToEnrollmentRecord = new Dictionary<string, EnrollmentRecord>();
                foreach (var enrollRecord in enrollmentRecords)                
                {
                    EnrollmentRecord foundRecord = null;
                    bool wasFound = userIdToEnrollmentRecord.TryGetValue(enrollRecord.UserId, out foundRecord);
                    if (wasFound)
                    {
                        if (enrollRecord.Version > foundRecord.Version)
                        {
                            userIdToEnrollmentRecord.Remove(enrollRecord.UserId);
                            userIdToEnrollmentRecord.Add(enrollRecord.UserId, enrollRecord);
                        }
                    }
                    else
                    {
                        userIdToEnrollmentRecord.Add(enrollRecord.UserId, enrollRecord);
                    }
                }

                //now replace enrollmentRecords with what is in dictionary
                enrollmentRecords = new List<EnrollmentRecord>();
                foreach (KeyValuePair<string, EnrollmentRecord> entry in userIdToEnrollmentRecord)
                {
                    enrollmentRecords.Add(entry.Value);
                }

                //order by last, then first name
                enrollmentRecords = enrollmentRecords.OrderBy(x => x.LastName).ThenBy(y => y.FirstName).ToList();


                string destinationFilename = Path.Combine(destinationFolder, string.Format("{0}.csv", enrollmentRecords[0].InsuranceCompany.Replace(",", "").Replace(".", "").Replace(" ", "")));
                using (StreamWriter writer = new StreamWriter(destinationFilename))
                {
                    foreach (var record in enrollmentRecords)
                    {
                        writer.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"", record.UserId, record.LastName, record.FirstName, record.Version, record.InsuranceCompany));
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception(string.Format("Error creating new insurance enrollment file for {0}", enrollmentRecords[0].InsuranceCompany));
            }

            return wasSuccess;
        }




    }
}



//using (StreamWriter writer = new StreamWriter(fullPath))  
//{  
//   writer.WriteLine("Monica Rathbun");  
//   writer.WriteLine("Vidya Agarwal");  
//   writer.WriteLine("Mahesh Chand");  
//   writer.WriteLine("Vijay Anand");  
//   writer.WriteLine("Jignesh Trivedi");  
//}  