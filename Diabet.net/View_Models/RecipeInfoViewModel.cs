using DevExpress.Mvvm;
using Diabet.net.DB;
using Diabet.net.Models;
using Diabet.net.Views;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace Diabet.net.View_Models
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
            Screenimg = SelectedRecipe.Screenimg;
            Recipe = GetIngtedientsForRecipe(SelectedRecipe.ID);
            boss_page = obj2;
        }

        private ObservableCollection<Ingredients> GetIngtedientsForRecipe(int id_recipe)
        {
            ObservableCollection<Ingredients> Item = dB_recipe.GetIngtedients(id_recipe);

            return Item;
        }

        #region Data from the form.
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
        /*17.11*/
        private BitmapImage _screenimg;
        public BitmapImage _Screenimg
        {
            get
            {
                return ByteToBitmapImage(Screenimg);
            }
                set
            {
                this._screenimg = _Screenimg;
                RaisePropertiesChanged(nameof(_Screenimg));
            }
        }

        private byte[] screenimg;
        public byte[] Screenimg
        {
            get
            {
                return screenimg;
            }
            set
            {
                this.screenimg = value;
                RaisePropertiesChanged(nameof(Screenimg));
            }
        }
        #endregion

        public ICommand back => new DelegateCommand(Back);
        private void Back()
        {
            Page Recipes = new AllRecipePage(boss_page);
            boss_page.CurrentPage = Recipes;
        }
        public static BitmapImage ByteToBitmapImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

    }
}
