using DevExpress.Mvvm;
using Diabet.net.DB;
using Diabet.net.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Diabet.net.View_Models
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
            if (0 <= Index && Index < AllApproveProduct.Count)
            {
                if (dB_NewFood.ApprovalProduct(AllApproveProduct[Index].ID))
                {
                    dB_NewFood.DeleteFromApproveProduct(AllApproveProduct[Index].ID);
                    AllApproveProduct.RemoveAt(Index);
                }
                else ErrorMes = Properties.Resources.already_there;
            }
            else ErrorMes = Properties.Resources.emptytable;
        }

        public ICommand delete_product => new DelegateCommand(Delete_Product);
        private void Delete_Product()
        {
            if (0 <= Index && Index < AllApproveProduct.Count)
            {
                dB_NewFood.DeleteFromApproveProduct(AllApproveProduct[Index].ID);
                AllApproveProduct.RemoveAt(Index);
            }
            else ErrorMes = Properties.Resources.emptytable;
        }

        private int MyToInt(string str)
        {
            int result = 0;

            return result;
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
    }
}
