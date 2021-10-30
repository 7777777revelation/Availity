using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentFileOrganizer
{
    public class EnrollmentRecord
    {
        public string UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Version { get; set; }
        public string InsuranceCompany { get; set; }
    }
}
