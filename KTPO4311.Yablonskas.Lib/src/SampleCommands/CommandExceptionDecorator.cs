using KTPO4311.Yablonskas.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Yablonskas.Lib.src.SampleCommands
{
    public class CommandExceptionDecorator: ISampleCommand
    {
        private readonly ISampleCommand sampleCommand;
        private IView view;

        public CommandExceptionDecorator(ISampleCommand sampleCommand, IView view)
        {
            this.sampleCommand = sampleCommand;
            this.view = view;
        }

        public void Execute()
        {
            view.Render("Начало: " + this.GetType().ToString());
            try
            {
                sampleCommand.Execute();
            }
            catch (Exception ex)
            {
                view.Render("Произошла ошибка: " + ex.Message);
            }
            finally
            {
                view.Render("Конец: " + this.GetType().ToString());
            }

        }
    }
}
