using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
using CloudApiLib;
using CtrlApplication.Modules.MainMenu;
using CtrlLib.Extensions;
using CtrlLib.Module;
using CtrlLib.Session;
using CtrlLib.UserInterface.Controls.Host;
using CtrlLib.UserInterface.Mvvm;

namespace CtrlApplication
{
    /// <summary>
    /// Interaktionslogik für LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;

            CloudApi.Initialize("http://localhost:9091/cloudapi/");

            //Debug
            MyUsername = "ctrl";
            MyPassword = new SecureString();
            "ctrl".ToCharArray().ToList().ForEach(p => MyPassword.AppendChar(p));
            PerformLogin();
        }

        public string MyUsername { get; set; }
        public SecureString MyPassword { get; set; }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            PerformLogin();
        }

        private void MyPassword_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PerformLogin();
            }
        }

        public async void PerformLogin()
        {
            UsernameTextItem.IsEnabled = false;
            PasswordMaskedTextItem.IsEnabled = false;
            LoginButton.IsEnabled = false;

            var user = new CtrlUser {Username = MyUsername, Password = MyPassword.ConvertToSha256HexString()};

            CtrlSession.Instance.CurrentUser = user;

            if (await CtrlSession.Instance.StartSession())
            {
                var appWnd = new CtrlWindow();
                var mod = CtrlModuleStarter.LoadModule<MainMenuUserControl, MainMenuViewModel>(null);

                appWnd.StartModule(mod);

                Close();
            }
            else
            {
                UsernameTextItem.IsEnabled = true;
                PasswordMaskedTextItem.IsEnabled = true;
                LoginButton.IsEnabled = true;
                //PasswordMaskedTextItem.CtrlValidationError = new CtrlValidationError
                //{
                //    ValidationErrorHeader = "Fehler beim Login",
                //    ValidationErrorText = "Passwort nicht korrekt!"
                //};
            }
        }
    }
}
