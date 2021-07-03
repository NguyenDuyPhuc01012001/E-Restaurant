﻿#pragma checksum "..\..\..\..\..\UI\Table\TableCard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6033892671611C689A063824ED20BF3320E42FEB"
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
    /// TableCard
    /// </summary>
    public partial class TableCard : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\UI\Table\TableCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel tableName;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\UI\Table\TableCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbkName;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\UI\Table\TableCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel tableStatus;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\UI\Table\TableCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbkStatus;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\UI\Table\TableCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editButton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\UI\Table\TableCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon addIcon;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\UI\Table\TableCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\UI\Table\TableCard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon deleteIcon;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QuanLyNhaHang;V1.0.0.0;component/ui/table/tablecard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UI\Table\TableCard.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tableName = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.tbkName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.tableStatus = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.tbkStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.editButton = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\..\UI\Table\TableCard.xaml"
            this.editButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.addButton_MouseEnter);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\..\..\UI\Table\TableCard.xaml"
            this.editButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.addButton_MouseLeave);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\..\..\UI\Table\TableCard.xaml"
            this.editButton.Click += new System.Windows.RoutedEventHandler(this.addButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.addIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 7:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\..\UI\Table\TableCard.xaml"
            this.deleteButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.deleteButton_MouseEnter);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\..\..\UI\Table\TableCard.xaml"
            this.deleteButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.deleteButton_MouseLeave);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\..\..\UI\Table\TableCard.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.deleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.deleteIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

