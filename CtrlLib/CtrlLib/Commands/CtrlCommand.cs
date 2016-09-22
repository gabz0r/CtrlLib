using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace CtrlLib.Commands
{
    public class CtrlCommand : RoutedUICommand
    {
        public CtrlCommand(string iText, string iName, Type iOwner, bool iGlobalCommand = false) : base(iText, iName, iOwner)
        {
            CtrlGlobalCommand = iGlobalCommand;
        }

        public bool CtrlGlobalCommand { get; set; }
    }
}
