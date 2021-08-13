using System;
using System.Collections.Generic;

#nullable disable

namespace api_finalproject.Models
{
    public partial class EstadoOrden
    {
        public EstadoOrden()
        {
            Ordens = new HashSet<Orden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
