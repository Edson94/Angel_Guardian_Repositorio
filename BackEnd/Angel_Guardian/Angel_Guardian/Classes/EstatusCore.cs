using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angel_Guardian.Controllers;
using Angel_Guardian.Models.ModelViews;
using Angel_Guardian.Models;

namespace Angel_Guardian.Classes
{
    public class EstatusCore
    {
        private AngelDbContext Db;
        public EstatusCore(AngelDbContext Db) { this.Db = Db; }
        public List<Estatus> get() {
            try { return this.Db.Estatus.ToList(); }
            catch (Exception) { throw; }
        }
    }
}
