using System.Text.Json;

namespace UserPlatform.Api.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                _logger.LogError($"Sales.Lead got an error : {ex.Message}\\n Stack Trace : {ex.StackTrace}\\n Inner Exception : {ex.InnerException?.Message}\\n Inner Stack : {ex.InnerException?.StackTrace}");

                await context.Response.WriteAsync(JsonSerializer.Serialize(ex.Message));
            }
        }
    }
}
