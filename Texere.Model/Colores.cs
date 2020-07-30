using System;
using System.ComponentModel.DataAnnotations;

namespace Texere.Model
{
    public class Colores
    {
        [Key]
        public int ColorId { get; set; }

        [StringLength(20)]
        public string Descripcion { get; set; }
    }
}
