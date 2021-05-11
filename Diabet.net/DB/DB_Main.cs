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
    class DB_Main
    {
        private const string StringConnection = @"Data Source=LEKRA_SH;Initial Catalog=KP_DataBase; Integrated Security=True";
        #region Вода
        public bool GetDateForWater(string id_user, string date)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_user From Daily_Water Where now_date = @now_date and id_user = @id_user";
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

        public string GetWater(string id_user, string date)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    if (GetDateForWater(id_user,date))
                    {
                        sqlCon.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = sqlCon;
                        command.CommandText = @"Select water From Daily_Water Where id_user = @id_user and now_date=@now_date";
                        command.Parameters.Add("@id_user", SqlDbType.Int);
                        command.Parameters.Add("@now_date", SqlDbType.DateTime);

                        command.Parameters["@id_user"].Value = id_user;
                        command.Parameters["@now_date"].Value = date;


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
        public void AddWater(string id_user)
        {


            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"INSERT INTO Daily_Water (id_user, water) VALUES (@id_user,@water)";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@water", SqlDbType.Real);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@water"].Value = 0;


                    command.ExecuteNonQuery();


                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }

        }

        public bool UpdateWater(string id_user, string date, float water)
        {


            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    string sql = string.Format("Update Daily_Water Set water = '{0}' Where id_user = '{1}' and now_date = '{2}'", water, id_user, date);

                    command.CommandText = @"Update Daily_Water Set water = @water Where id_user = @id_user and now_date = @now_date";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@now_date", SqlDbType.DateTime);
                    command.Parameters.Add("@water", SqlDbType.Float);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@now_date"].Value = date;
                    command.Parameters["@water"].Value = water;

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

        #region Таблетки
        public bool GetDateForPill(string id_user, string date)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_user From Daily_Pill Where now_date = @now_date and id_user = @id_user";
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

        public string GetPill(string id_user, string date)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    if (GetDateForPill(id_user, date))
                    {
                        sqlCon.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = sqlCon;
                        command.CommandText = @"Select pill From Daily_Pill Where id_user = @id_user and now_date=@now_date";
                        command.Parameters.Add("@id_user", SqlDbType.Int);
                        command.Parameters.Add("@now_date", SqlDbType.DateTime);

                        command.Parameters["@id_user"].Value = id_user;
                        command.Parameters["@now_date"].Value = date;


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

        public void AddPill(string id_user)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"INSERT INTO Daily_Pill (id_user, pill) VALUES (@id_user,@pill)";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@pill", SqlDbType.Real);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@pill"].Value = 0;


                    command.ExecuteNonQuery();


                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }

        }
        public bool UpdatePill(string id_user, string date, float pill)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    string sql = string.Format("Update Daily_Pill Set pill = '{0}' Where id_user = '{1}' and now_date = '{2}'", pill, id_user, date);

                    command.CommandText = @"Update Daily_Pill Set pill = @pill Where id_user = @id_user and now_date = @now_date";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@now_date", SqlDbType.DateTime);
                    command.Parameters.Add("@pill", SqlDbType.Float);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@now_date"].Value = date;
                    command.Parameters["@pill"].Value = pill;

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
        
        internal int GetDailyCalInTableUser(string id_user)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select Daily_Calories From Users Where id_user = @id_user";
                    command.Parameters.Add("@id_user", SqlDbType.Int);

                    command.Parameters["@id_user"].Value = id_user;

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

        public bool GetDateForDailyCal(string date, string id_user)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_user From Daily_Cal Where id_user = @id_user and now_date = @now_date";
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

        public int GetDailyCal(string id_user, string date)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    if (GetDateForDailyCal(date, id_user))
                    {
                        sqlCon.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = sqlCon;
                        command.CommandText = @"Select daily_cal From Daily_Cal Where id_user = @id_user and now_date=@now_date";
                        command.Parameters.Add("@id_user", SqlDbType.Int);
                        command.Parameters.Add("@now_date", SqlDbType.DateTime);

                        command.Parameters["@id_user"].Value = id_user;
                        command.Parameters["@now_date"].Value = date;


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

        public void AddDailyCal(string id_user, int cal)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"INSERT INTO Daily_Cal (id_user, daily_cal ) VALUES (@id_user,@daily_cal)";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@daily_cal", SqlDbType.Int);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@daily_cal"].Value = cal;


                    command.ExecuteNonQuery();

                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
        }

        public void UpdateDailyCal(string id_user, string date, int cal)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
             
                    command.CommandText = @"Update Daily_Cal Set daily_cal = @daily_cal Where id_user = @id_user and now_date = @now_date";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@now_date", SqlDbType.DateTime);
                    command.Parameters.Add("@daily_cal", SqlDbType.Float);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@now_date"].Value = date;
                    command.Parameters["@daily_cal"].Value = cal;

                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
        }

        /**/

        
        /**/
        /*
        public string GetTypeOfInsulinById(int id_type)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select type_of_insulin From Type_of_Insulin Where id_type = @id_type";
                    command.Parameters.Add("@id_type", SqlDbType.Int);

                    command.Parameters["@id_type"].Value = id_type;

                    SqlDataReader info = command.ExecuteReader();
                    object d = -1;
                    while (info.Read())
                    {
                        d = info["type_of_insulin"];
                        break;
                    }
                    return Convert.ToString(d);

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
        public string GetInsulin(string id_user, string date)
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
                        command.CommandText = @"Select insulin From Daily_Insulin Where id_user = @id_user and now_date=@now_date";
                        command.Parameters.Add("@id_user", SqlDbType.Int);
                        command.Parameters.Add("@now_date", SqlDbType.DateTime);

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
                        AddInsulin(id_user);
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

        public void AddInsulin(string id_user)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"INSERT INTO Daily_Insulin (id_user, insulin) VALUES (@id_user,@insulin)";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@insulin", SqlDbType.Real);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@insulin"].Value = 0;

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }

        }
        internal void AddInsulinInDailyInsulin(string id_user, string date, int id_type, float mass)
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
                    command.Parameters["@weight"].Value = mass;
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

        */
        /**/

        public ObservableCollection<Food> GetNameFoodByIdType(string id_user, string now, int type_of_food)
        {
            ObservableCollection<Food> spam = new ObservableCollection<Food>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_product, id_recipe, weight From Daily_Food Where id_type_of_food = @id_type_of_food and id_user = @id_user and now_date = @now_date";
                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@now_date", SqlDbType.DateTime);
                    command.Parameters.Add("@id_type_of_food", SqlDbType.Int);

                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@now_date"].Value = now;
                    command.Parameters["@id_type_of_food"].Value = type_of_food;

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

        private int GetCalRecipeById(string id)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select calorific_recipe From Recipe Where id_recipe = @id_recipe";
                    command.Parameters.Add("@id_recipe", SqlDbType.Int);

                    command.Parameters["@id_recipe"].Value = id;

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

        private int GetCalProductById(string id)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select calorific_product From Products Where id_product = @id_product";
                    command.Parameters.Add("@id_product", SqlDbType.Int);

                    command.Parameters["@id_product"].Value = id;

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

        private string GetNameProductById(string id)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select name_product From Products Where id_product = @id_product";
                    command.Parameters.Add("@id_product", SqlDbType.Int);

                    command.Parameters["@id_product"].Value = id;

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

        private string GetNameRecipeById(string id)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select name_recipe From Recipe Where id_recipe = @id_recipe";
                    command.Parameters.Add("@id_recipe", SqlDbType.Int);

                    command.Parameters["@id_recipe"].Value = id;

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

        internal ObservableCollection<Ingredients> GetIngtedients(int id)
        {
            ObservableCollection<Ingredients> spam = new ObservableCollection<Ingredients>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_product, weight_product From Prod_Rec Where id_recipe = @id_recipe";

                    command.Parameters.Add("@id_recipe", SqlDbType.Int);

                    command.Parameters["@id_recipe"].Value = id;

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
