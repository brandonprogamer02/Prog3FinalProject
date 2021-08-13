using System;
using System.Collections.Generic;

#nullable disable

namespace api_finalproject.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleOrdens = new HashSet<DetalleOrden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categorium Categoria { get; set; }
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
    }
}
