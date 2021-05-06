using DevExpress.Mvvm;
using Plan4Food.DB;
using Plan4Food.Models;
using Plan4Food.Views;
using System;
using System.Collections.Generic;
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
    class RegistrViewModel : ViewModelBase
    {
        public RegistrViewModel()
        {

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
        
        private string _weight;
        public string weight
        {
            get { return _weight; }
            set
            {
                this._weight = value;
                RaisePropertiesChanged(nameof(weight));

            }
        }

        private string _height;
        public string height
        {
            get { return _height; }
            set
            {
                this._height = value;
                RaisePropertiesChanged(nameof(height));

            }
        }
        private int _daily_calories;
        public int daily_calories
        {
            get
            {
                if (gender =="М")
                {
                    if (purpose_of_use == "1" ) {
                        double act = System.Convert.ToDouble(activity);
                        int result;
                        result = (int)((Convert.ToDouble(weight) * 10 + Convert.ToDouble(height) * 6.25 - Convert.ToDouble(age) * 5 + 5) * act * 0.85);
                        return result;
                    }
                    else if (purpose_of_use =="2")
                    {
                        double act = System.Convert.ToDouble(activity);
                        int result;
                        result = (int)((Convert.ToDouble(weight) * 10 + Convert.ToDouble(height) * 6.25 - Convert.ToDouble(age) * 5 + 5) * act);
                        return result;
                    }
                    else 
                    {
                        double act = System.Convert.ToDouble(activity);
                        int result;
                        result = (int)((Convert.ToDouble(weight) * 10 + Convert.ToDouble(height) * 6.25 - Convert.ToDouble(age) * 5 + 5) * act * 1.15);
                        return result;
                    }

                }
                else
                {
                    if (purpose_of_use == "1")
                    {
                        double act = System.Convert.ToDouble(activity);
                        int result;
                        result = (int)((Convert.ToDouble(weight) * 10 + Convert.ToDouble(height) * 6.25 - Convert.ToDouble(age) * 5 - 161) * act * 0.85);
                        return result;
                    }
                    else if (purpose_of_use == "2")
                    {
                        double act = System.Convert.ToDouble(activity);
                        int result;
                        result = (int)((Convert.ToDouble(weight) * 10 + Convert.ToDouble(height) * 6.25 - Convert.ToDouble(age) * 5 - 161) * act);
                        return result;
                    }
                    else
                    {
                        double act = System.Convert.ToDouble(activity);
                        int result;
                        result = (int)((Convert.ToDouble(weight) * 10 + Convert.ToDouble(height) * 6.25 - Convert.ToDouble(age) * 5 - 161) * act * 1.25);
                        return result;
                    }
                }

            }
        }

        private string _activity;
        public string activity
        {
            get { return _activity; }
            set
            {
                if (value.Equals("мин. уровень физнагрузки (отсутсвие)"))
                    this._activity = "1,2";
                else if (value.Equals("тренировки 3 раза в неделю"))
                    this._activity = "1,38";
                else if (value.Equals("тренировки 5 раза в неделю"))
                    this._activity = "1,46";
                else if (value.Equals("тренеровки каждый день"))
                    this._activity = "1,64";
                else
                    this._activity = "1,9";
                RaisePropertiesChanged(nameof(activity));
            }
        }

        private string _age;
        public string age
        {
            get { return _age; }
            set
            { 
                this._age = value;
                RaisePropertiesChanged(nameof(purpose_of_use));

            }
        }

        private string _gender;
        public string gender
        {
            get { return _gender; }
            set
            {
                if (value.Equals("Мужчина"))
                    this._gender = "М";
                else if (value.Equals("Женщина"))
                    this._gender = "Ж";
                RaisePropertiesChanged(nameof(gender));

            }
        }

        private string _purpose_of_use;
        public string purpose_of_use
        {
            get { return _purpose_of_use; }
            set
            {
                if (value.Equals("Сбросить вес"))
                    this._purpose_of_use = "1";
                else if (value.Equals("Поддерживать вес"))
                    this._purpose_of_use = "2";
                else
                    this._purpose_of_use = "3";
                RaisePropertiesChanged(nameof(purpose_of_use));
            }
        }

        private string _login;
        public string login
        {
            get { return _login; }
            set
            {
                this._login = value;
                RaisePropertiesChanged(nameof(login));
            }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set
            {
                this._password = value;
                RaisePropertiesChanged(nameof(password));
            }
        }

        private string _firstname;
        public string firstname
        {
            get { return _firstname; }
            set
            {
                this._firstname = value;
                RaisePropertiesChanged(nameof(firstname));
            }
        }

        private string _lastname;
        public string lastname
        {
            get { return _lastname; }
            set
            {
                this._lastname = value;
                RaisePropertiesChanged(nameof(lastname));
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
        bool flag;
        bool canreg = true;

        public ICommand register => new DelegateCommand(RegisterCommand);
        public void RegisterCommand()
        {
            try
            {
                ErrorMes = "";
                flag = true;
                login += " ";
                int x1 = login.Length - 1;
                login = login.Substring(0, x1);
                bool fl = true;

                if (password.Length < 8)
                {
                    ErrorMes = Properties.Resources.charac;
                }
                if (password == String.Empty || password == null || lastname == String.Empty || lastname == null || gender == null || gender == String.Empty ||
                    purpose_of_use == String.Empty || purpose_of_use == null || age == null || age == String.Empty || height == null || height == String.Empty ||
                    activity == String.Empty || activity == null || firstname == null || firstname == String.Empty)
                {
                    fl = false;
                    ErrorMes = Properties.Resources.emptyfield;
                }

                bool IsDone = true;
                if (fl && canreg)
                {
                    DataBaseUser spam = new DataBaseUser();
                    string Pass = DB.DB.Hash(password).ToString();
                    IsDone = spam.AddUser(login, Pass, firstname, lastname, purpose_of_use, gender, age, height, weight, activity, daily_calories);
                    if (IsDone)
                    {
                        AuthView t = new AuthView();
                        t.Show();
                        Close();
                    }
                }

                if (!IsDone)
                {

                    ErrorMes = Properties.Resources.existserr;
                    login = "";
                }
                canreg = true;
                flag = false;
            }
            catch (SystemException)
            {
                ErrorMes = Properties.Resources.errordata;
            }
        }

        public ICommand back => new DelegateCommand(Back);

        public void Back()
        {
            AuthView t = new AuthView();
            t.Show();
            Close();
        }
    }
}
