using ModelBindingAndValidation.Model;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelBindingAndValidation.Validation
{
    public class CustomReferenceModelValidation:ValidationAttribute
    {
        private string _propName;
        public CustomReferenceModelValidation() { }

        public CustomReferenceModelValidation(string propertyName)
        {
            _propName = propertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if(!string.IsNullOrEmpty(_propName))
                {
                    PropertyInfo obj = validationContext.ObjectType.GetProperty(_propName);
                    var val = (DateTime)obj.GetValue(validationContext.ObjectInstance);
                    var Todate = ((DateTime)value).Date;
                    if (val.Date > Todate)
                    {
                        return new ValidationResult(string.Format(ErrorMessage, _propName, validationContext.MemberName));
                    }
                }
                return null;
            }
            return null;
        }
    }
}
