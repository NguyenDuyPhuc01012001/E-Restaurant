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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Interaction logic for MenuManager.xaml
    /// </summary>
    public partial class MealManager : UserControl
    {
        public RoutedEventHandler eventSortByName;
        public RoutedEventHandler eventSortByPrice;
        public RoutedEventHandler eventSortByCategory;
           

        public MealManager()
        {
            InitializeComponent();

        }


        public MealManager(RoutedEventHandler eventSortByPrice, RoutedEventHandler eventSortByName, RoutedEventHandler eventSortByCategory)
        {
            this.eventSortByCategory = eventSortByCategory;
            this.eventSortByName = eventSortByName;
            this.eventSortByPrice = eventSortByPrice;
            InitializeComponent();
        }

        private void btnSortPrice_Click(object sender, RoutedEventArgs e)
        {
            ToggleIconStatus(priceSortIcon);
            if (eventSortByPrice != null)
            {
                eventSortByPrice(this, e);
            }
        }

        private void btnSortCategory_Click(object sender, RoutedEventArgs e)
        {
            ToggleIconStatus(categorySortIcon);
            if (eventSortByCategory != null)
            {
                eventSortByCategory(this, e);
            }
        }

        private void btnSortName_Click(object sender, RoutedEventArgs e)
        {
            ToggleIconStatus(nameSortIcon);
            if (eventSortByName != null)
            {
                eventSortByName(this, e);
            }
        }


        private void ToggleIconStatus(MaterialDesignThemes.Wpf.PackIcon btn)
        {
            if (btn.Kind == MaterialDesignThemes.Wpf.PackIconKind.ArrowBottom)
            {
                btn.Kind = MaterialDesignThemes.Wpf.PackIconKind.ArrowTop;
                btn.Foreground = Brushes.Green;
            }
            else
            {
                btn.Kind = MaterialDesignThemes.Wpf.PackIconKind.ArrowBottom;
                btn.Foreground = Brushes.Red;
            }
        }
    }
}
