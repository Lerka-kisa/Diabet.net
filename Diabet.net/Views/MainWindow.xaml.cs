using Diabet.net.View_Models;
using System.Windows;

namespace Diabet.net
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel m = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = m;
        }

    }
}
