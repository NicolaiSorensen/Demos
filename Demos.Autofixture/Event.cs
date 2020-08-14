using System;
using System.Net.Mail;

namespace Demos.AutoFixture
{
    public class Event
    {
        public Event(string subject, string content, int priority)
        {
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Priority = priority;
            Created = DateTime.Now;
        }

        public string Subject { get; private set; }

        public string Content { get; private set; }

        public DateTime Created  { get; private set; }

        public int Priority { get; private set; }
    }
}
