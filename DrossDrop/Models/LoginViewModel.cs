using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrossDrop.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Dit veld is vereist")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Dit veld is vereist")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
