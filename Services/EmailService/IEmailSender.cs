using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartupProject_Asp.NetCore_PostGRE.Services.EmailService
{
    public interface IEmailSender
    {
        // Summary:
        //     This API supports the ASP.NET Core Identity default UI infrastructure and is
        //     not intended to be used directly from your code. This API may change or be removed
        //     in future releases.
        Task SendEmailAsync(string email, string subject, string body, ICollection<string> attachmentFilePathList = null);
    }
}
