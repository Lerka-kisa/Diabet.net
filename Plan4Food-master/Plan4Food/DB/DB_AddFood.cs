using Plan4Food.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plan4Food.DB
{
    class DB_AddFood
    {
        private const string StringConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=KP_DataBase; Integrated Security=True";

        public string GetTypeOfFoodById(int id_type)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select type_of_food From Type_of_Food Where id_type = @id_type";
                    command.Parameters.Add("@id_type", SqlDbType.Int);

                    command.Parameters["@id_type"].Value = id_type;

                    SqlDataReader info = command.ExecuteReader();
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
                    return "";
                }
            }
        }

        internal ObservableCollection<Product> GetRecipe()
        {
            ObservableCollection<Product> spam = new ObservableCollection<Product>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_recipe, name_recipe, calorific_recipe,protein_recipe,fat_recipe,carbs_recipe, description From Recipe";


                    SqlDataReader info = command.ExecuteReader();
                    object p = -1, cal_food = -1, f_food = -1, c_food = 1, p_food = -1, i = -1, d = -1;

                    while (info.Read())
                    {
                        p = info["name_recipe"];
                        cal_food = info["calorific_recipe"];
                        p_food = info["protein_recipe"];
                        f_food = info["fat_recipe"];
                        c_food = info["carbs_recipe"];
                        i = info["id_recipe"];
                        d = info["description"];
                        spam.Add(new Product() { ID = Convert.ToInt32(i), Name = Convert.ToString(p), Calorific = Convert.ToString(cal_food + "ккал"), Protein = Convert.ToString(p_food + "г"), Fat = Convert.ToString(f_food + "г"), Carbs = Convert.ToString(c_food + "г"), Description = Convert.ToString(d) });

                    }

                    return spam;

                }
                catch (Exception e)
                {
                    return spam;
                }
            }
        }

        internal void AddProductInDailyFood(int id_product, int mass, int id_user, int id_type, string date)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"INSERT INTO Daily_Food (id_user, id_product, weight, id_type_of_food, now_date ) VALUES (@id_user,@id_product,@weight, @id_type_of_food, @now_date)";

                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@id_product", SqlDbType.Int);
                    command.Parameters.Add("@weight", SqlDbType.Int);
                    command.Parameters.Add("@id_type_of_food", SqlDbType.Int);
                    command.Parameters.Add("@now_date", SqlDbType.DateTime);


                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@id_product"].Value = id_product;
                    command.Parameters["@weight"].Value = mass;
                    command.Parameters["@id_type_of_food"].Value = id_type;
                    command.Parameters["@now_date"].Value = date;



                    command.ExecuteNonQuery();


                }
                catch (Exception e)
                {

                }
            }
        }

        internal void AddIngred(string id_recipe, int id_product, string mass)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"INSERT INTO Prod_Rec ( id_recipe, id_product, weight_product) VALUES (@id_recipe, @id_product, @weight_product)";

                    command.Parameters.Add("@id_product", SqlDbType.Int);
                    command.Parameters.Add("@id_recipe", SqlDbType.Int);
                    command.Parameters.Add("@weight_product", SqlDbType.Int);


                    command.Parameters["@id_product"].Value = id_product;
                    command.Parameters["@id_recipe"].Value = id_recipe;
                    command.Parameters["@weight_product"].Value = mass;



                    command.ExecuteNonQuery();

                    
                }
                catch (Exception e)
                {

                }
            }
            }

        internal bool AddRecipe(string name_Recipe, string cal_Recipe, string protein_Recipe, string fat_Recipe, string carb_Recipe, string description)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"INSERT INTO Recipe (name_recipe, calorific_recipe, protein_recipe, fat_recipe, carbs_recipe, description ) VALUES (@name_recipe,@calorific_recipe,@protein_recipe, @fat_recipe, @carbs_recipe, @description)";

                    command.Parameters.Add("@name_recipe", SqlDbType.NVarChar, 70);
                    command.Parameters.Add("@calorific_recipe", SqlDbType.SmallInt);
                    command.Parameters.Add("@protein_recipe", SqlDbType.Real);
                    command.Parameters.Add("@fat_recipe", SqlDbType.Real);
                    command.Parameters.Add("@carbs_recipe", SqlDbType.Real);
                    command.Parameters.Add("@description", SqlDbType.Text);


                    command.Parameters["@name_recipe"].Value = name_Recipe;
                    command.Parameters["@calorific_recipe"].Value = cal_Recipe;
                    command.Parameters["@protein_recipe"].Value = protein_Recipe;
                    command.Parameters["@fat_recipe"].Value = fat_Recipe;
                    command.Parameters["@carbs_recipe"].Value = carb_Recipe;
                    command.Parameters["@description"].Value = description;



                    command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal int GetCalRecipeByID(string id_recipe)
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

                    command.Parameters["@id_recipe"].Value = id_recipe;

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
                    return 0;
                }
            }
        }

        internal ObservableCollection<Product> GetSearchRecipe(string search_TextBox)
        {
            ObservableCollection<Product> spam = new ObservableCollection<Product>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_recipe, name_recipe, calorific_recipe,protein_recipe,fat_recipe,carbs_recipe From Recipe Where name_recipe Like @search_TextBox";

                    command.Parameters.AddWithValue("@search_TextBox", search_TextBox + "%");

                    SqlDataReader info = command.ExecuteReader();
                    object p = -1, cal_food = -1, f_food = -1, c_food = 1, p_food = -1, i = -1;

                    while (info.Read())
                    {
                        p = info["name_recipe"];
                        cal_food = info["calorific_recipe"];
                        p_food = info["protein_recipe"];
                        f_food = info["fat_recipe"];
                        c_food = info["carbs_recipe"];
                        i = info["id_recipe"];
                        spam.Add(new Product() { ID = Convert.ToInt32(i), Name = Convert.ToString(p), Calorific = Convert.ToString(cal_food + "ккал"), Protein = Convert.ToString(p_food + "г"), Fat = Convert.ToString(f_food + "г"), Carbs = Convert.ToString(c_food + "г") });

                    }

                    return spam;

                }
                catch (Exception e)
                {
                    return spam;
                }
            }
            throw new NotImplementedException();
        }

        internal ObservableCollection<Product> GetSearchProduct(string search_TextBox)
        {
            ObservableCollection<Product> spam = new ObservableCollection<Product>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_product, name_product, calorific_product,protein_product,fat_product,carbs_product From Products Where name_product Like @search_TextBox";

                   // command.Parameters.Add("@search_TextBox", SqlDbType.NVarChar,40);
                    command.Parameters.AddWithValue("@search_TextBox",  search_TextBox + "%");
                    //command.Parameters["@search_TextBox"].Value = search_TextBox;

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
                    return spam;
                }
            }
            }

        internal string GetIdRecipeByName(string name)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_recipe From Recipe Where name_recipe = @name_recipe";
                    command.Parameters.Add("@name_recipe", SqlDbType.NVarChar, 50);

                    command.Parameters["@name_recipe"].Value = name;

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
                    return "";
                }
            }
        }

        public void AddRecipeInDailyFood(int id_recipe, int mass, int id_user, int id_type, string date)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"INSERT INTO Daily_Food (id_user, id_recipe, weight, id_type_of_food, now_date ) VALUES (@id_user,@id_recipe,@weight, @id_type_of_food, @now_date)";

                    command.Parameters.Add("@id_user", SqlDbType.Int);
                    command.Parameters.Add("@id_recipe", SqlDbType.Int);
                    command.Parameters.Add("@weight", SqlDbType.Int);
                    command.Parameters.Add("@id_type_of_food", SqlDbType.Int);
                    command.Parameters.Add("@now_date", SqlDbType.DateTime);


                    command.Parameters["@id_user"].Value = id_user;
                    command.Parameters["@id_recipe"].Value = id_recipe;
                    command.Parameters["@weight"].Value = mass;
                    command.Parameters["@id_type_of_food"].Value = id_type;
                    command.Parameters["@now_date"].Value = date;



                    command.ExecuteNonQuery();

                    
                }
                catch (Exception e)
                {
                    
                }

            }
        }

        public ObservableCollection<Product> GetProduct()
        {
            ObservableCollection<Product> spam = new ObservableCollection<Product>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_product, name_product, calorific_product,protein_product,fat_product,carbs_product From Products";


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
                    return spam;
                }
            }
        }

        public string GetIdProductByName(string name)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {

                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_product From Products Where name_product = @name_product";
                    command.Parameters.Add("@name_product", SqlDbType.NVarChar, 50);

                    command.Parameters["@name_product"].Value = name;

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
                    return "";
                }
            }
        }

        public int GetCalProductByID(string id_product)
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

                    command.Parameters["@id_product"].Value = id_product;

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
                    return 0;
                }
            }
        }


    }
}
