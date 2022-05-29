using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace FlightLib
{
    public class Email
    {
        string fromEmail;
        string fromPass;
        string fromName;
        MailAddress fromAddr;
        string toEmail;
        string toName;
        MailAddress toAddr;
        string subject;
        string body;
        string template;
        SmtpClient smtp;
        public Email(string fromEmail, string fromPass, string fromName, string toEmail, string toName)
        {
            this.fromEmail = fromEmail;
            this.fromPass = fromPass;
            this.fromAddr = new MailAddress(fromEmail, fromName);

            this.fromName = fromName;
            this.toAddr = new MailAddress(toEmail, toName);
            this.toEmail = toEmail;
            this.toName = toName;
            this.smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(this.fromAddr.Address, fromPass)
            };

        }

        public string FromEmail { get => fromEmail; set => fromEmail = value; }
        public string FromPass { get => fromPass; set => fromPass = value; }
        public string ToEmail { get => toEmail; set => toEmail = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Body { get => body; set => body = value; }
        public string Template { get => template; set => template = value; }
        public string FromName { get => fromName; set => fromName = value; }
        public string ToName { get => toName; set => toName = value; }
        public void Send()
        {
            using (var message = new MailMessage(fromAddr, toAddr)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }
        public static bool IsValidEmail(string eMail)
        {
            bool Result = false;

            try
            {
                var eMailValidator = new MailAddress(eMail);

                Result = (eMail.LastIndexOf(".") > eMail.LastIndexOf("@"));
            }
            catch
            {
                Result = false;
            };

            return Result;
        }
    }
}
