using Diabet.net.View_Models;
using System.Windows.Controls;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для RecipePage.xaml
    /// </summary>
    public partial class RecipePage : Page
    {
        RecipePageViewModel r;
        public RecipePage()
        {
            r = new RecipePageViewModel();
            InitializeComponent();
            DataContext = r;
        }
    }
}
