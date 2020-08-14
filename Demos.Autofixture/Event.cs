using System;
using System.Net.Mail;

namespace Demos.AutoFixture
{
    public class Event
    {
        public Event(string subject, string content)
        {
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Created = DateTime.Now;
        }

        public string Subject { get; private set; }
        public string Content { get; private set; }
        public DateTime Created  { get; private set; }
    }
}
