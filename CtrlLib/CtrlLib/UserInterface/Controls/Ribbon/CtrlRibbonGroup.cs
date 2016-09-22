using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlLib.UserInterface.Controls.Ribbon
{
    public class CtrlRibbonGroup
    {
        public CtrlRibbonGroup()
        {
            CtrlRibbonItems = new List<CtrlRibbonItem>();
        }

        public CtrlRibbonGroup(string iHeader)
        {
            CtrlHeader = iHeader;
            CtrlRibbonItems = new List<CtrlRibbonItem>();
        }

        public string CtrlHeader { get; set; }
        public List<CtrlRibbonItem> CtrlRibbonItems;
    }
}
