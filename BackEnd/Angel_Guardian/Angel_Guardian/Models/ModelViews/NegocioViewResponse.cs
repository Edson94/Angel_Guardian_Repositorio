using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angel_Guardian.Models.ModelViews
{
    public class NegocioViewResponse
    {
        public int IdUsuario { get; set; }
        public int IdNegocio { get; set; }
        public String Nombre { get; set; }
        public String RazonSocial { get; set; }
        public int PuntuacionPromedio { get; set; }
        public String Direccion { get; set; }
        public String Imagen { get; set; }
        public String Ruta { get; set; }
    }
}
