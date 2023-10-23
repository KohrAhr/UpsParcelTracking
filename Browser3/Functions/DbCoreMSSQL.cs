using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Browser3.Functions
{
    public class DbCoreMSSQL
    {
        #region Variables
        private static SqlConnection? _DbConnection = null;

        public static SqlConnection? DbConnection
        {
            get { return _DbConnection; }
            set { _DbConnection = value; }
        }
        #endregion Variables

        public void OpenConnection(string aConnectionString)
        {
            DbConnection = new SqlConnection(aConnectionString);
            DbConnection.Open();
        }

        public void CloseConnection()
        {
            DbConnection?.Close();
            DbConnection?.DisposeAsync();
            DbConnection = null;
        }

        /// <summary>
        ///     Run Select statement and return data in DataTable
        /// </summary>
        /// <param name="aSql"></param>
        /// <returns>
        /// 
        /// </returns>
        public DataTable? RunExecStatement(string aSql)
        {
            DataTable? result = null;

            using (SqlCommand sqlCommand = new SqlCommand(aSql, DbConnection))
            {
                result = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    sqlDataAdapter.Fill(result);
                }
            }

            return result;
        }

        /// <summary>
        ///     Run Select statement and return data in ObservableCollection
        /// </summary>
        /// <param name="aSql"></param>
        /// <returns>
        /// 
        /// </returns>
        public ObservableCollection<T> RunExecStatement<T>(string aSql)
        {
            ObservableCollection<T>? result = null;

            if (DbConnection == null) 
            {
                throw new ArgumentNullException("Connection is null");
            }

            result = new ObservableCollection<T>(DbConnection.Query<T>(aSql).ToList());

            return result;
        }

        /// <summary>
        ///     Run Non select statement
        /// </summary>
        /// <param name="aSql"></param>
        /// <returns></returns>
        public int? RunNonExecStatement(string aSql)
        {
            int? result = null;

            using (SqlCommand sqlCommand = new SqlCommand(aSql, DbConnection))
            {
                result = sqlCommand.ExecuteNonQuery();
            }

            return result;
        }

        /// <summary>
        ///     Run Scalar select statement
        /// </summary>
        /// <param name="aSql"></param>
        /// <returns></returns>
        public int RunScalarExecStatement(string aSql)
        {
            int result = -1;

            using (SqlCommand sqlCommand = new SqlCommand(aSql, DbConnection))
            {
                result = (int)sqlCommand.ExecuteScalar();
            }

            return result;
        }

        public int RunNonExecStatementEx(string aSql) 
        {
            int result;

            if (DbConnection == null)
            {
                throw new ArgumentNullException("Connection is null");
            }

            result = DbConnection.Query<int>(aSql).FirstOrDefault();

            return result;
        }


        /// <summary>
        ///     with OpenAI
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public ObservableCollection<T> ConvertDataTableToObservableCollection<T>(DataTable? dataTable) where T : new()
        {
            ObservableCollection<T> collection = new ObservableCollection<T>();

            if (dataTable != null) 
            { 
                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (DataRow row in dataTable.Rows)
                {
                    T item = new T();

                    foreach (PropertyInfo property in properties)
                    {
                        string propertyName = property.Name;

                        if (dataTable.Columns.Contains(propertyName))
                        {
                            object value = row[propertyName];

                            if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                // Property is nullable
                                if (value == DBNull.Value)
                                {
                                    property.SetValue(item, null);
                                }
                                else
                                {
                                    property.SetValue(item, Convert.ChangeType(value, Nullable.GetUnderlyingType(property.PropertyType)));
                                }
                            }
                            else
                            {
                                // Property is non-nullable
                                if (value != DBNull.Value)
                                {
                                    property.SetValue(item, Convert.ChangeType(value, property.PropertyType));
                                }
                            }
                        }
                    }
                    collection.Add(item);
                }
            }

            return collection;
        }
    }
}
