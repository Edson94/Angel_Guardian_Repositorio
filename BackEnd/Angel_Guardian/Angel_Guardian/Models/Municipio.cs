using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angel_Guardian.Models
{
    public class Municipio
    {
        public int IdMunicipio { get; set; }
        public String Nombre { get; set; }
        public int IdEstado { get; set; }

        [JsonIgnore]
        public virtual Estado Estado { get; set ;}

        [JsonIgnore]
        public virtual ICollection<Direccion> Direccion { get; set; }
        [JsonIgnore]
        public virtual ICollection<Negocio> Negocio { get; set; }

    }
}
