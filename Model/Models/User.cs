using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [UIHint("User Name")]
        public string UserName { get; set; }
        [Required]
        [UIHint("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [UIHint("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [UIHint("Phone")]
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public string Role { get; set; }
    }
    public class RegisterUser
    {
        [Required]
        [UIHint("User Name")]
        public string UserName { get; set; }
        [Required]
        [UIHint("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [UIHint("Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        [UIHint("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [UIHint("Phone")]
        public string Phone { get; set; }
     

    }
    public class Login
    {
        [Required]
        [UIHint("User Name")]
        public string UserName { get; set; }
        [Required]
        [UIHint("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
