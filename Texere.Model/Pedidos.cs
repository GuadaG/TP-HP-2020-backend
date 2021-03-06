﻿using System;
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

        public int ClienteId { get; set; }
        public virtual Clientes Cliente { get; set; }

        public int EstadoId { get; set; }
        public virtual Estados Estado { get; set; }

        public virtual ICollection<LineasPedido> LineasPedido { get; set; }
    }
}
