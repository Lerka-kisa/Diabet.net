using DevExpress.Mvvm;
using Diabet.net.Views;
using System.Windows.Controls;

namespace Diabet.net.View_Models
{
    public class RecipePageViewModel : ViewModelBase
    {
        private Page AllRecipe;

        public RecipePageViewModel()
        {
            AllRecipe = new AllRecipePage(this);
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
