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
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Passwrd 
        {
            get { return password; }
            set { password = new PasswordEncryption().GetHashString(value); }
        }
        private string password;
    }

}
