using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Texere.WebAPI.DTOs
{
    public class InstitucionesDTO
    {
        public int InstitucionId { get; set; }
        public string DescInstitucion { get; set; }
        public int ModeloId { get; set; }
        public string DescModelo { get; set; }
        public byte[] Imagen { get; set; }
    }
}
