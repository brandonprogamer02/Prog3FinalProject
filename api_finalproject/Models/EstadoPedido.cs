using System;
using System.Collections.Generic;

#nullable disable

namespace api_finalproject.Models
{
    public partial class EstadoPedido
    {
        public EstadoPedido()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
