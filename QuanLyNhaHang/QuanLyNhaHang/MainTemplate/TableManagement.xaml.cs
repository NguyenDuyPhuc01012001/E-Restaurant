using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;
using QuanLyNhaHang.UI.Meal;
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
    /// Interaction logic for TableManagement.xaml
    /// </summary>
    public partial class TableManagement : Window
    {
        public TableManagement()
        {
            InitializeComponent();
            Load();
        }

        #region method
        private void Load()
        {
            LoadTable();
            LoadCategory();
            LoadFoodList();
            LoadCbTable();
        }
        private void LoadTable()
        {
            TableDAO.Instance.SetTableStatus();
            wpTable.Children.Clear();
            List<TableDTO> tableList = TableDAO.Instance.GetTableList();
            for (int i = 0; i < tableList.Count; i++)
            {
                TableDAO.Instance.SetTableStatus();
            }

            foreach (TableDTO item in tableList)
            {
                Table btn = new Table();

                btn.SetTest(item.Name, item.Status);
                btn.btnTable.Tag = item;

                btn.SetBackGround(item.Status);

                btn.btnTable.Click += BtnTable_Click;
                wpTable.Children.Add(btn);
            }
        }

       

        private void LoadFoodList()
        {
            wpFood.Children.Clear();

            List<FoodDTO> foodList = FoodDAO.Instance.GetListFood();
            foreach (FoodDTO food in foodList)
            {
                MealButton foodBTN = new MealButton();
                foodBTN.SetName(food.Name);
                foodBTN.btnMeal.Tag = food;
                foodBTN.btnMeal.Click += BtnMeal_Click;
                wpFood.Children.Add(foodBTN);
            }

        }

       

        void LoadCategory()
        {
            List<CategoryDTO> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.ItemsSource = listCategory;
            cbCategory.DisplayMemberPath = "Name";
        }
        private void LoadFoodListByCategory(int id)
        {
            wpFood.Children.Clear();

            List<FoodDTO> listFoodByCategory = FoodDAO.Instance.GetFoodByCategoryID(id);

            foreach (FoodDTO food in listFoodByCategory)
            {
                MealButton foodBTN = new MealButton();
                foodBTN.SetName(food.Name);
                foodBTN.btnMeal.Tag = food;
                foodBTN.btnMeal.Click += BtnMeal_Click;
                wpFood.Children.Add(foodBTN);
            }
        }
        private void LoadMealStatus(int tableID)
        {
            List<MealStatusDTO> listBillInfo = MealStatusDAO.Instance.GetListMealStatuses(tableID);

            spmealstatus.Children.Clear();

            foreach (MealStatusDTO item in listBillInfo)
            {
                MealStatusCard card = new MealStatusCard();
                card.Tag = item;
                card.SetText(item.Foodname, item.Count, item.Description, item.Status);
                spmealstatus.Children.Add(card);
            }
        }
        private void LoadCbTable()
        {
            List<TableDTO> tableList = TableDAO.Instance.GetTableList();
            ucCbTable.cbTable.ItemsSource = tableList;
            ucCbTable.cbTable.DisplayMemberPath = "Name";
        }
        private void LoadDiscount(int tableID)
        {
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(tableID);
            discount.discountTextBox.Text = BillDAO.Instance.GetDiscount(idBill).ToString();
        }
        private void LoadPrice(int tableID)
        {
            float price = 0;
            List<BillInfoDTO> listBill = BillInfoDAO.Instance.GetListMenuByTable(tableID);
            foreach (BillInfoDTO bill in listBill)
            {
                price += bill.TotalPrice;
            }

            Price.Text = price.ToString() + " VND";
        }
        #endregion

        #region event
        private void BtnTable_Click(object sender, RoutedEventArgs e)
        {
            int tableID = ((sender as Button).Tag as TableDTO).ID;
            spmealstatus.Tag = (sender as Button).Tag;

            LoadMealStatus(tableID);
            LoadDiscount(tableID);
            LoadPrice(tableID);

        }

        private void BtnMeal_Click(object sender, RoutedEventArgs e)
        {
            int mealID = ((sender as Button).Tag as FoodDTO).Id;
            wpFood.Tag = (sender as Button).Tag;
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            TableDTO table = spmealstatus.Tag as TableDTO;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.iD);
            int idFood = (wpFood.Tag as FoodDTO).Id;
            int count = Int16.Parse(txbQuantity.Text);
            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idFood, count);
                int idBillInfo = BillInfoDAO.Instance.GetBillInfo(BillDAO.Instance.GetMaxIDBill(), idFood);
                MealStatusDAO.Instance.InsertMealStatus(idBillInfo, addtionalNoteTextbox.Text);
            }
            else
            {
                int idBillInfo = BillInfoDAO.Instance.GetBillInfo(idBill, idFood);

                if (idBillInfo == -1)
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
                    idBillInfo = BillInfoDAO.Instance.GetBillInfo(idBill, idFood);
                    MealStatusDAO.Instance.InsertMealStatus(idBillInfo, addtionalNoteTextbox.Text);
                }
                else
                {
                    int countFood = BillInfoDAO.Instance.GetCount(idBillInfo) + count;
                    if (countFood > 0)
                    {
                        BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
                        MealStatusDAO.Instance.UpdateDes(idBillInfo, addtionalNoteTextbox.Text);
                    }
                    else
                    {
                        MealStatusDAO.Instance.DeleteMealStatusByBillInfo(idBillInfo);
                        BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
                    }
                }

            }
            LoadMealStatus(table.iD);
            LoadTable();

        }

        private void changeTableBtn_Click(object sender, RoutedEventArgs e)
        {
            TableDTO table = spmealstatus.Tag as TableDTO;
            int id1 = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);

            int id2 = (ucCbTable.cbTable.SelectedItem as TableDTO).ID;

            MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1}", table.Name, (ucCbTable.cbTable.SelectedItem as TableDTO).Name), "Notify");
            TableDAO.Instance.SwitchTable(table.iD, id2);
            LoadTable();
        }

        private void applyDiscountBtn_Click(object sender, RoutedEventArgs e)
        {
            TableDTO table = spmealstatus.Tag as TableDTO;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int dis;
            try
            {
                dis = Int16.Parse(discount.discountTextBox.Text);
            }
            catch
            {
                dis = 0;
            }
            BillDAO.Instance.UpdateDiscount(idBill, dis);
        }

        private void exportBillBtn_Click(object sender, RoutedEventArgs e)
        {
            TableDTO table = spmealstatus.Tag as TableDTO;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int dis;
            try
            {
                dis = Int16.Parse(discount.discountTextBox.Text);
            }
            catch
            {
                dis = 0;
            }


            if (idBill != -1)
            {
                MessageBox.Show("Do you want check out bill for " + table.Name, "Notify");
                BillTemplate bill = new BillTemplate(table.iD);
                bill.Show();
                BillDAO.Instance.CheckOut(idBill);
            }
            MealStatusDAO.Instance.DeleteMealStatusByTable(table.ID);
            spmealstatus.Children.Clear();
            LoadTable();
            Price.Text = "0 VND";
        }
        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            CategoryDTO selected = cb.SelectedItem as CategoryDTO;

            id = selected.Id;

            LoadFoodListByCategory(id);

        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion



    }
}
