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
    /// Interaction logic for ChangeMealStatus.xaml
    /// </summary>
    public partial class ChangeMealStatus : Window
    {
        public ChangeMealStatus()
        {
            InitializeComponent();
            LoadCbTable();
            LoadMealStatus();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadCbTable()
        {
            List<TableDTO> tableList = TableDAO.Instance.GetTableList();
            cbTableChef.ItemsSource = tableList;
            cbTableChef.DisplayMemberPath = "Name";
        }

        private void LoadMealStatus()
        {
            List<MealStatusDTO> listMealStatus = MealStatusDAO.Instance.GetListMealStatuses();

            spMealStatusChef.Children.Clear();

            foreach (MealStatusDTO item in listMealStatus)
            {
                ChangeMealStatusCard card = new ChangeMealStatusCard();
                card.cbStatus.Tag = item;
                card.SetText(item.Category,item.Foodname, item.Count, item.Description, item.Status); 
                card.cbStatus.SelectionChanged += CbStatus_SelectionChanged;
                spMealStatusChef.Children.Add(card);
            }
        }
        private void cbTableChef_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TableDTO table = cbTableChef.SelectedItem as TableDTO;
            List<MealStatusDTO> listMealStatus = MealStatusDAO.Instance.GetListMealStatusesByTable(table.ID);

            spMealStatusChef.Children.Clear();

            foreach (MealStatusDTO item in listMealStatus)
            {
                ChangeMealStatusCard card = new ChangeMealStatusCard();
                card.cbStatus.Tag = item;
                card.SetText(item.Category, item.Foodname, item.Count, item.Description, item.Status);
                card.cbStatus.SelectionChanged += CbStatus_SelectionChanged;
                spMealStatusChef.Children.Add(card);
            }
        }

        private void CbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int idBillInfo = ((sender as ComboBox).Tag as MealStatusDTO).IdBillInfo;
            int status = (sender as ComboBox).SelectedIndex;
            MealStatusDAO.Instance.UpdateStatus(idBillInfo,status);
        }
    }
}
