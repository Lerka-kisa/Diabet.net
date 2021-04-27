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
    class Update : ViewModelBase
    {
        DataBaseUser dbu = new DataBaseUser();
        DB_Main db = new DB_Main();
        DateTime today = DateTime.Today;
        UserPageViewModel activUser;
        string ID_user = Properties.Settings.Default.IdUser;
        public Update(UserPageViewModel user)
        {
            activUser = user;
        }

        private string up_weight;
        public string Up_Weight
        {
            get { return up_weight; }
            set
            {
                this.up_weight = value;
                RaisePropertiesChanged(nameof(Up_Weight));

            }
        }

        private string up_age;
        public string Up_Age
        {
            get { return up_age; }
            set
            {
                this.up_age = value;
                RaisePropertiesChanged(nameof(Up_Age));

            }
        }

        private string up_purpose;
        public string Up_Purpose
        {
            get { return up_purpose; }
            set
            {
                this.up_purpose = value;
                RaisePropertiesChanged(nameof(Up_Purpose));

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

        public ICommand updateage => new DelegateCommand(UpdateAge);

        private void UpdateAge()
        {
            try
            {
                if (Up_Age == String.Empty || Up_Age == null)
                ErrorMes = Properties.Resources.emptyfield;
            else if (activUser.Age == Convert.ToInt16(Up_Age))
                ErrorMes = Properties.Resources.olddata;
            else
            {
                

                    if (dbu.UpdateAgeUser(ID_user, Convert.ToInt16(Up_Age)))
                    {
                        activUser.Age = Convert.ToInt16(Up_Age);
                        int remain_cal = db.GetDailyCal(ID_user, today.ToString());
                        int new_cal = 0;
                        int now_day_cal = activUser.D_Cal;
                        int eat_cal = now_day_cal - remain_cal;

                        new_cal = GetNewDayCal(activUser.Gender, activUser.Purpose_of_Use, this.GetActivity(activUser.Activity), activUser.Height, activUser.Weight, activUser.Age);
                        db.UpdateDailyCal(ID_user, today.ToString(), new_cal - eat_cal);
                        if (dbu.UpdateDailyCalUser(ID_user, new_cal))
                            Close();

                    }
               
            }
            }
            catch (SystemException e)
            {
                ErrorMes = Properties.Resources.errordata;
            }

        }

        public ICommand updatemass => new DelegateCommand(Update_Mass);

        private void Update_Mass()
        {
            if (Up_Weight == String.Empty || Up_Weight == null)
                ErrorMes = Properties.Resources.emptyfield;
            else if (activUser.Weight == Up_Weight)
                ErrorMes = Properties.Resources.olddata;
            else
            {

                try
                {
                    if (dbu.UpdateMassUser(ID_user, Convert.ToDouble(Up_Weight)))
                    {
                        activUser.Weight = Up_Weight;
                        int remain_cal = db.GetDailyCal(ID_user, today.ToString());
                        int new_cal = 0;
                        int now_day_cal = activUser.D_Cal;
                        int eat_cal = now_day_cal - remain_cal;

                        new_cal = GetNewDayCal(activUser.Gender, activUser.Purpose_of_Use, this.GetActivity(activUser.Activity), activUser.Height, activUser.Weight, activUser.Age);
                        db.UpdateDailyCal(ID_user, today.ToString(), new_cal - eat_cal);
                        if (dbu.UpdateDailyCalUser(ID_user, new_cal))
                            Close();

                    }
                }
                catch (SystemException e)
                {
                    ErrorMes = Properties.Resources.errordata;
                }
               
            }     
        }


        public ICommand updatepurpose => new DelegateCommand(Update_Purpose);

        private void Update_Purpose()
        {
            if(Up_Purpose == null)
            {
                ErrorMes = Properties.Resources.emptyfield;
            }
            else if(activUser.Purpose_of_Use == Up_Purpose)
            {
                ErrorMes = Properties.Resources.olddata;
            }
            else {
                activUser.Purpose_of_Use = Up_Purpose;
                string new_purpose = "";
                if (Up_Purpose == "Сбросить вес")
                    new_purpose = "1";
                else if (Up_Purpose == "Поддерживать вес")
                    new_purpose = "2";
                else
                    new_purpose = "3";

                if (dbu.UpdatePurposeUser(ID_user, new_purpose))
                {
                    int remain_cal = db.GetDailyCal(ID_user, today.ToString());
                    int new_cal = 0;
                    int now_day_cal = activUser.D_Cal;
                    int eat_cal = now_day_cal - remain_cal;

                    new_cal = GetNewDayCal(activUser.Gender, new_purpose, this.GetActivity(activUser.Activity), activUser.Height, activUser.Weight, activUser.Age);
                    db.UpdateDailyCal(ID_user, today.ToString(), new_cal - eat_cal);
                    if (dbu.UpdateDailyCalUser(ID_user, new_cal))
                        Close();

                }
            }
           

        }


        private int GetNewDayCal(string g, string pOu, double activity, string height, string weight, short age)
        {
            if (g == "Мужской")
            {
                if (pOu == "Сбросить вес")
                {
                    int result;
                    result = (int)((Convert.ToDouble(weight) * 10 + Convert.ToDouble(height) * 6.25 - Convert.ToDouble(age) * 5 + 5) * activity * 0.85);
                    return result;
                }
                else if (pOu == "Набрать вес")
                {
                    int result;
                    result = (int)((Convert.ToDouble(weight) * 10 + Convert.ToDouble(height) * 6.25 - Convert.ToDouble(age) * 5 + 5) * activity * 1.15);
                    return result;
                }
                else
                {
                    double act = System.Convert.ToDouble(activity);
                    int result;
                    result = (int)((Convert.ToDouble(weight) * 10 + Convert.ToDouble(height) * 6.25 - Convert.ToDouble(age) * 5 + 5) * activity);
                    return result;
                }

            }
            else
            {
                if (pOu == "Сбросить вес")
                {
                    int result;
                    result = (int)((Convert.ToDouble(weight) * 10 + Convert.ToDouble(height) * 6.25 - Convert.ToDouble(age) * 5 - 161) * activity * 0.85);
                    return result;
                }
                else if (pOu == "Набрать вес")
                {
                    int result;
                    result = (int)((Convert.ToDouble(weight) * 10 + Convert.ToDouble(height) * 6.25 - Convert.ToDouble(age) * 5 - 161) * activity * 1.25);
                    return result;
                }
                else
                {
                    int result;
                    result = (int)((Convert.ToDouble(weight) * 10 + Convert.ToDouble(height) * 6.25 - Convert.ToDouble(age) * 5 - 161) * activity);
                    return result;
                }
            }

         }

        public double GetActivity(string act)
        {
            if (act == "Мин. уровень физнагрузки (отсутсвие)")
                return 1.2;
            else if (act == "Тренировки 3 раза в неделю")
                return  1.38;
            else if (act == "Тренировки 5 раза в неделю")
                return 1.46;
            else if (act == "Тренеровки каждый день")
                return 1.64;
            else
                return 1.9;
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
