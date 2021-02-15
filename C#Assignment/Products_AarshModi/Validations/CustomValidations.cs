using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products_AarshModi.Validations
{
    public class DateRangeAttribute : ValidationAttribute, System.Web.Mvc.IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage =
            FormatErrorMessage(metadata.GetDisplayName());           
            rule.ValidationType = "daterange";
            yield return rule;
        }

        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            bool x = dateTime < DateTime.Now;
            return x;
        }
    }


}
