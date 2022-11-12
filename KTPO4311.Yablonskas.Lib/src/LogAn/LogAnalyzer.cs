using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Yablonskas.Lib.src.LogAn
{
    public class LogAnalyzer : ILogAnalyzer
    {
        public event LogAnalyzerAction Analyzed = null;

        public IExtensionManager mrg;
        public IWebService srv;
        public IEmailService email;
        public LogAnalyzer()
        {
            mrg = ExtensionManagerFactory.Create();
            srv = WebServiceFactory.Create();
        }
        //Анализатор лог. файлов
        public bool IsValidLogFileName(string filename)
        {

            return mrg.IsValid(filename);
        }

        public void Analyze(string filename)
        {
            if (filename.Length < 8)
            {
                try
                {
                    //передать внешней службе сообщение об ошибке
                    srv = WebServiceFactory.Create();
                    srv.LogError("Filename is too short: " + filename);
                }
                catch (Exception e)
                {
                    //отправить сообщение по эл. почте
                    email = EmailServiceFactory.Create();
                    email.SendEmail("somewhere@mail.com", "Unable to call webservice", e.Message);


                }
            }

            RaiseAnalyzedEvent();
        }

        protected void RaiseAnalyzedEvent()
        {
            if (Analyzed != null)
            {
                Analyzed();
            }
        }
        //LAB#1
        //public bool WasLastFileNameValid { get; set; }

        //public bool IsValidLogFileName(string filename)
        //{
        //    WasLastFileNameValid = false;

        //    if (string.IsNullOrEmpty(filename))
        //    {
        //        throw new ArgumentException("Имя файла должно быть задано");
        //    }

        //    if (!filename.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
        //    {
        //        return false;
        //    }

        //    WasLastFileNameValid = true;
        //    return true;
        //}
    }
}
