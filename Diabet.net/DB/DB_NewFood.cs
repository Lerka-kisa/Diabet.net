using Diabet.net.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Diabet.net.DB
{
    class DB_NewFood
    {
        private const string StringConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Diabet.net; User=Admin; Password = Admin";
        private const string StringConnectionUser = @"Data Source=.\SQLEXPRESS;Initial Catalog=Diabet.net; User=User; Password = User";
        //private const string StringConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Diabet.net; Integrated Security=True";
        //private const string StringConnection = @"Data Source=LEKRA_SH;Initial Catalog=Diabet.net; Integrated Security=True";

        //+
        public bool AddProductInApproval(string name, string cal, string p, string f, string c)
        {
            string sqlExpression = "AddProductInApproval";

            using (SqlConnection sqlCon = new SqlConnection(StringConnectionUser))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@name_product", Value = name });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@calorific_product", Value = cal });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@protein_product", Value = p });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@fat_product", Value = f });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@carbs_product", Value = c });

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
        internal ObservableCollection<Product> GetAllApproveProduct()
        {
            string sqlExpression = "GetAllApproveProduct";

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
                    //MessageBox.Show(e.Message);
                    return spam;
                }
            }
        }

        //+
        public bool ApprovalProduct(int id)
        {
            string sqlExpression = "ApprovalProduct";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = id });

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
        internal void DeleteFromApproveProduct(int id)
        {
            string sqlExpression = "DeleteFromApproveProduct";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = id });
                    

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                }
            }
        }

        internal bool DeleteProduct(int id)
        {
            string sqlExpression = "DeleteProduct";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = id });

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
        internal bool DeleteRecipe(int id)
        {
            string sqlExpression = "DeleteRecipe";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = id });

                    SqlDataReader info = command.ExecuteReader();
                    object p = -1;
                    while (info.Read())
                    {
                        p = info["count"];
                    }
                    if (Convert.ToInt32(p) == 0)
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
        public bool AddProductInProduct(string name, string cal, string p, string f, string c)
        {
            string sqlExpression = "AddProductInProduct";

            using (SqlConnection sqlCon = new SqlConnection(StringConnection))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, sqlCon);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@name_product", Value = name });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@calorific_product", Value = cal });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@protein_product", Value = p });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@fat_product", Value = f });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@carbs_product", Value = c });

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
    }
}