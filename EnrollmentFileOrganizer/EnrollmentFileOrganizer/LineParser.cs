using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentFileOrganizer
{
    public class LineParser
    {
        private string _line;

        public LineParser(string line)
        {
            _line = line;
        }

        public EnrollmentRecord Parse() {

            EnrollmentRecord record = new EnrollmentRecord();

            try {
                int columnCount = 0; //0 = UserId, 1 = LastName, 2 = FirstName, 3 = Version, 4 = InsuranceCompany

                string columnString = "";
                bool isStartQuote = false;
                int lineLength = _line.Length;
                for (int i = 0; i < lineLength; i++)
                {
                    if (_line[i] == '"')
                    {
                        if (!isStartQuote)
                            isStartQuote = true;
                        else //this is an end quote
                        {
                            switch (columnCount)
                            {
                                //TODO: use an enum instead of "magic" numbers
                                case 0:
                                    record.UserId = columnString;
                                    break;
                                case 1:
                                    record.LastName = columnString;
                                    break;
                                case 2:
                                    record.FirstName = columnString;
                                    break;
                                case 3:
                                    record.Version = Convert.ToInt16(columnString);
                                    break;
                                case 4:
                                    record.InsuranceCompany = columnString;
                                    break;
                                default:
                                    break;
                            }

                            columnCount++;
                            columnString = "";
                            isStartQuote = false;
                        }
                    }
                    else if (_line[i] == ',')
                    {
                        if (isStartQuote)
                        {
                            //if we are within double quotes, the comma is part of the column, so add it
                            columnString = columnString + _line[i];
                        }
                        //skip char
                        continue;
                    }
                    else
                    {
                        //TODO: change to StringBuilder, as this concatenation really inefficient
                        columnString = columnString + _line[i];
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception(string.Format("Error parsing line '{0}' in Master Enrollment File.", _line)) ;
            }
            
            return record;
        }
    }
}
