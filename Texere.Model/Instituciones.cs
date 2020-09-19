using System;
using System.ComponentModel.DataAnnotations;

namespace Texere.Model
{
    public class Instituciones
    {
        [Key]
        public int InstitucionId { get; set; }

        [StringLength(60)]
        public string Descripcion { get; set; }

        public int? ModeloId { get; set; }
        public virtual Modelos Modelo { get; set; }
    }
}
