using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CloudApiLib;
using CtrlLib.App.Exception;

namespace CtrlLib.App
{
    public class CtrlApplication : Application
    {
        public CtrlApplication()
        {
            DispatcherUnhandledException += OnDispatcherUnhandledException;
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs dispatcherUnhandledExceptionEventArgs)
        {
            dispatcherUnhandledExceptionEventArgs.Dispatcher.BeginInvoke(DispatcherPriority.Render,
                (Action) (() =>
                {
                    new CtrlUnhandledExceptionWindow(dispatcherUnhandledExceptionEventArgs.Exception).Show();
                }));

            dispatcherUnhandledExceptionEventArgs.Handled = true;
        }
    }
}
