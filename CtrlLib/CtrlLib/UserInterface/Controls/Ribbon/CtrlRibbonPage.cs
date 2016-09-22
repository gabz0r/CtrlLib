using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlLib.UserInterface.Controls.Ribbon
{
    public class CtrlRibbonPage
    {
        public CtrlRibbonPage()
        {
            CtrlRibbonGroups = new List<CtrlRibbonGroup>();
        }

        public CtrlRibbonPage(string iHeader)
        {
            CtrlHeader = iHeader;
            CtrlRibbonGroups = new List<CtrlRibbonGroup>();
        }

        public string CtrlHeader { get; set; }
        public List<CtrlRibbonGroup> CtrlRibbonGroups { get; set; }

        public bool CtrlIsMainPage { get; set; }

        public decimal CtrlOrder { get; set; } = 1;
    }
}
