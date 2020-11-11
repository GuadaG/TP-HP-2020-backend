using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.WebAPI.DTOs
{
    public class LineasPedidoDTO
    {
        public int LineaPedidoId { get; set; }
        public int Cantidad { get; set; }
        public int AccesorioId { get; set; }
        public string Material { get; set; }
        public string Accesorio { get; set; }
        public string Modelo { get; set; }
        public int Estado { get; set; }
        public string Talle { get; set; }
        public float TotalLinea { get; set; }
    }
}
