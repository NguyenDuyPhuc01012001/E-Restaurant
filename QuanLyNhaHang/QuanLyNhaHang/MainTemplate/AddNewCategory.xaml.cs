﻿using QuanLyNhaHang.DAO;
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
    /// Interaction logic for AddNewCategory.xaml
    /// </summary>
    public partial class AddNewCategory : Window
    {
        public AddNewCategory()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string name = txtNameCategory.Text;
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Add new category succesfully");
                
            }
            else
            {
                MessageBox.Show("Add new category failed");
            }
        }


        
    }
}