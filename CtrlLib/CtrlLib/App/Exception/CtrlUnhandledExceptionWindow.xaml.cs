using System;
using System.Windows.Input;
using CloudApiLib;

namespace CtrlLib.App.Exception
{
    /// <summary>
    /// Interaktionslogik für CtrlUnhandledException.xaml
    /// </summary>
    public partial class CtrlUnhandledExceptionWindow
    {
        public CtrlUnhandledExceptionWindow(System.Exception iException)
        {
            InitializeComponent();
            CtrlException = iException;
            DataContext = this;
        }

        public System.Exception CtrlException { get; set; }

        private string _dummy;

        public string CtrlName
        {
            get { return CtrlException.ToString(); }
            set { _dummy = value; }
        }

        public string CtrlStackTrace
        {
            get { return CtrlException.StackTrace; }
            set { _dummy = value; }
        }

        public string CtrlInnerException
        {
            get { return CtrlException.InnerException?.ToString(); }
            set { _dummy = value; }
        }

        public string CtrlMessage
        {
            get { return CtrlException.Message; }
            set { _dummy = value; }
        }


        private void InnerException_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CtrlException.InnerException != null)
            {
                var wnd = new CtrlUnhandledExceptionWindow(CtrlException.InnerException);
                wnd.Show();
            }
        }
    }
}
