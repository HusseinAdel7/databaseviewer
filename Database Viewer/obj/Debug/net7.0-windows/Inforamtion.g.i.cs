﻿#pragma checksum "..\..\..\Inforamtion.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E8C8584B598B3E99CD4E99DB774D507016179DDC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Database_Viewer;
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


namespace Database_Viewer {
    
    
    /// <summary>
    /// Inforamtion
    /// </summary>
    public partial class Inforamtion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 80 "..\..\..\Inforamtion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Schemasnum;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Inforamtion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Tablesnum;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\Inforamtion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Viewsnum;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\Inforamtion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Proceduresnum;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\Inforamtion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Functionsnum;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\Inforamtion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Triggersum;
        
        #line default
        #line hidden
        
        
        #line 226 "..\..\..\Inforamtion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Indexesnum;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\..\Inforamtion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Rulesnum;
        
        #line default
        #line hidden
        
        
        #line 267 "..\..\..\Inforamtion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tableinfo;
        
        #line default
        #line hidden
        
        
        #line 298 "..\..\..\Inforamtion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button otherDbInfo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Database Viewer;V1.0.0.0;component/inforamtion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Inforamtion.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 23 "..\..\..\Inforamtion.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 46 "..\..\..\Inforamtion.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 55 "..\..\..\Inforamtion.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClose_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Schemasnum = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Tablesnum = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Viewsnum = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Proceduresnum = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Functionsnum = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.Triggersum = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.Indexesnum = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.Rulesnum = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.tableinfo = ((System.Windows.Controls.Button)(target));
            
            #line 268 "..\..\..\Inforamtion.xaml"
            this.tableinfo.Click += new System.Windows.RoutedEventHandler(this.Tablesinfo);
            
            #line default
            #line hidden
            return;
            case 13:
            this.otherDbInfo = ((System.Windows.Controls.Button)(target));
            
            #line 299 "..\..\..\Inforamtion.xaml"
            this.otherDbInfo.Click += new System.Windows.RoutedEventHandler(this.OtherDbInfo);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

