using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CloudApiLib;
using CtrlLib.Helper;

namespace CtrlLib.Session
{
    public class CtrlSession : CtrlSingleton<CtrlSession>
    {
        private Dictionary<string, object> _sessionData;
        
        public CtrlUser CurrentUser { get; set; }

        public object this[string iKey]
        {
            get
            {
                if (_sessionData != null && _sessionData.ContainsKey(iKey))
                    return _sessionData[iKey];

                return null;
            }
            set
            {
                if (_sessionData == null)
                    _sessionData = new Dictionary<string, object>();

                if (_sessionData.ContainsKey(iKey))
                {
                    _sessionData[iKey] = value;
                    return;
                }
                _sessionData.Add(iKey, value);
            }
        }

        public async Task<bool> StartSession()
        {
            if (CurrentUser == null)
                return false;

            var res = await CtrlUser.FindOne(u => u.Username == CurrentUser.Username && 
                                                  u.Password == CurrentUser.Password);

            if (res == null)
                return false;

            CurrentUser = res;

            return true;
        }

        public async Task SyncUser()
        {
            CurrentUser = await CtrlUser.FindOne(u => u.Username == CurrentUser.Username &&
                                                 u.Password == CurrentUser.Password);
        }
    }
}
