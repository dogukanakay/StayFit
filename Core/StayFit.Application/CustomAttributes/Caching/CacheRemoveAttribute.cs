using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.CustomAttributes.Caching
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CacheRemoveAttribute : Attribute
    {
        public string CacheKey { get; }

        public CacheRemoveAttribute(string cacheKey)
        {
            CacheKey = cacheKey;
        }
    }
}
