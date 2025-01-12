using Microsoft.AspNetCore.Hosting;
using NETCore.MailKit.Core;
using Shop.Core.Utilities.Results.Abstract;
using Shop.Core.Utilities.Results.Concrete.ErrorResults;
using Shop.Core.Utilities.Results.Concrete.SuccessResults;
using System.Text.RegularExpressions;

namespace Shop.Core.Helper.MailHelper
{
    public class EmailHelper : IEmailHelper
    {
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _env;

        public EmailHelper(IEmailService emailService, IWebHostEnvironment env)
        {
            _emailService = emailService;
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

            if (string.IsNullOrWhiteSpace(url))
                return new ErrorResult("URL cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(subject))
                return new ErrorResult("Subject cannot be null or empty.");

            try
            {
                string body = await GenerateEmailBodyAsync(url);
                await _emailService.SendAsync(email, subject, body);
                return new SuccessResult("Email sent successfully!");
            }
            catch (FileNotFoundException ex)
            {
                return new ErrorResult("Email template file not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                return new ErrorResult("An error occurred while sending the email: " + ex.Message);
            }
        }

        public async Task<IResult> SendNotificationEmailAsync(string email, string subject, string message)
        {
            if (!IsValidEmail(email))
                return new ErrorResult("Invalid email address.");

            if (string.IsNullOrWhiteSpace(subject))
                return new ErrorResult("Subject cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(message))
                return new ErrorResult("Message cannot be null or empty.");

            try
            {
                await _emailService.SendAsync(email, subject, message);
                return new SuccessResult("Notification sent successfully!");
            }
            catch (Exception ex)
            {
                return new ErrorResult("An error occurred while sending the notification: " + ex.Message);
            }
        }

        private async Task<string> GenerateEmailBodyAsync(string url)
        {
            string templatePath = Path.Combine(_env.WebRootPath, "Templates", "Verify.html");

            if (!File.Exists(templatePath))
                throw new FileNotFoundException("Email template file not found at " + templatePath);

            string body;

            try
            {
                using StreamReader reader = new StreamReader(templatePath);
                body = await reader.ReadToEndAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while reading the email template: " + ex.Message);
            }

            return body.Replace("{{url}}", url, StringComparison.OrdinalIgnoreCase);
        }

        Task<IResult> IEmailHelper.SendEmailAsync(string email, string url, string subject, string token)
        {
            return SendEmailAsync(email, url, subject, token);
        }

        Task<IResult> IEmailHelper.SendNotificationEmailAsync(string email, string subject, string message)
        {
            return SendNotificationEmailAsync(email, subject, message);
        }
    }
}
