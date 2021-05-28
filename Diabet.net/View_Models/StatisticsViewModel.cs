using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using Diabet.net.DB;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace Diabet.net.View_Models
{
    class StatisticsViewModel : ViewModelBase
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] LabelsMass { get; set; }
        public string[] LabelsBlood { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public DataBaseUser dbu = new DataBaseUser();
        public SolidColorBrush MyColorForFill;
        public SolidColorBrush MyColorForStroke;
        SolidColorBrush orange = new SolidColorBrush(Color.FromRgb(233, 114, 61));
        SolidColorBrush yellow = new SolidColorBrush(Color.FromRgb(244, 215, 94));

        public StatisticsViewModel(int x)
        {
            if (x == 1)
            {
                MyColorForFill = new SolidColorBrush(Color.FromArgb(56, 244, 215, 94));
                MyColorForStroke = orange;
                LabelsMass = GetDateParam(Properties.Settings.Default.IdUser,1);
                SeriesCollection = new SeriesCollection
                {
                    new LineSeries{
                        Title = Properties.Settings.Default.User,
                        Values = GetMassParam(Properties.Settings.Default.IdUser),
                        PointGeometry = DefaultGeometries.Circle,
                        PointGeometrySize = 10,
                        PointForeground = yellow
                    }
                };
            }
            if (x == 2)
            {
                MyColorForFill = new SolidColorBrush(Color.FromArgb(56, 244, 215, 94));
                MyColorForStroke = yellow;
                LabelsBlood = GetDateParam(Properties.Settings.Default.IdUser,2);
                SeriesCollection = new SeriesCollection
                {
                    new LineSeries{
                        Title = Properties.Settings.Default.User,
                        Values = GetBloodParam(Properties.Settings.Default.IdUser),
                        PointGeometry = DefaultGeometries.Circle,
                        PointGeometrySize = 10,
                        PointForeground = orange
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
        private ChartValues<double> GetBloodParam(string idUser)
        {
            ChartValues<double> Item = dbu.GetBloodFromHistory(idUser);
            return Item;
        }
        private string[] GetDateParam(string idUser, int Type)
        {
            List<string> Item = new List<string>();
            if (Type == 1) 
            {
                Item = dbu.GetDateFromHistory(idUser);
            }
            if (Type == 2)
            {
                Item = dbu.GetDateFromHistoryBlood(idUser);
            }
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
