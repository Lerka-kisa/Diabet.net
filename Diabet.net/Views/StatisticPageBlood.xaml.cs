using Diabet.net.View_Models;
using System.Windows.Controls;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для StatisticPageBlood.xaml
    /// </summary>
    public partial class StatisticPageBlood : Page
    {
        StatisticsViewModel s;
        public StatisticPageBlood()
        {
            s = new StatisticsViewModel(2);
            InitializeComponent();
            DataContext = s;
        }
    }
}
