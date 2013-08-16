using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrinivasToolkit.Business
{
    public class DataAccess
    {        
        private SqlConnection connection = new SqlConnection();

        public string ConnectionString
        {
            get
            {
                return connection.ConnectionString;
            }
            set
            {
                connection.ConnectionString = value;
            }
        }

        public DataAccess()
        {
            connection.ConnectionString = GetConnectionString();
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connectToolkit"].ConnectionString;
        }

        public object GetScalarValue(string sSQLStatement)
        {
            try
            {
                SqlCommand command = new SqlCommand(sSQLStatement, connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                object scalarValue = command.ExecuteScalar();
                connection.Close();
                return scalarValue;
            }
            catch { return null; }
        }

        public DataTable GetQueryResults(string sSQLStatement)
        {
            try
            {
                DataTable dsResults = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sSQLStatement, connection);
                adapter.Fill(dsResults);
                return dsResults;
            }
            catch { return new DataTable(); }
        }

        public bool ExecuteQuery(string sSQLStatement)
        {
            try
            {
                SqlCommand command = new SqlCommand(sSQLStatement, connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                int count = command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch { connection.Close(); return false; }
        }

    }
}
