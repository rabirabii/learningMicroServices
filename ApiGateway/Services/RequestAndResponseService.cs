using Yarp.ReverseProxy.Transforms;

namespace ApiGateway.Services
{
    public static class RequestAndResponseService
    {
        public static IServiceCollection AddRequestAndResponseService(this IServiceCollection services, IConfiguration config)
        {
            services.AddReverseProxy()
                    .LoadFromConfig(config.GetSection("ApiGateway"))
                    .AddTransforms(builder =>
                    {
                        // This request : Going to API Controllers
                        builder.AddRequestTransform(transformContext =>
                        {
                            // Add or modify the request header
                            transformContext.HttpContext.Request.Headers["X-Modifier-Header"] = "Rabi";

                            // Rewrite the request path
                            transformContext.ProxyRequest.Headers.Add("X-Forwarded-Path", "/new-path");
                            transformContext.HttpContext.Request.Path = "/new-path";
                            // Log Request Details
                            var request = transformContext.HttpContext.Request;
                            Console.WriteLine($"Request Path : {request.Path}");
                            return ValueTask.CompletedTask;
                        });


                        // This is going to the client
                        builder.AddResponseTransform(transformContext =>
                        {
                            // Add or Modify the response header
                            transformContext.HttpContext.Response.Headers["X-Custom-Response-Header"] = "Custom Header Included";

                            // Log response
                            Console.WriteLine("Respone has been modified");
                            return ValueTask.CompletedTask;
                        });
                    });
                    
            return services;
        
        }

        public static IApplicationBuilder useRRS(this  IApplicationBuilder app)
        {
            app.UseMiddleware<Interceptor>();
            return app;
        }
    }


}
