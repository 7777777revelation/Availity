using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EnrollmentFileOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {

            //load the master enrollment file
            var path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "MasterEnrollmentFileSample.csv");
            var masterEnrollmentFile = FileOperations.LoadMasterEnrollmentFile(path);

            var enrollmentRecordsByInsuranceCo = masterEnrollmentFile.EnrollmentRecords.OrderBy(x => x.InsuranceCompany).ToList();
            var recordCount = enrollmentRecordsByInsuranceCo.Count();
            var currentInsurancCo = enrollmentRecordsByInsuranceCo[0].InsuranceCompany;
            List<EnrollmentRecord> tempList = new List<EnrollmentRecord>();
            for (int i = 0; i < recordCount; i++)
            {

                if ((i == (recordCount - 1)))// last record
                {
                    tempList.Add(enrollmentRecordsByInsuranceCo[i]);

                    //write out records to a new file
                    FileOperations.CreateNewInsuranceEnrollmentFile(tempList, Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName);
                }
                else if (!String.Equals(enrollmentRecordsByInsuranceCo[i].InsuranceCompany, currentInsurancCo)) //the insurance co of the current record has changed from the last record
                {
                    //write out records to a new file
                    FileOperations.CreateNewInsuranceEnrollmentFile(tempList, Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName);

                    //start new list
                    tempList = new List<EnrollmentRecord>();
                    currentInsurancCo = enrollmentRecordsByInsuranceCo[i].InsuranceCompany;
                    tempList.Add(enrollmentRecordsByInsuranceCo[i]);
                }
                else
                {
                    tempList.Add(enrollmentRecordsByInsuranceCo[i]);
                }
            }


            int test = 5;

        }
    }
}


