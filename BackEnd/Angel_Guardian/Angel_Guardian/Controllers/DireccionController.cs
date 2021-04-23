using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angel_Guardian.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Angel_Guardian.Classes;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angel_Guardian.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        private DireccionCore ClDireccion;
        private EstadoCore ClEstado;
        private MunicipioCore ClMunicipio;
        private UsuarioCore CLUsuario;
        private AngelDbContext Db;
        public DireccionController(AngelDbContext Db)
        {
            this.Db = Db;
            ClDireccion = new DireccionCore(this.Db);
            ClEstado = new EstadoCore(this.Db);
            ClMunicipio = new MunicipioCore(this.Db);
            CLUsuario = new UsuarioCore(this.Db);
        }
        [HttpPost]
        public IActionResult get([FromBody]Direccion direccion)
        {
            try {
                return StatusCode(200, new { 
                    Error = false,
                    Direccion = ClDireccion.get(direccion)
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
        public IActionResult set([FromBody] Direccion direccion)
        {
            try
            {
                #region Validacion
                /*if (direccion.IdDireccion == null) {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El IdDireccion debe de ser defenido"
                    });
                }*/
                if (CLUsuario.ChecarUsuario(direccion.IdUsuario) == null) {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El Usuario no existe"
                    });
                }
                if (ClEstado.ChecarEstado(direccion.IdEstado) == null) {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El Estado no existe"
                    });
                }
                if (ClMunicipio.ChecarMunicipio(direccion.IdMunicipio) == null) {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El Municipio no existe"
                    });
                }
                if (direccion.Colonia == String.Empty) {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "La Colonia es necesaria"
                    });
                }
                if (direccion.Calle == String.Empty) {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "La Calle es necesaria"
                    });
                }
                if (direccion.NumeroInterior == 0) {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El Numero interior debe de ser mayor"
                    });
                }
                #endregion
                return StatusCode(200, new
                {
                    Error = false,
                    Direccion = ClDireccion.set(direccion)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = true,
                    Catch = ex.Message,
                    Catch2 = ex.InnerException
                });
            }
        }
        [HttpPost]
        public IActionResult remove([FromBody] Direccion direccion) {
            try
            {
                #region Validacion
                if (direccion.IdDireccion == 0)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "La IdDireccion debe de ser mayor 0"
                    });
                #endregion

                return StatusCode(200, new { 
                    Error = false,
                    Direcciones = ClDireccion.remove(direccion)
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
