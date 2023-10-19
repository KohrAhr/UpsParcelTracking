using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Browser3.Functions;

namespace Browser3.Core
{
    public static class CoreCache
    {
        /// <summary>
        ///     We are using Cache only for DataTable objects
        /// </summary>
        private static MemoryCache _cache = new MemoryCache("AppDataTableContext");

        public static T GetDataFromCacheOrDatabase<T>(string sqlQuery, string objectName = "") where T : new()
        {
            // Calc CRC32 for SqlQuery string? And use CRC as Name?
            if (string.IsNullOrEmpty(objectName))
            {
                objectName = sqlQuery;
            }

            // We are using CRC32 hash sum as name :)
            string newObjectName = CalcFunctions.CalculateCRC32(objectName).ToString();

            // If the data is in the cache, return it
            if (_cache.Contains(newObjectName) && _cache[newObjectName] is T cachedObject)
            {
                return cachedObject;
            }

            T dataResult = new T();
            object? x;

            // If the data is not in the cache, fetch it from the database

            // Type DataTable -- regular sql query
            if (typeof(T) == typeof(DataTable))
            {
                x = AppData.DbMSSQL.RunExecStatement(sqlQuery);

                if (x != null)
                {
                    dataResult = (T)x;
                }
            }
            else
            // Type Int -- Scalar query
            if (typeof(T) == typeof(Int64) || typeof(T) == typeof(Int32) || typeof(T) == typeof(Int16) || typeof(T) == typeof(int))
            {
                x = AppData.DbMSSQL.RunScalarExecStatement(sqlQuery);

                if (x != null)
                {
                    dataResult = (T)x;
                }
            }
            else
            {
                // Other type ?
                throw new NotImplementedException();
            }

            if (dataResult != null)
            {
                // Store the data in the cache with an expiration time
                CacheItemPolicy policy = new CacheItemPolicy
                {
                    // 60 minutes
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60)
                };
                _cache.Add(newObjectName, dataResult, policy);
            }

            return dataResult;
        }
    }
}
