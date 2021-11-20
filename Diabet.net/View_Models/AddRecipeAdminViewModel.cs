using DevExpress.Mvvm;
using Diabet.net.DB;
using Diabet.net.Models;
using Diabet.net.Views;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows;
using System.Windows.Input;

namespace Diabet.net.View_Models
{
    class AddRecipeAdminViewModel : ViewModelBase
    {
        public ObservableCollection<Ingredients> ingredients { get; set; }
        DB_AddFood dB_AddFood = new DB_AddFood();

        public AddRecipeAdminViewModel()
        {
            ingredients = new ObservableCollection<Ingredients>();
        }

        #region Data from the form.
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

        private byte[] screenimg;
        public byte[] Screenimg
        {
            get => screenimg;
            set
            {
                screenimg = value;
                RaisePropertiesChanged(nameof(Screenimg));
            }
        }
        #endregion

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
            bool check1 = false;
            bool check2 = false;

            if (Name_Recipe == String.Empty || Name_Recipe == null || Cal_Recipe == String.Empty || Cal_Recipe == null || Protein_Recipe == String.Empty || Protein_Recipe == null
                                    || Fat_Recipe == String.Empty || Fat_Recipe == null || Carb_Recipe == String.Empty || Carb_Recipe == null || Description == null || Description == String.Empty || ingredients.Count <= 0)
                ErrorMes = Properties.Resources.emptyfield;
            else check1 = true;
            if (check1)
            {
                if (Name_Recipe.Length > 50)
                    ErrorMes = Properties.Resources.bigname;
                else check2 = true;
            }
                
            if (check1 && check2)
            {
                byte[] a = {2,3,4} ;
                if (dB_AddFood.AddRecipe(Name_Recipe, Cal_Recipe, Protein_Recipe, Fat_Recipe, Carb_Recipe, Description, Screenimg))
                {
                    string id_recipe = dB_AddFood.GetIdRecipeByName(Name_Recipe);
                    foreach (var i in ingredients)
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
                    ErrorMes = "";
                }
                else
                    ErrorMes = Properties.Resources.errordata;
            }
        }

        private byte[] OpenImageDialog()
        {
            var openFileDialog = new OpenFileDialog { Filter = @"Image files (*.jpg,*.png,*.mp4)|*.jpg;*.png;*.mp4" };
            byte[] binArray = null;
            if (openFileDialog.ShowDialog() == true)
            {
                binArray = System.IO.File.ReadAllBytes(openFileDialog.FileName);
            }
            else
            {
                return null;
            }
            return binArray;
        }

        public static byte[] ImageToByte(Bitmap bitmap)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
        }

        public ICommand addPicture => new DelegateCommand(AddPicture);
        private void AddPicture()
        {
                byte[] binArray = OpenImageDialog();
                if (binArray == null) return;
                //if ((binArray.Length / 1024) > 1024)
                //{
                //    ErrorMes = "Файл больше мегабайта";
                //    return;
                //}
                else
                {
                    screenimg = binArray;
                    ErrorMes = "Изображение добавлено";
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
