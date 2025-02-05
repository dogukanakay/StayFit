using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Commons.CustomAttributes.Caching
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CacheAttribute : Attribute
    {
        public string CacheKey { get; }
        public int ExpirationInSeconds { get; }

        public CacheAttribute(string cacheKey, int expirationInSeconds)
        {
            CacheKey = cacheKey;
            ExpirationInSeconds = expirationInSeconds;
        }
    }
}
