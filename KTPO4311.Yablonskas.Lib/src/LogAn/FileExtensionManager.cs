
using System.Configuration;
using System.Reflection;


namespace KTPO4311.Yablonskas.Lib.src.LogAn
{
    public class FileExtensionManager : IExtensionManager
    {
        
        public bool IsValid(string file)
        {

            //читать конфиг. файл
            //вернуть true
            //если конфигурация поддерживается 
            string[] confValue = ConfigurationManager.AppSettings["AccaptableExtensions"].Split(" ");
            string extstr = Path.GetExtension(file);

            if (confValue == null)
            {
                Console.WriteLine("Your file has no appropriate configuration valie!");
                throw new NotImplementedException();
            }
                
            if (Array.IndexOf(confValue, extstr) != -1)
            {
                return true;

            }
            else
            {
                return false;
            }

        }
    }
}