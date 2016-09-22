using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CtrlLib.Commands
{
    public class CtrlCommands
    {
        public static readonly CtrlCommand CtrlAddToFavourites = new CtrlCommand("CtrlAddToFavourites", "CtrlAddToFavourites", typeof(CtrlCommands));
        public static readonly CtrlCommand CtrlRemoveFromFavourites = new CtrlCommand("CtrlRemoveFromFavourites", "CtrlRemoveFromFavourites", typeof(CtrlCommands));

        public static readonly CtrlCommand CtrlNew = new CtrlCommand("CtrlNew", "CtrlNew", typeof(CtrlCommands));
        public static readonly CtrlCommand CtrlSave = new CtrlCommand("CtrlSave", "CtrlSave", typeof(CtrlCommands));
        public static readonly CtrlCommand CtrlDelete = new CtrlCommand("CtrlDelete", "CtrlDelete", typeof(CtrlCommands));
        public static readonly CtrlCommand CtrlSearch = new CtrlCommand("CtrlSearch", "CtrlSearch", typeof(CtrlCommands));
    }
}
