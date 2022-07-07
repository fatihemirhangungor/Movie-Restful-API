using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace film_api.data.Redis
{
    public interface IRedisHelper
    {
        public Task<string> GetKeyAsync(string key);
        public Task<bool> SetKeyAsync(string key, string value);
    }
}
