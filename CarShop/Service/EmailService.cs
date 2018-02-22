using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using CarShop.Interfaces;
using CarShop.Models;

namespace CarShop.Service
{
    public class EmailService : IEmailService
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

        public MailMessage CreateMailMessage(Car carmodel)
        {
            return new MailMessage
            {
                Sender = new MailAddress(_login),
                From = new MailAddress(_login),
                To = { _login},
                Subject = $"Unauthorized person added car at {carmodel.DateCreate}",
                Body = "Unauthorized person added car",
                IsBodyHtml = true
            };

        }



        public void SendEmail(MailMessage mailMessage)
        {
            _smtpClient.Send(mailMessage);

        }
    }
}