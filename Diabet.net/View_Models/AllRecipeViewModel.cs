using DevExpress.Mvvm;
using Diabet.net.DB;
using Diabet.net.Models;
using Diabet.net.Views;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Diabet.net.View_Models
{
    public class AllRecipeViewModel : ViewModelBase
    {
        public ObservableCollection<Product> All_Recipe { get; set; }
        DB_AddFood dB_AddFood = new DB_AddFood();
        RecipePageViewModel Obj;
        public AllRecipeViewModel(RecipePageViewModel obj)
        {
            All_Recipe = GetAllRecipe();

            Obj = obj;
        }

        private ObservableCollection<Product> GetAllRecipe()
        {
            ObservableCollection<Product> ItemsDB = dB_AddFood.GetRecipe();

            return ItemsDB;
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

        private string search_textBox;
        public string Search_TextBox
        {
            get
            {
                return search_textBox;
            }
            set
            {
                this.search_textBox = value;
                RaisePropertiesChanged(nameof(Search_TextBox));
            }
        }

        public ICommand search_recipe => new DelegateCommand(Search_Recipe);
        private void Search_Recipe()
        {
            if (Search_TextBox == "")
                All_Recipe = GetAllRecipe();
            else
            {
                All_Recipe.Clear();
                ObservableCollection<Product> Item;
                Item = dB_AddFood.GetSearchRecipe(Search_TextBox);
                foreach (var i in Item)
                    All_Recipe.Add(i);
                Search_TextBox = null;
            }
        }

        public ICommand open_info_recipe => new DelegateCommand(OpenInfoRecipe);
        private void OpenInfoRecipe()
        {
            if (0 <= Index && Index < All_Recipe.Count)
            {
                Page RecipeInfo = new RecipeInfoPage(All_Recipe[Index], Obj);
                Obj.CurrentPage = RecipeInfo;
            }
            else ErrorMes = Properties.Resources.emptytable;
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
    }
}

