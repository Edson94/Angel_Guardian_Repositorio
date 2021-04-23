using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angel_Guardian.Controllers;
using Angel_Guardian.Models.ModelViews;
using Angel_Guardian.Models;


namespace Angel_Guardian.Classes
{
    public class NegocioCore
    {
        private AngelDbContext Db;
        public NegocioCore(AngelDbContext Db) { this.Db = Db; }
        public Negocio ChecarNegocio(int IdNegocio){
            try { return this.Db.Negocio.FirstOrDefault(e => e.IdNegocio == IdNegocio); }
            catch (Exception) { throw; }
        }
        public List<NegocioViewResponse> get(Negocio negocio) {
            try {
                var consulta = (from n in this.Db.Negocio
                                join sta in this.Db.Estado on n.IdEstado equals sta.IdEstado
                                join ima in this.Db.Imagen on n.IdImagen equals ima.IdImagen
                                join muni in this.Db.Municipio on n.IdMunicipio equals muni.IdMunicipio
                                where n.IdUsuario == negocio.IdUsuario && n.Activo == true
                                select new {
                                    IdUsuario = n.IdUsuario,
                                    IdNegocio = n.IdNegocio,
                                    Nombre = n.Nombre,
                                    RazonSocial = n.RazonSocial,
                                    Puntuacion = n.PuntuacionPromedio,
                                    Direccion = String.Concat(n.Calle," ",n.NumeroInterior.ToString()," "
                                        ,n.Colonia," ",sta.Nombre,",",muni.Nombre),
                                    Imagen = ima.Nombre,
                                    Ruta = ima.Ruta
                                }).ToList();
                return consulta.Select(y => new NegocioViewResponse() {
                    IdNegocio = y.IdNegocio,
                    Nombre = y.Nombre,
                    RazonSocial = y.RazonSocial,
                    PuntuacionPromedio = y.Puntuacion,
                    Direccion = y.Direccion,
                    Imagen = y.Imagen,
                    Ruta = y.Ruta
                }).ToList();
            }
            catch (Exception) { throw; }
        }
        public List<NegocioViewResponse> set(Negocio negocio)
        {
            try {
                Negocio negocio1 = this.Db.Negocio.FirstOrDefault(e => e.Nombre == negocio.Nombre);
                if (negocio1 != null)
                {
                    if (negocio1.Activo == false)
                        negocio1.Activo = true;
                    else
                    {
                        negocio1.IdImagen = negocio.IdImagen;
                        negocio1.IdEstado = negocio.IdEstado;
                        negocio1.IdMunicipio = negocio.IdMunicipio;
                        negocio1.Calle = negocio.Calle;
                        negocio1.Colonia = negocio.Colonia;
                        negocio1.NumeroInterior = negocio.NumeroInterior;
                    }
                    this.Db.Negocio.Update(negocio1);
                }
                else {
                    negocio.Fecha = DateTime.Now;
                    negocio.Activo = true;

                    this.Db.Add(negocio);
                }
                this.Db.SaveChanges();

                return get(negocio);
            }
            catch (Exception) { throw; }
        }
        public List<NegocioViewResponse> remove(Negocio nego) {
            try
            {
                Negocio negocio = this.Db.Negocio.FirstOrDefault(e => e.IdNegocio == nego.IdNegocio);
                if (negocio != null)
                {
                    negocio.Activo = false;

                    this.Db.Negocio.Update(negocio);
                }
                this.Db.SaveChanges();
                return get(nego);
            }
            catch (Exception ex) { throw; }
        }
    }
}
