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
using LiveCharts;
using LiveCharts.Wpf;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;
using QuanLyNhaHang.MainTemplate;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Interaction logic for ManagerForm.xaml
    /// </summary>
    public partial class ManagerForm : Window
    {
        public ManagerForm(int id)
        {
            InitializeComponent();

            tblName.Text = StaffDAO.Instance.GetNameById(id);
            SetReportPage();
        }

        #region Method
        #region Reset
        private void ResetReportManager()
        {
            GridAssistant.Children.Clear();
        }

        private void ResetManagerFieldHolder()
        {
            ManagerFieldHolder.Children.Clear();
        }

        private void ModifyCategory_Modify(object sender, EventArgs e)
        {
            SetCategoryPage();
        }
        #endregion

        #region Set
        private void SetGridAssistantToDefault()
        {
            ResetReportManager();
        }
        private void SetGridPrincipalToDefault()
        {
            ResetManagerFieldHolder();
        }
        private void SetGridPrincipal()
        {
            DisableGridAssistant();
            EnableGridPrincipal();

            SearchBoxContainer.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Visible;
        }
        private void SetGridAssistant()
        {
            DisableGridPrincipal();
            EnableGridAssistant();
        }
        private void SetReportPage()
        {
            SetGridAssistantToDefault();
            SetGridAssistant();
            IncludeReportManager();
        }
        private void SetStaffPage()
        {
            SetGridPrincipalToDefault();
            SetGridPrincipal();
            IncludeStaffManagerTable();
            IncludeStaffList();
        }
        private void SetMealPage()
        {
            SetGridPrincipalToDefault();
            SetGridPrincipal();
            IncludeMealManagerTable();
            IncludeFoodList();
        }
        private void SetCategoryPage()
        {
            SetGridPrincipalToDefault();
            SetGridPrincipal();
            IncludeCategoryTable();
            IncludeCategoryList();
        }
        private void SetTableManagerPage()
        {
            SetGridPrincipalToDefault();
            SetGridPrincipal();
            IncludeTableManager();
            IncludeTableList();
            SearchBoxContainer.Visibility = Visibility.Hidden;
        }
        private void SetAccountManagerPage()
        {
            SetGridPrincipalToDefault();
            SetGridPrincipal();
            IncludeAccountManager();
            IncludeAccountList();
            AddButton.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Include
        #region Report
        private void IncludeReportManager()
        {
            GridAssistant.Children.Add(new ReportManager());
        }
        #endregion

        #region Category
        private void IncludeCategoryList()
        {
            ListHolder.Children.Clear();
            List<CategoryDTO> categoryList = CategoryDAO.Instance.GetListCategory();
            foreach (CategoryDTO category in categoryList)
            {
                CategoryCard categoryCard = new CategoryCard();
                categoryCard.SetText(category.Id, category.Name);
                ListHolder.Children.Add(categoryCard);
            }
        }
        private void IncludeCategoryListByName(string name)
        {
            ListHolder.Children.Clear();
            List<CategoryDTO> categoryList = CategoryDAO.Instance.GetListCategoryByName(name);

            foreach (CategoryDTO category in categoryList)
            {
                CategoryCard categoryCard = new CategoryCard();
                categoryCard.SetText(category.Id, category.Name);
                ListHolder.Children.Add(categoryCard);
            }
        }
        private void IncludeCategoryListAscending(string name)
        {
            ListHolder.Children.Clear();
            List<CategoryDTO> categoryList = CategoryDAO.Instance.GetListCategoryByNameAscending(name);

            foreach (CategoryDTO category in categoryList)
            {
                CategoryCard categoryCard = new CategoryCard();
                categoryCard.SetText(category.Id, category.Name);
                ListHolder.Children.Add(categoryCard);
            }
        }
        private void IncludeCategoryListDescending(string name)
        {
            ListHolder.Children.Clear();
            List<CategoryDTO> categoryList = CategoryDAO.Instance.GetListCategoryByNameDescending(name);

            foreach (CategoryDTO category in categoryList)
            {
                CategoryCard categoryCard = new CategoryCard();
                categoryCard.SetText(category.Id, category.Name);
                ListHolder.Children.Add(categoryCard);
            }
        }
        private void IncludeCategoryTable()
        {
            ManagerFieldHolder.Children.Add(new CategoryManager(CategoryNameSort));
        }
        #endregion

        #region Staff
        private void IncludeStaffManagerTable()
        {
            StaffManager staffManager = new StaffManager();
            ManagerFieldHolder.Children.Add(staffManager);
            sortStaffNameClickCount = 0;
            sortStaffSalaryClickCount = 0;
            sortStaffPositionClickCount = 0;
            staffManager.btnSortName.Click += BtnSortName_Click;
            staffManager.btnSortSalary.Click += BtnSortSalary_Click;
            staffManager.btnSortPosition.Click += BtnSortPosition_Click;
        }
        private void IncludeStaffList()
        {
            ListHolder.Children.Clear();
            List<StaffDTO> staffList = StaffDAO.Instance.GetListStaff();
            foreach (StaffDTO staff in staffList)
            {
                StaffCard card = new StaffCard();
                card.SetText(staff.Name,staff.Salary,staff.Position);
                card.editButton.Tag = staff;
                card.deleteButton.Tag = staff;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeStaffListByName(string name)
        {
            ListHolder.Children.Clear();
            List<StaffDTO> staffList = StaffDAO.Instance.GetListStaffByName(name);

            foreach (StaffDTO staff in staffList)
            {
                StaffCard card = new StaffCard();
                card.SetText(staff.Name, staff.Salary, staff.Position);
                card.editButton.Tag = staff;
                card.deleteButton.Tag = staff;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeStaffListByNameAsc(string name)
        {
            ListHolder.Children.Clear();
            List<StaffDTO> staffList = StaffDAO.Instance.GetListStaffByNameAscending(name);

            foreach (StaffDTO staff in staffList)
            {
                StaffCard card = new StaffCard();
                card.SetText(staff.Name, staff.Salary, staff.Position);
                card.editButton.Tag = staff;
                card.deleteButton.Tag = staff;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeStaffListByNameDesc(string name)
        {
            ListHolder.Children.Clear();
            List<StaffDTO> staffList = StaffDAO.Instance.GetListStaffByNameDescending(name);

            foreach (StaffDTO staff in staffList)
            {
                StaffCard card = new StaffCard();
                card.SetText(staff.Name, staff.Salary, staff.Position);
                card.editButton.Tag = staff;
                card.deleteButton.Tag = staff;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeStaffListBySalaryAsc(string name)
        {
            ListHolder.Children.Clear();
            List<StaffDTO> staffList = StaffDAO.Instance.GetListStaffBySalaryAscending(name);

            foreach (StaffDTO staff in staffList)
            {
                StaffCard card = new StaffCard();
                card.SetText(staff.Name, staff.Salary, staff.Position);
                card.editButton.Tag = staff;
                card.deleteButton.Tag = staff;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeStaffListBySalaryDesc(string name)
        {
            ListHolder.Children.Clear();
            List<StaffDTO> staffList = StaffDAO.Instance.GetListStaffBySalaryDescending(name);

            foreach (StaffDTO staff in staffList)
            {
                StaffCard card = new StaffCard();
                card.SetText(staff.Name, staff.Salary, staff.Position);
                card.editButton.Tag = staff;
                card.deleteButton.Tag = staff;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeStaffListByPositionAsc(string name)
        {
            ListHolder.Children.Clear();
            List<StaffDTO> staffList = StaffDAO.Instance.GetListStaffByPositionAscending(name);

            foreach (StaffDTO staff in staffList)
            {
                StaffCard card = new StaffCard();
                card.SetText(staff.Name, staff.Salary, staff.Position);
                card.editButton.Tag = staff;
                card.deleteButton.Tag = staff;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeStaffListByPositionDesc(string name)
        {
            ListHolder.Children.Clear();
            List<StaffDTO> staffList = StaffDAO.Instance.GetListStaffByPositionDescending(name);

            foreach (StaffDTO staff in staffList)
            {
                StaffCard card = new StaffCard();
                card.SetText(staff.Name, staff.Salary, staff.Position);
                card.editButton.Tag = staff;
                card.deleteButton.Tag = staff;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        #endregion

        #region Meal
        private void IncludeMealManagerTable()
        {
            ManagerFieldHolder.Children.Add(new MealManager());
            MealManager mealManager = new MealManager();
            ManagerFieldHolder.Children.Add(mealManager);
            sortStaffNameClickCount = 0;
            sortStaffSalaryClickCount = 0;
            sortStaffPositionClickCount = 0;
            mealManager.btnSortName.Click += BtnSortMealName_Click;
            mealManager.btnSortCategory.Click += BtnSortMealCategory_Click;
            mealManager.btnSortPrice.Click += BtnSortMealPrice_Click;
        }
        private void IncludeFoodList()
        {
            ListHolder.Children.Clear();
            List<FoodDTO> foodList = FoodDAO.Instance.GetListFood();
            foreach (FoodDTO food in foodList)
            {
                string category = CategoryDAO.Instance.GetCategoryByID(food.CategoryID);
                int quantity = FoodDAO.Instance.GetOrderQuantityByID(food.Id);

                MealCard meal = new MealCard();
                meal.SetText(food.Name, category, food.Price, quantity);
                ListHolder.Children.Add(meal);
            }
        }
        private void IncludeFoodListByName(string name)
        {
            ListHolder.Children.Clear();
            List<FoodDTO> foodlist = FoodDAO.Instance.SearchFoodByName(name);

            foreach (FoodDTO food in foodlist)
            {
                string category = CategoryDAO.Instance.GetCategoryByID(food.CategoryID);
                int quantity = FoodDAO.Instance.GetOrderQuantityByID(food.Id);
                MealCard card = new MealCard();
                card.SetText(food.Name, category, food.Price, quantity);
                card.editButton.Tag = food;
                card.deleteButton.Tag = food;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeFoodListByNameAsc(string name)
        {
            ListHolder.Children.Clear();
            List<FoodDTO> foodlist = FoodDAO.Instance.GetListFoodByNameAscending(name);

            foreach (FoodDTO food in foodlist)
            {
                string category = CategoryDAO.Instance.GetCategoryByID(food.CategoryID);
                int quantity = FoodDAO.Instance.GetOrderQuantityByID(food.Id);
                MealCard card = new MealCard();
                card.SetText(food.Name, category, food.Price, quantity);
                card.editButton.Tag = food;
                card.deleteButton.Tag = food;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeFoodListByNameDesc(string name)
        {
            ListHolder.Children.Clear();
            List<FoodDTO> foodlist = FoodDAO.Instance.GetListFoodByNameDescending(name);

            foreach (FoodDTO food in foodlist)
            {
                string category = CategoryDAO.Instance.GetCategoryByID(food.CategoryID);
                int quantity = FoodDAO.Instance.GetOrderQuantityByID(food.Id);
                MealCard card = new MealCard();
                card.SetText(food.Name, category, food.Price, quantity);
                card.editButton.Tag = food;
                card.deleteButton.Tag = food;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeFoodListByCategoryAsc(string name)
        {
            ListHolder.Children.Clear();
            List<FoodDTO> foodlist = FoodDAO.Instance.GetListFoodByidCategoryAscending(name);

            foreach (FoodDTO food in foodlist)
            {
                string category = CategoryDAO.Instance.GetCategoryByID(food.CategoryID);
                int quantity = FoodDAO.Instance.GetOrderQuantityByID(food.Id);
                MealCard card = new MealCard();
                card.SetText(food.Name, category, food.Price, quantity);
                card.editButton.Tag = food;
                card.deleteButton.Tag = food;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeFoodListByCategoryDesc(string name)
        {
            ListHolder.Children.Clear();
            List<FoodDTO> foodlist = FoodDAO.Instance.GetListFoodByidCategoryDescending(name);

            foreach (FoodDTO food in foodlist)
            {
                string category = CategoryDAO.Instance.GetCategoryByID(food.CategoryID);
                int quantity = FoodDAO.Instance.GetOrderQuantityByID(food.Id);
                MealCard card = new MealCard();
                card.SetText(food.Name, category, food.Price, quantity);
                card.editButton.Tag = food;
                card.deleteButton.Tag = food;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeFoodListByPriceAsc(string name)
        {
            ListHolder.Children.Clear();
            List<FoodDTO> foodlist = FoodDAO.Instance.GetListFoodByPriceAscending(name);

            foreach (FoodDTO food in foodlist)
            {
                string category = CategoryDAO.Instance.GetCategoryByID(food.CategoryID);
                int quantity = FoodDAO.Instance.GetOrderQuantityByID(food.Id);
                MealCard card = new MealCard();
                card.SetText(food.Name, category, food.Price, quantity);
                card.editButton.Tag = food;
                card.deleteButton.Tag = food;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        private void IncludeFoodListByPriceDesc(string name)
        {
            ListHolder.Children.Clear();
            List<FoodDTO> foodlist = FoodDAO.Instance.GetListFoodByPriceDescending(name);

            foreach (FoodDTO food in foodlist)
            {
                string category = CategoryDAO.Instance.GetCategoryByID(food.CategoryID);
                int quantity = FoodDAO.Instance.GetOrderQuantityByID(food.Id);
                MealCard card = new MealCard();
                card.SetText(food.Name, category, food.Price, quantity);
                card.editButton.Tag = food;
                card.deleteButton.Tag = food;

                card.editButton.Click += EditButton_Click;
                card.deleteButton.Click += DeleteButton_Click;

                ListHolder.Children.Add(card);
            }
        }
        #endregion

        #region Account
        private void IncludeAccountManager()
        {
            ManagerFieldHolder.Children.Add(new AccountManager(Account_UserNameSort,Account_OwnerSort,Account_PositionSort));
        }
        private void IncludeAccountList()
        {
            ListHolder.Children.Clear();
            List<AccountDTO> accountList = AccountDAO.Instance.GetListAccount();

            foreach (AccountDTO item in accountList)
            {
                StaffDTO staff = StaffDAO.Instance.GetStaffById(item.IDStaff);
                AccountCard acc = new AccountCard();
                acc.SetText(item.UserName, staff.Name, staff.Position);
                acc.DeleteAccount += Acc_DeleteAccount;
                ListHolder.Children.Add(acc);
            }
        }
        private void IncludeAccountListByUserName(string username)
        {
            ListHolder.Children.Clear();
            List<AccountDTO> accountList = AccountDAO.Instance.GetListAccountByUserName(username);

            foreach (AccountDTO item in accountList)
            {
                StaffDTO staff = StaffDAO.Instance.GetStaffById(item.IDStaff);
                AccountCard acc = new AccountCard();
                acc.SetText(item.UserName, staff.Name, staff.Position);
                acc.DeleteAccount += Acc_DeleteAccount;
                ListHolder.Children.Add(acc);
            }
        }
        private void IncludeAccount_PositionListAscending(string text)
        {
            ListHolder.Children.Clear();
            List<AccountDTO> accounts = AccountDAO.Instance.GetAccount_PositionListAscending(text);
            foreach (AccountDTO item in accounts)
            {
                StaffDTO staff = StaffDAO.Instance.GetStaffById(item.IDStaff);
                AccountCard acc = new AccountCard();
                acc.SetText(item.UserName, staff.Name, staff.Position);
                acc.DeleteAccount += Acc_DeleteAccount;
                ListHolder.Children.Add(acc);
            }
        }
        private void IncludeAccount_PositionListDescending(string text)
        {
            ListHolder.Children.Clear();
            List<AccountDTO> accounts = AccountDAO.Instance.GetAccount_PositionListDescending(text);
            foreach (AccountDTO item in accounts)
            {
                StaffDTO staff = StaffDAO.Instance.GetStaffById(item.IDStaff);
                AccountCard acc = new AccountCard();
                acc.SetText(item.UserName, staff.Name, staff.Position);
                acc.DeleteAccount += Acc_DeleteAccount;
                ListHolder.Children.Add(acc);
            }
        }
        private void IncludeAccount_UsernameListAscending(string text)
        {
            ListHolder.Children.Clear();
            List<AccountDTO> accounts = AccountDAO.Instance.GetAccount_UsernameListAscending(text);
            foreach (AccountDTO item in accounts)
            {
                StaffDTO staff = StaffDAO.Instance.GetStaffById(item.IDStaff);
                AccountCard acc = new AccountCard();
                acc.SetText(item.UserName, staff.Name, staff.Position);
                acc.DeleteAccount += Acc_DeleteAccount;
                ListHolder.Children.Add(acc);
            }
        }
        private void IncludeAccount_UsernameListDescending(string text)
        {
            ListHolder.Children.Clear();
            List<AccountDTO> accounts = AccountDAO.Instance.GetAccount_UsernameListDescending(text);
            foreach (AccountDTO item in accounts)
            {
                StaffDTO staff = StaffDAO.Instance.GetStaffById(item.IDStaff);
                AccountCard acc = new AccountCard();
                acc.SetText(item.UserName, staff.Name, staff.Position);
                acc.DeleteAccount += Acc_DeleteAccount;
                ListHolder.Children.Add(acc);
            }
        }
        private void IncludeAccount_OwnerListAscending(string text)
        {
            ListHolder.Children.Clear();
            List<AccountDTO> accounts = AccountDAO.Instance.GetAccount_OwnerListAscending(text);
            foreach (AccountDTO item in accounts)
            {
                StaffDTO staff = StaffDAO.Instance.GetStaffById(item.IDStaff);
                AccountCard acc = new AccountCard();
                acc.SetText(item.UserName, staff.Name, staff.Position);
                acc.DeleteAccount += Acc_DeleteAccount;
                ListHolder.Children.Add(acc);
            }
        }
        private void IncludeAccount_OwnerListDescending(string text)
        {
            ListHolder.Children.Clear();
            List<AccountDTO> accounts = AccountDAO.Instance.GetAccount_OwnerListDescending(text);
            foreach (AccountDTO item in accounts)
            {
                StaffDTO staff = StaffDAO.Instance.GetStaffById(item.IDStaff);
                AccountCard acc = new AccountCard();
                acc.SetText(item.UserName, staff.Name, staff.Position);
                acc.DeleteAccount += Acc_DeleteAccount;
                ListHolder.Children.Add(acc);
            }
        }
        #endregion

        #region Table
        private void IncludeTableListAscending()
        {
            ListHolder.Children.Clear();
            List<TableDTO> tables = TableDAO.Instance.GetTableListAscending();
            foreach (TableDTO table in tables)
            {
                TableCard tableCard = new TableCard();
                tableCard.SetText(table.Name, table.Status);
                ListHolder.Children.Add(tableCard);
            }
        }
        private void IncludeTableListDescending()
        {
            ListHolder.Children.Clear();
            List<TableDTO> tables = TableDAO.Instance.GetTableListDescending();
            foreach (TableDTO table in tables)
            {
                TableCard tableCard = new TableCard();
                tableCard.SetText(table.Name, table.Status);
                ListHolder.Children.Add(tableCard);
            }
        }
        private void IncludeTableManager()
        {
            ManagerFieldHolder.Children.Add(new TableManager(TableSort));
        }
        private void IncludeTableList()
        {
            ListHolder.Children.Clear();
            List<TableDTO> tableList = TableDAO.Instance.GetTableList();
            foreach (TableDTO table in tableList)
            {
                TableCard tableCard = new TableCard();
                tableCard.SetText(table.Name, table.Status);
                ListHolder.Children.Add(tableCard);
            }
        }
        #endregion
        #endregion

        #region Sort
        private void TableSort(object sender, RoutedEventArgs eventArgs)
        {
            if (tableButtonClickCount % 2 == 0)
            {
                IncludeTableListDescending();
            }
            else
            {
                IncludeTableListAscending();
            }
            tableButtonClickCount++;
        }
        private void CategoryNameSort(object sender, RoutedEventArgs e)
        {
            //categoryButtonClickCount % 2 == 0 : sort descending
            //caegoryButtonClickCount % 2 != 0 : sort ascending
            if (categoryButtonClickCount % 2 == 0)
            {
                IncludeCategoryListDescending(searchTxb.Text);
            }
            else
            {
                IncludeCategoryListAscending(searchTxb.Text);
            }

            categoryButtonClickCount++;
        }

        #region Account
        private void Account_UserNameSort(object sender, RoutedEventArgs e)
        {
            //Account_UsernameButtonClickCount % 2 == 0 : sort descending
            //Account_UsernameButtonClickCount % 2 != 0 : sort ascending
            if (Account_UsernameButtonClickCount % 2 == 0)
            {
                IncludeAccount_UsernameListDescending(searchTxb.Text);
            }
            else
            {
                IncludeAccount_UsernameListAscending(searchTxb.Text);
            }

            Account_UsernameButtonClickCount++;
        }
        private void Account_OwnerSort(object sender, RoutedEventArgs e)
        {
            //Account_OwnerButtonClickCount % 2 == 0 : sort descending
            //Account_OwnerButtonClickCount % 2 != 0 : sort ascending
            if (Account_OwnerButtonClickCount % 2 == 0)
            {
                IncludeAccount_OwnerListDescending(searchTxb.Text);
            }
            else
            {
                IncludeAccount_OwnerListAscending(searchTxb.Text);
            }

            Account_OwnerButtonClickCount++;
        }
        private void Account_PositionSort(object sender, RoutedEventArgs e)
        {
            //Account_PositionButtonClickCount % 2 == 0 : sort descending
            //Account_PositionButtonClickCount % 2 != 0 : sort ascending
            if (Account_PositionButtonClickCount % 2 == 0)
            {

                IncludeAccount_PositionListDescending(searchTxb.Text);
            }
            else
            {
                IncludeAccount_PositionListAscending(searchTxb.Text);
            }

            Account_PositionButtonClickCount++;
        }
        #endregion
        #endregion

        private void DisableGridPrincipal()
        {
            GridPrincipal.Visibility = Visibility.Collapsed;
        }
        private void EnableGridPrincipal()
        {
            GridPrincipal.Visibility = Visibility.Visible;
        }
        private void DisableGridAssistant()
        {
            GridAssistant.Visibility = Visibility.Collapsed;

        }
        private void EnableGridAssistant()
        {
            GridAssistant.Visibility = Visibility.Visible;

        }

        private void MoveCursorMenu(int index)
        {
            //TrainsitioningContentSlide.OnApplyTemplate();
            //GridCursor.Margin = new Thickness(0, (150+(60 * index)), 0, 0);
        }
        #endregion

        #region Event
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);
            switch (index)
            {
                case 0:
                    SetReportPage();
                    break;
                case 1:
                    SetStaffPage();
                    break;
                case 2:
                    SetMealPage();
                    break;
                case 3:
                    SetCategoryPage();
                    break;
                case 4:
                    SetTableManagerPage();
                    break;
                case 5:
                    SetAccountManagerPage();
                    break;
            }
        }
        private void searchTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            if (!String.IsNullOrWhiteSpace(searchTxb.Text))
            {
                switch (index)
                {
                    case 1:
                        IncludeStaffListByName(searchTxb.Text);
                        break;
                    case 3:
                        IncludeCategoryListByName(searchTxb.Text);
                        break;
                    case 5:
                        IncludeAccountListByUserName(searchTxb.Text);
                        break;
                }
            }
            else
            {
                switch (index)
                {
                    case 1:
                        SetStaffPage();
                        break;
                    case 2:
                        SetMealPage();
                        break;
                    case 3:
                        SetCategoryPage();
                        break;
                    case 4:
                        SetTableManagerPage();
                        break;
                    case 5:
                        SetAccountManagerPage();
                        break;
                }
            }
        }
        private void ChangepasswordButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.ShowDialog();
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            switch (index)
            {
                case 1:
                    AddNewStaff addNewStaff = new AddNewStaff();
                    addNewStaff.ShowDialog();
                    break;
                case 2:
                    AddNewMeal addNewMeal = new AddNewMeal();
                    addNewMeal.ShowDialog();
                    break;
                case 3:
                    ModifyCategory modifyCategory = new ModifyCategory("Add", -1);
                    modifyCategory.Modify += ModifyCategory_Modify;
                    modifyCategory.ShowDialog();
                    break;
                case 4:
                    AddNewTable addNewTable = new AddNewTable();
                    addNewTable.ShowDialog();
                    break;
            }
        }
        private void BtnSortMealPrice_Click(object sender, RoutedEventArgs e)
        {
            if (sortMealPriceClickCount % 2 == 0)
            {
                IncludeFoodListByPriceAsc(searchTxb.Text);
            }
            else
            {
                IncludeFoodListByPriceDesc(searchTxb.Text);
            }

            sortMealPriceClickCount++;
        }
        private void BtnSortMealCategory_Click(object sender, RoutedEventArgs e)
        {
            if (sortMealCategoryClickCount % 2 == 0)
            {
                IncludeFoodListByCategoryAsc(searchTxb.Text);
            }
            else
            {
                IncludeFoodListByCategoryDesc(searchTxb.Text);
            }

            sortMealCategoryClickCount++;
        }
        private void BtnSortMealName_Click(object sender, RoutedEventArgs e)
        {
            if (sortMealNameClickCount % 2 == 0)
            {
                IncludeFoodListByNameAsc(searchTxb.Text);
            }
            else
            {
                IncludeFoodListByNameDesc(searchTxb.Text);
            }

            sortMealNameClickCount++;
        }
        private void BtnSortPosition_Click(object sender, RoutedEventArgs e)
        {
            if (sortStaffPositionClickCount % 2 == 0)
            {
                IncludeStaffListByPositionAsc(searchTxb.Text);
            }
            else
            {
                IncludeStaffListByPositionDesc(searchTxb.Text);
            }

            sortStaffPositionClickCount++;
        }
        private void BtnSortSalary_Click(object sender, RoutedEventArgs e)
        {
            if (sortStaffSalaryClickCount % 2 == 0)
            {
                IncludeStaffListBySalaryAsc(searchTxb.Text);
            }
            else
            {
                IncludeStaffListBySalaryDesc(searchTxb.Text);
            }

            sortStaffSalaryClickCount++;
        }
        private void BtnSortName_Click(object sender, RoutedEventArgs e)
        {
            if (sortStaffNameClickCount % 2 == 0)
            {
                IncludeStaffListByNameAsc(searchTxb.Text);
            }
            else
            {
                IncludeStaffListByNameDesc(searchTxb.Text);
            }

            sortStaffNameClickCount++;

        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            StaffDTO staff = (sender as Button).Tag as StaffDTO;
            EditStaff editStaff = new EditStaff(staff.Id);
            editStaff.ShowDialog();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Delete staff will delete account. Do you want to countinue?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning) != MessageBoxResult.OK)
            {
                return;
            }
            StaffDTO staff = (sender as Button).Tag as StaffDTO;
            AccountDAO.Instance.DeleteAccountByIdStaff(staff.Id);
            if (StaffDAO.Instance.DeleteStaff(staff.Id))
            {
                MessageBox.Show("Delete staff successful");
            }
            else
                MessageBox.Show("Delete staff fail");
            IncludeStaffList();
        }

        private void Acc_DeleteAccount(object sender, EventArgs e)
        {
            IncludeAccountList();
        }
        #endregion

        #region Field
        public Func<ChartPoint, string> PointLabel { get; set; }

        private int sortStaffNameClickCount = 0;

        private int sortStaffSalaryClickCount = 0;

        private int sortStaffPositionClickCount = 0;

        private int categoryButtonClickCount = 0;

        private int tableButtonClickCount = 0;

        private int Account_UsernameButtonClickCount = 0;

        private int Account_OwnerButtonClickCount = 0;

        private int Account_PositionButtonClickCount = 0;

        private int sortMealPriceClickCount = 0;

        private int sortMealNameClickCount = 0;

        private int sortMealCategoryClickCount = 0;
        #endregion
    }
}