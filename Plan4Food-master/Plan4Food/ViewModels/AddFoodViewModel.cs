using DevExpress.Mvvm;
using Plan4Food.DB;
using Plan4Food.Models;
using Plan4Food.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Plan4Food.ViewModels
{
    internal class AddFoodViewModel : ViewModelBase
    {
        DB_Main db = new DB_Main();
        public ObservableCollection<Product> All_Product { get; set; }
        private MainPageViewModel Obj;
        DateTime today = DateTime.Today;
        DB_AddFood dB_AddFood = new DB_AddFood();
       
    
        public AddFoodViewModel(  MainPageViewModel obj)
        {
            All_Product = new ObservableCollection<Product>();
            All_Product = GetAllProduct();
            Index = new int();

          

            Obj = obj;

        }

        private string errorMes;
        public string ErrorMes
        {
            get { return errorMes; }
            set
            {
                this.errorMes = value;
                RaisePropertiesChanged(nameof(ErrorMes));
            }
        }

        private string search_textbox;
        public string Search_TextBox
        {
            get
            {
                return search_textbox;
            }
            set
            {
                this.search_textbox = value;
                RaisePropertiesChanged(nameof(Search_TextBox));
            }
        }

        private string type_of_food;
        public string Type_of_food
        {
            get
            {
                return GetTypeOfFood(Properties.Settings.Default.IdTypeOfFood);
            }
            set
            {
                this.type_of_food = value;
                RaisePropertiesChanged(nameof(Type_of_food));
            }
        }

        private string GetTypeOfFood(int idTypeOfFood)
        {
            string type = dB_AddFood.GetTypeOfFoodById(idTypeOfFood);
            return type;
        }

       
       

        

        private ObservableCollection<Product> GetAllProduct()
        {
            ObservableCollection<Product> ItemsDB = dB_AddFood.GetProduct();
            ObservableCollection<Product> ItemsDB_2 = dB_AddFood.GetRecipe();

            foreach (var i in ItemsDB_2)
                ItemsDB.Add(i);

            return ItemsDB;

        }

        private string mass;
        public string Mass
        {
            get
            {
                return mass;
            }
            set
            {
                this.mass = value;
                RaisePropertiesChanged(nameof(Mass));
            }
        }
        private int index;
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                this.index = value;
                RaisePropertiesChanged(nameof(Index));
            }
        }

       

        public ICommand add_product => new DelegateCommand(Add_Product);

        private void Add_Product()
        {
            try
            {
                if (Mass == null || Mass == String.Empty)
                    ErrorMes = Properties.Resources.emptyfield;
                else
                {
                    int Daily_Cal = Obj.daily_cal;
                    string id_product = dB_AddFood.GetIdProductByName(All_Product[Index].Name);
                    string id_recipe = dB_AddFood.GetIdRecipeByName(All_Product[Index].Name);
                    int cal = 0;
                    int id_type_food = Properties.Settings.Default.IdTypeOfFood;
                    if (id_product == "-1")
                    {
                        dB_AddFood.AddRecipeInDailyFood(All_Product[Index].ID, Convert.ToInt32(Mass), Convert.ToInt32(Properties.Settings.Default.IdUser), id_type_food, today.ToString());
                        cal = dB_AddFood.GetCalRecipeByID(id_recipe);
                    }
                    else if (id_recipe == "-1")
                    {
                        dB_AddFood.AddProductInDailyFood(All_Product[Index].ID, Convert.ToInt32(Mass), Convert.ToInt32(Properties.Settings.Default.IdUser), id_type_food, today.ToString());
                        cal = dB_AddFood.GetCalProductByID(id_product);
                    }
                    int caloriesEaten;
                    caloriesEaten = Convert.ToInt32(Mass) * cal / 100;

                    Close();

                    if (id_type_food == 1)
                        Obj.Name_food_breakfast.Add(new Food { Name = All_Product[Index].Name, Mass = Mass + "г", Cal = Convert.ToString(caloriesEaten) + "ккал" });
                    else if (id_type_food == 2)
                        Obj.Name_food_lunch.Add(new Food { Name = All_Product[Index].Name, Mass = Mass + "г", Cal = Convert.ToString(caloriesEaten) + "ккал" });
                    else if (id_type_food == 3)
                        Obj.Name_food_dinner.Add(new Food { Name = All_Product[Index].Name, Mass = Mass + "г", Cal = Convert.ToString(caloriesEaten) + "ккал" });
                    else if (id_type_food == 4)
                        Obj.Name_food_snack.Add(new Food { Name = All_Product[Index].Name, Mass = Mass + "г", Cal = Convert.ToString(caloriesEaten) + "ккал" });
                    else
                    { }
                    Daily_Cal -= caloriesEaten;
                    db.UpdateDailyCal(Properties.Settings.Default.IdUser, today.ToString(), Daily_Cal);
                    Obj.daily_cal = Daily_Cal;
                }
            }
            catch(SystemException)
            {
                ErrorMes = Properties.Resources.errordata;
            }
        }

        public ICommand search_product => new DelegateCommand(Search_Product);

        private void Search_Product()
        {
            if (Search_TextBox == "")
                All_Product = GetAllProduct();
            else
            {
                All_Product.Clear();
                ObservableCollection<Product> Item = dB_AddFood.GetSearchProduct(Search_TextBox);
                foreach (var i in Item)
                    All_Product.Add(i);
                Item = dB_AddFood.GetSearchRecipe(Search_TextBox);
                foreach (var i in Item)
                    All_Product.Add(i);
            }
        }

        public void Close()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }

        public ICommand close => new DelegateCommand(Close);

        public ICommand openNewFood => new DelegateCommand(OpenNewFood);

        public void OpenNewFood()
        {
            New_Food win = new New_Food(Obj);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
            Close();
        }

    }
}
