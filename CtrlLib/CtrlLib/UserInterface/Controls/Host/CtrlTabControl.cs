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

namespace CtrlLib.UserInterface.Controls.Host
{
    public class CtrlTabControl : TabControl
    {
        static CtrlTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CtrlTabControl), new FrameworkPropertyMetadata(typeof(CtrlTabControl)));
        }

        #region DepProp_CtrlBackground

/***********************************************************************************************/

        public static readonly DependencyProperty CtrlBackgroundProperty = DependencyProperty.Register("CtrlBackground", typeof (SolidColorBrush), typeof (CtrlTabControl),
            new FrameworkPropertyMetadata((SolidColorBrush) new BrushConverter().ConvertFrom("#ecf0f1")));

        public SolidColorBrush CtrlBackground
        {
            get { return (SolidColorBrush) GetValue(CtrlBackgroundProperty); }
            set { SetValue(CtrlBackgroundProperty, value); }
        }

/***********************************************************************************************/

        #endregion
    }
}
