using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Only alphabets are allowed")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Only alphabets are allowed")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("\\+998\\d{9}", ErrorMessage = "It should start with +998 followed by 9 digits")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Password should contain at least one uppercase and lowercase letter, one digit, and one special character and should have minimum 8 length")]
        public string Password { get; set; }
    }
}
