using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Interaction logic for ChefForm.xaml
    /// </summary>
    public partial class ChefForm : Window
    {
        public ChefForm()
        {
            InitializeComponent();
        }
        public ChefForm(int id)
        {
            InitializeComponent();

            tblName.Text = StaffDAO.Instance.GetNameById(id);
            LoadMealStatus();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadMealStatus()
        {
            List<BillInfoDTO> listMealStatus = BillInfoDAO.Instance.GetListMenu();
            spMealStatusChef.Children.Clear();

            foreach (BillInfoDTO item in listMealStatus)
            {
                ChangeMealStatusCard card = new ChangeMealStatusCard();
                card.cbStatus.Tag = item;
                card.SetText(item.Category, item.FoodName, item.Count, item.Description, item.Status);
                card.cbStatus.SelectionChanged += CbStatus_SelectionChanged;
                spMealStatusChef.Children.Add(card);
            }
               
        }

        private void CbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int idBillInfo = ((sender as ComboBox).Tag as BillInfoDTO).Id;
            int status = (sender as ComboBox).SelectedIndex;
            BillInfoDAO.Instance.UpdateStatus(idBillInfo, status);
        }
    }
}
