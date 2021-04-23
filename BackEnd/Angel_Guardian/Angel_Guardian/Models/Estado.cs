using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Angel_Guardian.Models
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Direccion> Direccion { get; set; }
        [JsonIgnore]
        public virtual ICollection<Municipio> Municipio { get; set; }
        [JsonIgnore]
        public virtual ICollection<Negocio> Negocio { get; set; }
    }
}
