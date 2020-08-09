using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Texere.Model
{
    public class Materiales
    {
    [Key]
        public int MaterialId { get; set; }

        [StringLength(20)]
        public string DescMaterial { get; set; }

        public virtual ICollection<LineasPedido> LineasPedido { get; set; }
    }
}
