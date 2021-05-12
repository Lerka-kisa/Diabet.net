using DevExpress.Mvvm;
using Diabet.net.DB;
using Diabet.net.Models;
using Diabet.net.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Diabet.net.View_Models
{
    internal class AddInsulinViewModel: ViewModelBase
    {
        MainPageViewModel Obj;
        DB_AddInsulin dB = new DB_AddInsulin();
        DateTime today = DateTime.Today;
        int type;
        public ObservableCollection<Product> AllApproveProduct { get; set; }
        public AddInsulinViewModel(MainPageViewModel obj, int _type)
        {
            Obj = obj;
            type = _type;
        }

        #region Дата
        private string _date;
        public string date
        {
            get => today.ToShortDateString();
            set
            {
                this._date = value;
                RaisePropertiesChanged(nameof(date));
            }
        }
        #endregion

        #region Id_User
        private string _id_user;
        public string id_user
        {
            get { return getIdUser(); }
            set
            {
                this._id_user = value;
                RaisePropertiesChanged(nameof(id_user));
            }
        }
        private string getIdUser()
        {
            return Properties.Settings.Default.IdUser;
        }
        #endregion

        public ICommand add_insulin => new DelegateCommand(Add_Day);

        public void Add_Day()
        {

            if (Up_Insulin == String.Empty || Up_Insulin == null)

                ErrorMes = Properties.Resources.emptyfield;

            else
            {
                dB.AddInsulin(Properties.Settings.Default.IdUser, today.ToString(), type, Up_Insulin);
                float insulin_day_up = float.Parse(dB.GetInsulinDay(id_user, today.ToString(), 1));
                Obj.str_insulin_day = Convert.ToString(insulin_day_up) + " ед.";
                float insulin_night_up = float.Parse(dB.GetInsulinDay(id_user, today.ToString(), 2));
                Obj.str_insulin_night = Convert.ToString(insulin_night_up) + " ед.";
                Close();
            }
        }
        public void Add_Night()
        {
            if (Up_Insulin == String.Empty || Up_Insulin == null)

                ErrorMes = Properties.Resources.emptyfield;

            else
            {
                dB.AddInsulin(Properties.Settings.Default.IdUser, today.ToString(), type, Up_Insulin);
                float insulin_night_up = float.Parse(dB.GetInsulinDay(id_user, today.ToString(), 2));
                Obj.str_insulin_night = Convert.ToString(insulin_night_up) + " ед.";
                Close();
            }
        }
        private string errorMes;
        public string ErrorMes
        {
            get { return errorMes; }
            set
            {
                this.errorMes = value;
                RaisePropertiesChanged(nameof(ErrorMes));
            }
        }
        private string up_insulin;
        public string Up_Insulin
        {
            get
            {
                return up_insulin;
            }
            set
            {
                this.up_insulin = value;
                RaisePropertiesChanged(nameof(Up_Insulin));
            }
        }
        public void Close()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }
        public ICommand back => new DelegateCommand(Back);

        private void Back()
        {
            Close();

        }
    }
}
