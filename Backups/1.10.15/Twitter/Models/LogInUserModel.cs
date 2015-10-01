﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LogInUserModel
    {
        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Passwrd
        {
            get { return password; }
            set 
            {
                if (value != null)
                    password = new PasswordEncryption().GetHashString(value);
                else password = value; 
            }
        }
        private string password;
    }
}
