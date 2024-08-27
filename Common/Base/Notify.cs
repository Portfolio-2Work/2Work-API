namespace _2Work_API.Common.Base
{
    public class Notify
    {
        public List<string> Messages { get; set; } = new();

        public Notify()
        {
        }

        public Notify(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
                Messages.Add(msg);
        }

        public void AddMessage(string message)
        {
            if (message == null)
                return;

            Messages.Add(message);
        }

        public void AddMessage(FluentValidation.Results.ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                Messages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
        }

        public List<string> GetMessages() => Messages;
    }
}
