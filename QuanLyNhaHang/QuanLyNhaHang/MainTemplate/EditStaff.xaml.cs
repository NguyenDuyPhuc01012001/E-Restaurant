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

namespace QuanLyNhaHang.MainTemplate
{
    /// <summary>
    /// Interaction logic for EditStaff.xaml
    /// </summary>
    public partial class EditStaff : Window
    {
        public EditStaff()
        {
            InitializeComponent();
        }
        public EditStaff(int id)
        {
            InitializeComponent();
            StaffDTO staff = StaffDAO.Instance.GetStaffById(id);
            this.Tag = staff.Id;
            AccountDTO account = AccountDAO.Instance.GetAccountByIdUser(staff.Id);
            txtNameEmployee.Text = staff.Name;
            txtUserNameEmployee.Text = account.UserName;
            txtEmailEmployee.Text = staff.Email;
            txtPhoneEmployee.Text = staff.Phone;
            txtSalaryEmployee.Text = staff.Salary.ToString();
            cmbPoition.SelectedIndex = staff.Position;

            if (staff.Sex == 1)
                rdoMale.IsChecked = true;
            else
                rdoFemale.IsChecked = true;
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string name = txtNameEmployee.Text;
            string UserName = txtUserNameEmployee.Text;
            string email = txtEmailEmployee.Text;
            string phone = txtPhoneEmployee.Text;
            string salary = txtSalaryEmployee.Text;
            int position = cmbPoition.SelectedIndex;
            int sex = Convert.ToInt32(rdoMale.IsChecked.Value);

            if (name == null || UserName == null || email == null || phone == null || salary == null )
                MessageBox.Show("Please fill out the form first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            /*if ((StaffDAO.Instance.CheckPhoneExist(phone) == 0 || StaffDAO.Instance.CheckPhoneExist(phone) == idStaff) && (StaffDAO.Instance.CheckEmailExist(email) == 0||StaffDAO.Instance.CheckEmailExist(email) == idStaff))
            {
                *//*StaffDAO.Instance.InsertStaff(name, sex, email, phone,Int32.Parse(salary), position);

                AccountDAO.Instance.InsertAccount(UserName, StaffDAO.Instance.GetMaxIdStaff());*//*

                MessageBox.Show("Edit staff successfuly");
            }
            else
                MessageBox.Show("Phone or Email is exist");*/

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
