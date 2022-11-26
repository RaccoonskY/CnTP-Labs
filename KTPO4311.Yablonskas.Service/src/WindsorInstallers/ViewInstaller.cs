using Castle.Core.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO4311.Yablonskas.Lib.src.LogAn;
using KTPO4311.Yablonskas.Lib.src.SampleCommands;
using KTPO4311.Yablonskas.Lib.src.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Yablonskas.Service.src.WindsorInstallers
{
    public class ViewInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IView>().ImplementedBy<ConsoleView>().LifeStyle.Singleton
                );
        }
    }
}
