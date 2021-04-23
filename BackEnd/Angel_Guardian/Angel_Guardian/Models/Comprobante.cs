using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Angel_Guardian.Models
{
	public class Comprobante
	{
		[Key]
		public int IdComprobante { get; set; }
		public int IdUsuario { get; set; }
		public int IdNegocio { get; set; }
		public Boolean Efectivo { get; set; }
		public int IdEstatus { get; set; }
		public int IdDireccion { get; set; }
		public int Puntuacion { get; set; }
		public float Precio { get; set; }
		public float Pago { get; set; }
		public float Cambio { get; set; }
		public DateTime Fecha { get; set; }

		[JsonIgnore]
		public virtual Usuario Usuario { get; set; }
		[JsonIgnore]
		public virtual Negocio Negocio { get; set; }
		[JsonIgnore]
		public virtual Direccion Direccion { get; set; }
		[JsonIgnore]
		public virtual Estatus Estatus { get; set; }

		[JsonIgnore]
		public virtual ICollection<ComprobanteDetalle> ComprobanteDetalle { get; set; }
	}
}
