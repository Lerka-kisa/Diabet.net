using DevExpress.Mvvm;
using Plan4Food.DB;
using Plan4Food.Models;
using Plan4Food.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Plan4Food.ViewModels
{
    class ApproveAdminViewModel : ViewModelBase
    {
        DB_Main db = new DB_Main();
        public ObservableCollection<Product> AllApproveProduct { get; set; }
        DB_NewFood dB_NewFood = new DB_NewFood();


        public ApproveAdminViewModel()
        {
            AllApproveProduct = new ObservableCollection<Product>();
            AllApproveProduct = dB_NewFood.GetAllApproveProduct();
          
        }

        private int index;
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                this.index = value;
                RaisePropertiesChanged(nameof(Index));
            }
        }

        public ICommand add_product => new DelegateCommand(Add_Product);

        private void Add_Product()
        {
            dB_NewFood.AddProduct(AllApproveProduct[Index].Name, AllApproveProduct[Index].Calorific.Replace("ккал", ""), AllApproveProduct[Index].Protein.Replace("г", ""), AllApproveProduct[Index].Fat.Replace("г", ""), AllApproveProduct[Index].Carbs.Replace("г", ""));
            dB_NewFood.DeleteFromApproveProduct(AllApproveProduct[Index].Name, AllApproveProduct[Index].Calorific.Replace("ккал", ""), AllApproveProduct[Index].Protein.Replace("г", ""), AllApproveProduct[Index].Fat.Replace("г", ""), AllApproveProduct[Index].Carbs.Replace("г", ""));
            AllApproveProduct.RemoveAt(Index);
        }

        public ICommand delete_product => new DelegateCommand(Delete_Product);

        private void Delete_Product()
        {
            dB_NewFood.DeleteFromApproveProduct(AllApproveProduct[Index].Name, AllApproveProduct[Index].Calorific.Replace("ккал",""), AllApproveProduct[Index].Protein.Replace("г",""), AllApproveProduct[Index].Fat.Replace("г", ""), AllApproveProduct[Index].Carbs.Replace("г", ""));
            AllApproveProduct.RemoveAt(Index);

        }

        private int MyToInt(string str)
        {
            int result = 0;


            return result;
        }
    }
}
