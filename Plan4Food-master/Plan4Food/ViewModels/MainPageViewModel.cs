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

namespace Plan4Food.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        DB_Main db = new DB_Main();
        DateTime today = DateTime.Today;
        //       public int daily_cal { get; set; }
        public ObservableCollection<Food> Name_food_breakfast { get; set; }
        public ObservableCollection<Food> Name_food_lunch { get; set; }
        public ObservableCollection<Food> Name_food_dinner { get; set; }
        public ObservableCollection<Food> Name_food_snack { get; set; }
        //  public int cal;

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
            // cal = db.GetDailyCal(id_user, today.ToString());
            //daily_cal = cal;

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
            get => Convert.ToString(water) + "л";
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
            str_water = Convert.ToString(water) + "л";

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
            Add_Food win = new Add_Food(this);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();

        }

        public ICommand add_lunch => new DelegateCommand(Add_Lunch);

        private void Add_Lunch()
        {

            Properties.Settings.Default.IdTypeOfFood = 2;
            Properties.Settings.Default.Save();
            Add_Food win = new Add_Food(this);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        public ICommand add_dinner => new DelegateCommand(Add_Dinner);

        private void Add_Dinner()
        {

            Properties.Settings.Default.IdTypeOfFood = 3;
            Properties.Settings.Default.Save();
            Add_Food win = new Add_Food(this);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }

        public ICommand add_snack => new DelegateCommand(Add_Snack);

        private void Add_Snack()
        {

            Properties.Settings.Default.IdTypeOfFood = 4;
            Properties.Settings.Default.Save();
            Add_Food win = new Add_Food(this);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
        }
        #endregion
    }
}

