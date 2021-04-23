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
    public class MunicipioController : ControllerBase
    {
        private EstadoCore ClEstado;
        private MunicipioCore CLMunicipio;
        private AngelDbContext Db;
        public MunicipioController(AngelDbContext Db)
        {
            this.Db = Db;
            CLMunicipio = new MunicipioCore(this.Db);
            ClEstado = new EstadoCore(this.Db);
        }
        [HttpPost]
        public IActionResult get([FromBody] Municipio municipio) {
            try {
                #region validacion
                if (ClEstado.ChecarEstado(municipio.IdEstado) == null) {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El Estado no existe"
                    });
                }
                #endregion

                return StatusCode(200, new {
                    Error = false,
                    Municipio = CLMunicipio.get(municipio)
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
    }
}
