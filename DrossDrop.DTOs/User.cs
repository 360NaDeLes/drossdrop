using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DrossDrop.DTOs
{
    public class User
    {
        public int userId { get; set; }
        public int roleId { get; set; }
        public int cartId { get; set; }
        [Required(ErrorMessage = "Dit veld is vereist")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "Dit veld is vereist")]
        [StringLength(50, ErrorMessage = "Het wachtwoord moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required(ErrorMessage = "Dit veld is vereist")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Dit veld is vereist")]
        public string lastName { get; set; }
        public string salt { get; set; }
    }
}
