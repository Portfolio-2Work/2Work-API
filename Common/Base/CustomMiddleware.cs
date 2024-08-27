using System.Net;
using System.Text.Json;

namespace _2Work_API.Common.Base
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                object json = new
                {
                    ErrorNotification = new
                    {
                        Messages = new string[] { ex.Message }
                    },
                    IsSuccess = false
                };

                JsonSerializerOptions options = new()
                {
                    PropertyNameCaseInsensitive = true
                };

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(json, options);

            }
        }
    }
}
