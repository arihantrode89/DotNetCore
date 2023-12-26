using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidation.Validation
{
    public class CustomModelValidation:ValidationAttribute
    {
        private int _year=2000;
        public CustomModelValidation(int year) 
        { 
            _year=year;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                var dob = (DateTime)value;
                if (dob.Year >= _year)
                {
                    return new ValidationResult(string.Format(ErrorMessage,_year));
                }

            }
            return null;
        }
    }
}
