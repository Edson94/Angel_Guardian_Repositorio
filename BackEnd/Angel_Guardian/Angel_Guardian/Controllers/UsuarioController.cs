using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angel_Guardian.Models;
using Angel_Guardian.Classes;
using Angel_Guardian.Utils;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Angel_Guardian.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private AngelDbContext Db;
        private UsuarioCore usuarioCore;
        public UsuarioController(AngelDbContext Db) { this.Db = Db; }
        [HttpPost]
        public IActionResult Login([FromBody] Usuario usuario) {
            try {
                if (usuario.NickName == String.Empty)
                    return StatusCode(400, new {
                        Error = true,
                        Catch = "NickName no puede ir vacio"
                    });
                if (usuario.Password == String.Empty)
                    return StatusCode(400, new {
                        Error = true,
                        Catch = "Password no puede ir vacio"
                    });
                usuarioCore = new UsuarioCore(this.Db);

                return StatusCode(200, new {
                    Error = false,
                    Usuario = usuarioCore.Login(usuario)
                });
            }
            catch (Exception ex) {
                return StatusCode(500, new {
                    Error = true,
                    Catch = ex.Message
                });
            }
        }
        [HttpPost]
        public IActionResult Registro([FromBody] Usuario usuario)
        {
            try {
                #region validacion
                /*if (usuario.Password == String.Empty || usuario.Password == null)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "Password no puede ir vacio"
                    });
                if (usuario.NombreUsuario == String.Empty || usuario.NombreUsuario == null)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "Nombre no puede ir vacio"
                    });*/
                if (usuario.ApellidoMaterno == String.Empty || usuario.ApellidoMaterno == null)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "Apellido Materno no puede ir vacio"
                    });
                if (usuario.ApellidoPaterno == String.Empty || usuario.ApellidoPaterno == null)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "Apellido Paterno no puede ir vacio"
                    });
                if (usuario.Celular != String.Empty || usuario.Celular != null)
                {
                    if (!Utils.Utils.IsNumber(usuario.Celular))
                        return StatusCode(400, new
                        {
                            Error = true,
                            Catch = "Celular debe de ser numerico"
                        });
                }
                else
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "Celular no puede ir vacio"
                    });
                if (usuario.Email != String.Empty || usuario.Email != null)
                {
                    if (!Utils.Utils.IsEMail(usuario.Email))
                        return StatusCode(400, new
                        {
                            Error = true,
                            Catch = "Email no esta en formato valido"
                        });
                }
                else
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "Email no puede ir vacio"
                    });
                #endregion

                usuario.Password = "123456789";
                usuario.NombreUsuario = "Edson";
                usuario.NickName = String.Concat(usuario.NombreUsuario.Substring(0, 1).ToLower(), usuario.ApellidoPaterno.ToLower());
                usuario.Fecha = DateTime.Now;
                usuarioCore = new UsuarioCore(this.Db);
                return StatusCode(200, new
                {
                    Error = false,
                    Agrego = usuarioCore.Guardar(usuario)
                });
            }
            catch (Exception ex) {
                return StatusCode(500, new
                {
                    Error = true,
                    Catch = ex.InnerException
                });
            }
        }
        [HttpPost]
        public IActionResult Actualizar([FromBody] Usuario usuario) {
            try {
                #region validacion
                if (usuario.IdUsuario == 0)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "IdUsuario no puede ir vacio"
                    });
                /*if (usuario.Password == String.Empty || usuario.Password == null)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "Password no puede ir vacio"
                    });
                if (usuario.NombreUsuario == String.Empty || usuario.NombreUsuario == null)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "Nombre no puede ir vacio"
                    });*/
                if (usuario.ApellidoMaterno == String.Empty || usuario.ApellidoMaterno == null)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "Apellido Materno no puede ir vacio"
                    });
                if (usuario.ApellidoPaterno == String.Empty || usuario.ApellidoPaterno == null)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "Apellido Paterno no puede ir vacio"
                    });
                if (usuario.Celular != String.Empty || usuario.Celular != null)
                {
                    if (!Utils.Utils.IsNumber(usuario.Celular))
                        return StatusCode(400, new
                        {
                            Error = true,
                            Catch = "Celular debe de ser numerico"
                        });
                }
                else
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "Celular no puede ir vacio"
                    });
                if (usuario.Email != String.Empty || usuario.Email != null)
                {
                    if (!Utils.Utils.IsEMail(usuario.Email))
                        return StatusCode(400, new
                        {
                            Error = true,
                            Catch = "Email no esta en formato valido"
                        });
                }
                else
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "Email no puede ir vacio"
                    });
                #endregion
                usuarioCore = new UsuarioCore(this.Db);
                usuario.Password = "123456";

                return StatusCode(200, new
                {
                    Error = false,
                    Edito = usuarioCore.Actualizar(usuario)
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
        public IActionResult Eliminar([FromBody] Usuario usuario) {
            try {
                #region validacion
                if (usuario.IdUsuario == 0)
                    return StatusCode(400, new
                    {
                        Error = true,
                        Catch = "IdUsuario no puede ir vacio"
                    });
                #endregion
                usuarioCore = new UsuarioCore(this.Db);
                return StatusCode(200, new {
                    Error = false,
                    Elimino = usuarioCore.Eliminar(usuario)
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
