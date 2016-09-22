using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CtrlLib.UserInterface.Controls.Editors
{
    public class CtrlTextBox : TextBox
    {
        static CtrlTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CtrlTextBox), new FrameworkPropertyMetadata(typeof(CtrlTextBox)));
        }

        public CtrlTextBox()
        {
            Background = Brushes.White;
            CtrlIsValid = true;
        }
        
        #region DependencyProperties

        #region DepProp_CtrlLabelText

        /***********************************************************************************************/

        public static readonly DependencyProperty CtrlLabelProperty = DependencyProperty.Register("CtrlLabel", typeof (string), typeof (CtrlTextBox),
            new FrameworkPropertyMetadata(default(string)));

        public string CtrlLabel
        {
            get { return (string) GetValue(CtrlLabelProperty); }
            set { SetValue(CtrlLabelProperty, value); }
        }

        /***********************************************************************************************/

        #endregion

        #region DepProp_CtrlIsValid

/***********************************************************************************************/

        public static readonly DependencyProperty CtrlIsValidProperty = DependencyProperty.Register("CtrlIsValid", typeof (bool), typeof (CtrlTextBox),
            new FrameworkPropertyMetadata(default(bool)));

        public bool CtrlIsValid
        {
            get { return (bool) GetValue(CtrlIsValidProperty); }
            set { SetValue(CtrlIsValidProperty, value); }
        }

/***********************************************************************************************/

        #endregion

        #endregion
    }
}
