using System;
using System.Collections.Generic;

#nullable disable

namespace api_finalproject.Models
{
    public partial class DetalleOrden
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int OrdenId { get; set; }

        public virtual Orden Orden { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
