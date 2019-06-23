using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompareCSV;

namespace DiffTest
{
    [TestClass]
    public class ValidationMessage
    {
        [TestMethod]
        public void ArgumentCheck()
        {
            string input = "/var/log/a.csv";
            CompareCSV.Comparison compare = new CompareCSV.Comparison();
            Comparison.diffOffCsv(input);
        }
    }
}
