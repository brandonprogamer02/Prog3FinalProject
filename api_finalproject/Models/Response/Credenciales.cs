using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_finalproject.Models.Response
{
    public class Credenciales
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
