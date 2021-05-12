using LiveCharts;
using Diabet.net.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diabet.net.DB
{
    class DataBaseUser
    {
        private const string StringConnection = @"Data Source=LEKRA_SH;Initial Catalog=KP_DataBase; Integrated Security=True";
        //private const string StringConnection = @"Data Source=DESKTOP-DN7MK5L\SQLEXPRESS;Initial Catalog=KP_DataBase; Integrated Security=True";


        public bool GiveUserByLoginAndPassword(string login, string password)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select count(*) From Users Where login = @login and password = @password";
                    command.Parameters.Add("@login", SqlDbType.NVarChar, 20);
                    command.Parameters.Add("@password", SqlDbType.NVarChar, 100);

                    command.Parameters["@login"].Value = login;
                    command.Parameters["@password"].Value = password;
                    object count = command.ExecuteScalar();
                    if (Convert.ToInt32(count) > 0)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }

        }

        internal ChartValues<double> GetMassFromHistory(string id_user)
        {
            ChartValues<double> spam = new ChartValues<double>();

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select Weight From History Where id_user = @id_user;";
                    command.Parameters.Add("@id_user", SqlDbType.Int);

                    command.Parameters["@id_user"].Value = id_user;
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
                    MessageBox.Show(e.Message);
                    return spam;
                }
            }
        }

        internal bool GetIsAdminUser(string id_user)
        {

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select is_admin From Users Where id_user = @id_user";
                    command.Parameters.Add("@id_user", SqlDbType.Int);

                    command.Parameters["@id_user"].Value = id_user;
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
                    MessageBox.Show(e.Message);
                    return false;
                }
            }


        }

        internal bool UpdatePurposeUser(string id_user, string new_purpose)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;

                    command.CommandText = @"Update Users Set Purpose_of_Use = @Purpose_of_Use Where id_user = @id_user";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@Purpose_of_Use", SqlDbType.SmallInt);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@Purpose_of_Use"].Value = new_purpose;

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

        internal List<string> GetDateFromHistory(string id_user)
        {
            List<string> spam = new List<string>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select Date_of_Change From History Where id_user = @id_user;";
                    command.Parameters.Add("@id_user", SqlDbType.Int);

                    command.Parameters["@id_user"].Value = id_user;
                    SqlDataReader info = command.ExecuteReader();
                    object date = -1;
                    int i = 1;

                    while (info.Read())
                    {
                        date = info["Date_of_Change"];
                        if (i == 1)
                        {
                            spam.Add(Convert.ToDateTime(date).ToShortDateString());
                            i++;
                        }
                        else if (spam.IndexOf(Convert.ToDateTime(date).ToShortDateString()) == -1)
                        {
                            spam.Add(Convert.ToDateTime(date).ToShortDateString());
                        }
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

        public bool AddUser(string login, string password, string firstname, string lastname, string purpose_of_use, string gender, string age, string height, string weight, string activity, int daily_calories, string sugar)
        {


            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"INSERT INTO Users (login, password, is_admin, First_Name, Last_Name,  Height, Weight, Daily_Calories,  Age, Gender, Activity, Purpose_of_Use, blood_sugar) VALUES (@login,@password,@is_admin,@First_Name,@Last_Name,  @Height, @Weight, @Daily_Calories, @Age, @Gender, @Activity, @Purpose_of_Use, @Sugar)";

                    command.Parameters.Add("@login", SqlDbType.NVarChar, 20);
                    command.Parameters.Add("@password", SqlDbType.NVarChar, 100);
                    command.Parameters.Add("@is_admin", SqlDbType.Bit);
                    command.Parameters.Add("@First_Name", SqlDbType.NVarChar, 20);
                    command.Parameters.Add("@Last_Name", SqlDbType.NVarChar, 20);
                    command.Parameters.Add("@Height", SqlDbType.Real);
                    command.Parameters.Add("@Weight", SqlDbType.Real);
                    command.Parameters.Add("@Daily_Calories", SqlDbType.SmallInt);
                    command.Parameters.Add("@Age", SqlDbType.SmallInt);
                    command.Parameters.Add("@Gender", SqlDbType.NVarChar, 5);
                    command.Parameters.Add("@Activity", SqlDbType.Float);
                    command.Parameters.Add("@Purpose_of_Use", SqlDbType.SmallInt);
                    command.Parameters.Add("@Sugar", SqlDbType.Real);

                    command.Parameters["@login"].Value = login;
                    command.Parameters["@password"].Value = password;
                    command.Parameters["@is_admin"].Value = 0;
                    command.Parameters["@First_Name"].Value = firstname;
                    command.Parameters["@Last_Name"].Value = lastname;
                    command.Parameters["@Height"].Value = height;
                    command.Parameters["@Weight"].Value = weight;
                    command.Parameters["@Daily_Calories"].Value = daily_calories;
                    command.Parameters["@Age"].Value = age;
                    command.Parameters["@Gender"].Value = gender;
                    command.Parameters["@Activity"].Value = activity;
                    command.Parameters["@Purpose_of_Use"].Value = purpose_of_use;
                    command.Parameters["@Sugar"].Value = sugar;

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

        public string GetIdUserByLogin(string login)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_user From Users Where login = @login";
                    command.Parameters.Add("@login", SqlDbType.NVarChar, 20);

                    command.Parameters["@login"].Value = login;
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
                    MessageBox.Show(e.Message);
                    return "";
                }
            }

        }

        public Users GetUserInfo(string id_user)
        {
            Users spam = new Users();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"select  login, First_Name, Last_Name, Height, Weight,Daily_Calories, Age, Gender, Activity,Purpose_of_Use From Users Where id_user=@id_user ;";
                    command.Parameters.Add("@id_user", SqlDbType.Int);

                    command.Parameters["@id_user"].Value = id_user;
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

        public bool UpdateAgeUser(string id_user, short age)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;

                    command.CommandText = @"Update Users Set Age = @age Where id_user = @id_user";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@age", SqlDbType.SmallInt);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@age"].Value = age;

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

        public bool UpdateMassUser(string id_user, double mass)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;

                    command.CommandText = @"Update Users Set Weight = @mass Where id_user = @id_user";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@mass", SqlDbType.Real);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@mass"].Value = mass;

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
        public bool UpdateSugarUser(string id_user, double sugar)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;

                    command.CommandText = @"Update Users Set blood_sugar = @blood_sugar Where id_user = @id_user";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@blood_sugar", SqlDbType.Real);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@blood_sugar"].Value = sugar;

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

        public bool UpdateDailyCalUser(string id_user, int daily_cal)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;

                    command.CommandText = @"Update Users Set Daily_Calories = @daily_cal Where id_user = @id_user";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@daily_cal", SqlDbType.SmallInt);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@daily_cal"].Value = daily_cal;

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

        public string GetSugar(string id_user)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                        sqlCon.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = sqlCon;
                        command.CommandText = @"Select blood_sugar From Users Where id_user = @id_user";
                        command.Parameters.Add("@id_user", SqlDbType.Int);

                        command.Parameters["@id_user"].Value = id_user;


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
                    MessageBox.Show(e.Message);
                    return "";
                }
            }
        }
    }
}
