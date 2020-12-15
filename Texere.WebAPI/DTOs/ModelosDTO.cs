using System.Collections.Generic;

namespace Texere.WebAPI.DTOs
{
    public class ModelosDTO
    {
        public int ModeloId { get; set; }
        public string DescModelo { get; set; }
        public string Imagen { get; set; }
        public int ColorBaseId { get; set; }
        public List<int> Instituciones { get; set; }
        public List<int> Colores { get; set; }
    }
}
