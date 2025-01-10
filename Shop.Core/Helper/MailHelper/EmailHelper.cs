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
using Microsoft.AspNetCore.Hosting;

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
            if (string.IsNullOrWhiteSpace(email)) return false;
            const string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }

        public async Task<IResult> SendEmailAsync(string email, string url, string subject, string token)
        {
            if (!IsValidEmail(email))
                return new ErrorResult("Invalid email address.");

            try
            {
                string templatePath = Path.Combine(_env.WebRootPath, "Templates", "Verify.html");
                if (!File.Exists(templatePath))
                    return new ErrorResult("Email template not found.");

                string templateContent = await File.ReadAllTextAsync(templatePath);
                string body = templateContent.Replace("{{url}}", url).Replace("{{token}}", token);

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("HelloJob", _emailConfiguration.Email));
                message.To.Add(MailboxAddress.Parse(email));
                message.Subject = subject;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = body
                };

                return await SendEmailInternalAsync(message);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> SendNotificationEmailAsync(string email, string subject, string messageText)
        {
            if (!IsValidEmail(email))
                return new ErrorResult("Invalid email address.");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("HelloJob", _emailConfiguration.Email));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = messageText
            };

            return await SendEmailInternalAsync(message);
        }

        private async Task<IResult> SendEmailInternalAsync(MimeMessage message)
        {
            try
            {
                using var client = new SmtpClient();
                await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_emailConfiguration.Email, _emailConfiguration.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                return new SuccessResult("Email successfully sent!");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}

