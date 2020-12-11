using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texere.Model;

namespace Texere.WebAPI.DTOs
{
    public class PedidosDTO
    {
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public string Estado { get; set; }
        public int EstadoId { get; set; }
        public string ClienteDni { get; set; }
        public string ClienteNombre { get; set; }
    }
}
