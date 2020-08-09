using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Texere.Model
{
    public class Talles
    {
        [Key]
        public int TalleId { get; set; }

        [StringLength(20)]
        public string DescTalle { get; set; }

        public int Medida { get; set; }

        public virtual ICollection<LineaPedido> LineaPedidos { get; set; }
    }
}
