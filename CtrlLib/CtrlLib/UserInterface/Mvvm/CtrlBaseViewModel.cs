using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CtrlLib.UserInterface.Mvvm
{
    public class CtrlBaseViewModel : INotifyPropertyChanged
    {
        public CtrlBaseUserControl CtrlUserControl;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void CtrlOnParametersPassed(Dictionary<string, object> iModuleParameters)
        {

        }
    }
}
