using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Angel_Guardian.Models
{
    public class Direccion
    {
        [Key]
        public int IdDireccion { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }
        public int IdMunicipio { get; set; }
        public String Calle { get; set; }
        public String Colonia { get; set; }
        public int NumeroInterior { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
        [JsonIgnore]
        public virtual Estado Estado { get; set; }
        [JsonIgnore]
        public virtual Municipio Municipio { get; set; }

        [JsonIgnore]
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
