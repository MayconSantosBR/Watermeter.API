namespace Watermeter.Project.API.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailConfirmation(List<string> emails, string about, string route);
    }
}