using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Projeto_Cash_Control
{
    public class DataBase
    {

        public NpgsqlConnection OpenConnection()
        {
            string host = ConfigurationManager.AppSettings["ConfigHost"];
            string user = ConfigurationManager.AppSettings["ConfigUser"];
            string pass = ConfigurationManager.AppSettings["ConfigPass"];
            string por = ConfigurationManager.AppSettings["ConfigPort"];
            string databasename = ConfigurationManager.AppSettings["ConfigDataBaseName"];

            string connString = String.Format("Server ={0}; User Id= {1}; Database = {2}; Port = {3}; Password={4} ", host, user, databasename, por, pass);
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            return conn;
        }

        public void CloseConnection(NpgsqlConnection con)
        {
            con.Close();
        }



    }
}