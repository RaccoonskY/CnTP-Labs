
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;   
using KTPO4311.Yablonskas.Lib.src.SampleCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Yablonskas.Service.src.WindsorInstallers
{
    public class SampleCommandInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ISampleCommand>().ImplementedBy<SampleCommandDecorator>().LifeStyle.Singleton,
                Component.For<ISampleCommand>().ImplementedBy<CommandExceptionDecorator>().LifeStyle.Singleton,
                Component.For<ISampleCommand>().ImplementedBy<SecondCommand>().LifeStyle.Singleton
                );
        }
    }
}
