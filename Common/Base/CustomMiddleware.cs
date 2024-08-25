namespace _2Work_API.Common.Base
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Notify _notify;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
            _notify = new();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _notify.AddMessage(ex.Message);
            }
        }
    }
}
