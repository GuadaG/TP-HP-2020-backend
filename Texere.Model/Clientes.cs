using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Texere.Model
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [StringLength(15)]
        public string DniCuit { get; set; }

        [StringLength(50)]
        public int NombreApellido { get; set; }

        [StringLength(20)]
        public int Telefono { get; set; }

        [StringLength(30)]
        public int Email { get; set; }

        [StringLength(30)]
        public int Domicilio { get; set; }

        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
