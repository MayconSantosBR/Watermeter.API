using MimeKit;

namespace Watermeter.Project.API.Models.Email
{
    public class Message
    {
        public List<MailboxAddress> Destinations { get; set; }
        public string About { get; set; }
        public string Content { get; set; }

        public Message(List<string> destinations, string about, string route)
        {
            this.Destinations = new List<MailboxAddress>();
            this.About = about;
            this.Content = route;

            List<MailboxAddress> email = new();
            email.Add(new MailboxAddress("Email", destinations.FirstOrDefault()));

            this.Destinations.AddRange(email);
        }
    }
}
