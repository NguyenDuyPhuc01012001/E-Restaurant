﻿#pragma checksum "..\..\..\..\MainTemplate\Login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1959EFE3366E5566240778AE22D82F5F0D923CA7"
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
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\MainTemplate\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox usernameContainer;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\MainTemplate\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas passwordStack;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\MainTemplate\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid passwordContainer;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\MainTemplate\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbPassword;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\MainTemplate\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\MainTemplate\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button passwordVisability;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\MainTemplate\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon passwordShow;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyNhaHang;V1.0.0.0;component/maintemplate/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MainTemplate\Login.xaml"
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
            this.usernameContainer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.passwordStack = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.passwordContainer = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.txbPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.passwordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 48 "..\..\..\..\MainTemplate\Login.xaml"
            this.passwordBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.passwordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.passwordVisability = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\MainTemplate\Login.xaml"
            this.passwordVisability.Click += new System.Windows.RoutedEventHandler(this.passwordShow_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.passwordShow = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 8:
            
            #line 61 "..\..\..\..\MainTemplate\Login.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Login_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

