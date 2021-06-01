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



        #region events
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string name = txtNameMeal.Text;
            string category = cmbCategory.SelectedItem.ToString();
            int categoryID = CategoryDAO.Instance.GetIDCategoryByName(category);
            float price = float.Parse(txtPriceMeal.Text);

            if (FoodDAO.Instance.AddMeal(name, categoryID, price))
            {
                MessageBox.Show("Thành công");
                if (addMeal != null)
                    addMeal(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditMealEvent_Click(object sender, RoutedEventArgs e)
        {
            //Fix: get IDfood by name, idCategory first then edit 
            int id = 1;

            string name = txtNameMeal.Text;
            int categoryID = 0;
            string category = cmbCategory.SelectedItem.ToString();
            float price = float.Parse(txtPriceMeal.Text);


            if (FoodDAO.Instance.EditMeal(id, name, categoryID, price))
            {
                MessageBox.Show("Thành công");
                if (editMeal != null)
                    editMeal(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        private void DeleteMealEvent_Click(object sender, RoutedEventArgs e)
        {
            //Fix: get IDfood by name, idCategory first then delete 
            int id = 1;

            if (FoodDAO.Instance.DeleteMeal(id))
            {
                MessageBox.Show("Thành công");
                if (deleteMeal != null)
                    deleteMeal(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        private event EventHandler addMeal;
        public event EventHandler AddMeal
        {
            add { addMeal += value; }
            remove { addMeal -= value; }
        }

        private event EventHandler editMeal;
        public event EventHandler EditMeal
        {
            add { editMeal += value; }
            remove { editMeal -= value; }
        }

        private event EventHandler deleteMeal;
        public event EventHandler DeleteMeal
        {
            add { DeleteMeal += value; }
            remove { DeleteMeal -= value; }
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
