using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography; 

namespace Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Please enter your full name")]
        [MaxLength(60, ErrorMessage = "Full name should contain maximum of 60 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        [MaxLength(60, ErrorMessage = "Username should contain maximum of 60 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Please enter a valid email address")]
        [MaxLength(100, ErrorMessage = "Email should contain maximum of 100 characters")]
        public string Email { get; set; }
       
        //[StringLength(60,MinimumLength= 8, ErrorMessage = "Minimum 8 characters")]
        //[MinLength(3, ErrorMessage = "Password must be at least 6 characters")]
        [Required(ErrorMessage = "Please enter your password")]
        [StringLength(60, MinimumLength = 5,ErrorMessage="5 chars minimum length!")]
        public string Passwrd 
        {
            get { return password; }
            set { password = new PasswordEncryption().GetHashString(value); }
        }
        private string password;
    }

}
