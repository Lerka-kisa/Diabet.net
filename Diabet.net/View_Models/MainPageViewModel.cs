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
using Enterwell.Clients.Wpf.Notifications;
using LiveCharts;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Diabet.net.View_Models
{
    public class MainPageViewModel : ViewModelBase
    {
        DB_Main db = new DB_Main();
        DB_AddInsulin db_i = new DB_AddInsulin();
        DataBaseUser db_u = new DataBaseUser();
        DateTime today = DateTime.Today;
        
        Users user;
        public ObservableCollection<Food> Name_food_breakfast { get; set; }
        public ObservableCollection<Food> Name_food_lunch { get; set; }
        public ObservableCollection<Food> Name_food_dinner { get; set; }
        public ObservableCollection<Food> Name_food_snack { get; set; }


        public MainPageViewModel()
        {
            Name_food_breakfast = new ObservableCollection<Food>();
            Name_food_breakfast = GetNameFood(1);
            Name_food_lunch = new ObservableCollection<Food>();
            Name_food_lunch = GetNameFood(2);
            Name_food_dinner = new ObservableCollection<Food>();
            Name_food_dinner = GetNameFood(3);
            Name_food_snack = new ObservableCollection<Food>();
            Name_food_snack = GetNameFood(4);
            daily_cal = new int();
            daily_cal = db.GetDailyCal(id_user, today.ToString());
            user = db_u.GetUserInfo(Properties.Settings.Default.IdUser);
            Blood_sugar = db_u.GetSugar(id_user);
        }

        private string blood_sugar;
        public string Blood_sugar
        {
            get { return blood_sugar; }
            set
            {
                this.blood_sugar = value;
                RaisePropertiesChanged(nameof(Blood_sugar));

            }
        }
        public ICommand update_blood_sugar => new DelegateCommand(Update_Blood_Sugar);

        private void Update_Blood_Sugar()
        {
            UpdateSugar _win = new UpdateSugar(this);
            _win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _win.Show();
            
        }
        private float _sugar;
        public float sugar
        {
            get => float.Parse(db_u.GetSugar(id_user));
            set
            {
                this._sugar = value;
                RaisePropertiesChanged(nameof(sugar));
            }
        }

        private int _daily_cal;
        public int daily_cal
        {
            get
            {
                return db.GetDailyCal(id_user, today.ToString());
            }
            set
            {
                this._daily_cal = value;
                RaisePropertiesChanged(nameof(daily_cal));
            }
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

        #region Вода
        private float _water;
        public float water
        {
            get => float.Parse(db.GetWater(id_user, today.ToString()));
            set
            {
                this._water = value;
                RaisePropertiesChanged(nameof(water));
            }
        }

        private string _str_water;
        public string str_water
        {
            get => Convert.ToString(water) + " л";
            set
            {
                this._str_water = value;
                RaisePropertiesChanged(nameof(str_water));
            }
        }

        public ICommand add_water => new DelegateCommand(Add_Water);

        private void Add_Water()
        {

            float up_water = water + (float)0.25;
            db.UpdateWater(id_user, today.ToString(), up_water);
            water = up_water;
            str_water = Convert.ToString(water) + " л";

        }
        #endregion

        #region Таблетки
        private float _pill;
        public float pill
        {
            get => float.Parse(db.GetPill(id_user, today.ToString()));
            set
            {
                this._pill = value;
                RaisePropertiesChanged(nameof(pill));
            }
        }

        private string _str_pill;
        public string str_pill
        {
            get => Convert.ToString(pill) + " шт.";
            set
            {
                this._str_pill = value;
                RaisePropertiesChanged(nameof(str_pill));
            }
        }

        public ICommand add_pill => new DelegateCommand(Add_Pill);

        private void Add_Pill()
        {

            float up_pill = pill + (float)1;
            db.UpdatePill(id_user, today.ToString(), up_pill);
            pill = up_pill;
            str_pill = Convert.ToString(pill) + " шт.";

        }
        #endregion

        #region Дневной инсулин
        public ICommand add_insulin_day => new DelegateCommand(Add_Insulin_Day);

        private void Add_Insulin_Day()
        {
            AddInsulin win = new AddInsulin(this, 1);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
            float insulin_day_up = float.Parse(db_i.GetInsulinDay(id_user, today.ToString(), 1));
            str_insulin_day = Convert.ToString(insulin_day_up) + " ед.";
        }

        private float up_insulin_day;
        public float Up_Insulin_Day
        {
            get { return up_insulin_day; }
            set
            {
                this.up_insulin_day = value;
                RaisePropertiesChanged(nameof(Up_Insulin_Day));
            }
        }

        private float _insulin_day;
        public float insulin_day
        {
            get => float.Parse(db_i.GetInsulinDay(id_user, today.ToString(),1));
            set
            {
                this._insulin_day = value;
                RaisePropertiesChanged(nameof(insulin_day));
            }
        }

        private string _str_insulin_day;
        public string str_insulin_day
        {
            get => Convert.ToString(insulin_day) + " ед.";
            set
            {
                this._str_insulin_day = value;
                RaisePropertiesChanged(nameof(str_insulin_day));
            }
        }
        #endregion

        #region Ночной инсулин
        public ICommand add_insulin_night => new DelegateCommand(Add_Insulin_Night);

        private void Add_Insulin_Night()
        {
            AddInsulin win = new AddInsulin(this,2);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        private float up_insulin_night;
        public float Up_Insulin_Night
        {
            get { return up_insulin_night; }
            set
            {
                this.up_insulin_night = value;
                RaisePropertiesChanged(nameof(Up_Insulin_Night));
            }
        }
        private float _insulin_night;
        public float insulin_night
        {
            get => float.Parse(db_i.GetInsulinDay(id_user, today.ToString(), 2));
            set
            {
                this._insulin_night = value;
                RaisePropertiesChanged(nameof(insulin_night));
            }
        }

        private string _str_insulin_night;
        public string str_insulin_night
        {
            get => Convert.ToString(insulin_night) + " ед.";
            set
            {
                this._str_insulin_night = value;
                RaisePropertiesChanged(nameof(str_insulin_night));
            }
        }
#endregion

        #region Еда
        private ObservableCollection<Food> GetNameFood(int type_of_food)
        {
            ObservableCollection<Food> ItemsDB = db.GetNameFoodByIdType(id_user, today.ToString(), type_of_food);

            return ItemsDB;

        }

        public ICommand add_breakfast => new DelegateCommand(Add_Breakfast);

        private void Add_Breakfast()
        {

            Properties.Settings.Default.IdTypeOfFood = 1;
            Properties.Settings.Default.Save();
            AddFood win = new AddFood(this);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        public ICommand add_lunch => new DelegateCommand(Add_Lunch);

        private void Add_Lunch()
        {

            Properties.Settings.Default.IdTypeOfFood = 2;
            Properties.Settings.Default.Save();
            AddFood win = new AddFood(this);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        public ICommand add_dinner => new DelegateCommand(Add_Dinner);

        private void Add_Dinner()
        {

            Properties.Settings.Default.IdTypeOfFood = 3;
            Properties.Settings.Default.Save();
            AddFood win = new AddFood(this);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        public ICommand add_snack => new DelegateCommand(Add_Snack);

        private void Add_Snack()
        {

            Properties.Settings.Default.IdTypeOfFood = 4;
            Properties.Settings.Default.Save();
            AddFood win = new AddFood(this);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }
        #endregion
        //private async void StartNotifyTimer()
        //{
        //    if (_NotifyIsEnabled)
        //    {

        //    }
        //}
    }
}

