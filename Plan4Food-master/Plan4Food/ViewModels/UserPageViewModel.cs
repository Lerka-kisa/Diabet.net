using DevExpress.Mvvm;
using Plan4Food.DB;
using Plan4Food.Models;
using Plan4Food.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Plan4Food.ViewModels
{
   public class UserPageViewModel : ViewModelBase
    {
        
        DataBaseUser db_user = new DataBaseUser();
        Users user;
        

        public UserPageViewModel()
        {
            user = db_user.GetUserInfo(Properties.Settings.Default.IdUser);
            LastName = user.LastName;
            FirstName = user.FirstName;
            Weight = user.Weight;
            Height = user.Height;
            Activity = user.Activity;
            Age = user.Age;
            Purpose_of_Use = user.Purpose_of_Use;
            Gender = user.Gender;
            D_Cal = user.Daily_Calories;
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Height { get; set; }
        public string Activity { get; set; }
        public string Gender { get; set; }

        private string weight;
        public string Weight
        {
            get { return weight; }
            set
            {
                this.weight = value;
                RaisePropertiesChanged(nameof(Weight));

            }
        }

        private short d_cal;
        public short D_Cal
        {
            get { return d_cal; }
            set
            {
                this.d_cal = value;
                RaisePropertiesChanged(nameof(D_Cal));

            }
        }



        private short age;
        public short Age
        {
            get { return age; }
            set
            {
                this.age = value;
                RaisePropertiesChanged(nameof(Age));

            }
        }

        private string purpose_of_use;
        public string Purpose_of_Use
        {
            get { return purpose_of_use; }
            set
            {
                this.purpose_of_use = value;
                RaisePropertiesChanged(nameof(Purpose_of_Use));

            }
        }

        public ICommand update_age => new DelegateCommand(Update_Age);

        private void Update_Age()
        {
            UpdateAge _win = new UpdateAge(this);
            _win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _win.Show();
           
        }

        public ICommand update_mass => new DelegateCommand(Update_Mass);

        private void Update_Mass()
        {
            UpdateMass _win = new UpdateMass(this);
            _win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _win.Show();

        }

        public ICommand update_purpose => new DelegateCommand(Update_Purpose);

        private void Update_Purpose()
        {
            UpdatePurpose _win = new UpdatePurpose(this);
            _win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _win.Show();

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
