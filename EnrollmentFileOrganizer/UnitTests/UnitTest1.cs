using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnrollmentFileOrganizer;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LineParser_CorrectlyParsesFieldContainingComma()
        {
            LineParser parser = new LineParser("\"User9822\", \"Bellto\", \"Mike\", \"65\", \"Hartford Insurance Co., Inc\"");
            var enrollmentRecord = parser.Parse();
            Assert.AreEqual(enrollmentRecord.InsuranceCompany, "Hartford Insurance Co., Inc");
        }

        [TestMethod]
        public void LineParser_CorrectlyParsesFieldsThatDoNotContainCommas()
        {
            LineParser parser = new LineParser("\"User9822\", \"Bellto\", \"Mike\", \"65\", \"Hartford Insurance Co. Inc\"");
            var enrollmentRecord = parser.Parse();
            Assert.AreEqual(enrollmentRecord.InsuranceCompany, "Hartford Insurance Co. Inc");
        }

        [TestMethod]
        public void LoadMasterEnrollmentFile_ReturnsFileObjectWithCorrectNumberOfRecords()
        {
            //load the master enrollment file
            var path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "MasterEnrollmentFileSample.csv");
            var masterEnrollmentFile = FileOperations.LoadMasterEnrollmentFile(path);
            Assert.AreEqual(masterEnrollmentFile.EnrollmentRecords.Count, 22);
        }






    }
}


