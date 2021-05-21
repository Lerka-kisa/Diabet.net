using Diabet.net.View_Models;
using System.Windows.Controls;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        StatisticsViewModel s;
        public StatisticsPage()
        {
            s = new StatisticsViewModel(1);
            InitializeComponent();
            DataContext = s;
        }
    }
}
