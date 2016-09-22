using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using CloudApiLib;
using CtrlLib.Helper;
using CtrlLib.UserInterface.Mvvm;

namespace CtrlApplication.Modules.Article
{
    public class ArticleViewModel : CtrlBaseViewModel
    {
        private CtrlArticle _article;
        public CtrlArticle Article
        {
            get { return _article; }
            set 
            {
                if(_article == value) return;

                _article = value;
                OnPropertyChanged("Article");
            }
        }

        public override void CtrlOnParametersPassed(Dictionary<string, object> iModuleParameters)
        {
            if (iModuleParameters == null || !iModuleParameters.ContainsKey("ARTICLE_ID"))
            {
                Article = new CtrlArticle();
            }
        }

        public void SaveArticle()
        {
            var awaiter = Article.Save().GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    CtrlValidationHelper.ApplyValidationError(Article, CtrlUserControl);
                    if (Article.IsValid())
                    {
                        ((ArticleUserControl) CtrlUserControl).LockUserControl();
                    }
                });
            });
        }

        public void NewArticle()
        {
            var awaiter = Article.Save().GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Dispatcher.CurrentDispatcher.Invoke(async () =>
                {
                    ((ArticleUserControl)CtrlUserControl).UnlockUserControl();

                    Article = new CtrlArticle();
                    await Article.Save();
                    CtrlValidationHelper.ApplyValidationError(Article, CtrlUserControl);
                });
            });
        }
    }
}
