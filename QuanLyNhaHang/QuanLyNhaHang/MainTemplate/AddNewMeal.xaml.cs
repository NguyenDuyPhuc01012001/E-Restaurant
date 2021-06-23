﻿using System;
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
using Microsoft.Win32;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Interaction logic for AddNewMeal.xaml
    /// </summary>
    public partial class AddNewMeal : Window
    {
        public AddNewMeal()
        {
            InitializeComponent();
            LoadCategory();
        }

        List<FoodDTO> SearchFoodByName(string name)
        {
            List<FoodDTO> listFoodDTO = FoodDAO.Instance.SearchFoodByName(name);

            return listFoodDTO;
        }

        private void Search_Click(object sender, EventArgs e)
        {
           
        }

        #region events
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string name = txtNameMeal.Text;
            string category = cmbCategory.Text;
            //int categoryID = CategoryDAO.Instance.GetIDCategoryByName(category);
            float price = float.Parse(txtPriceMeal.Text);
            int categoryID = 1 ;
            switch (category)
            {
                case "Hải sản":
                    categoryID = 1;
                    break;
                case "Lâm sản":
                    categoryID = 3;
                    break;
                case "Nông sản":
                    categoryID = 2;
                    break;
                case "Nước":
                    categoryID = 4;
                    break;
                default:
                    break;
            }
          

            if (FoodDAO.Instance.AddMeal(name,categoryID, price))
            {
                MessageBox.Show("Add New Meal Successfully");
 
                if (addMeal != null)
                    addMeal(this, new EventArgs());
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Add New Meal Failed");
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private event EventHandler addMeal;
        public event EventHandler AddMeal
        {
            add { addMeal += value; }
            remove { addMeal -= value; }
        }






        #endregion

        #region Method
        void LoadCategory()
        {
            List<CategoryDTO> listCategory = CategoryDAO.Instance.GetListCategory();
            cmbCategory.ItemsSource = listCategory;
            cmbCategory.DisplayMemberPath = "Name";
        }

        #endregion
    }
}
