using KTPO4311.Yablonskas.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Yablonskas.Lib.src.SampleCommands
{
    public class FirstCommand: ISampleCommand
    {
        public FirstCommand(IView view)
        {
            this.view = view;
        }

        private readonly IView view;
        private int iExecute = 0;

        public void Execute()
        {
            iExecute++;
            view.Render(this.GetType().ToString() + "\n iExecute = " + iExecute);
           
        }
    }
}
