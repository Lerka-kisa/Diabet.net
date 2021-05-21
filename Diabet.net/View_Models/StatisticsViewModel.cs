using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Windows.Input;
using Diabet.net.DB;
using System.Collections.ObjectModel;
using Diabet.net.Models;
using Diabet.net.Views;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace Diabet.net.View_Models
{
    class StatisticsViewModel : ViewModelBase
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public DataBaseUser dbu = new DataBaseUser();
        public SolidColorBrush MyColorForFill;
        public SolidColorBrush MyColorForStroke;
        public SolidColorBrush MyColorForPoint;

        public StatisticsViewModel(int x)
        {
            if (x == 1)
            {
                MyColorForFill = new SolidColorBrush(Color.FromArgb(56, 244, 215, 94));
                MyColorForStroke = new SolidColorBrush(Color.FromRgb(233, 114, 61));
                MyColorForPoint = new SolidColorBrush(Color.FromRgb(244, 215, 94));
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
            }
            if (x == 2)
            {
                MyColorForFill = new SolidColorBrush(Color.FromArgb(56, 244, 215, 94));
                MyColorForStroke = new SolidColorBrush(Color.FromRgb(244, 215, 94));
                MyColorForPoint = new SolidColorBrush(Color.FromRgb(233, 114, 61));
                Labels = GetDateParamBlood(Properties.Settings.Default.IdUser);
                SeriesCollection = new SeriesCollection
                {
                    new LineSeries{
                        Title = Properties.Settings.Default.User,
                        Values = GetBloodParam(Properties.Settings.Default.IdUser),
                        PointGeometry = DefaultGeometries.Circle,
                        PointGeometrySize = 10,
                        PointForeground = MyColorForPoint
                    }
                };
            }
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

        private ChartValues<double> GetBloodParam(string idUser)
        {
            ChartValues<double> Item = dbu.GetBloodFromHistory(idUser);
            return Item;
        }

        private string[] GetDateParamBlood(string idUser)
        {
            List<string> Item = dbu.GetDateFromHistoryBlood(idUser);
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
