﻿#pragma checksum "..\..\Login_Window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80048F05802CA938C004DA9F1CC09841F1E9028C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
    /// Login_Window
    /// </summary>
    public partial class Login_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label16;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label17;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button L_button;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginbox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordbox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ErrorLbl;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Login_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back_button;
        
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
            System.Uri resourceLocater = new System.Uri("/StacjaBenzynowa;component/login_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Login_Window.xaml"
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
            this.label16 = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.label17 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.L_button = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Login_Window.xaml"
            this.L_button.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.zaloguj_button);
            
            #line default
            #line hidden
            return;
            case 4:
            this.loginbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.passwordbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ErrorLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.back_button = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Login_Window.xaml"
            this.back_button.Click += new System.Windows.RoutedEventHandler(this.Back_button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

