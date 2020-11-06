using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Texere.WebAPI.DTOs
{
    public class PedidosDTO
    {
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public string Estado { get; set; }
    }
}
