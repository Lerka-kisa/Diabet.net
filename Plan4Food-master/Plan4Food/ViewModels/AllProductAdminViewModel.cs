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
    class AllProductAdminViewModel : ViewModelBase
    {
        public ObservableCollection<Product> All_Product { get; set; }
        DB_AddFood dB_AddFood = new DB_AddFood();
        public ObservableCollection<Ingredients> ALL_Ingredients;

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
            if (ALL_Ingredients == null)
                ALL_Ingredients = new ObservableCollection<Ingredients>() { new Ingredients() { Name_Product = All_Product[Index].Name, ID_Product = All_Product[Index].ID, Mass = Mass, ID_Recipe = 0 } };
            else
                ALL_Ingredients.Add(new Ingredients() { Name_Product = All_Product[Index].Name, ID_Product = All_Product[Index].ID, Mass = Mass, ID_Recipe=0});

            
            Close();
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
    }
        }
