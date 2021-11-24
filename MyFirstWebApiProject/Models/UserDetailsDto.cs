using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApiProject.Models
{
    public class UserDetailsDto
    {
        [Required]
        [MaxLength(5, ErrorMessage = "LastName should not be more five characters")]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 5, ErrorMessage = "FirstName should  be between 5 and 8")]
        [Display ( Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        public string Title { get; set; }
        public int Age { get; set; }
        [ValidateAge(10, 18, ErrorMessage = "Age out of range")]
        public string Position { get; set; }
    }
     
    public class ValidateAge :ValidationAttribute
    {
        private readonly int _minAge, _maxAge;
        public ValidateAge(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

           int ageYear = Convert.ToDateTime(value).Year;
            var currentDate = DateTime.Now.Year;

            var age = currentDate - ageYear;
            if ((ageYear + age) > currentDate)
                age--;

            if (age >= _minAge && age <= _maxAge)
                return base.IsValid(age, validationContext);

            return base.IsValid(value, validationContext);
        }
    }
}
