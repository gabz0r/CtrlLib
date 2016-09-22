using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CtrlApplication.Modules.Article;

namespace CtrlApplication.ModuleMapping
{
    public class ModuleDictionary
    {
        public static Dictionary<string, Tuple<Type, Type>> ModuleMapping = new Dictionary<string, Tuple<Type, Type>>
        {
            { "Article", new Tuple<Type, Type>(typeof(ArticleUserControl), typeof(ArticleViewModel)) }
        }; 
    }
}
