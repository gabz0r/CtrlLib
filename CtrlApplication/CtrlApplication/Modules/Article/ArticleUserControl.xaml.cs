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
using CloudApiLib;
using CtrlLib.Commands;
using CtrlLib.Helper;
using CtrlLib.UserInterface.Controls.Host;
using CtrlLib.UserInterface.Controls.Ribbon;
using CtrlLib.UserInterface.Mvvm;
using CtrlLib.UserInterface.Search;

namespace CtrlApplication.Modules.Article
{
    /// <summary>
    /// Interaktionslogik für ArticleUserControl.xaml
    /// </summary>
    public partial class ArticleUserControl
    {
        public ArticleUserControl()
        {
            InitializeComponent();
        }

        #region Properties

        public ArticleViewModel ViewModel { get; set; }

        #endregion

        #region Overrides

        public override List<CtrlRibbonPage> OnRibbonItemsSet()
        {
            var retList = new List<CtrlRibbonPage>();

            var mainPage = new CtrlRibbonPage { CtrlIsMainPage = true };

            mainPage.CtrlRibbonGroups.Add(new CtrlRibbonGroup("Matierialwirtschaft")
            {
                CtrlRibbonItems = new List<CtrlRibbonItem>
                {
                    new CtrlRibbonItem {CtrlIcon = "file", Content="Lieferanten"}
                }
            });

            retList.Add(mainPage);
            
            return retList;
        }
        
        public override void CtrlOnAttachedToWindow(CtrlWindow iWindow)
        {
            iWindow.Title = "Artikelstamm";
        }

        public override void CtrlOnViewModelAttached(CtrlBaseViewModel iViewModel)
        {
            ViewModel = CtrlViewModel as ArticleViewModel;
        }

        #endregion
        
        #region Commands

        private void CtrlNewCommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void CtrlNewCommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ViewModel.NewArticle();
        }

        private void CtrlSaveCommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CtrlSaveCommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ViewModel.SaveArticle();
        }

        private void CtrlSearchCommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void CtrlSearchCommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var searchParam = new CtrlSearch
            {
                DocumentSearchType = typeof(CtrlArticle),
                SearchWindowHeader = "Artikelsuche",
                ParentUserControl = this
            };

            searchParam.OnSearchComplete += result =>
            {
                ViewModel.Article = (CtrlArticle) result;
                ViewModel.SaveArticle();
            };

            CtrlSearch.DoSearch(searchParam);
        }

        #endregion

        #region Methods

        public void LockUserControl()
        {
            ArticleIdTextBox.IsReadOnly = true;
        }

        public void UnlockUserControl()
        {
            ArticleIdTextBox.IsReadOnly = false;
        }

        #endregion

        #region Events

        private void ArticleUserControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            var searchParam = new CtrlSearch
            {
                DocumentSearchType = typeof(CtrlArticle),
                SearchWindowHeader = "Artikelsuche",
                ParentUserControl = this
            };

            searchParam.OnSearchComplete += result =>
            {
                if (result != null)
                {
                    ViewModel.Article = (CtrlArticle) result;
                    LockUserControl();
                }
                else
                {
                    ViewModel.NewArticle();
                }
            };

            CtrlSearch.DoSearch(searchParam);
        }

        #endregion

    }
}
