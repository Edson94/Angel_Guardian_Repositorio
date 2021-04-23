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
    public class ImagenController : ControllerBase
    {
        private ImagenCore clImagen; 
        private AngelDbContext Db;
        public ImagenController(AngelDbContext Db)
        {
            this.Db = Db;
            clImagen = new ImagenCore(this.Db);
        }
        [HttpPost]
        public IActionResult get()
        {
            try {
                return StatusCode(200, new { 
                    Error = false,
                    Imagenes = clImagen.get()
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
        public IActionResult set([FromBody] Imagen imagen)
        {
            try {
                #region Validacion
                if (imagen.Nombre == String.Empty || imagen.Nombre == null) {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "El Nombre no puede ir vacio"
                    });
                }
                if (imagen.Ruta == String.Empty || imagen.Ruta == null)
                {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "La Ruta no puede ir vacio"
                    });
                }
                if (imagen.Size == 0)
                {
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "EL peso debe de ser mayor"
                    });
                }
                #endregion

                return StatusCode(200, new { 
                    Error = false,
                    Imagenes = clImagen.set(imagen)
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
    }
}
