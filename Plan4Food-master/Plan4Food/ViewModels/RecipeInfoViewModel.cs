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
using System.Windows.Controls;
using System.Windows.Input;

namespace Plan4Food.ViewModels
{
    class RecipeInfoViewModel : ViewModelBase
    {
        Product SelectedRecipe;
        public ObservableCollection<Ingredients> Recipe { get; set; }
        DB_Main dB_recipe = new DB_Main();
        RecipePageViewModel boss_page;
        public RecipeInfoViewModel(Product obj,RecipePageViewModel obj2)
        {
            SelectedRecipe = obj;
            Name_Recipe = SelectedRecipe.Name;
            Description_Recipe = SelectedRecipe.Description;
            Cal_Recipe = SelectedRecipe.Calorific;
            Protein_Recipe = SelectedRecipe.Protein;
            Fat_Recipe = SelectedRecipe.Fat;
            Carb_Recipe = SelectedRecipe.Carbs;
            Recipe = GetIngtedientsForRecipe(SelectedRecipe.ID);
            boss_page = obj2;
        }

        private ObservableCollection<Ingredients> GetIngtedientsForRecipe(int id_recipe)
        {
            ObservableCollection<Ingredients> Item = dB_recipe.GetIngtedients(id_recipe);

            return Item;
        }

        private string name_recipe;
        public string Name_Recipe
        {
            get
            {
                return name_recipe;
            }
            set
            {
                this.name_recipe = value;
                RaisePropertiesChanged(nameof(Name_Recipe));
            }
        }
        private string cal_recipe;
        public string Cal_Recipe
        {
            get
            {
                return cal_recipe;
            }
            set
            {
                this.cal_recipe = value;
                RaisePropertiesChanged(nameof(Cal_Recipe));
            }
        }
        private string protein_recipe;
        public string Protein_Recipe
        {
            get
            {
                return protein_recipe;
            }
            set
            {
                this.protein_recipe = value;
                RaisePropertiesChanged(nameof(Protein_Recipe));
            }
        }

        private string fat_recipe;
        public string Fat_Recipe
        {
            get
            {
                return fat_recipe;
            }
            set
            {
                this.fat_recipe = value;
                RaisePropertiesChanged(nameof(Fat_Recipe));
            }
        }

        private string carb_recipe;
        public string Carb_Recipe
        {
            get
            {
                return carb_recipe;
            }
            set
            {
                this.carb_recipe = value;
                RaisePropertiesChanged(nameof(Carb_Recipe));
            }
        }
        private string description_recipe;
        public string Description_Recipe
        {
            get
            {
                return description_recipe;
            }
            set
            {
                this.description_recipe = value;
                RaisePropertiesChanged(nameof(Description_Recipe));
            }
        }

        public ICommand back => new DelegateCommand(Back);

        private void Back()
        {
            Page Recipes = new AllRecipePage(boss_page);
            boss_page.CurrentPage = Recipes;
        }
    }
}
