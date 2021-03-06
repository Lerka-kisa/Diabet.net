using DevExpress.Mvvm;
using Diabet.net.DB;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Windows;
using System.Windows.Input;

namespace Diabet.net.View_Models
{
    class Update : ViewModelBase
    {
        DataBaseUser dbu = new DataBaseUser();
        DB_Main db = new DB_Main();
        DateTime today = DateTime.Today;
        DateTime todaytime = DateTime.Now;
        UserPageViewModel activUser;
        MainPageViewModel Obj;
        string ID_user = Properties.Settings.Default.IdUser;
        public Update(UserPageViewModel user)
        {
            activUser = user;
        }
        
        public Update(MainPageViewModel obj)
        {
            Obj = obj;
        }

        #region Weight
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
                        int now_day_cal = activUser.D_Cal;
                        int eat_cal = now_day_cal - remain_cal;

                        int new_cal = GetNewDayCal(activUser.Gender, activUser.Purpose_of_Use, this.GetActivity(activUser.Activity), activUser.Height, activUser.Weight, activUser.Age);
                        db.UpdateDailyCal(ID_user, today.ToString(), new_cal - eat_cal);
                        if (dbu.UpdateDailyCalUser(ID_user, new_cal))
                            Close();
                    }
                }
                catch (SystemException e)
                {
                    //MessageBox.Show(e.Message);
                    ErrorMes = Properties.Resources.errordata;
                }

            }
        }
        #endregion

        #region Age
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
                //MessageBox.Show(e.Message);
                ErrorMes = Properties.Resources.errordata;
            }

        }
        #endregion

        #region Purpose
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

        public ICommand updatepurpose => new DelegateCommand(Update_Purpose);
        private void Update_Purpose()
        {
            if (Up_Purpose == null)
            {
                ErrorMes = Properties.Resources.emptyfield;
            }
            else if (activUser.Purpose_of_Use == Up_Purpose)
            {
                ErrorMes = Properties.Resources.olddata;
            }
            else
            {
                try
                {
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
                        int now_day_cal = activUser.D_Cal;
                        int eat_cal = now_day_cal - remain_cal;

                        int new_cal = GetNewDayCal(activUser.Gender, new_purpose, this.GetActivity(activUser.Activity), activUser.Height, activUser.Weight, activUser.Age);
                        db.UpdateDailyCal(ID_user, today.ToString(), new_cal - eat_cal);
                        if (dbu.UpdateDailyCalUser(ID_user, new_cal))
                            Close();
                    }
                }
                catch (SystemException e)
                {
                    //MessageBox.Show(e.Message);
                    ErrorMes = Properties.Resources.errordata;
                }
            }
        }
        #endregion

        #region Blood_sugar
        private string up_sugar;
        public string Up_Sugar
        {
            get { return up_sugar; }
            set
            {
                this.up_sugar = value;
                RaisePropertiesChanged(nameof(Up_Sugar));

            }
        }

        public ICommand updatesugar => new DelegateCommand(Update_Sugar);
        private void Update_Sugar()
        {
            if (Up_Sugar == String.Empty || Up_Sugar == null)
                ErrorMes = Properties.Resources.emptyfield;
            else if (Obj.Blood_sugar == Up_Sugar)
                ErrorMes = Properties.Resources.olddata;
            else
            {

                try
                {
                    if (dbu.UpdateSugarUser(ID_user, Convert.ToDouble(Up_Sugar)))
                    {
                        Obj.Blood_sugar = dbu.GetSugar(ID_user);
                        float sugar = float.Parse(Obj.Blood_sugar);
                        if (Obj.NotifyIsEnabled)
                        {
                            if (sugar > 9.0)
                            {
                                new ToastContentBuilder()
                                .AddArgument("action", "viewConversation")
                                .AddArgument("conversationId", 9813)
                                .AddText("Уровень сахара слишком высокий!")
                                .AddText("Необходимо срочно сделать укол инсулина")
                                .Show();
                            }
                            if (sugar < 4.0)
                            {
                                new ToastContentBuilder()
                                .AddArgument("action", "viewConversation")
                                .AddArgument("conversationId", 9813)
                                .AddText("Уровень сахара слишком низкий!")
                                .AddText("Необходимо срочно съесть что-нибудь сладкое")
                                .Show();
                            }
                        }


                        Close();

                    }
                }
                catch (SystemException e)
                {
                    //MessageBox.Show(e.Message);
                    ErrorMes = Properties.Resources.errordata;
                }

            }
        }
        #endregion

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
