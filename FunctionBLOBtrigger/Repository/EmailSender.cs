using System.Net;
using System.Net.Mail;
using FunctionBLOBtrigger.Services;

namespace FunctionBLOBtrigger.Repository
{
    internal class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.sendgrid.net", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("apikey", "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")
            };

            return client.SendMailAsync(
                new MailMessage(from: "olegkrava7@gmail.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}

