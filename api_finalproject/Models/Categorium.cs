using System;
using System.Collections.Generic;

#nullable disable

namespace api_finalproject.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public int Nombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
