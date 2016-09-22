using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudApiLib;
using CloudApiLib.Documents;

namespace CtrlBusinessLib
{
    public class CtrlException : CADocument<CtrlException>
    {
        static CtrlException()
        {
            CloudApi.RegisterObjectType<CtrlException>();
        }

        public string Name { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
    }
}
