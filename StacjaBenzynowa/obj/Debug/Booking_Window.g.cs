﻿#pragma checksum "..\..\Booking_Window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "349B2EFF85A2B9CAEE41F08C898B974B55918C2E"
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
    /// Booking_Window
    /// </summary>
    public partial class Booking_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Booking_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back_button;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Booking_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateReservation;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Booking_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Adres_firmy;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Booking_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Time;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Booking_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Hour;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Booking_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Minute;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Booking_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Reserve;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Booking_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView BookingListView;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Booking_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Adres_firmy_Copy;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Booking_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Adres_firmy_Copy1;
        
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
            System.Uri resourceLocater = new System.Uri("/StacjaBenzynowa;component/booking_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Booking_Window.xaml"
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
            this.back_button = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Booking_Window.xaml"
            this.back_button.Click += new System.Windows.RoutedEventHandler(this.Back_button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DateReservation = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.Adres_firmy = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Time = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Hour = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Minute = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Reserve = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\Booking_Window.xaml"
            this.Reserve.Click += new System.Windows.RoutedEventHandler(this.Reserve_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BookingListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            this.Adres_firmy_Copy = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.Adres_firmy_Copy1 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

