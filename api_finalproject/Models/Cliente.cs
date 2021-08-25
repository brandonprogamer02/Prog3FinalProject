using System;
using System.Collections.Generic;

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
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public int NumeroContacto { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
