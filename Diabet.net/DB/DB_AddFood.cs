using Diabet.net.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Diabet.net.DB
{
    class DB_AddFood
    {
        private const string StringConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Diabet.net; Integrated Security=True";
        //private const string StringConnection = @"Data Source=LEKRA_SH;Initial Catalog=Diabet.net; Integrated Security=True";

        //+
        internal ObservableCollection<Product> GetRecipe()
        {
            string sqlExpression = "GetRecipe";
            ObservableCollection<Product> spam = new ObservableCollection<Product>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader info = command.ExecuteReader();
                    object p = -1, cal_food = -1, f_food = -1, c_food = 1, p_food = -1, i = -1, d = -1, s = -1;

                    while (info.Read())
                    {
                        p = info["name_recipe"];
                        cal_food = info["calorific_recipe"];
                        p_food = info["protein_recipe"];
                        f_food = info["fat_recipe"];
                        c_food = info["carbs_recipe"];
                        s = info["screen_img"];
                        i = info["id_recipe"];
                        d = info["description"];

                        spam.Add(new Product() { ID = Convert.ToInt32(i), Name = Convert.ToString(p), Calorific = Convert.ToString(cal_food + "ккал"), Protein = Convert.ToString(p_food + "г"), Fat = Convert.ToString(f_food + "г"), Carbs = Convert.ToString(c_food + "г"), Description = Convert.ToString(d), Screenimg = (byte[])s });
                        ////else
                        ////    spam.Add(new Product() { ID = Convert.ToInt32(i), Name = Convert.ToString(p), Calorific = Convert.ToString(cal_food + "ккал"), Protein = Convert.ToString(p_food + "г"), Fat = Convert.ToString(f_food + "г"), Carbs = Convert.ToString(c_food + "г"), Description = Convert.ToString(d)});
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
        public ObservableCollection<Product> GetProduct()
        {
            string sqlExpression = "GetProduct";
            ObservableCollection<Product> spam = new ObservableCollection<Product>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader info = command.ExecuteReader();
                    object p = -1, cal_food = -1, f_food = -1, c_food = 1, p_food = -1, i = -1;

                    while (info.Read())
                    {
                        i = info["id_product"];
                        p = info["name_product"];
                        cal_food = info["calorific_product"];
                        p_food = info["protein_product"];
                        f_food = info["fat_product"];
                        c_food = info["carbs_product"];
                        spam.Add(new Product() { ID = Convert.ToInt32(i), Name = Convert.ToString(p), Calorific = Convert.ToString(cal_food + "ккал"), Protein = Convert.ToString(p_food + "г"), Fat = Convert.ToString(f_food + "г"), Carbs = Convert.ToString(c_food + "г") });
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
        public string GetTypeOfFoodById(int id_type)
        {
            string sqlExpression = "GetTypeOfFoodById";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter type = new SqlParameter{ ParameterName = "@id_type", Value = id_type };
                    command.Parameters.Add(type);

                    var info = command.ExecuteReader();
                    object d = -1;
                    while (info.Read())
                    {
                        d = info["type_of_food"];
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

        //+
        internal void AddProductInDailyFood(int id_product, int mass, int id_user, int id_type, string date)
        {
            string sqlExpression = "AddProductInDailyFood";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_product", Value = id_product });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@weight", Value = mass });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_type_of_food", Value = id_type });
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
        public void AddRecipeInDailyFood(int id_recipe, int mass, int id_user, int id_type, string date)
        {
            string sqlExpression = "AddRecipeInDailyFood";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_user", Value = id_user });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_recipe", Value = id_recipe });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@weight", Value = mass });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_type_of_food", Value = id_type });
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
        internal void AddIngred(string id_recipe, int id_product, string mass)
        {
            string sqlExpression = "AddIngred";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_product", Value = id_product });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_recipe", Value = id_recipe });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@weight_product", Value = mass });

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            }

        //+
        internal bool AddRecipe(string name_Recipe, string cal_Recipe, string protein_Recipe, string fat_Recipe, string carb_Recipe, string description, byte[] screenimg)
        {
            string sqlExpression = "AddRecipe";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@name_recipe", Value = name_Recipe });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@calorific_recipe", Value = cal_Recipe });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@protein_recipe", Value = protein_Recipe });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@fat_recipe", Value = fat_Recipe });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@carbs_recipe", Value = carb_Recipe });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@description", Value = description });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@screen_img", Value = screenimg });

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
        internal ObservableCollection<Product> GetSearchRecipe(string search_TextBox)
        {
            string sqlExpression = "GetSearchRecipe";

            ObservableCollection<Product> spam = new ObservableCollection<Product>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@search_TextBox", search_TextBox + "%");

                    SqlDataReader info = command.ExecuteReader();
                    object p = -1, cal_food = -1, f_food = -1, c_food = 1, p_food = -1, i = -1, s = -1, d = -1;

                    while (info.Read())
                    {
                        p = info["name_recipe"];
                        cal_food = info["calorific_recipe"];
                        p_food = info["protein_recipe"];
                        f_food = info["fat_recipe"];
                        s = info["screen_img"];
                        c_food = info["carbs_recipe"];
                        i = info["id_recipe"];
                        d = info["description"];

                        spam.Add(new Product() { ID = Convert.ToInt32(i), Name = Convert.ToString(p), Calorific = Convert.ToString(cal_food + "ккал"), Protein = Convert.ToString(p_food + "г"), Fat = Convert.ToString(f_food + "г"), Carbs = Convert.ToString(c_food + "г"), Description = Convert.ToString(d), Screenimg = (byte[])s });
                    }

                    return spam;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return spam;
                }
            }
            throw new NotImplementedException();
        }

        //+
        internal ObservableCollection<Product> GetSearchProduct(string search_TextBox)
        {
            string sqlExpression = "GetSearchProduct";

            ObservableCollection<Product> spam = new ObservableCollection<Product>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@search_TextBox",  search_TextBox + "%");

                    SqlDataReader info = command.ExecuteReader();
                    object p = -1, cal_food = -1, f_food = -1, c_food = 1, p_food = -1, i = -1;

                    while (info.Read())
                    {
                        i = info["id_product"];
                        p = info["name_product"];
                        cal_food = info["calorific_product"];
                        p_food = info["protein_product"];
                        f_food = info["fat_product"];
                        c_food = info["carbs_product"];
                        spam.Add(new Product() { ID = Convert.ToInt32(i), Name = Convert.ToString(p), Calorific = Convert.ToString(cal_food + "ккал"), Protein = Convert.ToString(p_food + "г"), Fat = Convert.ToString(f_food + "г"), Carbs = Convert.ToString(c_food + "г") });
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
        internal string GetIdRecipeByName(string name)
        {
            string sqlExpression = "GetIdRecipeByName";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@name_recipe", Value = name });

                    SqlDataReader info = command.ExecuteReader();
                    object r = -1;
                    while (info.Read())
                    {
                        r = info["id_recipe"];
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
        public string GetIdProductByName(string name)
        {
            string sqlExpression = "GetIdProductByName";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@name_product", Value = name });

                    SqlDataReader info = command.ExecuteReader();
                    object r = -1;
                    while (info.Read())
                    {
                        r = info["id_product"];
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
        public int GetCalProductByID(string id_product)
        {
            string sqlExpression = "GetCalProductByID";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_product", Value = id_product });

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
        internal int GetCalRecipeByID(string id_recipe)
        {
            string sqlExpression = "GetCalRecipeByID";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id_recipe", Value = id_recipe });

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
    }
}