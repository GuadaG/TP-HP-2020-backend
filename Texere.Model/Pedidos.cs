using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Texere.Model
{
    public class Pedidos
    {
        [Key]
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; }
        public Estados Estado { get; set; }
        
        public int ClienteId { get; set; }
        public virtual Clientes Cliente { get; set; }

        public virtual ICollection<LineaPedido> LineaPedido { get; set; }
    }

    //public enum Estados
    //{   Pendiente = 0,
    //    EnCurso = 1,
    //    Finalizado = 2,
    //    Cancelado = 3
    //}
}
