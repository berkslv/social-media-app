using System.Net;
using Core.Utilities.Mail.Abstract;
using Core.Utilities.Results;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Core.Utilities.Mail.Concrete
{
    public class MailManager : IMailService
    {
        public async Task<IResult> SendMail(string mailAddress, string name, string subject, string body)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("CollegeHub", Environment.GetEnvironmentVariable("MAIL_ACCOUNT")));
            message.To.Add(new MailboxAddress(name, mailAddress));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(Environment.GetEnvironmentVariable("MAIL_HOST"), 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(Environment.GetEnvironmentVariable("MAIL_USERNAME"), Environment.GetEnvironmentVariable("MAIL_PASSWORD"));

                    await client.SendAsync(message);
                    client.Disconnect(true);

                    return new SuccessResult("Mail gönderildi", HttpStatusCode.OK);
                }
                catch (System.Exception)
                {
                    return new ErrorResult("Mail gönderiminde hata oluştu. Daha sonra tekrar deneyiniz.",  HttpStatusCode.BadRequest);
                }

            }
        }
    }
}