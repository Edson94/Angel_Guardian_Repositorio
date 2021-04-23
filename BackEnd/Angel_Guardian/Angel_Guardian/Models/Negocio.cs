using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Angel_Guardian.Models
{
    public class Negocio
    {
        [Key]
        public int IdNegocio { get; set; }
        public int IdImagen { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuario { get; set; }
        public int IdMunicipio { get; set; }
        public String Nombre { get; set; }
        public String RazonSocial { get; set; }
        public int PuntuacionPromedio { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public int NumeroInterior { get; set; }
        public DateTime Fecha { get; set; }
        public Boolean Activo { get; set; }

        [JsonIgnore]
        public virtual Imagen Imagen { get; set; }
        [JsonIgnore]
        public virtual Estado Estado { get; set; }
        [JsonIgnore]
        public virtual Municipio Municipio { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
        

        [JsonIgnore]
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Servicio> Servicio { get; set; }
    }
}
