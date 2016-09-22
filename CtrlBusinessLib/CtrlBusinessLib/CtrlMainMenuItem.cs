using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudApiLib;
using CloudApiLib.Documents;
using CloudApiLib.Triggers;

namespace CtrlBusinessLib
{
    public class CtrlMainMenuItem : CADocument<CtrlMainMenuItem>
    {
        static CtrlMainMenuItem()
        {
            CloudApi.RegisterObjectType<CtrlMainMenuItem>();
        }

        public string MenuNodeId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string AssociatedModule { get; set; }

        [CAMethod]
        public static async Task AddItemAsFavourite(string iUsername, string iNodeId)
        {
            var user = await CtrlUser.FindOne(u => u.Username == iUsername);

            if (user == null)
                return;

            if (user.MenuFavourites == null)
                user.MenuFavourites = new List<string>();
            
            user.MenuFavourites.Add(iNodeId);

            await user.Update();
        }

        [CAMethod]
        public static async Task RemoveItemFromFavourites(string iUsername, string iNodeId)
        {
            var user = await CtrlUser.FindOne(u => u.Username == iUsername);

            if (user == null)
                return;

            user.MenuFavourites.Remove(iNodeId);

            await user.Update();
        }
    }
}
