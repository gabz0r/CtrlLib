using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlLib.Helper
{
    public class CtrlSingleton<T> where T : class
    {
        private static readonly Lazy<T> InstanceHolder = new Lazy<T>(CreateInstance);
        public static T Instance => InstanceHolder.Value;

        private static T CreateInstance()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }
    }
}
