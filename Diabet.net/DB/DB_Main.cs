using Diabet.net.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Diabet.net.DB
{
    class DB_Main
    {
        private const string StringConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Diabet.net; Integrated Security=True";
        //private const string StringConnection = @"Data Source=LEKRA_SH;Initial Catalog=Diabet.net; Integrated Security=True";

        //+
        #region Вода
        //+
        public bool GetDateForWater(string id_user, string date)
        {
            string sqlExpression = "GetDateForWater";

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

        //+
        public string GetWater(string id_user, string date)
        {
            string sqlExpression = "GetWater";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    if (GetDateForWater(id_user, date))
                    {
                        sqlCon.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@now_date", Value = date });

                        SqlDataReader info = command.ExecuteReader();
                        object w = -1;
                        while (info.Read())
                        {
                            w = info["water"];
                            break;
                        }
                        return Convert.ToString(w);
                    }
                    else
                    {
                        AddWater(id_user);
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
        public void AddWater(string id_user)
        {
            string sqlExpression = "AddWater";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@water", Value = 0 });

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        //+
        public bool UpdateWater(string id_user, string date, float water)
        {
            string sqlExpression = "UpdateWater";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@now_date", Value = date });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@water", Value = water });

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
        #endregion

        //+
        #region Таблетки
        //+
        public bool GetDateForPill(string id_user, string date)
        {
            string sqlExpression = "GetDateForPill";

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

        //+
        public string GetPill(string id_user, string date)
        {
            string sqlExpression = "GetPill";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    if (GetDateForPill(id_user, date))
                    {
                        sqlCon.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@now_date", Value = date });

                        SqlDataReader info = command.ExecuteReader();
                        object w = -1;
                        while (info.Read())
                        {
                            w = info["pill"];
                            break;
                        }
                        return Convert.ToString(w);
                    }
                    else
                    {
                        AddPill(id_user);
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
        public void AddPill(string id_user)
        {
            string sqlExpression = "AddPill";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@pill", Value = 0 });

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        //+
        public bool UpdatePill(string id_user, string date, float pill)
        {
            string sqlExpression = "UpdatePill";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@now_date", Value = date });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@pill", Value = pill });

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
        #endregion

        //+
        #region Ежедневная норма каллорий
        //+
        internal int GetDailyCalInTableUser(string id_user)
        {
            string sqlExpression = "GetDailyCalInTableUser";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });

                    SqlDataReader info = command.ExecuteReader();
                    object d = -1;
                    while (info.Read())
                    {
                        d = info["Daily_Calories"];
                        break;
                    }
                    return Convert.ToInt32(d);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return 0;
                }
            }
        }
        
        //+
        public bool GetDateForDailyCal(string date, string id_user)
        {
            string sqlExpression = "GetDateForDailyCal";

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

        //+
        public int GetDailyCal(string id_user, string date)
        {
            string sqlExpression = "GetDailyCal";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    if (GetDateForDailyCal(date, id_user))
                    {
                        sqlCon.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@now_date", Value = date });

                        SqlDataReader info = command.ExecuteReader();
                        object d = -1;
                        while (info.Read())
                        {
                            d = info["daily_cal"];
                            break;
                        }
                        return Convert.ToInt32(d);
                    }
                    else
                    {
                        int cal = GetDailyCalInTableUser(id_user);
                        AddDailyCal(id_user, cal);
                        return cal;                       
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return 0;
                }
            }
        }

        //+
        public void AddDailyCal(string id_user, int cal)
        {
            string sqlExpression = "AddDailyCal";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@daily_cal", Value = cal });

                    command.ExecuteNonQuery();                   
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        //+
        public void UpdateDailyCal(string id_user, string date, int cal)
        {
            string sqlExpression = "UpdateDailyCal";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@now_date", Value = date });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@daily_cal", Value = cal });

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        #endregion

        //+
        public ObservableCollection<Food> GetNameFoodByIdType(string id_user, string now, int type_of_food)
        {
            string sqlExpression = "GetNameFoodByIdType";
            ObservableCollection<Food> spam = new ObservableCollection<Food>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@now_date", Value = now });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_type_of_food", Value = type_of_food });

                    SqlDataReader info = command.ExecuteReader();
                    object p = -1, r = -1, mass_food=-1;
                    string name_food;
                    int  cal_food;
                    while (info.Read())
                    {
                        p = info["id_product"];

                        if (DBNull.Value.Equals(p))
                        {
                            r = info["id_recipe"];
                            mass_food = info["weight"];                          
                            name_food = GetNameRecipeById(Convert.ToString(r));
                            cal_food = GetCalRecipeById(Convert.ToString(r));
                            spam.Add(new Food() { Name = name_food, Mass = Convert.ToString(mass_food + "г"), Cal = Convert.ToString(Convert.ToInt32(mass_food) * cal_food / 100 + "ккал") });                          
                        }
                        else
                        {
                            mass_food = info["weight"];
                            name_food = GetNameProductById(Convert.ToString(p));
                            cal_food = GetCalProductById(Convert.ToString(p));
                            spam.Add(new Food() { Name = name_food, Mass = Convert.ToString(mass_food + "г"), Cal = Convert.ToString(Convert.ToInt32(mass_food) * cal_food / 100 + "ккал") });
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

        //+
        private int GetCalRecipeById(string id)
        {
            string sqlExpression = "GetCalRecipeById";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_recipe", Value = id });

                    SqlDataReader info = command.ExecuteReader();
                    object r = -1;
                    while (info.Read())
                    {
                        r = info["calorific_recipe"];
                        break;
                    }
                    return Convert.ToInt32(r);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return 0;
                }
            }
        }

        //+
        private int GetCalProductById(string id)
        {
            string sqlExpression = "GetCalProductByID";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_product", Value = id });

                    SqlDataReader info = command.ExecuteReader();
                    object r = -1;
                    while (info.Read())
                    {
                        r = info["calorific_product"];
                        break;
                    }

                    return Convert.ToInt32(r);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return 0;
                }
            }
        }

        //+
        private string GetNameProductById(string id)
        {
            string sqlExpression = "GetNameProductById";
            
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_product", Value = id });

                    SqlDataReader info = command.ExecuteReader();
                    object r = -1;
                    while (info.Read())
                    {
                        r = info["name_product"];
                        break;
                    }
                    return Convert.ToString(r);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return "";
                }
            }
        }

        //+
        private string GetNameRecipeById(string id)
        {
            string sqlExpression = "GetNameRecipeById";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_recipe", Value = id });

                    SqlDataReader info = command.ExecuteReader();
                    object r = -1;
                    while (info.Read())
                    {
                        r = info["name_recipe"];
                        break;
                    }
                    return Convert.ToString(r);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return "";
                }
            }        
        }

        //+
        internal ObservableCollection<Ingredients> GetIngtedients(int id)
        {
            string sqlExpression = "GetIngtedients";

            ObservableCollection<Ingredients> spam = new ObservableCollection<Ingredients>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_recipe", Value = id });

                    SqlDataReader info = command.ExecuteReader();
                    object i = -1, mass = -1;

                    while (info.Read())
                    {
                        i = info["id_product"];
                        mass = info["weight_product"];                       
                        spam.Add(new Ingredients() { ID_Recipe = id, ID_Product = Convert.ToInt32(i), Mass = Convert.ToString(mass + "г"), Name_Product = this.GetNameProductById(Convert.ToString(i))});
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
    }
}
