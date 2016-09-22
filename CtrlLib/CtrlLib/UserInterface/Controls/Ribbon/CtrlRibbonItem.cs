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

namespace CtrlLib.UserInterface.Controls.Ribbon
{
    public class CtrlRibbonItem : Button
    {
        static CtrlRibbonItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CtrlRibbonItem), new FrameworkPropertyMetadata(typeof(CtrlRibbonItem)));
        }
        
        public ImageSource CtrlIconSource => new BitmapImage(new Uri($"pack://application:,,,/CtrlLib;component/Resources/Icons/{CtrlIcon}.png"));
        public string CtrlIcon { get; set; }
    }
}
