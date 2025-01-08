using MimeKit;
using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using Shop.Core.Utilities.Results.Abstract;
using Shop.Core.Utilities.Results.Concrete.ErrorResults;
using Shop.Core.Utilities.Results.Concrete.SuccessResults;
using System.Text.RegularExpressions;

namespace Shop.Core.Helper.MailHelper
{
    public class EmailHelper : IEmailHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly IEmailConfiguration _emailConfiguration;
        public EmailHelper(IEmailConfiguration emailConfiguration, IWebHostEnvironment env)
        {
            _emailConfiguration = emailConfiguration;
            _env = env;
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            var pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new(pattern);
            return regex.IsMatch(email);
        }

        public async Task<IResult> SendEmailAsync(string email, string url, string subject, string token)
        {
            try
            {
                string senderEmail = _emailConfiguration.Email;
                string senderPassword = _emailConfiguration.Password;
                int port = _emailConfiguration.Port;
                string smtp = _emailConfiguration.SmtpServer;


                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("HelloJob", senderEmail));
                message.To.Add(MailboxAddress.Parse(email));
                message.Subject = subject;
                message.Importance = MessageImportance.High;
                string mybody = string.Empty;
                string path = Path.Combine(_env.WebRootPath, "Templates", "Verify.html");
                using (StreamReader SourceReader = System.IO.File.OpenText(path))
                {
                    mybody = SourceReader.ReadToEnd();
                }
                mybody = mybody.Replace("{{url}}", url);
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = mybody
                };
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(smtp, port, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(senderEmail, senderPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                return new SuccessResult("Email send succesfully!");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }

        public async Task<IResult> SendNotificationEmailAsync(string email, string subject, string message)
        {
            try
            {
                string senderEmail = _emailConfiguration.Email;
                string senderPassword = _emailConfiguration.Password;
                int port = _emailConfiguration.Port;
                string smtp = _emailConfiguration.SmtpServer;

                var notificationMessage = new MimeMessage();
                notificationMessage.From.Add(new MailboxAddress("HelloJob", senderEmail));
                notificationMessage.To.Add(MailboxAddress.Parse(email));
                notificationMessage.Subject = subject;
                notificationMessage.Importance = MessageImportance.High;
                notificationMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(smtp, port, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(senderEmail, senderPassword);
                    await client.SendAsync(notificationMessage);
                    await client.DisconnectAsync(true);
                }

                return new SuccessResult("Melumatlandirma e-postası ugurla gönderildi!");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }


    }
}

