using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Angel_Guardian.Models
{
    public class ComprobanteDetalle
    {
        [Key]
        public int IdComprobanteDetalle { get; set; }
        public int IdComprobante { get; set; }
        public int IdServicio { get; set; }
        public int IdEstatus { get; set; }
        public int Puntuacion { get; set; }
        public float Precio { get; set; }
        public float? Cambio { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }

        [JsonIgnore]
        public virtual Comprobante Comprobante { get; set; }
        [JsonIgnore]
        public virtual Servicio Servicio { get; set; }
        [JsonIgnore]
        public virtual Estatus Estatus { get; set; }

    }
}
