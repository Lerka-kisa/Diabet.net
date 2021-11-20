﻿using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Diabet.net.DB
{
    class DB
    {
        private const string StringConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Diabet.net; Integrated Security=True";
        //private const string StringConnection = "server=LEKRA_SH;Trusted_Connection=Yes;DataBase=Diabet.net;";

        public static SqlConnection Get_DB_Connection()
        { 

            SqlConnection cn_connection = new SqlConnection(StringConnection);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            return cn_connection;
        }

        public static DataTable Get_DataTable(string query)
        {
            SqlConnection cn_connection = Get_DB_Connection();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, cn_connection);
            adapter.Fill(table);

            return table;
        }

        public static void Execute_SQL(string query)
        {
            SqlConnection cn_connection = Get_DB_Connection();

            SqlCommand cmd_Command = new SqlCommand(query, cn_connection);
            cmd_Command.ExecuteNonQuery();
        }

        public static void Close_DB_Connection()
        {               
            SqlConnection cn_connection = new SqlConnection(StringConnection);
            if (cn_connection.State != ConnectionState.Closed) cn_connection.Close();
        }

        public static string Hash(string input)
        {
            byte[] hash = Encoding.ASCII.GetBytes(input);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string output = "";
            foreach (var b in hashenc)
            {
                output += b.ToString("x2");
            }
            return output;
        }
    }
}
