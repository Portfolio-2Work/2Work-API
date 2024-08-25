namespace _2Work_API.Interfaces.Notify
{
    public interface INotify
    {
        List<string> GetMessages();
        void AddMessage(string message);
        void AddMessage(FluentValidation.Results.ValidationResult validationResult);
    }
}
