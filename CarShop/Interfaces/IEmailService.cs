using System.Net.Mail;
using CarShop.Models;

namespace CarShop.Interfaces
{
    public interface IEmailService
    {
        MailMessage CreateMailMessage(Car carmodel);
        void SendEmail(MailMessage mailMessage);
    }
}