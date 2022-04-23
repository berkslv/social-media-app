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
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Directory where the json files are located
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
    
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Hub of University", configuration.GetValue<string>("Mail:Account")));
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
                    client.Connect("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(configuration.GetValue<string>("Mail:Username"), configuration.GetValue<string>("Mail:Password"));

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