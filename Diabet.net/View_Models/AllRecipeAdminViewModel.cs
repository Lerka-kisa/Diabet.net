using DevExpress.Mvvm;
using Diabet.net.DB;
using Diabet.net.Models;
using Diabet.net.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Diabet.net.View_Models
{
    class AllRecipeAdminViewModel : ViewModelBase
    {
        public ObservableCollection<Product> All_Recipe { get; set; }
        DB_AddFood dB_AddFood = new DB_AddFood();

        public AllRecipeAdminViewModel()
        {
            All_Recipe = dB_AddFood.GetRecipe();
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

        public ICommand search_product => new DelegateCommand(Search_Product);

        private void Search_Product()
        {
            if (Search_TextBox == "")
                All_Recipe = dB_AddFood.GetProduct();
            else
            {
                All_Recipe.Clear();
                ObservableCollection<Product> Item = dB_AddFood.GetSearchRecipe(Search_TextBox);
                foreach (var i in Item)
                    All_Recipe.Add(i);
            }
        }

    }
}

