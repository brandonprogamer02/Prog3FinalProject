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
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Contrasena { get; set; }
        [Required]
        public int NumeroContacto { get; set; }
        [Required]
        public int Latitud { get; set; }
        [Required]
        public int Longitud { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
    }
}
