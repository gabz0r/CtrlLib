using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CloudApiLib;
using CtrlLib.Session;
using CtrlLib.UserInterface.Mvvm;
namespace CtrlApplication.Modules.MainMenu
{
    public class MainMenuViewModel : CtrlBaseViewModel
    {
        private bool _mainMenuExpanded;
        public bool MainMenuExpanded
        {
            get { return _mainMenuExpanded; }
            set 
            {
                if(_mainMenuExpanded == value) return;

                _mainMenuExpanded = value;
                OnPropertyChanged("MainMenuExpanded");
            }
        }

        private ObservableCollection<CtrlMainMenuItem> _menuItems;
        public ObservableCollection<CtrlMainMenuItem> MenuItems
        {
            get { return _menuItems; }
            set 
            {
                if(_menuItems == value) return;

                _menuItems = value;
                OnPropertyChanged("MenuItems");
            }
        }

        private ObservableCollection<CtrlMainMenuItem> _favouriteItems;
        public ObservableCollection<CtrlMainMenuItem> FavouriteItems
        {
            get { return _favouriteItems; }
            set 
            {
                if(_favouriteItems == value) return;

                _favouriteItems = value;
                OnPropertyChanged("FavouriteItems");
            }
        }

        public override void CtrlOnParametersPassed(Dictionary<string, object> iModuleParameters)
        {
        }

        public async void LoadMenuItems()
        {
            var currentUserFavs = CtrlSession.Instance.CurrentUser.MenuFavourites;

            MenuItems = await CtrlMainMenuItem.All();
            FavouriteItems = await CtrlMainMenuItem.Find(u => currentUserFavs.Contains(u.MenuNodeId));
        }

        public async void LoadUserFavourites()
        {
            var currentUserFavs = CtrlSession.Instance.CurrentUser.MenuFavourites;
            FavouriteItems = await CtrlMainMenuItem.Find(u => currentUserFavs.Contains(u.MenuNodeId));
        }
    }
}
