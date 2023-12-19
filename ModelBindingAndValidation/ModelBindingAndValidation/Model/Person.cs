using Microsoft.AspNetCore.Mvc;
using ModelBindingAndValidation.Validation;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidation.Model
{
    public class Person
    {
        //[FromQuery]
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [CustomModelValidation(2000,ErrorMessage ="Date of Birth year should be less than {0}")]
        public DateTime Dob {  get; set; }
        public DateTime FromDate { get; set; }

        [CustomReferenceModelValidation("FromDate",ErrorMessage ="{1} should not be greater than {0}")]
        public DateTime ToDate { get; set; }

        public override string ToString()
        {
            return $"Person : {Id} {Name} {Dob}";
        }
    }
}
