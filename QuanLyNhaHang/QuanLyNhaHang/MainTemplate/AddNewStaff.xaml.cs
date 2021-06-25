﻿using QuanLyNhaHang.DAO;
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
    /// Interaction logic for AddNewStaff.xaml
    /// </summary>
    public partial class AddNewStaff : Window
    {
        public AddNewStaff()
        {
            InitializeComponent();
        }


        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtNameEmployee.Text;
                string UserName = txtUserNameEmployee.Text;
                string email = txtEmailEmployee.Text;
                string phone = txtPhoneEmployee.Text;
                string salary = txtSalaryEmployee.Text;
                int position = cmbPoition.SelectedIndex;
                int sex = Convert.ToInt32(rdoMale.IsChecked.Value);

                if (name == null || UserName == null || email == null || phone == null || salary == null)
                    MessageBox.Show("Please fill out the form first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                if (StaffDAO.Instance.CheckPhoneExist(phone) == 0 && StaffDAO.Instance.CheckEmailExist(email) == 0)
                {
                    if (AccountDAO.Instance.CheckUsernamelExist(UserName) == 0)
                    {
                        StaffDAO.Instance.InsertStaff(name, sex, email, phone, Int32.Parse(salary), position);

                        AccountDAO.Instance.InsertAccount(UserName, StaffDAO.Instance.GetMaxIdStaff());

                        MessageBox.Show("Add new staff successfuly");

                        this.Close();
                    }
                    else
                        MessageBox.Show("Username is exist");
                }
                else
                    MessageBox.Show("Phone or Email is exist");
            }
            catch (FormatException formatExcept)
            {
                MessageBox.Show("Please fill all field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception except)
            {
                MessageBox.Show(except.ToString(), "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
       

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
