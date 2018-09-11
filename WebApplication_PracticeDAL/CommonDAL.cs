using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication_PracticeDAL
{
    public class CommonDAL
    {
        private SqlTransaction _sqlTransaction;
        private readonly SqlConnection _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString);

        public void BeginTransaction()
        {
            if (_sqlConnection.State != ConnectionState.Open)
                _sqlConnection.Open();
            _sqlTransaction = _sqlConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _sqlTransaction.Commit();
        }

        public void RollBackTransaction()
        {
            _sqlTransaction.Rollback();
        }

        public DataTable Query(string query)
        {
            var SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString);
            var SqlCommand = new SqlCommand
            {
                Connection = SqlConnection,
                CommandText = query
            };
            var SqlDataAdapter = new SqlDataAdapter(SqlCommand);
            var dataTable = new DataTable();
            SqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public bool Command(string command)
        {
            var SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString);
            var SqlCommand = new SqlCommand
            {
                Connection = SqlConnection,
                CommandText = command
            };
            return SqlCommand.ExecuteNonQuery() > 0;
        }



    }
}