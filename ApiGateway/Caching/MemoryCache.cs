using Microsoft.Extensions.Caching.Memory;

namespace ApiGateway.Caching
{
    public interface IMemoryCacheService
    {
        void SetCache(string key, object value, int expirationInSecods);

        string GetCache(string key);
    }

    public class MemoryCacheService(IMemoryCache memoryCache) : IMemoryCacheService
    {
        public string GetCache(string key)=> (string)memoryCache.Get(key)!;


        public void SetCache(String key, object value, int expirationInSecods) => memoryCache.Set(key, value, DateTimeOffset.Now.AddSeconds(expirationInSecods));


    }
}
