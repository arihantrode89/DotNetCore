using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class PersonRegister
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Enter proper email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="Password and Confirm Password should be same")]
        [DataType(DataType.Password)]

        public string ConfirmPassword {  get; set; }
    }
}
