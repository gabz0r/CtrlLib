using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using CtrlLib.UserInterface.Controls.Host;
using CtrlLib.UserInterface.Mvvm;
using MongoDB.Bson;

namespace CtrlLib.UserInterface.Search
{
    /// <summary>
    /// Interaktionslogik für CtrlSearchWindow.xaml
    /// </summary>
    public partial class CtrlSearchUserControl
    {
        public CtrlSearchUserControl()
        {
            InitializeComponent();
        }

        public override void CtrlOnAttachedToWindow(CtrlWindow iWindow)
        {
            iWindow.CtrlCanResize = false;
            iWindow.Owner = ((CtrlSearchViewModel)CtrlViewModel).CtrlSearchParam.ParentUserControl.CtrlWindow;
            iWindow.Closing += CtrlWindowOnClosing;
        }

        private void FtsTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ((CtrlSearchViewModel)CtrlViewModel).QueryFullTextSearch(FtsTextBox.Text);
            }
        }
        
        private void ResultsGridControl_OnCtrlRowDoubleClick(object sender, MouseButtonEventArgs args)
        {
            if (sender != null)
            {
                ((CtrlSearchViewModel)CtrlViewModel).ReturnResult(sender);
            }
            ((CtrlSearchViewModel) CtrlViewModel).CtrlSearchParam.ParentUserControl.IsEnabled = true;
            CtrlWindow.Close();
        }
        
        private void CtrlWindowOnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            ((CtrlSearchViewModel)CtrlViewModel).ReturnResult(null);
        }
    }
}
