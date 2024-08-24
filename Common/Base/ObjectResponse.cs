namespace _2Work_API.Common.Base
{
    public class ObjectResponse<T> where T : new()
    {
        public T? Data { get; set; } = typeof(T).IsClass ? new T() : default(T);


        public Notify ErrorNotification { get; set; } = new Notify();


        public Notify SuccessNotification { get; set; } = new Notify();


        public bool IsSuccess => ErrorNotification.Messages == null || ErrorNotification.Messages.Count == 0;
    }
}
