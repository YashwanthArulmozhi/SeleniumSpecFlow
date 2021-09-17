using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SeleniumCSharpSpecflowProject.Utils
{
    class DatabaseUtils : ReporterClass
    {
         List<string> columnDataFromDb = new List<string>();
         SqlConnection connection;
         SqlCommand command;
         SqlDataAdapter dataAdapter;
         SqlDataReader dataReader;

         public List<string> GetDataFromDbColumn(string connectionString,string selectQuery,string columnName)
        {
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                command = new SqlCommand(selectQuery, connection);
                dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    columnDataFromDb.Add(dataReader.GetString(0));
                }
                return columnDataFromDb;
            }
            catch(SqlException e)
            {
                AddFailedStepLog("Exception in getting Database connection "+e.InnerException);
            }
            finally
            {
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            return columnDataFromDb;
        }

        public void InsertDataToDbTable(string connectionString, string insertQuery)
        {
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                command = new SqlCommand(insertQuery, connection);
                dataAdapter.InsertCommand = command;
                dataAdapter.InsertCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                AddFailedStepLog("Exception in getting Database connection " + e.InnerException);
            }
            finally
            {
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
        }
    }
}
