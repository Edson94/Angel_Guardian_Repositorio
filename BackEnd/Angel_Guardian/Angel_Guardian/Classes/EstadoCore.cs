using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angel_Guardian.Controllers;
using Angel_Guardian.Models;

namespace Angel_Guardian.Classes
{
    public class EstadoCore
    {
        private AngelDbContext Db;
        public EstadoCore(AngelDbContext Db) { this.Db = Db; }
        public Estado ChecarEstado(int IdEstado) {
            try { return this.Db.Estado.FirstOrDefault(e => e.IdEstado == IdEstado); }
            catch (Exception) { throw; }
        }
        public List<Estado> GetEstados()
        {
            List<Estado> estados = new List<Estado>();
            try {
                estados = (from s in Db.Estado select s).ToList();
            }
            catch (Exception) { throw; }
            return estados;
        }
    }
}
