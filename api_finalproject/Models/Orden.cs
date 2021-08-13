using System;
using System.Collections.Generic;

#nullable disable

namespace api_finalproject.Models
{
    public partial class Orden
    {
        public Orden()
        {
            DetalleOrdens = new HashSet<DetalleOrden>();
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string ComentarioDireccion { get; set; }
        public int EstadoOrdenId { get; set; }
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual EstadoOrden EstadoOrden { get; set; }
        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
