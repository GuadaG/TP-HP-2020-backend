using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Texere.Model
{
    public class Modelos
    {
        [Key]
        public int ModeloId { get; set; }

        [StringLength(20)]
        public string DescModelo { get; set; }

        // falta la imagen

        public virtual ICollection<LineasPedido> LineasPedido { get; set; }

        //  public virtual ICollection<Instituciones> Instituciones { get; set; }
        //  public virtual ICollection<Colores> Colores { get; set; }

    }
}
