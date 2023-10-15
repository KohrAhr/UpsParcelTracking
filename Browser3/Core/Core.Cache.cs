using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Browser3.Core
{
    public static class CoreCache
    {
        /// <summary>
        ///     We are using Cache only for DataTable objects
        /// </summary>
        private static MemoryCache _cache = new MemoryCache("App");

        public static DataTable? GetDataFromCacheOrDatabase(string objectName, string sqlQuery)
        {
            // If the data is in the cache, return it
            if (_cache.Contains(objectName))
            {
                CacheItem cachedData = _cache.GetCacheItem(objectName);
                return (DataTable) cachedData.Value;
            }

            // If the data is not in the cache, fetch it from the database
            DataTable? dataTable = AppData.DbMSSQL.RunExecStatement(sqlQuery);

            if (dataTable != null) 
            { 
                // Store the data in the cache with an expiration time
                CacheItemPolicy policy = new CacheItemPolicy
                {
                    // 60 minutes
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60)
                };
                _cache.Add(objectName, dataTable, policy);
            }

            return dataTable;
        }
    }
}
