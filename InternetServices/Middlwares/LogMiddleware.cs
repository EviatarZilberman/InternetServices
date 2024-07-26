namespace InternetServices.Middlwares
{
    public class LogMiddleware
    {
        private readonly ILogger<LogMiddleware>? _logger;
        private readonly RequestDelegate? _next;
        private string? _message;

        public LogMiddleware(ILogger<LogMiddleware>? logger, RequestDelegate request, string message)
        {
            this._logger = logger;
            this._next = request;
            this._message = message;
        }

        public async Task? InvokeAsync(HttpContext httpContext)
        {
            this._logger?.LogInformation(this._message);
            try
            {
                this._logger?.LogInformation(httpContext.Request.Method);
            }
            catch (Exception ex)
            {
                this._logger?.LogError(ex.Message);

            }
            await this._next(httpContext);
            this._logger?.LogInformation(httpContext.Response.StatusCode.ToString());
        }
    }
}
