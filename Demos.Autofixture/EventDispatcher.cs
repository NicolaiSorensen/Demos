using System.Linq;

namespace Demos.AutoFixture
{
    public class EventDispatcher
    {
        private readonly IEventHub _eventHub;
        private readonly IValidator<Event> _validator;

        public EventDispatcher(IEventHub eventHub, IValidator<Event> validator)
        {
            _eventHub = eventHub;
            _validator = validator;
        }

        public void SendAll(Event[] events)
        {
            var validEvents = events.Where(x => _validator.Validate(x).IsValid).ToArray();
            _eventHub.Send(validEvents);
        }
    }

    public interface IValidator<in T>
    {
        public ValidationResult Validate(T entity);
    }

    public class ValidationResult
    {
        public ValidationResult(bool isValid, string validationError)
        {
            IsValid = isValid;
            ValidationError = validationError;
        }

        public string ValidationError { get; private set; }

        public bool IsValid { get; private set; }
    }

    public interface IEventHub
    {
        public void Send(Event[] events);
    }
    
}