using Diabet.net.View_Models;
using System.Windows;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MainWindowAdminViewModel m;
        public AdminWindow()
        {
            m = new MainWindowAdminViewModel();
            InitializeComponent();
            DataContext = m;
        }
    }
}
