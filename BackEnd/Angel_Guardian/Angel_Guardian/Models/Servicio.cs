using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Angel_Guardian.Models
{
    public class Servicio
    {
		[Key]
		public int IdServicio { get; set; }
		public int IdNegocio { get; set; }
		public int Puntuacion { get; set; }
		public String Nombre { get; set; }
		public String Descripcion { get; set; }
		public double Duracion { get; set; }
		public double Precio { get; set; }
		public DateTime Fecha { get; set; }
		public bool Activo { get; set; }

		[JsonIgnore]
		public virtual Negocio Negocio { get; set; }

		[JsonIgnore]
		public virtual ICollection<ComprobanteDetalle> ComprobanteDetalle { get; set; }
	}
}
