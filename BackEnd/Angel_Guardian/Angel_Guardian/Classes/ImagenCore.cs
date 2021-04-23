using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angel_Guardian.Controllers;
using Angel_Guardian.Models.ModelViews;
using Angel_Guardian.Models;

namespace Angel_Guardian.Classes
{
    public class ImagenCore
    {
        private AngelDbContext Db;
        public ImagenCore(AngelDbContext Db) { this.Db = Db; }
        public Imagen ChecarImagen(int IdImagen)
        {
            try { return this.Db.Imagen.FirstOrDefault(e => e.IdImagen == IdImagen); }
            catch (Exception) { throw; }
        }
        public List<Imagen> get()
        {
            try { return this.Db.Imagen.ToList(); }
            catch (Exception) { throw; }
        }
        public List<Imagen> set(Imagen imagen) {
            try {
                Imagen img = this.Db.Imagen.FirstOrDefault(e => e.Nombre == imagen.Nombre);
                if (img != null)
                    return null;
                
                imagen.Fecha = DateTime.Now;
                
                this.Db.Imagen.Add(imagen);
                this.Db.SaveChanges();
                
                return get();
            }
            catch (Exception) { throw; }
        }
    }
}
