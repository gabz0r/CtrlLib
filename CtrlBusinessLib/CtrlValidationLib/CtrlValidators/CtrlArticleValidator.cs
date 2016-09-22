using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CloudApiLib;
using CloudApiLib.Documents;

namespace CtrlValidationLib.CtrlValidators
{
    public class CtrlArticleValidator
    {
        public static async Task<CtrlValidationResult> ValidateProperty(PropertyInfo iProperty, object iPropertyValue, CADocumentModification iModificationType)
        {
            var propName = iProperty.Name;

            switch (propName)
            {
                case "ArticleId":
                {

                    var val = iPropertyValue as string;
                    if (iModificationType == CADocumentModification.Create)
                    {
                        var articleExists = await CtrlArticle.FindOne(article => article.ArticleId == val);
                        if (articleExists != null)
                        {
                            return new CtrlValidationResult { Property = iProperty, IsValid = false, ValidationError = "Artikelnummer ist bereits vergeben." };
                        }
                    }

                    if (string.IsNullOrEmpty(val))
                    {
                        return new CtrlValidationResult {Property = iProperty, IsValid = false, ValidationError = "Feld muss gefüllt sein."};
                    }

                    break;
                }
            }

            return new CtrlValidationResult {Property = iProperty, IsValid = true};
        }
    }
}
