namespace film_api.data.Redis
{
    public interface IRedisHelper
    {
        public Task<string> GetKeyAsync(string key);
        public Task<bool> SetKeyAsync(string key, string value);
    }
}
