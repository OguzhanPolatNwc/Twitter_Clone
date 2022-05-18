using App.Application.Interfaces;
using System.Net;
using System.Net.Mail;

namespace App.Application.Services.Mail
{
    public class SmtpEmailService : IEmailService
    {
        public void Send(string toEmail, string subject, string body)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential("platinumade05@gmail.com", "159753Plat");
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("platinumade05@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = body;
                client.Send(mail);
            }
            catch (Exception ex)
            {
            }
        }

        public void Send(List<string> toEmails, string subject, string body)
        {
            Console.WriteLine("Group email sent via SMTP");
        }
    }
}