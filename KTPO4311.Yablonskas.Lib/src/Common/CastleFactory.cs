using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Yablonskas.Lib.src.Common
{
    public static class CastleFactory
    {
        public static IWindsorContainer container { get; private set; }

        static CastleFactory()
        {
            container = new WindsorContainer();
        }
    }
}
