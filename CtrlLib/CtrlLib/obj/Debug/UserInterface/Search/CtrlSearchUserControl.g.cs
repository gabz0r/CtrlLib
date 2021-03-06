﻿#pragma checksum "..\..\..\..\UserInterface\Search\CtrlSearchUserControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "53C6F683B18D8A5410A8B45AC1AAA0D8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using CtrlLib.UserInterface.Controls.Data.CtrlGridView;
using CtrlLib.UserInterface.Controls.Editors;
using CtrlLib.UserInterface.Controls.Host;
using CtrlLib.UserInterface.Layout;
using CtrlLib.UserInterface.Mvvm;
using CtrlLib.UserInterface.Search;
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


namespace CtrlLib.UserInterface.Search {
    
    
    /// <summary>
    /// CtrlSearchUserControl
    /// </summary>
    public partial class CtrlSearchUserControl : CtrlLib.UserInterface.Mvvm.CtrlBaseUserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\UserInterface\Search\CtrlSearchUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CtrlLib.UserInterface.Layout.CtrlLayoutGroup FieldSearchLayoutGroup;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\UserInterface\Search\CtrlSearchUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CtrlLib.UserInterface.Layout.CtrlLayoutGroup FulltextSearchLayoutGroup;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\UserInterface\Search\CtrlSearchUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CtrlLib.UserInterface.Controls.Editors.CtrlTextBox FtsTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\UserInterface\Search\CtrlSearchUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CtrlLib.UserInterface.Controls.Data.CtrlGridView.CtrlGridView ResultsGridControl;
        
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
            System.Uri resourceLocater = new System.Uri("/CtrlLib;component/userinterface/search/ctrlsearchusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserInterface\Search\CtrlSearchUserControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.FieldSearchLayoutGroup = ((CtrlLib.UserInterface.Layout.CtrlLayoutGroup)(target));
            return;
            case 2:
            this.FulltextSearchLayoutGroup = ((CtrlLib.UserInterface.Layout.CtrlLayoutGroup)(target));
            return;
            case 3:
            this.FtsTextBox = ((CtrlLib.UserInterface.Controls.Editors.CtrlTextBox)(target));
            return;
            case 4:
            this.ResultsGridControl = ((CtrlLib.UserInterface.Controls.Data.CtrlGridView.CtrlGridView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

