using Shop.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Helper.MailHelper
{
    public interface IEmailHelper
    {
        bool IsValidEmail(string email);

        Task<IResult> SendEmailAsync(string email, string url, string subject, string token);
        Task<IResult> SendNotificationEmailAsync(string email, string subject, string message);

    }
}
