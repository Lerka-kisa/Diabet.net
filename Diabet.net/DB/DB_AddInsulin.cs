using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace Diabet.net.DB
{
    class DB_AddInsulin
    {
        private const string StringConnection = @"Data Source=LEKRA_SH;Initial Catalog=Diabet.net; Integrated Security=True";

        public void AddInsulin(string id_user, string date, int id_type, string insulin)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"INSERT INTO Daily_Insulin (id_user, weight, id_type_of_insulin, now_date ) VALUES (@id_user,@weight, @id_type_of_insulin, @now_date)";

                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@weight", SqlDbType.Int);
                    command.Parameters.Add("@id_type_of_insulin", SqlDbType.Int);
                    command.Parameters.Add("@now_date", SqlDbType.DateTime);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@weight"].Value = insulin;
                    command.Parameters["@id_type_of_insulin"].Value = id_type;
                    command.Parameters["@now_date"].Value = date;

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public string GetInsulin(string id_user, string date, int type)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    if (GetDateForInsulin(id_user, date))
                    {
                        sqlCon.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = sqlCon;
                        command.CommandText = @"Select sum(weight) insulin From Daily_Insulin Where id_user = @id_user and now_date=@now_date and id_type_of_insulin=@id_type_of_insulin";
                        command.Parameters.Add("@id_user", SqlDbType.Int);
                        command.Parameters.Add("@now_date", SqlDbType.DateTime);
                        command.Parameters.Add("@id_type_of_insulin", SqlDbType.Int);

                        command.Parameters["@id_type_of_insulin"].Value = type;
                        command.Parameters["@id_user"].Value = id_user;
                        command.Parameters["@now_date"].Value = date;

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
                        //AddInsulin(id_user);
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
        
        public bool GetDateForInsulin(string id_user, string date)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_user From Daily_Insulin Where now_date = @now_date and id_user = @id_user";
                    command.Parameters.Add("@now_date", SqlDbType.DateTime);
                    command.Parameters.Add("@id_user", SqlDbType.Int);

                    command.Parameters["@now_date"].Value = date;
                    command.Parameters["@id_user"].Value = id_user;

                    SqlDataReader info = command.ExecuteReader();
                    object d = -1;
                    while (info.Read())
                    {
                        d = info["id_user"];
                        break;
                    }
                    if (Convert.ToInt32(d) == -1)
                        return false;
                    else if (Convert.ToString(d) == id_user)
                        return true;
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
