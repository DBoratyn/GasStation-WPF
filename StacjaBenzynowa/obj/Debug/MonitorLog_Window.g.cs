﻿#pragma checksum "..\..\MonitorLog_Window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E52B3679D17A2F2D2A94123D3032ECAEE53A8E05"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using StacjaBenzynowa;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace StacjaBenzynowa {
    
    
    /// <summary>
    /// MonitorLog_Window
    /// </summary>
    public partial class MonitorLog_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\MonitorLog_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LogListView;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\MonitorLog_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back_button;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\MonitorLog_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox YearList;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\MonitorLog_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MonthList;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\MonitorLog_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Wlasciciel_Copy18;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\MonitorLog_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Wlasciciel_Copy17;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StacjaBenzynowa;component/monitorlog_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MonitorLog_Window.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LogListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.back_button = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\MonitorLog_Window.xaml"
            this.back_button.Click += new System.Windows.RoutedEventHandler(this.Back_button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.YearList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 43 "..\..\MonitorLog_Window.xaml"
            this.YearList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.YearList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MonthList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 51 "..\..\MonitorLog_Window.xaml"
            this.MonthList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MonthList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Wlasciciel_Copy18 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Wlasciciel_Copy17 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

