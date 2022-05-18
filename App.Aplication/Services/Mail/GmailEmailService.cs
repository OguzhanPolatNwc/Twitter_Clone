using App.Application.Interfaces;

namespace App.Application.Services
{
    public class GmailEmailService : IEmailService
    {
        public void Send(string toEmail, string subject, string body)
        {
            Console.WriteLine("Email sent via Gmail");
        }

        public void Send(List<string> toEmails, string subject, string body)
        {
            Console.WriteLine("Group email sent via Gmail");
        }
    }
}
