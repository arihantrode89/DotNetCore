namespace ViewComponentExample.Models
{
    public class Person
    {
        public string PersonName { get; set; }
        public string Email { get; set; }
        public PersonGender Gender { get; set; }
    }

    public enum PersonGender
    {
        Male,Female,Other
    }
}
