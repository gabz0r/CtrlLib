using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CtrlLib.Commands;
using CtrlLib.Helper;
using CtrlLib.Module;
using CtrlLib.Session;
using CtrlLib.UserInterface.Controls.Host;
using CtrlLib.UserInterface.Controls.Indicators;
using CtrlLib.UserInterface.Controls.Ribbon;

namespace CtrlLib.UserInterface.Mvvm
{
    public class CtrlBaseWindow : Window
    {
        private string _ctrlUser;
        public string CtrlUser
        {
            get
            {
                var user = CtrlSession.Instance.CurrentUser;
                return $"{user.FirstName} {user.LastName}";
            }
            set
            { _ctrlUser = value; }
        }

        private CtrlBaseUserControl _currentModule;
        private CtrlModuleStarter _starter;

        public bool CtrlCanResize { get; set; } = true;

        public void StartModule(CtrlModuleStarter iModuleStarter)
        {
            _starter = iModuleStarter;
            Closing += CtrlWindow_OnClosing;


            if (_starter.DisplayType == ModuleDisplayType.ModalDialog)
            {
                if (_starter.ParentUserControl == null)
                {
                    throw new Exception("Modal dialogs must have the ParentUserControl property set");
                }
                _starter.ParentUserControl.IsEnabled = false;
            }

            Show();

            var contentGrid = new Grid();
            var contentGridRows = contentGrid.RowDefinitions;
            
            var loader = new CtrlLoadingIndicator();

            if (iModuleStarter.RenderType == ModuleRenderType.WithRibbon)
            {
                var items = _starter.UserControl.OnRibbonItemsSet();

                var ribbonBar = BuildRibbonBar(items, _starter.UserControl);

                contentGridRows.Add(new RowDefinition {Height = new GridLength(120, GridUnitType.Pixel)});
                contentGridRows.Add(new RowDefinition {Height = new GridLength(1, GridUnitType.Star)});

                

                Grid.SetRow(ribbonBar, 0);
                Grid.SetRow(loader, 1);

                contentGrid.Children.Add(ribbonBar);
                contentGrid.Children.Add(loader);
            }
            else
            {
                contentGrid.Children.Add(loader);
            }

            Content = contentGrid;

            _starter.UserControl.CtrlViewModel.CtrlOnParametersPassed(iModuleStarter.ModuleParam);
            _currentModule = _starter.UserControl;

            _currentModule.Margin = new Thickness(0 , 10, 0, 0 );

            Grid.SetRow(_currentModule, 1);

            contentGrid.Children.Remove(loader);
            contentGrid.Children.Add(_currentModule);

            _starter.UserControl.CtrlWindow = this;
            _starter.UserControl.CtrlOnAttachedToWindow((CtrlWindow)this);
        }

        private void CtrlWindow_OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            if (_starter.DisplayType == ModuleDisplayType.ModalDialog)
            {
                if (_starter.ParentUserControl == null)
                {
                    throw new Exception("Modal dialogs must have the ParentUserControl property set");
                }
                _starter.ParentUserControl.IsEnabled = true;
            }
        }

        private CtrlTabControl BuildRibbonBar(List<CtrlRibbonPage> iPages, CtrlBaseUserControl iCommandTarget)
        {
            var ribbonBar = new CtrlTabControl {CtrlBackground = FindResource("CtrlPickColor") as SolidColorBrush, Margin = new Thickness(2, 0, 2, 0)};

            if (iPages == null)
            {
                iPages = new List<CtrlRibbonPage>();
            }

            var mainPage = new CtrlRibbonPage {CtrlIsMainPage = true, CtrlOrder = 0};

            mainPage.CtrlRibbonGroups.Add(new CtrlRibbonGroup("Basis")
            {
                CtrlRibbonItems = new List<CtrlRibbonItem>
                {
                    new CtrlRibbonItem { CtrlIcon = "file", Content = "Neu", Command = CtrlCommands.CtrlNew, CommandTarget = iCommandTarget},
                    new CtrlRibbonItem { CtrlIcon = "file", Content = "Speichern", Command = CtrlCommands.CtrlSave, CommandTarget = iCommandTarget},
                    new CtrlRibbonItem { CtrlIcon = "file-14", Content = "Löschen", Command = CtrlCommands.CtrlDelete, CommandTarget = iCommandTarget},
                    new CtrlRibbonItem { CtrlIcon = "file-19", Content = "Suche", Command = CtrlCommands.CtrlSearch, CommandTarget = iCommandTarget}
                }
            });

            iPages.Add(mainPage);

            var mainPages = iPages.Where(p => p.CtrlIsMainPage).OrderBy(p => p.CtrlOrder).ToList();
            var mainPageContainerHost = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5, 0, 5, 0) };

            foreach (var page in mainPages)
            {
                foreach (var group in page.CtrlRibbonGroups)
                {
                    foreach (var item in group.CtrlRibbonItems)
                    {
                        item.VerticalAlignment = VerticalAlignment.Center;
                        mainPageContainerHost.Children.Add(item);
                    }

                    mainPageContainerHost.Children.Add(new Border {Height = 70, Width = 1, VerticalAlignment = VerticalAlignment.Center, BorderThickness = new Thickness(1), BorderBrush = Brushes.Gray, Margin = new Thickness(5, 0, 5, 0)});
                }
            }

            var mainPageTabItem = new TabItem { Content = mainPageContainerHost, Header = "Haupt" };
            ribbonBar.Items.Add(mainPageTabItem);

            var otherPages = iPages.Where(p => !p.CtrlIsMainPage).ToList();

            foreach (var page in otherPages)
            {
                var containerHost = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5, 0, 5, 0) };
                
                foreach (var group in page.CtrlRibbonGroups)
                {
                    foreach (var item in group.CtrlRibbonItems)
                    {
                        item.VerticalAlignment = VerticalAlignment.Center;
                        containerHost.Children.Add(item);
                    }

                    mainPageContainerHost.Children.Add(new Border { Height = 120, Width = 10, BorderThickness = new Thickness(4) });
                }

                var itm = new TabItem {Content = containerHost, Header = page.CtrlHeader};
                ribbonBar.Items.Add(itm);
            }

            return ribbonBar;
        }
    }
}
