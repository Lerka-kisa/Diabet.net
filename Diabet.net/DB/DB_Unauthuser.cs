using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diabet.net.DB
{
    class DB_Unauthuser
    {
        private const string StringConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Diabet.net; User=Unauthuser; Password = Unauthuser";

        public bool GiveUserByLoginAndPassword(string login, string password)
        {
            string sqlExpression = "GiveUserByLoginAndPassword";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@login", Value = login });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@password", Value = password });

                    object count = command.ExecuteScalar();
                    if (Convert.ToInt32(count) > 0)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    return false;
                }
            }

        }

        public string GetIdUserByLogin(string login)
        {
            string sqlExpression = "GetIdUserByLogin";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@login", Value = login });

                    SqlDataReader info = command.ExecuteReader();
                    object id = -1;
                    while (info.Read())
                    {
                        id = info["id_user"];
                        break;
                    }
                    return Convert.ToString(id);
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    return "";
                }
            }
        }

        internal bool GetIsAdminUser(string id_user)
        {
            string sqlExpression = "GetIsAdminUser";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });

                    SqlDataReader info = command.ExecuteReader();
                    object id = -1;
                    while (info.Read())
                    {
                        id = info["is_admin"];
                        break;
                    }
                    if (Convert.ToInt32(id) == 1)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public bool AddUser(string login, string password, string firstname, string lastname, string purpose_of_use, string gender, string age, string height, string weight, float activity, int daily_calories, string sugar)
        {
            string sqlExpression = "AddUser";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@login", Value = login });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@password", Value = password });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@is_admin", Value = 0 });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@First_Name", Value = firstname });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Last_Name", Value = lastname });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Height", Value = height });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Weight", Value = weight });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Daily_Calories", Value = daily_calories });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Age", Value = age });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Gender", Value = gender });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Activity", Value = activity });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Purpose_of_Use", Value = purpose_of_use });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Sugar", Value = sugar });

                    command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
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
