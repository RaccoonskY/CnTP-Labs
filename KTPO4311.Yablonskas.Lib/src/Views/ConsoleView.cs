using KTPO4311.Yablonskas.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Yablonskas.Lib.src.Views
{
    public class ConsoleView: IView
    {
        public void Render(string text)
        {
            Console.WriteLine(text);
        }
    }
}
