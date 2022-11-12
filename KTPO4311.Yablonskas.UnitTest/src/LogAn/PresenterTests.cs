using KTPO4311.Yablonskas.Lib.src.LogAn;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.Extensions;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Yablonskas.UnitTest.src.LogAn
{
    public class PresenterTests
    {
        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender() 
        {
            IView mockView = Substitute.For<IView>();
            FakeLogAnalyzer stubLogAnalyzer = new();

            Presenter presenter = new(stubLogAnalyzer, mockView);
            stubLogAnalyzer.CallRaiseAnalyzedEvent();


            mockView.Received().Render("Обработка завершена");
        }

        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender_NSubstitute()
        {

            IView mockView = Substitute.For<IView>();
            ILogAnalyzer stubLogAnalyzer = Substitute.For<ILogAnalyzer>();

            Presenter presenter = new(stubLogAnalyzer, mockView);
            stubLogAnalyzer.Analyzed += Raise.Event<LogAnalyzerAction>();


            mockView.Received().Render("Обработка завершена");
        }


    }



    class FakeLogAnalyzer: LogAnalyzer
    {
        public void CallRaiseAnalyzedEvent()
        {
            base.RaiseAnalyzedEvent();
        }

    }

   
}
