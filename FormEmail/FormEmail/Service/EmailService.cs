using FormEmail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace FormEmail.Service
{
    public class EmailService
    {

        private SmtpClient _stmpClient;

        public EmailService()
        {
            _stmpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials =
                 new NetworkCredential("gym550182@gmail.com", "!QAZ2wsx#EDC")
            };

        }
            //Poniższa metoda tworzy tego maila
        public MailMessage SendMessage(Models.ContactForm model)
        {
            var mailMessage = new MailMessage
            {
                Sender = new MailAddress("gym550182@gmail.com"),
                From = new MailAddress("gym550182@gmail.com"),
                To = { "gym550182@gmail.com" },
                Subject= model.Subject,
                Body = model.Body,
                IsBodyHtml = true
            };
            return mailMessage;
        }

        //Poniższa metoda wysyła tylko maila
        public void SendEmail(MailMessage message)
        {
            _stmpClient.Send(message);
        }
    }
}