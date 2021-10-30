using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentFileOrganizer
{
    public class MasterEnrollmentFile
    {
        public List<EnrollmentRecord> EnrollmentRecords { get; set; }
        public MasterEnrollmentFile() {
            EnrollmentRecords = new List<EnrollmentRecord>();
        }
    }
}
