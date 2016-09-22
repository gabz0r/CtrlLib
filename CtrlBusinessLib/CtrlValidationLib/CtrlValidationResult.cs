using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CtrlValidationLib
{
    public class CtrlValidationResult
    {
        public PropertyInfo Property { get; set; }
        public bool IsValid { get; set; }
        public string ValidationError { get; set; }
    }
}
