using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTPO4311.Yablonskas.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;

namespace KTPO4311.Yablonskas.UnitTest.src.Sample
{ 
    public class SampleNSubstituteTests
    {
        [Test]
        public void Returns_ParticularArg_Works()
        {
            //создание поддельного объекта
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
            //Настроить объект, чтобы метод возвращал true для заданного значения входного параметра
            fakeExtensionManager.IsValid("validfile.ext").Returns(true);

            //Воздейстие на тестируемый объект 
            bool result = fakeExtensionManager.IsValid("validfile.ext");

            //Проверка ожидаемого результата
            Assert.IsTrue(result); 

        }

        [Test]
        public void Returns_ArgAny_Works()
        {
            //создание поддельного объекта
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
            //Настроить объект, чтобы метод возвращал true для заданного значения входного параметра
            fakeExtensionManager.IsValid(Arg.Any<string>()).Returns(true);

            //Воздейстие на тестируемый объект 
            bool result = fakeExtensionManager.IsValid("anyfile.ext");

            //Проверка ожидаемого результата
            Assert.IsTrue(result);

        }

        [Test]

        public void Returns_ArgAny_Throws()
        {
            //Создание поддельного объекта
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            //настройка объекта, чтобы метод вызывал исключение, независимо от входных аргументов
            fakeExtensionManager.When(x => x.IsValid(Arg.Any<string>()))
                .Do(context => { throw new Exception("fake exception"); });

            //Проверка, что было вызвано исключение
            Assert.Throws<Exception>(() => fakeExtensionManager.IsValid("anything"));

        }

        [Test]
        public void Received_ParticularArg_Saves()
        {
            //Поддельный объект
            IWebService mockWebService = Substitute.For<IWebService>();

            //Воздействие на подделку
            mockWebService.LogError("Fake message");

            //Проверка, что поддельный объект сохранил параметры вызова
            mockWebService.Received().LogError("Fake message");
        }

    }   
}
