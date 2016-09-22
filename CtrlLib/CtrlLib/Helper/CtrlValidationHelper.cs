using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CtrlLib.UserInterface.Controls.Editors;
using CtrlLib.UserInterface.Mvvm;
using CtrlValidationLib;

namespace CtrlLib.Helper
{
    public class CtrlValidationHelper
    {
        public static void ApplyValidationError(object iDocument, CtrlBaseUserControl iUserControl)
        {
            var fi = iDocument.GetType().GetField("InvalidFields");
            var iResults = fi.GetValue(iDocument) as List<CtrlValidationResult>;

            if (iResults == null) return;

            var validateControls = CtrlUiHelper.FindVisualChildren<CtrlTextBox>(iUserControl);
            foreach (var control in validateControls)
            {
                var bindingExp = control.GetBindingExpression(CtrlTextBox.TextProperty);
                if (bindingExp != null)
                {
                    if (iResults.Count(val => val.Property.Name == bindingExp.ResolvedSourcePropertyName) > 0)
                    {
                        control.CtrlIsValid = false;

                        var hint =
                            iResults.First(res => res.Property.Name == bindingExp.ResolvedSourcePropertyName);

                        control.ToolTip = hint.ValidationError;
                    }
                    else
                    {
                        control.CtrlIsValid = true;
                        control.ToolTip = null;
                    }
                }
            }
        }
    }
}
