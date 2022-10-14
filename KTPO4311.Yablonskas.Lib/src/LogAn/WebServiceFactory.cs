using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Yablonskas.Lib.src.LogAn
{
    
    public class WebServiceFactory
    {
        private static IWebService customService = null;

        public static IWebService Create()
        {
            if (customService != null)
            {
                return customService;
            }

            return new WebService();
        }

        public static void SetService(IWebService srv)
        {
            customService = srv;
        }
    }
}
