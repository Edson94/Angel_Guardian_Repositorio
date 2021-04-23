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
    public class NegocioController : ControllerBase
    {
        private ServicioCore ClServicio;
        private NegocioCore ClNegocio;
        private UsuarioCore ClUsuario;
        private EstadoCore ClEstado;
        private MunicipioCore CLMunicipio;
        private ImagenCore CLImagen;
        private AngelDbContext Db;
        public NegocioController(AngelDbContext Db)
        {
            this.Db = Db;
            ClServicio = new ServicioCore(this.Db);
            ClNegocio = new NegocioCore(this.Db);
            ClUsuario = new UsuarioCore(this.Db);
            CLMunicipio = new MunicipioCore(this.Db);
            CLImagen = new ImagenCore(this.Db);
            ClEstado = new EstadoCore(this.Db);
        }
        [HttpPost]
        public IActionResult get([FromBody] Negocio negocio)
        {
            try
            {
                return StatusCode(200, new
                {
                    Error = false,
                    Negocios = ClNegocio.get(negocio)
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
        public IActionResult set([FromBody] Negocio negocio)
        {
            try
            {
                #region Validaciones
                if (ClUsuario.ChecarUsuario(negocio.IdUsuario) == null) {
                    return StatusCode(400, new {
                        Error = true,
                        Catch = "El Usuario no existe"
                    });
                }
                if (ClEstado.ChecarEstado(negocio.IdEstado) == null)
                {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El Estado no existe"
                    });
                }
                if (CLMunicipio.ChecarMunicipio(negocio.IdMunicipio) == null)
                {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El Municipio no existe"
                    });
                }
                if (CLImagen.ChecarImagen(negocio.IdImagen) == null)
                {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "La Imagen no existe"
                    });
                }
                if (negocio.Nombre == String.Empty)
                {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El nombre debe ser necesario"
                    });
                }
                if (negocio.RazonSocial == String.Empty)
                {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "La Razon Social debe ser necesario"
                    });
                }
                if (negocio.Calle == String.Empty)
                {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "La calle debe ser necesario"
                    });
                }
                if (negocio.Colonia == String.Empty)
                {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "La colonia debe ser necesario"
                    });
                }
                if (negocio.NumeroInterior == 0)
                {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El numero interior debe ser necesario"
                    });
                }
                #endregion
                return StatusCode(200, new
                {
                    Error = false,
                    Negocios = ClNegocio.set(negocio)
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
        public IActionResult remove([FromBody] Negocio negocio)
        {
            try
            {
                #region Validaciones
                if (negocio.IdNegocio == 0)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El IdNegocio debe ser mayor a cero"
                    });
                if (negocio.IdUsuario == 0)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El IdUsuario debe ser mayor a cero"
                    });
                #endregion

                return StatusCode(200, new
                {
                    Error = false,
                    Negocios = ClNegocio.remove(negocio)
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
