using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CtrlLib.UserInterface.Controls.Actions
{
    public class CtrlButton : Button
    {
        static CtrlButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CtrlButton), new FrameworkPropertyMetadata(typeof(CtrlButton)));
        }

        public CtrlButton()
        {
            Background = Brushes.Gainsboro;
        }
    }
}
