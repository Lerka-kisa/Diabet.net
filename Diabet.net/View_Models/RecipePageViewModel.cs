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
using System.Windows.Controls;
using System.Windows.Input;

namespace Diabet.net.View_Models
{
    public class RecipePageViewModel : ViewModelBase
    {
        private Page AllRecipe;
        private Page RecipeInfo;
     

        public RecipePageViewModel()
        {
            
            AllRecipe = new AllRecipePage(this);
          //  RecipeInfo = new RecipeInfoPage();
            
            CurrentPage = AllRecipe;

            
        }

       
        private Page currentpage;
        public Page CurrentPage
        {
            get
            {
                return currentpage;
            }
            set
            {
                this.currentpage = value;
                RaisePropertiesChanged(nameof(CurrentPage));
            }
        }
    }
}
