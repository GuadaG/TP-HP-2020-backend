﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Texere.Model
{
    public class Estados
    {
        [Key]
        public int EstadoId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pedidos> Pedidos { get; set; }
        public virtual ICollection<LineasPedido> LineasPedido { get; set; }
    }

    public enum EstadosEnum
    {
        Pendiente = 1,
        EnCurso = 2,
        Finalizado = 3,
        Cancelado = 4
    }
}
