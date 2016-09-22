using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CtrlLib.UserInterface.Mvvm;

namespace CtrlLib.Module
{
    public class CtrlModuleStarter
    {
        public CtrlBaseUserControl UserControl { get; set; }
        public Dictionary<string, object> ModuleParam { get; set; }

        public CtrlBaseUserControl ParentUserControl { get; set; }

        public ModuleRenderType RenderType { get; set; }
        public ModuleDisplayType DisplayType { get; set; }

        public static CtrlModuleStarter LoadModule<TUC, TVM>(CtrlBaseUserControl iParent = null)
        {
            var uc = Activator.CreateInstance<TUC>() as CtrlBaseUserControl;
            uc.CtrlViewModel = Activator.CreateInstance<TVM>() as CtrlBaseViewModel;

            return new CtrlModuleStarter { UserControl = uc,  ParentUserControl = iParent };
        }

        public static CtrlModuleStarter LoadModule(Type iUserControlType, Type iViewModelType)
        {
            var uc = Activator.CreateInstance(iUserControlType) as CtrlBaseUserControl;
            uc.CtrlViewModel = Activator.CreateInstance(iViewModelType) as CtrlBaseViewModel;

            return new CtrlModuleStarter { UserControl = uc };
        }
    }
}
