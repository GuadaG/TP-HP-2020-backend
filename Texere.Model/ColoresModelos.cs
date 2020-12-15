using System;
using System.Collections.Generic;
using System.Text;

namespace Texere.Model
{
    public class ColoresModelos
    {
        public int ColorId { get; set; }
        public virtual Colores Colores { get; set; }

        public int ModeloId { get; set; }
        public virtual Modelos Modelos { get; set; }

        public int Orden { get; set; }
    }
}
