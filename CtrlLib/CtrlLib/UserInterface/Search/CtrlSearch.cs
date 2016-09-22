using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudApiLib.Documents;
using CtrlLib.Module;
using CtrlLib.UserInterface.Controls.Host;
using CtrlLib.UserInterface.Mvvm;

namespace CtrlLib.UserInterface.Search
{
    public class CtrlSearch
    {
        public Type DocumentSearchType { get; set; }
        public string SearchWindowHeader { get; set; }
        public CtrlBaseUserControl ParentUserControl { get; set; }

        public delegate void OnSearchCompleteDelegate(object iResults);
        public event OnSearchCompleteDelegate OnSearchComplete;

        public static object DoSearch(CtrlSearch iSearchParam)
        {
            if (iSearchParam.ParentUserControl == null)
            {
                throw new Exception("ParentUserControl can not be null.");
            }

            var searchWnd = new CtrlWindow();

            var mod = CtrlModuleStarter.LoadModule<CtrlSearchUserControl, CtrlSearchViewModel>(iSearchParam.ParentUserControl);
            mod.RenderType = ModuleRenderType.Normal;
            mod.DisplayType = ModuleDisplayType.ModalDialog;

            mod.ModuleParam = new Dictionary<string, object>
            {
                { "SEARCH_PARAM", iSearchParam }
            };

            searchWnd.Height = 830;
            searchWnd.Width = 1150;

            searchWnd.Title = iSearchParam.SearchWindowHeader;

            searchWnd.StartModule(mod);

            return null;
        }

        public void ReturnResult(object iResult)
        {
            if (OnSearchComplete != null)
            {
                OnSearchComplete(iResult);
                OnSearchComplete = null;
            }
        }
    }
}
