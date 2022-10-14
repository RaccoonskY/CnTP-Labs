



namespace KTPO4311.Yablonskas.Lib.src.LogAn
{
   
    public class EmailServiceFactory
    {
        private static IEmailService customEmailService = null;


        public static IEmailService Create()
        {
            if (customEmailService != null)
            {
                return customEmailService;
            }

            throw new NotImplementedException();
        }

        public static void SetService(IEmailService srv)
        {
            customEmailService = srv;
        }
    }
}
