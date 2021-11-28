using DevExpress.Mvvm;
using Diabet.net.DB;
using Diabet.net.Models;
using Diabet.net.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Diabet.net.View_Models
{
    class AllProductAdminViewModel : ViewModelBase
    {
        public ObservableCollection<Product> All_Product { get; set; }
        DB_AddFood dB_AddFood = new DB_AddFood();
        public ObservableCollection<Ingredients> ALL_Ingredients;
        private MainPageViewModel Obj;

        public AllProductAdminViewModel(ObservableCollection<Ingredients> ingredients)
        {
            All_Product = dB_AddFood.GetProduct();
            ALL_Ingredients = ingredients;
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

        public ICommand search_product => new DelegateCommand(Search_Product);
        private void Search_Product()
        {
            if (Search_TextBox == "")
                All_Product = dB_AddFood.GetProduct();
            else
            {
                All_Product.Clear();
                ObservableCollection<Product> Item = dB_AddFood.GetSearchProduct(Search_TextBox);
                foreach (var i in Item)
                    All_Product.Add(i);
                Search_TextBox = null;
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

        public ICommand new_ingr => new DelegateCommand(New_Ingr);
        private void New_Ingr()
        {
            if (mass == null || mass == String.Empty)
                ErrorMes = "Введите массу ингридиента";
            else
            {
                if (ALL_Ingredients == null)
                    ALL_Ingredients = new ObservableCollection<Ingredients>() { new Ingredients() { Name_Product = All_Product[Index].Name, ID_Product = All_Product[Index].ID, Mass = Mass, ID_Recipe = 0 } };
                else
                    ALL_Ingredients.Add(new Ingredients() { Name_Product = All_Product[Index].Name, ID_Product = All_Product[Index].ID, Mass = Mass, ID_Recipe = 0 });

                Close();
            }
           
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

        public ICommand back => new DelegateCommand(Close);
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

        public ICommand openNewFood => new DelegateCommand(OpenNewFood);
        public void OpenNewFood()
        {
            NewFoodAdmin win = new NewFoodAdmin(Obj);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
            Close();
        }
    }
 }
