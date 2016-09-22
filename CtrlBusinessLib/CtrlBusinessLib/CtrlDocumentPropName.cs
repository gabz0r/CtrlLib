using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudApiLib;
using CloudApiLib.Documents;

namespace CtrlBusinessLib
{
    public class CtrlDocumentPropName : CADocument<CtrlDocumentPropName>
    {
        static CtrlDocumentPropName()
        {
            CloudApi.RegisterObjectType<CtrlDocumentPropName>();
        }

        public string CtrlDocumentName { get; set; }
        public Dictionary<string, string> PropertyNameLabelMapping { get; set; } 
    }
}
