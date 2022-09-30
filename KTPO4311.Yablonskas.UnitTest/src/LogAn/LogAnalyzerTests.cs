using NUnit.Framework;
using KTPO4311.Yablonskas.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KTPO4311.Yablonskas.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {



        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithbadextension.slf");

            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithbadextension.SLF");

            Assert.True(result);
        }

       
        [TestCase("filename.slf")]
        [TestCase("filename.SLF")]

        public void IsValidLogFileName_ValidExtension_ReturnsTrue(string filename)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName(filename);

            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(""));

            StringAssert.Contains("Имя файла должно быть задано", ex.Message);
        }


        [TestCase("badfile.fooo", false)]
        [TestCase("badfile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, analyzer.WasLastFileNameValid);

        }
    }
}
