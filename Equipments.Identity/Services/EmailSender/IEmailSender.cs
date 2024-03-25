using System.Threading.Tasks;

namespace Equipments.Identity.Services.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
