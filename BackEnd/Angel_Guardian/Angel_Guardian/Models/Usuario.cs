using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Angel_Guardian.Models
{
	public class Usuario
	{
		[Key]
		public int IdUsuario { get; set; }
		public String NickName { get; set; }
		[JsonIgnore]
		public String Password { get; set; }
		public String NombreUsuario { get; set; }
		public String ApellidoPaterno { get; set; }
		public String ApellidoMaterno { get; set; }
		public string Celular { get; set; }
		public String Email { get; set; }
		public Boolean Consumidor { get; set; }
		public DateTime Fecha { get; set; }

		[JsonIgnore]
		public virtual ICollection<Comprobante> Comprobantes { get; set; }
		[JsonIgnore]
		public virtual ICollection<Direccion> Direccion { get; set; }
		[JsonIgnore]
		public virtual ICollection<Negocio> Negocio { get; set; }
	}
}
