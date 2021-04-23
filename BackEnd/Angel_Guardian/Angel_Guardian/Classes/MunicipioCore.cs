using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angel_Guardian.Controllers;
using Angel_Guardian.Models.ModelViews;
using Angel_Guardian.Models;

namespace Angel_Guardian.Classes
{
    public class MunicipioCore
    {
        private AngelDbContext Db;
        public MunicipioCore(AngelDbContext Db) { this.Db = Db; }
        public Municipio ChecarMunicipio(int IdMunicipio)
        {
            try { return this.Db.Municipio.FirstOrDefault(e => e.IdMunicipio == IdMunicipio); }
            catch (Exception) { throw; }
        }
        public List<Municipio> get(Municipio municipio)
        {
            try { return this.Db.Municipio.Where(e => e.IdEstado == municipio.IdEstado).ToList(); }
            catch (Exception) { throw; }
        }
    }
}
