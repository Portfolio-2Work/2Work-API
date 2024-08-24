using System.ComponentModel.DataAnnotations;

namespace _2Work_API.Interfaces.Notify
{
    public interface INotify
    {
        List<string> GetMessages();
        string GetFlatMessages();
        void AddMessage(string message);
        void AddMessage(IEnumerable<string> messages);
        void AddMessage(ValidationResult validationResult);
    }
}
