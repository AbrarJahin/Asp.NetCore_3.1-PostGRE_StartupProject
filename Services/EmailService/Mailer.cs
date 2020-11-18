using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Hosting;
using MailKit.Security;

namespace StartupProject_Asp.NetCore_PostGRE.Services.EmailService
{
    public class Mailer : IMailer
    {
        private readonly SmtpSettings SmtpSettings;
        private readonly IWebHostEnvironment Environment;
        private readonly ILogger<Mailer> Logger;

        public Mailer(IOptions<SmtpSettings> _options, IWebHostEnvironment _env, ILogger<Mailer> logger)
        {
            Environment = _env;
            SmtpSettings = _options.Value;
            Logger = logger;
        }

        [Obsolete]
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(SmtpSettings.SenderName, SmtpSettings.SenderEmailAddress));
                message.To.Add(new MailboxAddress(email));
                message.Subject = subject;
                message.Body = new TextPart("html")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    if (Environment.IsDevelopment())
                    {
                        await client.ConnectAsync(SmtpSettings.Server, SmtpSettings.Port, SecureSocketOptions.StartTlsWhenAvailable);
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                    }
                    else
                    {
                        await client.ConnectAsync(SmtpSettings.Server);
                    }

                    await client.AuthenticateAsync(SmtpSettings.UserName, SmtpSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError("Email Sent Failed - " + ex.Message);
            }
        }
    }
}
