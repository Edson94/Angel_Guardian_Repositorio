using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angel_Guardian.Controllers;
using Angel_Guardian.Models;

namespace Angel_Guardian.Classes
{
    public class ServicioCore
    {
        private AngelDbContext Db;
        public ServicioCore(AngelDbContext Db) { this.Db = Db; }
        public List<Servicio> get(Servicio servicio) {
            try { return this.Db.Servicio.Where(e => e.IdNegocio == servicio.IdNegocio && e.Activo == true).ToList(); }
            catch (Exception) { throw; }
        }
        public List<Servicio> set(Servicio servicio) {
            try {
                Servicio servicio1 = this.Db.Servicio.FirstOrDefault(e => e.Nombre == servicio.Nombre
                    && e.IdNegocio == servicio.IdNegocio);
                if (servicio1 == null)
                {
                    servicio.Fecha = DateTime.Now;
                    servicio.Activo = true;
                    this.Db.Servicio.Add(servicio);
                }
                else
                {
                    if (servicio.Activo == false)
                        servicio1.Activo = true;
                    else
                    {
                        servicio1.Descripcion = servicio.Descripcion;
                        servicio1.Duracion = servicio.Duracion;
                        servicio1.Precio = servicio.Precio;
                    }
                    this.Db.Servicio.Update(servicio1);
                }
                this.Db.SaveChanges();
                return this.Db.Servicio.Where(e => e.IdNegocio == servicio.IdNegocio && e.Activo == true).ToList();
            }
            catch (Exception) { throw; }
        }
        public List<Servicio> delete(Servicio servicio)
        {
            try {
                Servicio servicio1 = this.Db.Servicio.FirstOrDefault(e => e.IdServicio == servicio.IdServicio);
                if (servicio1 != null) {
                    servicio1.Activo = false;

                    this.Db.Servicio.Update(servicio1);
                    this.Db.SaveChanges();
                }
                return this.Db.Servicio.Where(e => e.IdNegocio == servicio1.IdNegocio && e.Activo == true).ToList();
            }
            catch (Exception) { throw; }
        }
    }
}
