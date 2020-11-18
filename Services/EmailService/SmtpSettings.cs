namespace StartupProject_Asp.NetCore_PostGRE.Services.EmailService
{
    public class SmtpSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; }
        public string SenderEmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}