﻿#pragma checksum "..\..\..\..\MainTemplate\ChefForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DD53524CD6897AD2D8A2521C736710B073D58302"
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
using QuanLyNhaHang;
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
    /// ChefForm
    /// </summary>
    public partial class ChefForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\MainTemplate\ChefForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock passwordSave;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\MainTemplate\ChefForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblName;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\MainTemplate\ChefForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InfoButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\MainTemplate\ChefForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangepasswordButton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\MainTemplate\ChefForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LogoutButton;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\MainTemplate\ChefForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mealCardContainer;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\MainTemplate\ChefForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spMealStatusChef;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QuanLyNhaHang;component/maintemplate/chefform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MainTemplate\ChefForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.passwordSave = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.tblName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.InfoButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\MainTemplate\ChefForm.xaml"
            this.InfoButton.Click += new System.Windows.RoutedEventHandler(this.InfoButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ChangepasswordButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\MainTemplate\ChefForm.xaml"
            this.ChangepasswordButton.Click += new System.Windows.RoutedEventHandler(this.ChangepasswordButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LogoutButton = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\MainTemplate\ChefForm.xaml"
            this.LogoutButton.Click += new System.Windows.RoutedEventHandler(this.LogoutButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.mealCardContainer = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.spMealStatusChef = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

