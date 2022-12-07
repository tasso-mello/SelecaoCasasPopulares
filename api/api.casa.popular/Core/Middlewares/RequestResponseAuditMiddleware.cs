namespace api.casa.popular.Core.Middlewares
{
    public class RequestResponseAuditMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseAuditMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception)
            {
                HandleExceptionAsync(context);
            }
        }

        private static void HandleExceptionAsync(HttpContext context)
            => context.Response.Redirect("/Error");
    }
}
