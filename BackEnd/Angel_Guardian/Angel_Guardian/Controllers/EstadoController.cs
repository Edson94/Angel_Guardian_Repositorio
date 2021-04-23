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
    public class EstadoController : ControllerBase
    {
        private AngelDbContext Db;
        private EstadoCore Estado;
        public EstadoController(AngelDbContext Db) { this.Db = Db; }

        [HttpPost]
        public IActionResult Get()
        {
            try {
                Estado = new EstadoCore(this.Db);

                return StatusCode(200, new {
                    Error = false,
                    ListEstados = Estado.GetEstados()
                });
            }
            catch (Exception ex) {
                return StatusCode(500, new { 
                    Error = true,
                    Catch = ex.Message
                });
            }
        }
    }
}
