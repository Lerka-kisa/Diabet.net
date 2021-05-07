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
    class AddRecipeAdminViewModel : ViewModelBase
    {
        public ObservableCollection<Ingredients> ingredients { get; set; }

        public AddRecipeAdminViewModel()
        {
            ingredients = new ObservableCollection<Ingredients>();
        }
     
        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                this.description = value;
                RaisePropertiesChanged(nameof(description));
            }
        }

        private string name_Recipe;
        public string Name_Recipe
        {
            get
            {
                return name_Recipe;
            }
            set
            {
                this.name_Recipe = value;
                RaisePropertiesChanged(nameof(Name_Recipe));
            }
        }

        private string cal_Recipe;
        public string Cal_Recipe
        {
            get
            {
                return cal_Recipe;
            }
            set
            {
                this.cal_Recipe = value;
                RaisePropertiesChanged(nameof(Cal_Recipe));
            }
        }

        private string protein_Recipe;
        public string Protein_Recipe
        {
            get
            {
                return protein_Recipe;
            }
            set
            {
                this.protein_Recipe = value;
                RaisePropertiesChanged(nameof(Protein_Recipe));
            }
        }

        private string fat_Recipe;
        public string Fat_Recipe
        {
            get
            {
                return fat_Recipe;
            }
            set
            {
                this.fat_Recipe = value;
                RaisePropertiesChanged(nameof(Fat_Recipe));
            }
        }

        private string carb_Recipe;
        public string Carb_Recipe
        {
            get
            {
                return carb_Recipe;
            }
            set
            {
                this.carb_Recipe = value;
                RaisePropertiesChanged(nameof(Carb_Recipe));
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
        public ICommand addIngr => new DelegateCommand(AddIngr);

        private void AddIngr()
        {
            AddIngridient _win = new AddIngridient(ingredients);
            _win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _win.Show();
        }

        public ICommand new_recipe => new DelegateCommand(New_Recipe);

        private void New_Recipe()
        {
            DB_AddFood dB_AddFood = new DB_AddFood();
            if(dB_AddFood.AddRecipe(Name_Recipe, Cal_Recipe, Protein_Recipe, Fat_Recipe, Carb_Recipe, Description))
            {
                string id_recipe = dB_AddFood.GetIdRecipeByName(Name_Recipe);
                foreach(var i in ingredients)
                {
                    dB_AddFood.AddIngred(id_recipe, i.ID_Product, i.Mass);
                }

                Name_Recipe = "";
                Cal_Recipe = "";
                Protein_Recipe = "";
                Fat_Recipe = "";
                Carb_Recipe = "";
                Description = "";
                ingredients.Clear();
            }
           
        }

        public ICommand clearForm => new DelegateCommand(ClearForm);

        private void ClearForm()
        {
            Name_Recipe = "";
            Cal_Recipe = "";
            Protein_Recipe = "";
            Fat_Recipe = "";
            Carb_Recipe = "";
            Description = "";
            ingredients.Clear();
        }
    }
}
