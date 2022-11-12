using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Yablonskas.Lib.src.LogAn
{
    public class Presenter
    {
        public ILogAnalyzer logAnalyzer;
        public IView view;

        public Presenter(ILogAnalyzer logAnalyzer, IView view)
        {
            this.view = view;
            this.logAnalyzer = logAnalyzer;
            logAnalyzer.Analyzed += OnLogAnalyzed;
        }

        private void OnLogAnalyzed()
        {
            view.Render("Обработка завершена");
        }
    }
}
