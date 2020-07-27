using System;
using System.ComponentModel.DataAnnotations;

namespace Texere.Model
{
    public class Institucion
    {
        [Key]
        public int InstitucionId { get; set; }

        [StringLength(20)]
        public string Descripcion { get; set; }
    }
}
