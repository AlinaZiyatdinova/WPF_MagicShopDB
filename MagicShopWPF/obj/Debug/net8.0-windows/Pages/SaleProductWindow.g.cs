﻿#pragma checksum "..\..\..\..\Pages\SaleProductWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F39EC034CDFDAA262201D165716800351BFC6853"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MagicShopWPF.Pages;
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


namespace MagicShopWPF.Pages {
    
    
    /// <summary>
    /// SaleProductWindow
    /// </summary>
    public partial class SaleProductWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\Pages\SaleProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textblock_description;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Pages\SaleProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_amount;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Pages\SaleProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combobox_clientInfo;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Pages\SaleProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_sellProduct;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Pages\SaleProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_backPage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MagicShopWPF;component/pages/saleproductwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\SaleProductWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\Pages\SaleProductWindow.xaml"
            ((MagicShopWPF.Pages.SaleProductWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textblock_description = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.textbox_amount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.combobox_clientInfo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.button_sellProduct = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\Pages\SaleProductWindow.xaml"
            this.button_sellProduct.Click += new System.Windows.RoutedEventHandler(this.button_sellProduct_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.button_backPage = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\Pages\SaleProductWindow.xaml"
            this.button_backPage.Click += new System.Windows.RoutedEventHandler(this.button_backPage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
