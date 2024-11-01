using ApiGateway.Caching;
using ApiGateway.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy()
        //.LoadFromConfig(builder.Configuration.GetSection("ApiGateway"));
        .LoadFromMemory(BasicConfig.GetRoutes(), BasicConfig.GetClusters());
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IMemoryCacheService, MemoryCacheService>();
var app = builder.Build();


app.MapReverseProxy();
//app.MapReverseProxy(proxypipeline =>
//{
//    // Add Custom middleware to the proxy pipeline
//    proxypipeline.Use(async (context, next) =>
//    {
//        // Retrieve the caching services from the request's service provider
//        var cacheService = context.RequestServices.GetRequiredService<IMemoryCacheService>();
//        // Attempt to get a cache response based on the request path
//        var cacheResponse = cacheService.GetCache(context.Request.Path);

//        // if a cache response is found, lets use it
//        if(!string.IsNullOrEmpty(cacheResponse))
//        {
//            // Set the response content to Json
//            context.Response.ContentType = "application/json";
//            // Write the cache response to the response body
//            await context.Response.WriteAsync(cacheResponse);
//        } else
//        {
//            var originalResponseBodyStream = context.Response.Body;

//            // Create a new memory stream to temporarily store the response
//            using(var responseBody = new MemoryStream())
//            {
//                // Replace the response body stream with the memory stream
//                context.Response.Body = responseBody;

//                // Call the next middleware in the pipeline
//                await next();

//                context.Response.Body.Seek(0, SeekOrigin.Begin);
//                var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
//                context.Response.Body.Seek(0, SeekOrigin.Begin);
//                var cacheKey = context.Request.Path.ToString();
//                cacheService.SetCache(cacheKey, responseBodyText, 60);
//                await responseBody.CopyToAsync(originalResponseBodyStream);

//            }
//        }
//    });
//});
app.Run();
