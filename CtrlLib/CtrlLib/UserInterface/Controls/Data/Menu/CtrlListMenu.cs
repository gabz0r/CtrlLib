using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace CtrlLib.UserInterface.Controls.Data.Menu
{
    public class CtrlListMenu : ListView, INotifyPropertyChanged
    {
        static CtrlListMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CtrlListMenu), new FrameworkPropertyMetadata(typeof(CtrlListMenu)));
        }
        
        #region Properties

        private string _filterText;
        public string FilterText
        {
            get { return _filterText; }
            set 
            {
                if(_filterText == value) return;

                var colView = ItemsSource as CollectionView;

                _filterText = value;
                OnPropertyChanged("FilterText");

                colView?.Refresh();
            }
        }

        #endregion
        
        #region DependencyProperties

        #region DepProp_CtrlMenuItems

        /***********************************************************************************************/

        public static readonly DependencyProperty CtrlMenuItemsProperty = DependencyProperty.Register("CtrlMenuItems", typeof(ObservableCollection<CtrlMainMenuItem>), typeof(CtrlListMenu),
            new PropertyMetadata(default(ObservableCollection<CtrlMainMenuItem>), CtrlMenuItemsPropertyChanged));

        private static void CtrlMenuItemsPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var uiElem = dependencyObject as CtrlListMenu;
            if (uiElem != null)
            {
                var colView = CollectionViewSource.GetDefaultView(uiElem.CtrlMenuItems);

                colView.Filter += item =>
                {
                    var menuItem = item as CtrlMainMenuItem;
                    if (menuItem != null)
                    {
                        if(string.IsNullOrEmpty(uiElem.FilterText)) return true;
                        if (!menuItem.Title.ToUpper().Contains(uiElem.FilterText.ToUpper()) &&
                            !menuItem.Description.ToUpper().Contains(uiElem.FilterText.ToUpper())) return false;

                    }
                    return true;
                };

                uiElem.ItemsSource = colView;
            }
        }

        public ObservableCollection<CtrlMainMenuItem> CtrlMenuItems
        {
            get { return (ObservableCollection<CtrlMainMenuItem>) GetValue(CtrlMenuItemsProperty); }
            set { SetValue(CtrlMenuItemsProperty, value); }
        }

        /***********************************************************************************************/

        #endregion

        #endregion

        #region PropChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
