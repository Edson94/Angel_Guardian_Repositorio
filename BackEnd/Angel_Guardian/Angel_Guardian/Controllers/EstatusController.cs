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
    public class EstatusController : ControllerBase
    {
        private EstatusCore ClEstatus;
        private AngelDbContext Db;
        public EstatusController(AngelDbContext Db)
        {
            this.Db = Db;
            ClEstatus = new EstatusCore(this.Db);
        }
        [HttpPost]
        public IActionResult get()
        {
            try
            {
                return StatusCode(200, new {
                    Error = false,
                    Estatus = ClEstatus.get()
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
