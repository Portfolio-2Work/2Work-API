namespace _2Work_API.Common.Base
{
    public class Notify
    {
        public Notify()
        {
        }

        public List<string> Messages { get; set; } = new();

        public void AddMessage(string message)
        {
            if (message == null)
                return;

            Messages.Add(message);
        }

        public void AddMessage(IEnumerable<string> messages)
        {
            if (messages != null && messages.Any())
            {
                foreach (var message in messages)
                {
                    AddMessage(message);
                }
            }
        }

        public void AddMessage(FluentValidation.Results.ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                Messages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
        }

        public List<string> GetMessages() => Messages;
        public string GetFlatMessages()
        {
            var result = "";
            if (Messages != null && Messages.Count > 0)
            {
                foreach (var message in Messages)
                {
                    result += message + ",";
                }
                return result;
            }
            return result;
        }
    }
}
