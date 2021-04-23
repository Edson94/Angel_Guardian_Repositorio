using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Angel_Guardian.Models
{
    public class Estatus
    {
        [Key]
        public int IdEstatus { get; set; }
        public String Nombre { get; set; }
        public DateTime Fecha { get; set; }

        [JsonIgnore]
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
