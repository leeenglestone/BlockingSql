using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using BlockingSql.MvcWebApplication.Models;

namespace BlockingSql.MvcWebApplication.Controllers
{
    internal class SqlHelper
    {
        public static IEnumerable<BlockingSqlStatementModel> GetBlockingSqlStatements()
        {
            var connectionStringKeys = ConfigurationManager.AppSettings["ConnectionKeys"]
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            
            const string sql = "sp_whoisactive";

            var blockingSqlStatements = new List<BlockingSqlStatementModel>();

            foreach (var connectionStringKey in connectionStringKeys)
            {
                var connectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;

                using (var sqlConnection = new SqlConnection(connectionString))
                using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        var blockingSqlStatement = new BlockingSqlStatementModel();

                        try
                        {
                            blockingSqlStatement.BlockingSessionId = int.Parse(reader["blocking_session_id"].ToString()); // will break if null
                        }
                        catch { }

                        blockingSqlStatement.Server = connectionStringKey;
                        blockingSqlStatement.DatabaseName = reader["database_name"].ToString();
                        blockingSqlStatement.Duration = reader["dd hh:mm:ss.mss"].ToString();
                        blockingSqlStatement.HostName = reader["host_name"].ToString();
                        blockingSqlStatement.LoginName = reader["login_name"].ToString();
                        blockingSqlStatement.ProgramName = reader["program_name"].ToString();
                        blockingSqlStatement.SessionId = int.Parse(reader["session_id"].ToString());
                        blockingSqlStatement.SqlText = reader["sql_text"].ToString();
                        blockingSqlStatement.Status = reader["status"].ToString();

                        blockingSqlStatements.Add(blockingSqlStatement);
                    }
                }
            }

            return blockingSqlStatements;
        }
    }
}