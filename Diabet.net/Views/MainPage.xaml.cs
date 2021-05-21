using Diabet.net.View_Models;
using System.Windows.Controls;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        MainPageViewModel m;
        public MainPage()
        {
            m = new MainPageViewModel();
            InitializeComponent();
            DataContext = m;
        }
    }
}
