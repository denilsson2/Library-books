using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace Repository.Repository.Base
{
    /// <summary>
    /// Containing a SqlConnection and SqlCommand to perform Sql-queries
    /// </summary>
    public class SqlIt
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }

        public SqlIt(SqlConnection sc, string query)
        {
            Connection = sc;
            Command = new SqlCommand(query, Connection);
        }
    }

    /// <summary>
    /// Is used for getting and posting data from and to the database.
    /// </summary>
    /// <typeparam name="T">Entity model</typeparam>
    public abstract class BaseRepository<T>
        where T : class
    {
        private static object mapItEach(SqlDataReader dar, PropertyInfo pi)
        {
            return Convert.ChangeType(dar[pi.Name], pi.PropertyType);
        }

        private static T mapIt(SqlDataReader dar)
        {
            T _obj = Activator.CreateInstance<T>();
            Type t = typeof(T);

            foreach (PropertyInfo property in t.GetProperties())
                if (!Convert.IsDBNull(dar[property.Name]))
                    property.SetValue(_obj, Convert.ChangeType(dar[property.Name], property.PropertyType));
                else
                    property.SetValue(_obj, null);

            return (T)Convert.ChangeType(_obj, typeof(T));
        }

        private static SqlIt createSqlIt(string query, SqlParameter[] sp = null)
        {
            string _connectionString = DataSource.getConnectionString("projectmanager");

            SqlIt sqlIt = new SqlIt(new SqlConnection(_connectionString), query);

            if (sp != null && sp.Length > 0)
                sqlIt.Command.Parameters.AddRange(sp);

            return sqlIt;
        }

        protected static object dbGetProperty(string query, string propertyname, SqlParameter[] sp)
        {
            object _obj = new object();
            SqlIt sqlIt = null;
            PropertyInfo pi = typeof(T).GetProperty(propertyname);

            if (sp != null && sp.Length == 1)
                sqlIt = createSqlIt(query, sp);
            else
                return null;

            try
            {
                sqlIt.Connection.Open();
                SqlDataReader dar = sqlIt.Command.ExecuteReader();

                if (dar.Read())
                {
                    _obj = mapItEach(dar, pi);
                }
                else
                {
                    _obj = null;
                }
            }
            catch (Exception eObj)
            {
                throw new Exception("Database problem(s) when getting object property!", eObj);
            }
            finally
            {
                if (sqlIt.Connection != null)
                    sqlIt.Connection.Close();
            }

            return _obj;
        }

        protected static T dbGet(string query, SqlParameter[] sp)
        {
            T _obj = default(T);
            SqlIt sqlIt = createSqlIt(query, sp);

            try
            {
                sqlIt.Connection.Open();
                SqlDataReader dar = sqlIt.Command.ExecuteReader();

                if (dar.Read())
                {
                    _obj = mapIt(dar);
                }
            }
            catch (Exception eObj)
            {
                throw new Exception("Database problem(s) when getting data!", eObj);
            }
            finally
            {
                if (sqlIt.Connection != null)
                    sqlIt.Connection.Close();
            }

            return _obj;
        }

        protected static List<T> dbGetList(string query, SqlParameter[] sp)
        {
            List<T> _objList = null;

            SqlIt sqlIt = createSqlIt(query, sp);

            try
            {
                sqlIt.Connection.Open();
                SqlDataReader dar = sqlIt.Command.ExecuteReader();
                if (dar != null)
                {
                    _objList = new List<T>();
                    while (dar.Read())
                    {

                        _objList.Add(mapIt(dar));

                    }
                }
            }
            catch (Exception eObj)
            {
                throw new Exception("Database problem(s) when getting list!", eObj);
            }
            finally
            {
                if (sqlIt.Connection != null)
                    sqlIt.Connection.Close();
            }
            return _objList;
        }

        protected static void dbPost(string query, SqlParameter[] sp)
        {
            string _connectionString = DataSource.getConnectionString("projectmanager");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query, con);

            if (sp != null && sp.Length > 0)
                cmd.Parameters.AddRange(sp);

            try
            {
                con.Open();
                cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new Exception("Database problem(s) when posting!",e);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
    }
}
