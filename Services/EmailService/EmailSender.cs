using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Hosting;
using MailKit.Security;
using System.Collections.Generic;

namespace StartupProject_Asp.NetCore_PostGRE.Services.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings SmtpSettings;
        private readonly IWebHostEnvironment Environment;
        private readonly ILogger<EmailSender> Logger;

        public EmailSender(IOptions<SmtpSettings> _options, IWebHostEnvironment _env, ILogger<EmailSender> logger)
        {
            Environment = _env;
            SmtpSettings = _options.Value;
            Logger = logger;
        }

        [Obsolete]
        public async Task SendEmailAsync(string email, string subject, string body, ICollection<string> attachmentFilePathList = null)
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
                //Configuring with razor email template
                //https://derekarends.com/how-to-create-email-templates-with-asp-net-core-2-2/

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

                    //Send an attachment
                    //foreach (string item in attachmentFilePathList)
                    //{
                    //}
                    //var attachment = new MimePart("image", "gif")
                    //{
                    //    Content = new MimeContent(File.OpenRead(path)),
                    //    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    //    ContentTransferEncoding = ContentEncoding.Base64,
                    //    FileName = Path.GetFileName(path)
                    //};

                    //// now create the multipart/mixed container to hold the message text and the
                    //// image attachment
                    //var multipart = new Multipart("mixed");
                    //multipart.Add(body);
                    //multipart.Add(attachment);

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
