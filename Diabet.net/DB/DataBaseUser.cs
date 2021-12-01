using LiveCharts;
using Diabet.net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Text;
using System.Security.Cryptography;

namespace Diabet.net.DB
{
    class DataBaseUser
    {
        private const string StringConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Diabet.net; Integrated Security=True";
        //private const string StringConnection = @"Data Source=LEKRA_SH;Initial Catalog=Diabet.net; Integrated Security=True";

        //+
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

        //+
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

        //+
        internal ChartValues<double> GetMassFromHistory(string id_user)
        {
            string sqlExpression = "GetMassFromHistory";

            ChartValues<double> spam = new ChartValues<double>();

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });

                    SqlDataReader info = command.ExecuteReader();
                    object date = -1;
                    int i = 1;

                    while (info.Read())
                    {
                        date = info["Weight"];
                        if (i == 1)
                        {
                            spam.Add(Convert.ToDouble(date));
                            i++;
                        }
                        else if (spam.IndexOf(Convert.ToDouble(date)) == -1)
                        {
                            spam.Add(Convert.ToDouble(date));
                        }
                    }
                    return spam;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    return spam;
                }
            }
        }

        //+
        internal List<string> GetDateFromHistory(string id_user)
        {
            string sqlExpression = "GetDateFromHistory";

            List<string> spam = new List<string>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });

                    SqlDataReader info = command.ExecuteReader();
                    object date = -1;
                    int i = 1;

                    while (info.Read())
                    {
                        date = info["Date_of_Change"];
                        spam.Add(Convert.ToDateTime(date).ToShortDateString());
                        i++;
                    }
                    return spam;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    return spam;
                }
            }
        }

        //+
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

        //+
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

        //+
        public Users GetUserInfo(string id_user)
        {
            string sqlExpression = "GetUserInfo";

            Users spam = new Users();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });

                    SqlDataReader info = command.ExecuteReader();
                    object l = -1, fn = -1, ln = -1, h = 1, w = -1, dc = -1, a = -1;
                    string g = "", activ = "", p = "";

                    while (info.Read())
                    {
                        l = info["login"];
                        fn = info["First_Name"];
                        ln = info["Last_Name"];
                        h = info["Height"];
                        w = info["Weight"];
                        dc = info["Daily_Calories"];
                        a = info["Age"];

                        if (Convert.ToString(info["Gender"]) == "М")
                            g = "Мужской";
                        else
                            g = "Женский";

                        if (Convert.ToString(info["Activity"]) == "1,2")
                            activ = "Мин. уровень физнагрузки (отсутсвие)";
                        else if (Convert.ToString(info["Activity"]) == "1,38")
                            activ = "Тренировки 3 раза в неделю";
                        else if (Convert.ToString(info["Activity"]) == "1,46")
                            activ = "Тренировки 5 раза в недел";
                        else if (Convert.ToString(info["Activity"]) == "1,64")
                            activ = "Тренеровки каждый день";
                        else
                            activ = "Ежедневная нагрузка + физ.работа";

                        if (Convert.ToString(info["Purpose_of_Use"]) == "1")
                            p = "Сбросить вес";
                        else if (Convert.ToString(info["Purpose_of_Use"]) == "2")
                            p = "Поддерживать вес";
                        else
                            p = "Набрать вес";

                        spam = new Users
                        {
                            Id_user = Convert.ToInt32(id_user),
                            Login = Convert.ToString(l),
                            LastName = Convert.ToString(ln),
                            FirstName = Convert.ToString(fn),
                            Height = Convert.ToString(h),
                            Weight = Convert.ToString(w),
                            Daily_Calories = Convert.ToInt16(dc),
                            Age = Convert.ToInt16(a),
                            Gender = g,
                            Activity = activ,
                            Purpose_of_Use = p
                        };
                    }
                    return spam;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return spam;
                }
            }
        }

        //+
        public string GetSugar(string id_user)
        {
            string sqlExpression = "GetSugar";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });

                    SqlDataReader info = command.ExecuteReader();
                    object w = -1;
                    while (info.Read())
                    {
                        w = info["blood_sugar"];
                        break;
                    }
                    return Convert.ToString(w);
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    return "";
                }
            }
        }

        //+
        #region Updating user data
        //+
        public bool UpdateAgeUser(string id_user, short age)
        {
            string sqlExpression = "UpdateAgeUser";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@age", Value = age });

                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        //+
        public bool UpdateMassUser(string id_user, double weight)
        {
            string sqlExpression = "UpdateMassUser";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@weight", Value = weight });

                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        
        //+
        internal bool UpdatePurposeUser(string id_user, string new_purpose)
        {
            string sqlExpression = "UpdatePurposeUser";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Purpose_of_Use", Value = new_purpose });

                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    return false;
                }
            }
        }
        
        //+
        public bool UpdateSugarUser(string id_user, double sugar)
        {
            string sqlExpression = "UpdateSugarUser";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@blood_sugar", Value = sugar });

                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    return false;
                }
            }
        }
        
        //+
        public bool UpdateDailyCalUser(string id_user, int daily_cal)
        {
            string sqlExpression = "UpdateDailyCalUser";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@daily_cal", Value = daily_cal });

                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    return false;
                }
            }
        }
        #endregion

        //+
        #region Statistic of blood
        //+
        internal List<string> GetDateFromHistoryBlood(string id_user)
        {
            string sqlExpression = "GetDateFromHistoryBlood";

            List<string> spam = new List<string>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });

                    SqlDataReader info = command.ExecuteReader();
                    object date = -1;
                    int i = 1;

                    while (info.Read())
                    {
                        date = info["Date_of_Change"];
                        spam.Add(Convert.ToDateTime(date).ToShortDateString());
                        i++;
                    }
                    return spam;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    return spam;
                }
            }
        }

        //+
        internal ChartValues<double> GetBloodFromHistory(string id_user)
        {
            string sqlExpression = "GetBloodFromHistory";

            ChartValues<double> spam = new ChartValues<double>();

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });

                    SqlDataReader info = command.ExecuteReader();
                    object date = -1;
                    int i = 1;

                    while (info.Read())
                    {
                        date = info["blood_shugar"];
                        if (i == 1)
                        {
                            spam.Add(Convert.ToDouble(date));
                            i++;
                        }
                        else if (spam.IndexOf(Convert.ToDouble(date)) == -1)
                        {
                            spam.Add(Convert.ToDouble(date));
                        }
                    }
                    return spam;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    return spam;
                }
            }
        }
        #endregion

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