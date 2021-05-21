using Diabet.net.View_Models;
using System.Windows.Controls;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для AllRecipePage.xaml
    /// </summary>
    public partial class AllRecipePage : Page
    {
        AllRecipeViewModel r;
        public AllRecipePage(RecipePageViewModel obj)
        {
            r = new AllRecipeViewModel(obj);
            InitializeComponent();
            DataContext = r;
        }
    }
}
