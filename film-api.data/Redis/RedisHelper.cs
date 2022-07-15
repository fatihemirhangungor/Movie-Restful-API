using StackExchange.Redis;

namespace film_api.data.Redis
{
    public class RedisHelper : IRedisHelper
    {
        /// <summary>
        /// Read the value of given key
        /// </summary>
        /// <param name="key">Name of the key</param>
        /// <returns>String data from redis</returns>
        public async Task<string> GetKeyAsync(string key)
        {
            var database = await GetRedisDatabase();

            var value = await database.StringGetAsync(key);

            return await Task.FromResult(value);
        }

        /// <summary>
        /// Create a key with value
        /// </summary>
        /// <param name="key">Name of the key</param>
        /// <param name="value">Name of the value</param>
        /// <returns>Redis Key</returns>
        public async Task<bool> SetKeyAsync(string key, string value)
        {
            var database = await GetRedisDatabase();

            return await database.StringSetAsync(key, value);
        }

        /// <summary>
        /// Connection for redis database
        /// </summary>
        /// <returns>IDatabase</returns>
        private async Task<IDatabase> GetRedisDatabase()
        {
            var config = new ConfigurationOptions
            {
                EndPoints = { "localhost" },
                Ssl = false,
                AbortOnConnectFail = false
            };

            ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(config);

            return redis.GetDatabase(0);
        }
    }
}