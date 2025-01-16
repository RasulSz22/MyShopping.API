using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Shop.Core.Helper.MailHelper;
namespace Shop.Businness.Services.MailService
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "smtp.server.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUser = "your-email@example.com";
        private readonly string _smtpPass = "your-email-password";


        public async Task SendAsync(string email, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Name", _smtpUser)); 
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;  

            message.Body = new TextPart("html") { Text = body };

            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpUser, _smtpPass);
                await client.SendAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Email could not be sent: {ex.Message}", ex);
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }
}
