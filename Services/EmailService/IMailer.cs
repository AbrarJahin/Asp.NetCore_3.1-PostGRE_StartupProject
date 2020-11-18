using System.Threading.Tasks;

namespace StartupProject_Asp.NetCore_PostGRE.Services.EmailService
{
    public interface IMailer
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}
