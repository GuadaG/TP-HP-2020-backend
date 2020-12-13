using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Texere.WebAPI.DTOs
{
    public class ModelosDTO
    {
        public string ModeloId { get; set; }
        public string DescModelo { get; set; }
        public string Imagen { get; set; }
        public byte[] ImagenByte { get; set; }
        public List<int> Instituciones { get; set; }
        public int ColorBase { get; set; }
        public int Color1 { get; set; }
    }
}
