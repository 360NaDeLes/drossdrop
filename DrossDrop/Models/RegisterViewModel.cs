﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrossDrop.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Dit veld is vereist")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Dit veld is vereist")]
        public string lastName { get; set; }
        
        [Required(ErrorMessage = "Dit veld is vereist")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Dit veld is vereist")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}