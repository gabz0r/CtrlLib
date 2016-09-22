﻿#pragma checksum "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A650EBB4CA410F54B70A77EF3722A218"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using CtrlApplication.Modules.MainMenu;
using CtrlLib.Commands;
using CtrlLib.UserInterface.Controls.Actions;
using CtrlLib.UserInterface.Controls.Data.Menu;
using CtrlLib.UserInterface.Controls.Host;
using CtrlLib.UserInterface.Controls.Indicators;
using CtrlLib.UserInterface.Mvvm;
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


namespace CtrlApplication.Modules.MainMenu {
    
    
    /// <summary>
    /// MainMenuUserControl
    /// </summary>
    public partial class MainMenuUserControl : CtrlLib.UserInterface.Mvvm.CtrlBaseUserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding AddToFavouritesCommandBinding;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding RemoveFromFavouritesCommandBinding;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition ListMenuColumn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition DashboardColumn;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CtrlLib.UserInterface.Controls.Data.Menu.CtrlListMenu FavouritesListView;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CtrlLib.UserInterface.Controls.Data.Menu.CtrlListMenu MenuItemsListView;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CtrlLib.UserInterface.Controls.Host.CtrlTabControl ModulesTabControl;
        
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
            System.Uri resourceLocater = new System.Uri("/CtrlApplication;component/modules/mainmenu/mainmenuusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
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
            this.AddToFavouritesCommandBinding = ((System.Windows.Input.CommandBinding)(target));
            
            #line 19 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
            this.AddToFavouritesCommandBinding.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.AddToFavourites_OnCanExecute);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
            this.AddToFavouritesCommandBinding.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.AddToFavourites_OnExecuted);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RemoveFromFavouritesCommandBinding = ((System.Windows.Input.CommandBinding)(target));
            
            #line 23 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
            this.RemoveFromFavouritesCommandBinding.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.RemoveFromFavourites_OnCanExecute);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
            this.RemoveFromFavouritesCommandBinding.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.RemoveFromFavourites_OnExecuted);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ListMenuColumn = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 4:
            this.DashboardColumn = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 5:
            this.FavouritesListView = ((CtrlLib.UserInterface.Controls.Data.Menu.CtrlListMenu)(target));
            
            #line 42 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
            this.FavouritesListView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.AllMenus_OnMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MenuItemsListView = ((CtrlLib.UserInterface.Controls.Data.Menu.CtrlListMenu)(target));
            
            #line 47 "..\..\..\..\Modules\MainMenu\MainMenuUserControl.xaml"
            this.MenuItemsListView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.AllMenus_OnMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ModulesTabControl = ((CtrlLib.UserInterface.Controls.Host.CtrlTabControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

