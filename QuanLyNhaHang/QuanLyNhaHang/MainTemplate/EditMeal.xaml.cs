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
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.MainTemplate
{
    /// <summary>
    /// Interaction logic for EditMeal.xaml
    /// </summary>
    public partial class EditMeal : Window
    {
        private string FoodName;


        public EditMeal(string foodName)
        {
            InitializeComponent();
            LoadCategory();
            this.FoodName = foodName;

            int idd = FoodDAO.Instance.GetIDFoodByName(FoodName);
            FoodDTO food = FoodDAO.Instance.GetFoodById(idd);

            txtNameMeal.Text = food.Name;
            txtPriceMeal.Text = food.Price.ToString();
            //cmbCategory.SelectedItem = CategoryDAO.Instance.GetCategoryByID(food.CategoryID);
            
    
        }
        private event EventHandler editMeal;
        public event EventHandler editmeal
        {
            add { editMeal += value; }
            remove { editMeal -= value; }
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            int id = FoodDAO.Instance.GetIDFoodByName(FoodName);
            
            //MessageBox.Show(FoodName);
            //MessageBox.Show(id.ToString());
            string name = txtNameMeal.Text;
            int categoryID = (cmbCategory.SelectedItem as CategoryDTO).Id;
            string category = cmbCategory.Text;
            float price = float.Parse(txtPriceMeal.Text);
            
            //switch (category)
            //{
            //    case "Hải sản":
            //        categoryID = 1;
            //        break;
            //    case "Lâm sản":
            //        categoryID = 3;
            //        break;
            //    case "Nông sản":
            //        categoryID = 2;
            //        break;
            //    case "Nước":
            //        categoryID = 4;
            //        break;
            //    default:
            //        break;
            //}


            if (FoodDAO.Instance.EditMeal(id,name, categoryID, price))
            {
                MessageBox.Show("Successfully");
                if (editMeal != null)
                    editMeal(this, new EventArgs());
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void LoadCategory()
        {
            List<CategoryDTO> listCategory = CategoryDAO.Instance.GetListCategory();
            cmbCategory.ItemsSource = listCategory;
            cmbCategory.DisplayMemberPath = "Name";
        }
    }
}
