﻿#pragma checksum "..\..\..\..\UserControls\OpposerControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CB133E3F4BEF4E9C137A434CF81CDF3EE7285CDF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ContestationUI.UserControls;
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


namespace ContestationUI.UserControls {
    
    
    /// <summary>
    /// OpposerControl
    /// </summary>
    public partial class OpposerControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\UserControls\OpposerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUserName;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\UserControls\OpposerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView OpposersListView;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\UserControls\OpposerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtFineNumber;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\UserControls\OpposerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtReasonForContestation;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\UserControls\OpposerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNotes;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\UserControls\OpposerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbDecisionType;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\UserControls\OpposerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDecision;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\..\UserControls\OpposerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtAmount;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\UserControls\OpposerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDownload;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\..\UserControls\OpposerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExit;
        
        #line default
        #line hidden
        
        
        #line 222 "..\..\..\..\UserControls\OpposerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser PdfBrowser;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ContestationUI;component/usercontrols/opposercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\OpposerControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\UserControls\OpposerControl.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtUserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\..\UserControls\OpposerControl.xaml"
            this.txtUserName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtUserName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OpposersListView = ((System.Windows.Controls.ListView)(target));
            
            #line 37 "..\..\..\..\UserControls\OpposerControl.xaml"
            this.OpposersListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OpposersListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtFineNumber = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txtReasonForContestation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtNotes = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cmbDecisionType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.BtnDecision = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\..\UserControls\OpposerControl.xaml"
            this.BtnDecision.Click += new System.Windows.RoutedEventHandler(this.BtnDecision_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtAmount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.BtnDownload = ((System.Windows.Controls.Button)(target));
            
            #line 159 "..\..\..\..\UserControls\OpposerControl.xaml"
            this.BtnDownload.Click += new System.Windows.RoutedEventHandler(this.BtnDownload_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BtnExit = ((System.Windows.Controls.Button)(target));
            
            #line 198 "..\..\..\..\UserControls\OpposerControl.xaml"
            this.BtnExit.Click += new System.Windows.RoutedEventHandler(this.BtnExit_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.PdfBrowser = ((System.Windows.Controls.WebBrowser)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

