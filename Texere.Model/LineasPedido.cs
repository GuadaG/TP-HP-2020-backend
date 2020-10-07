using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Texere.Model
{
	public class LineasPedido
	{
		[Key]
		public int LineaPedidoId { get; set; }
		public int Cantidad { get; set; }
		public Estados Estado { get; set; }
		[StringLength(50)]
		public string Observaciones { get; set; }
		//public float? TotalLinea { get; set; }

		public virtual Pedidos Pedido { get; set; }
		public int PedidoId { get; set; }

		public virtual Talles Talle { get; set; }
		public int? TalleId { get; set; }

		public virtual Accesorios Accesorio { get; set; }
		public int AccesorioId { get; set; }

		public virtual Materiales Material { get; set; }
		public int MaterialId { get; set; }

		public virtual Modelos Modelo { get; set; }
		public int ModeloId { get; set; }
	}
}	