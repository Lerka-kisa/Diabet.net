using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace Diabet.net.DB
{
    class DB_AddInsulin
    {
        private const string StringConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Diabet.net; Integrated Security=True";
        //private const string StringConnection = @"Data Source=LEKRA_SH;Initial Catalog=Diabet.net; Integrated Security=True";
        
        //+
        public void AddInsulin(string id_user, string date, int id_type, string insulin)
        {
            string sqlExpression = "AddInsulin";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@weight", Value = insulin });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_type_of_insulin", Value = id_type });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@now_date", Value = date });

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        //+
        public string GetInsulin(string id_user, string date, int type)
        {
            string sqlExpression = "GetInsulin";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    if (GetDateForInsulin(id_user, date))
                    {
                        sqlCon.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@now_date", Value = date });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@id_type_of_insulin", Value = type });

                        SqlDataReader info = command.ExecuteReader();
                        object w = -1;
                        while (info.Read())
                        {
                            w = info["insulin"];
                            break;
                        }
                        return Convert.ToString(w);
                    }
                    else
                    {
                        return Convert.ToString(0);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return "";
                }
            }
        }
        
        //+
        public bool GetDateForInsulin(string id_user, string date)
        {
            string sqlExpression = "GetDateForInsulin";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@now_date", Value = date });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });

                    SqlDataReader info = command.ExecuteReader();
                    object d = -1;
                    while (info.Read())
                    {
                        d = info["id_user"];
                        break;
                    }
                    if (Convert.ToInt32(d) == -1) return false;
                    else 
                        if (Convert.ToString(d) == id_user) return true;
                        else
                            return false;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }
    }
}