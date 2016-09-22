using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudApiLib;
using CloudApiLib.Documents;

namespace CtrlBusinessLib
{
    class CtrlUser : CADocument<CtrlUser>
    {
        static CtrlUser()
        {
            CloudApi.RegisterObjectType<CtrlUser>();
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Link to CtrlMainMenuItem.MenuNodeId
        public List<string> MenuFavourites { get; set; } 
    }
}
