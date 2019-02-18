using System.Collections.Generic;

namespace JBHiFi
{
    public static class Cache
    {
        private static Dictionary<string, object> cache;

        private static object cacheLock = new object();
        public static Dictionary<string, object> AppCache
        {
            get
            {
                lock (cacheLock)
                {
                    if (cache == null)
                    {
                        cache = new Dictionary<string, object>();
                    }
                    return cache;
                }
            }
        }
    }
}