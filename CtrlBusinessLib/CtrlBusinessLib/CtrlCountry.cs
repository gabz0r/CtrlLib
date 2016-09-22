using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudApiLib;
using CloudApiLib.Documents;

namespace CtrlBusinessLib
{
    public class CtrlCountry : CADocument<CtrlCountry>
    {
        static CtrlCountry()
        {
            CloudApi.RegisterObjectType<CtrlCountry>();
        }

        public string Code { get; set; }
        public string FullName { get; set; }
    }
}
