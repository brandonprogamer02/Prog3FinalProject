﻿using System;
using System.Collections.Generic;

#nullable disable

namespace api_finalproject.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }
}
