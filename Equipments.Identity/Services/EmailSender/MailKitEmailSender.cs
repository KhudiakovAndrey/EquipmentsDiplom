using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace Equipments.Identity.Services.EmailSender
{
    public class MailKitEmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public MailKitEmailSender(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                using var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("КПК Компьютерная техника", _emailSettings.Name));
                emailMessage.To.Add(new MailboxAddress("Пользователю", to));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, false);
                    await client.AuthenticateAsync(_emailSettings.Name, _emailSettings.Password);
                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
