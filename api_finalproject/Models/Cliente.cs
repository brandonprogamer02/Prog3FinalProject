using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace api_finalproject.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Ordens = new HashSet<Orden>();
        }

        public int Id { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
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
        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
