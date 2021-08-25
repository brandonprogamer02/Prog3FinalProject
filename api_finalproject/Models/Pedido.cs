using System;
using System.Collections.Generic;

#nullable disable

namespace api_finalproject.Models
{
    public partial class Pedido
    {
        public int Id { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public int OrdenId { get; set; }
        public int EstadoPedidoId { get; set; }

        public virtual EstadoPedido EstadoPedido { get; set; }
        public virtual Orden Orden { get; set; }
    }
}
