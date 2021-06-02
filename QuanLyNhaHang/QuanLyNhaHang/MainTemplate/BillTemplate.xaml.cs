﻿using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;
namespace QuanLyNhaHang
{
    /// <summary>
    /// Interaction logic for BillTemplate.xaml
    /// </summary>
    public partial class BillTemplate : Window
    {
        public BillTemplate()
        {

            InitializeComponent();

            ShowBill(3);
        }

        private void ShowBill(int id)
        {

            List<MenuDTO> listBill = MenuDAO.Instance.GetListMenuByTable(id);
            gridBill.ItemsSource = listBill;

        }
        private void LoadBillByTable(int id)
        {

        }
        private void exportBillBtn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(billGrd, "invoice");

                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
        private void gridBill_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            //update column details when generating
            if (headername == "FoodName")
            {
                e.Column.Header = "Name";
                e.Column.DisplayIndex = 0;
            }
            else if (headername == "Count")
            {
                e.Column.Header = "Quantity";
                e.Column.DisplayIndex = 1;
            }
            else if (headername == "FoodName")
            {
                e.Column.Header = "Name";
                e.Column.DisplayIndex = 2;
            }
            else if (headername == "TotalPrice")
            {
                e.Column.Header = "Total Price";
                e.Column.DisplayIndex = 3;
            }
        }
    }
}
