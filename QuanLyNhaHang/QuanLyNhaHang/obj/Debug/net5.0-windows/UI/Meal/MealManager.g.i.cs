﻿#pragma checksum "..\..\..\..\..\UI\Meal\MealManager.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CC0B870E57443B9C6FE566C8C686FB6143BE6764"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace QuanLyNhaHang {
    
    
    /// <summary>
    /// MealManager
    /// </summary>
    public partial class MealManager : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\..\UI\Meal\MealManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSortName;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\UI\Meal\MealManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon nameSortIcon;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\UI\Meal\MealManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSortCategory;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\UI\Meal\MealManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon categorySortIcon;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\UI\Meal\MealManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSortPrice;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\UI\Meal\MealManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon priceSortIcon;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\UI\Meal\MealManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSortQuantity;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\UI\Meal\MealManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon quantitySortIcon;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QuanLyNhaHang;V1.0.0.0;component/ui/meal/mealmanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UI\Meal\MealManager.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnSortName = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\..\UI\Meal\MealManager.xaml"
            this.btnSortName.Click += new System.Windows.RoutedEventHandler(this.btnSortName_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nameSortIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 3:
            this.btnSortCategory = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\..\UI\Meal\MealManager.xaml"
            this.btnSortCategory.Click += new System.Windows.RoutedEventHandler(this.btnSortCategory_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.categorySortIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 5:
            this.btnSortPrice = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\..\..\UI\Meal\MealManager.xaml"
            this.btnSortPrice.Click += new System.Windows.RoutedEventHandler(this.btnSortPrice_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.priceSortIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 7:
            this.btnSortQuantity = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\..\UI\Meal\MealManager.xaml"
            this.btnSortQuantity.Click += new System.Windows.RoutedEventHandler(this.btnSortQuantity_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.quantitySortIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

