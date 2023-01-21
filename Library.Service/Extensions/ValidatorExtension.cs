using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Extensions
{
    public static class ValidatorExtension
    {
        public static IList<ValidationResult> ValidateProperties(this object o)
        {
            var validationResult = new List<ValidationResult>();
            var context = new ValidationContext(o, null, null);
            Validator.TryValidateObject(o, context, validationResult, true);
            return validationResult;
        }
    }
}
