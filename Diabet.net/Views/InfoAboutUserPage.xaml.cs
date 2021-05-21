using Diabet.net.View_Models;
using System.Windows.Controls;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для InfoAboutUserPage.xaml
    /// </summary>
    public partial class InfoAboutUserPage : Page
    {
        UserPageViewModel u;
        public InfoAboutUserPage()
        {
            u = new UserPageViewModel();
            InitializeComponent();
            DataContext = u;
        }
    }
}
