using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Watermeter.Project.API.Models.Email;
using Watermeter.Project.API.Services.Interfaces;

namespace Watermeter.Project.API.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmailConfirmation(List<string> emails, string about, string route)
        {
			try
			{
				Message message = new(emails, about, route);

                var messageBody = EmailBodyFactory(message);
                SendEmail(messageBody);
			}
			catch
			{
				throw;
			}
        }

        private void SendEmail(MimeMessage messageBody)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(configuration.GetValue<string>("EmailSettings:SmtpServer"), configuration.GetValue<int>("EmailSettings:Port"), true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(configuration.GetValue<string>("EmailSettings:From"), configuration.GetValue<string>("EmailSettings:Password"));
                    client.Send(messageBody);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage EmailBodyFactory(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("default", configuration.GetValue<string>("EmailSettings:From")));
            emailMessage.To.AddRange(message.Destinations);
            emailMessage.Subject = message.About;
            emailMessage.Body = new TextPart(TextFormat.Text)
            {
                Text = message.Content
            };

            return emailMessage;
        }
    }
}
