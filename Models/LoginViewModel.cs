using System;
using System.ComponentModel.DataAnnotations;

namespace CarsCatalog.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        public string ReturnUrl { get; set; }

    }
}
