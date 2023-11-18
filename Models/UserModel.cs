using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sept2023WebAppMVC.Models
{
    public class UserModel
    {
        [Required]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please enter lastname")]
        public string Lastname { get; set; }
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date, ErrorMessage ="Please select date of birth")]
        public DateTime  DateOfBirth { get; set; }

        [Range(18,256,ErrorMessage ="please enter age should be above 18")]
        public int Age { get; set; }

        [Required(ErrorMessage ="Please enter address")]
        [DataType(DataType.MultilineText)]
        [StringLength(800, ErrorMessage ="please enter address should be between 10, 800",MinimumLength =10)]
        public string   Address { get; set; }

        [Required(ErrorMessage ="Please enter mobile number")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid mobile number")]
        public long MobileNumer { get; set; }

        [Required(ErrorMessage ="Please enter email")]
        [DataType(DataType.EmailAddress, ErrorMessage =" invalid email ")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter Username")]
        [MinLength(6,ErrorMessage ="please enter username should miniman 6 charecters")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="please enter password")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*\W)(?!.* ).{8,16}$",ErrorMessage = "the password must contain a single digit, one lowercase letter, one uppercase letter, one special character")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="doesn't matched with password")]
        public string ConformPassword { get; set; }

    }
}