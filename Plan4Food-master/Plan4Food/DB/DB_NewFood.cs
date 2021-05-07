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
    class DB_NewFood
    {
        private const string StringConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=KP_DataBase; Integrated Security=True";

        public void AddProductInApproval(string name, string cal, string p, string f, string c)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"INSERT INTO Products_Awaiting_Approval (name_product, calorific_product, protein_product, fat_product, carbs_product ) VALUES (@name_product,@calorific_product,@protein_product, @fat_product, @carbs_product)";

                    command.Parameters.Add("@name_product", SqlDbType.NVarChar, 70);
                    command.Parameters.Add("@calorific_product", SqlDbType.Int);
                    command.Parameters.Add("@protein_product", SqlDbType.Real);
                    command.Parameters.Add("@fat_product", SqlDbType.Real);
                    command.Parameters.Add("@carbs_product", SqlDbType.Real);


                    command.Parameters["@name_product"].Value = name;
                    command.Parameters["@calorific_product"].Value = cal;
                    command.Parameters["@protein_product"].Value = p;
                    command.Parameters["@fat_product"].Value = f;
                    command.Parameters["@carbs_product"].Value = c;



                    command.ExecuteNonQuery();


                }
                catch (Exception e)
                {

                }
            }
        }

        internal void DeleteFromApproveProduct(string name, string cal, string p, string f, string c)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Delete From Products_Awaiting_Approval Where name_product = @name_product and calorific_product = @calorific_product and protein_product = @protein_product and fat_product = @fat_product and carbs_product = @carbs_product";

                    command.Parameters.Add("@name_product", SqlDbType.NVarChar, 70);
                    command.Parameters.Add("@calorific_product", SqlDbType.Int);
                    command.Parameters.Add("@protein_product", SqlDbType.Real);
                    command.Parameters.Add("@fat_product", SqlDbType.Real);
                    command.Parameters.Add("@carbs_product", SqlDbType.Real);


                    command.Parameters["@name_product"].Value = name;
                    command.Parameters["@calorific_product"].Value = cal;
                    command.Parameters["@protein_product"].Value = p;
                    command.Parameters["@fat_product"].Value = f;
                    command.Parameters["@carbs_product"].Value = c;



                    command.ExecuteNonQuery();


                }
                catch (Exception e)
                {

                }
            }
        }

        internal ObservableCollection<Product> GetAllApproveProduct()
        {
            ObservableCollection<Product> spam = new ObservableCollection<Product>();
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"Select id_product, name_product, calorific_product,protein_product,fat_product,carbs_product From Products_Awaiting_Approval";


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

        public void AddProduct(string name, string cal, string p, string f, string c)
        {
            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlCon;
                    command.CommandText = @"INSERT INTO Products (name_product, calorific_product, protein_product, fat_product, carbs_product ) VALUES (@name_product,@calorific_product,@protein_product, @fat_product, @carbs_product)";

                    command.Parameters.Add("@name_product", SqlDbType.NVarChar, 70);
                    command.Parameters.Add("@calorific_product", SqlDbType.Int);
                    command.Parameters.Add("@protein_product", SqlDbType.Real);
                    command.Parameters.Add("@fat_product", SqlDbType.Real);
                    command.Parameters.Add("@carbs_product", SqlDbType.Real);


                    command.Parameters["@name_product"].Value = name;
                    command.Parameters["@calorific_product"].Value = cal;
                    command.Parameters["@protein_product"].Value = p;
                    command.Parameters["@fat_product"].Value = f;
                    command.Parameters["@carbs_product"].Value = c;



                    command.ExecuteNonQuery();


                }
                catch (Exception e)
                {

                }
            }
        }

    }
}
