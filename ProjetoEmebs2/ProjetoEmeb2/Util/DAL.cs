using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjetoEmeb2.Models
{
    public class DAL
    {
        //private static string server = "servermysql21.mysql.database.azure.com";
        //private static string database = "DbSecretaria";
        //private static string user = "guiazetri@servermysql21";
        //private static string password = "mOo616dC";
        //private string connectionString = $"Server={server}; Port=3306; Database={database}; Uid={user}; Pwd={password}; Charset=utf8";

        private static string server = "localhost";
        private static string database = "DbSecretaria";
        private static string user = "root";
        private static string password = "";
        private string connectionString = $"Server={server};Database={database};Uid={user};Pwd={password};Port=3306;CharSet=utf8;SslMode=none";
        
        private MySqlConnection connection;

        public DAL()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        //Executa SELECTs
        public DataTable RetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(dataTable);
            return dataTable;
        }

        //Executa INSERTs, UPDATEs, DELETEs
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        
    }
}



       


