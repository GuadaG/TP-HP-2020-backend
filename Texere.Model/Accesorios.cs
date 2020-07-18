using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Texere.Model
{
    public class Accesorios
    {
        [Key]
        public int AccesorioId { get; set; }

        [StringLength(20)]
        public string Descripcion { get; set; }

        public bool TieneTalle { get; set; }

        public virtual ICollection<PrecioAccesorio> HistoricoPrecio { get; set; }
    }
}
