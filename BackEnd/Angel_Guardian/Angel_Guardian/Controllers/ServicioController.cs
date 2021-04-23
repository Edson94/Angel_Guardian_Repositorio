using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angel_Guardian.Models;
using Angel_Guardian.Utils;
using Angel_Guardian.Classes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angel_Guardian.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private ServicioCore ClServicio;
        private NegocioCore ClNegocio;
        private AngelDbContext Db;
        public ServicioController(AngelDbContext Db) { 
            this.Db = Db;
            ClServicio = new ServicioCore(this.Db);
            ClNegocio = new NegocioCore(this.Db);
        }
        [HttpPost]
        public IActionResult get([FromBody] Servicio servicio) {
            try {
                #region Validaciones
                if (ClNegocio.ChecarNegocio(servicio.IdNegocio) == null)
                    return StatusCode(400, new { 
                        Error = true,
                        Catch = "El Negocio no existe"
                    });
                #endregion

                return StatusCode(200, new { 
                    Error = false,
                    Servicios = ClServicio.get(servicio)
                });
            }
            catch (Exception ex) {
                return StatusCode(500, new
                {
                    Error = true,
                    Catch = ex.Message
                });
            }
        }
        [HttpPost]
        public IActionResult set([FromBody] Servicio servicio) {
            try {
                #region Validaciones
                if (ClNegocio.ChecarNegocio(servicio.IdNegocio) == null)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El Negocio no existe"
                    });
                if (servicio.Nombre == String.Empty || servicio.Nombre == null)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El Nombre es obligatorio"
                    });
                if (servicio.Descripcion == String.Empty || servicio.Descripcion == null)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "La Descripcion es obligatorio"
                    });
                if (servicio.Duracion == 0)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "La Duracion debe de ser mayor a cero"
                    });
                if (servicio.Precio == 0)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El Precio debe de ser mayor a cero"
                    });
                #endregion
                return StatusCode(200, new
                {
                    Error = false,
                    Servicios = ClServicio.set(servicio)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = true,
                    Catch = ex.Message
                });
            }
        }
        [HttpPost]
        public IActionResult remove([FromBody] Servicio servicio) {
            try {
                #region Validaciones
                if (servicio.IdServicio == 0)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El Id debe ser mayor a cero"
                    });
                #endregion

                return StatusCode(200, new
                {
                    Error = false,
                    Servicios = ClServicio.delete(servicio)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = true,
                    Catch = ex.Message
                });
            }
        }
    }
}
