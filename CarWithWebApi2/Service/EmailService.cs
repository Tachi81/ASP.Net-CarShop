using System.Net;
using System.Net.Mail;
using CarWithWebApi2.Models;


namespace CarShop.Service
{
    public class EmailService 
    {
        private SmtpClient _smtpClient;
        private const string _login = "gym550182@gmail.com";
        private const string _pass = "!QAZ2wsx#EDC";

        public EmailService()
        {
            Initialize();
        }

        private void Initialize()
        {
            _smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(_login, _pass)
            };
        }
        public void SendEmail(EmailApiModel mail)
        {
            var message = new MailMessage
            {
                Sender = new MailAddress(_login),
                From = new MailAddress(_login),
                Subject = mail.Subject,
                To = { mail.To},
                Body = "Unauthorized person added car",
                IsBodyHtml = true
            };

            _smtpClient.Send(message);

        }
    }
}