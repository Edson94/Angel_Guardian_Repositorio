using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angel_Guardian.Controllers;
using Angel_Guardian.Models;
using Angel_Guardian.Models.ModelViews;

namespace Angel_Guardian.Classes
{
    public class DireccionCore
    {
        private AngelDbContext Db;
        public DireccionCore(AngelDbContext Db) { this.Db = Db; }
        public List<DireccionViewResponse> get(Direccion direccion)
        {
            try {
                return (from s in this.Db.Direccion
                        join e in this.Db.Estado on s.IdEstado equals e.IdEstado
                        join m in this.Db.Municipio on s.IdMunicipio equals m.IdMunicipio
                        join u in this.Db.Usuario on s.IdUsuario equals u.IdUsuario
                        where s.IdUsuario == direccion.IdUsuario 
                        select new DireccionViewResponse
                        {
                            Estado = e.Nombre,
                            Municipio = m.Nombre,
                            Calle = s.Calle,
                            Colonia = s.Colonia,
                            Numero = s.NumeroInterior
                        }).ToList();
            }
            catch (Exception) { throw; }
        }
        public List<DireccionViewResponse> set(Direccion direccion)
        {
            try {
                Direccion direc = this.Db.Direccion.FirstOrDefault(e => e.IdDireccion == direccion.IdDireccion);
                if (direc != null)
                {
                    direc.IdEstado = direccion.IdEstado;
                    direc.IdMunicipio = direccion.IdMunicipio;
                    direc.Calle = direccion.Calle;
                    direc.Colonia = direccion.Colonia;
                    direc.NumeroInterior = direccion.NumeroInterior;

                    this.Db.Update(direc);
                }
                else
                {
                    direccion.IdDireccion = this.Db.Direccion.ToList().Count + 1;
                    this.Db.Add(direccion);
                }
                this.Db.SaveChanges();

                return get(direccion);
            }
            catch (Exception) { throw; }
        }
        public List<DireccionViewResponse> remove(Direccion direccion)
        {
            try {
                Direccion direc = this.Db.Direccion.FirstOrDefault(e => e.IdDireccion == direccion.IdDireccion);
                if (direc == null)
                    return null;
                else
                {
                    this.Db.Direccion.Remove(direc);
                    this.Db.SaveChanges();
                }
                return this.get(direc);
            }
            catch (Exception) { throw; }
        }
    }
}
