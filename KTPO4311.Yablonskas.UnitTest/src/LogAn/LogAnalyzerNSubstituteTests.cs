using KTPO4311.Yablonskas.Lib.src.LogAn;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Yablonskas.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerNSubstituteTests
    {

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
            fakeExtensionManager.IsValid("validfile.ext").Returns(true);
            ExtensionManagerFactory.SetManager(fakeExtensionManager);

            LogAnalyzer log = new();
            bool retr = log.IsValidLogFileName("validfile.ext");

            Assert.IsTrue(retr);

        }

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsFalse()
        {
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
            fakeExtensionManager.IsValid("unvalidfile.false").Returns(false);
            ExtensionManagerFactory.SetManager(fakeExtensionManager);

            LogAnalyzer log = new();
            bool retr = log.IsValidLogFileName("unvalidfile.false");

            Assert.IsFalse(retr);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            bool retr = true;
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
            fakeExtensionManager.When(x => x.IsValid(Arg.Any<string>()))
               .Do(context => { throw new Exception("fake exception"); });
            ExtensionManagerFactory.SetManager(fakeExtensionManager);

            LogAnalyzer log = new();
            try
            {
                log.IsValidLogFileName("WhatADay.ext");
            }
            catch (Exception)
            {
                 retr = false;
            }

            Assert.IsFalse(retr);

        }

        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            IWebService mockWebService = Substitute.For<IWebService>();
            WebServiceFactory.SetService(mockWebService);

            LogAnalyzer log = new LogAnalyzer();
            string filename = "1.ext";

            log.Analyze(filename);

            mockWebService.Received().LogError("Filename is too short: " + filename);

        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            IWebService stubWebService = Substitute.For<IWebService>();
            WebServiceFactory.SetService(stubWebService);
            stubWebService.When(x => x.LogError(Arg.Any<string>())).Do(context => { throw new Exception("fake exception"); });

            IEmailService mockEmail = Substitute.For<IEmailService>();
            EmailServiceFactory.SetService(mockEmail);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFilename = "abc.ext";
            log.Analyze(tooShortFilename);

            mockEmail.Received().SendEmail("somewhere@mail.com", "Unable to call webservice", "fake exception");

        }
    }

}
