using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CloudApiLib;
using CtrlApplication.ModuleMapping;
using CtrlLib.Helper;
using CtrlLib.Module;
using CtrlLib.Session;
using CtrlLib.UserInterface.Controls.Data.Menu;
using CtrlLib.UserInterface.Controls.Host;
using CtrlLib.UserInterface.Controls.Indicators;
using CtrlLib.UserInterface.Mvvm;

namespace CtrlApplication.Modules.MainMenu
{
    /// <summary>
    /// Interaktionslogik für MainMenuUserControl.xaml
    /// </summary>
    public partial class MainMenuUserControl
    {
        public MainMenuUserControl()
        {
            InitializeComponent();
        }

        public override void CtrlOnAttachedToWindow(CtrlWindow iWindow)
        {
            iWindow.Title = "ctrl office - Hauptmenü";
        }

        public override void CtrlOnViewModelAttached(CtrlBaseViewModel iViewModel)
        {
            ((MainMenuViewModel) CtrlViewModel).LoadMenuItems();
            ((MainMenuViewModel) CtrlViewModel).LoadUserFavourites();
        }

        private void AddToFavourites_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var clickedItem = e.Parameter as CtrlMainMenuItem;

            if (clickedItem == null)
            {
                e.CanExecute = true;
                e.Handled = true;
                return;
            }

            var user = CtrlSession.Instance.CurrentUser;
            e.CanExecute = user.MenuFavourites.Count(u => u == clickedItem.MenuNodeId) == 0;
            e.Handled = true;
        }

        private async void AddToFavourites_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var user = CtrlSession.Instance.CurrentUser;
            var clickedItem = e.Parameter as CtrlMainMenuItem;

            await CtrlMainMenuItem.AddItemAsFavourite(user.Username, clickedItem.MenuNodeId);
            await CtrlSession.Instance.SyncUser();


            ((MainMenuViewModel) CtrlViewModel).LoadUserFavourites();
        }

        private void RemoveFromFavourites_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var clickedItem = e.Parameter as CtrlMainMenuItem;

            if (clickedItem == null)
            {
                e.CanExecute = true;
                e.Handled = true;
                return;
            }

            var user = CtrlSession.Instance.CurrentUser;
            e.CanExecute = user.MenuFavourites.Count(u => u == clickedItem.MenuNodeId) > 0;
            e.Handled = true;
        }

        private async void RemoveFromFavourites_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var user = CtrlSession.Instance.CurrentUser;
            var clickedItem = e.Parameter as CtrlMainMenuItem;

            await CtrlMainMenuItem.RemoveItemFromFavourites(user.Username, clickedItem.MenuNodeId);
            await CtrlSession.Instance.SyncUser();

            ((MainMenuViewModel) CtrlViewModel).LoadUserFavourites();
        }

        private void AllMenus_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject originalSource = (DependencyObject)e.OriginalSource;
            while ((originalSource != null) && !(originalSource is ListViewItem))
                originalSource = VisualTreeHelper.GetParent(originalSource);

            if (originalSource is ListViewItem)
            {
                var sendingMenu = sender as CtrlListMenu;
                if (sendingMenu == null)
                    return;

                var sendingItem = sendingMenu.SelectedItem as CtrlMainMenuItem;
                if (sendingItem == null)
                    return;

                var mod = sendingItem.AssociatedModule;
                var modInfo = ModuleDictionary.ModuleMapping[mod];


                var appWnd = new CtrlWindow();
                var modObj = CtrlModuleStarter.LoadModule(modInfo.Item1, modInfo.Item2);

                modObj.RenderType = ModuleRenderType.WithRibbon;

                appWnd.StartModule(modObj);

                DashboardColumn.Width = new GridLength(0);
                CtrlWindow.Width = ListMenuColumn.ActualWidth + 12;

                CtrlWindow.WindowState = WindowState.Normal;
                CtrlWindow.WindowState = WindowState.Minimized;

                CtrlWindow.Height = 800;
            }
        }
    }
}
