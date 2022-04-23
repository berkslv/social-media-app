using Core.Utilities.Results;

namespace Core.Utilities.Mail.Abstract
{
    public interface IMailService
    {
        Task<IResult> SendMail(string mailAddress, string name, string subject, string body);
    }
}