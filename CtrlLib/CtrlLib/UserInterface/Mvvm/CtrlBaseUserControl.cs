using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using CtrlLib.UserInterface.Controls.Host;
using CtrlLib.UserInterface.Controls.Ribbon;

namespace CtrlLib.UserInterface.Mvvm
{
    public class CtrlBaseUserControl : UserControl
    {
        private CtrlBaseViewModel _ctrlViewModel;
        public CtrlBaseViewModel CtrlViewModel
        {
            get { return _ctrlViewModel; }
            set
            {
                _ctrlViewModel = value;
                DataContext = value;
                _ctrlViewModel.CtrlUserControl = this;
                CtrlOnViewModelAttached(_ctrlViewModel);
            }
        }

        private CtrlBaseWindow _ctrlWindow;
        public CtrlBaseWindow CtrlWindow
        {
            get { return _ctrlWindow; }
            set 
            {
                if(Equals(_ctrlWindow, value)) return;
                _ctrlWindow = value;
            }
        }

        public virtual void CtrlOnViewModelAttached(CtrlBaseViewModel iViewModel)
        {

        }

        public virtual void CtrlOnAttachedToWindow(CtrlWindow iWindow)
        {

        }

        public virtual List<CtrlRibbonPage> OnRibbonItemsSet()
        {
            return null;
        }

    }
}
