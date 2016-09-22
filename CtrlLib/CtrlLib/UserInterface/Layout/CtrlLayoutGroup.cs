using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CtrlLib.UserInterface.Layout
{
    public class CtrlLayoutGroup : StackPanel
    {
        public CtrlLayoutGroup()
        {
            Grid.SetIsSharedSizeScope(this, true);
            Margin = new Thickness(5);
            HorizontalAlignment = HorizontalAlignment.Left;
        }
    }
}
