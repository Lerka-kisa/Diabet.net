using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Windows.Input;
using Plan4Food.DB;
using System.Collections.ObjectModel;
using Plan4Food.Models;
using Plan4Food.Views;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace Plan4Food.ViewModels
{
    class StatisticsViewModel : ViewModelBase
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public DataBaseUser dbu = new DataBaseUser();
        public SolidColorBrush MyColorForFill = new SolidColorBrush(Color.FromArgb(56,174,150,130));
        public SolidColorBrush MyColorForStroke = new SolidColorBrush(Color.FromRgb(174, 150, 130));
        public SolidColorBrush MyColorForPoint = new SolidColorBrush(Color.FromRgb(203, 77, 63));

        public StatisticsViewModel()
        {
            Labels = GetDateParam(Properties.Settings.Default.IdUser);
            SeriesCollection = new SeriesCollection
            {
                new LineSeries{
                    Title = Properties.Settings.Default.User,
                    Values = GetMassParam(Properties.Settings.Default.IdUser),
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,
                    PointForeground = MyColorForPoint
                    
                }
               
            };
            YFormatter = value => value.ToString("C");

            ((LineSeries)SeriesCollection[0]).Stroke = MyColorForStroke;
            ((LineSeries)SeriesCollection[0]).Fill = MyColorForFill;


        }

       
        private ChartValues<double> GetMassParam(string idUser)
        {
            ChartValues<double> Item = dbu.GetMassFromHistory(idUser);
            return Item;
        }

        private string[] GetDateParam(string idUser)
        {
            List<string> Item = dbu.GetDateFromHistory(idUser);
            string[] a = new string[Item.Count];
            int i = 0;
            foreach (var j in Item)
            {
                
                a[i] = j;
                i++;
            }
            return a;
        }
    }
}
