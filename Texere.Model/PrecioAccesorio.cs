using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Texere.Model
{
    public class PrecioAccesorio
    {
        [Key]
        public int PrecioAccesorioId { get; set; }
        public DateTime FechaVigencia { get; set; }
        public float Valor { get; set; }
        public int AccesorioId { get; set; }

        public virtual Accesorios Accesorio { get; set; }
    }
}
