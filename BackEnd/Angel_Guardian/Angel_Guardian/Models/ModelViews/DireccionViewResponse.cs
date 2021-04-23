using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angel_Guardian.Models.ModelViews
{
    public class DireccionViewResponse
    {
        public String Estado { get; set; }
        public String Municipio { get; set; }
        public int Numero { get; set; }
        public String Calle { get; set; }
        public String Colonia { get; set; }
    }
}
