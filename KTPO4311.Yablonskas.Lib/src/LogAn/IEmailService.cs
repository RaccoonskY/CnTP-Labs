
namespace KTPO4311.Yablonskas.Lib.src.LogAn
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
}
