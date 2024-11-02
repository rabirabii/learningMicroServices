namespace ApiGateway.Services
{
    public class Interceptor(RequestDelegate next)
    {

        public async Task InvokeAsync(HttpContext context)
        {
            await next(context);
        }
    }
}
