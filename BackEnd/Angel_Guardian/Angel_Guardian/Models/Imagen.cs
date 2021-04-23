using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Angel_Guardian.Models
{
    public class Imagen
    {
        [Key]
        public int IdImagen { get; set; }
        public String Nombre { get; set; }
        public String Ruta { get; set; }
        public double Size { get; set; }
        public DateTime Fecha { get; set; }

        [JsonIgnore]
        public virtual ICollection<Negocio> Negocio { get; set; }
    }
}
