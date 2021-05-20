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

        #region Insulin
        public ICommand add_insulin => new DelegateCommand(Add_Insulin);
        public void Add_Insulin()
        {

            if (Up_Insulin == String.Empty || Up_Insulin == null)

                ErrorMes = Properties.Resources.emptyfield;

            else
            {
                dB.AddInsulin(Properties.Settings.Default.IdUser, today.ToString(), type, Up_Insulin);
                if(type == 1)
                {
                    float insulin_day_up = float.Parse(dB.GetInsulin(id_user, today.ToString(), 1) ?? "0.0");
                    Obj.str_insulin_day = Convert.ToString(insulin_day_up) + " ед.";

                }
                else
                {
                    float insulin_night_up = float.Parse(dB.GetInsulin(id_user, today.ToString(), 2) ?? "0.0");
                    Obj.str_insulin_night = Convert.ToString(insulin_night_up) + " ед.";
                }
                Close();
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
        #endregion

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


        public ICommand back => new DelegateCommand(Back);
        private void Back()
        {
            Close();
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
    }
}
