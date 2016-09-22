using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CloudApiLib;
using CloudApiLib.Documents;
using CtrlValidationLib.CtrlValidators;

namespace CtrlValidationLib
{
    public class CtrlValidation
    {
        private static Dictionary<Type, Type> _validatorMapping = new Dictionary<Type, Type>
        {
            { typeof(CtrlArticle), typeof(CtrlArticleValidator) }
        }; 

        public static async Task<CtrlValidationResult> Validate(object iTypeInstance, PropertyInfo iProperty, CADocumentModification iModificationType)
        {
            var propVal = iProperty.GetValue(iTypeInstance);
            if (!_validatorMapping.ContainsKey(iTypeInstance.GetType()))
                return new CtrlValidationResult {IsValid = true};

            var validator = _validatorMapping[iTypeInstance.GetType()];
            return await (Task<CtrlValidationResult>) validator.GetMethod("ValidateProperty").Invoke(null, new[] {iProperty, propVal, iModificationType});
        } 
    }
}
