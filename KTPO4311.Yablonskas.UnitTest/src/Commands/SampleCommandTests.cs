using KTPO4311.Yablonskas.Lib.src.LogAn;
using KTPO4311.Yablonskas.Lib.src.SampleCommands;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.Extensions;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Yablonskas.UnitTest.src.Commands
{
    public class SampleCommandTests
    {
        [Test]
        public void IsFirstCommand_ExecuteReturnsCorrectText()
        {
            IView mockView = Substitute.For<IView>();
            FirstCommand firstCommand= new FirstCommand(mockView);

            firstCommand.Execute();


            mockView.Received().Render(firstCommand.GetType().ToString() + "\n iExecute = " + 1);

        }

        [Test]
        public void IsSampleCommandDecorator_CallsSampleCommandExecute()
        {
            IView mockView = Substitute.For<IView>();
            ISampleCommand mockSampleCommand = Substitute.For<ISampleCommand>();
            SampleCommandDecorator sampleCommandDecorator = new SampleCommandDecorator(mockSampleCommand, mockView);

            sampleCommandDecorator.Execute();


            mockSampleCommand.Received().Execute();
        }

        [Test]
        public void IsSampleCommandDecorator_ExecuteReturnsCorrectText()
        {
            IView mockView = Substitute.For<IView>();
            ISampleCommand mockSampleCommand = Substitute.For<ISampleCommand>();
            SampleCommandDecorator sampleCommandDecorator = new SampleCommandDecorator(mockSampleCommand, mockView);

            sampleCommandDecorator.Execute();


            mockView.Received().Render("Начало: " + sampleCommandDecorator.GetType().ToString());
            mockView.Received().Render("Конец: " + sampleCommandDecorator.GetType().ToString());
        }

        [Test]
        public void IsCommandExceptionDecorator_CallsSampleCommandExecute()
        {
            IView mockView = Substitute.For<IView>();
            ISampleCommand mockSampleCommand = Substitute.For<ISampleCommand>();
            CommandExceptionDecorator exceptionCommandDecorator = new CommandExceptionDecorator(mockSampleCommand, mockView);

            exceptionCommandDecorator.Execute();


            mockSampleCommand.Received().Execute();
        }

        [Test]
        public void IsCommandExceptionDecorator_ExecuteProceedsException()
        {
            IView mockView = Substitute.For<IView>();
            ISampleCommand mockSampleCommand = Substitute.For<ISampleCommand>();
            mockSampleCommand.When(x => x.Execute()).Do(context => { throw new Exception("fake exception"); });
            CommandExceptionDecorator exceptionCommandDecorator = new CommandExceptionDecorator(mockSampleCommand, mockView);

            exceptionCommandDecorator.Execute();


            mockView.Received().Render("Произошла ошибка: " + "fake exception");
        }
    }
}
