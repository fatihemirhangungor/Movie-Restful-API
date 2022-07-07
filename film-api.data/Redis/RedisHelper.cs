﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace film_api.data.Redis
{
    public class RedisHelper : IRedisHelper
    {
        public async Task<string> GetKeyAsync(string key)
        {
            var database = await GetRedisDatabase();

            var value = await database.StringGetAsync(key);

            return await Task.FromResult(value);
        }

        public async Task<bool> SetKeyAsync(string key, string value)
        {
            var database = await GetRedisDatabase();

            return await database.StringSetAsync(key, value);
        }

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