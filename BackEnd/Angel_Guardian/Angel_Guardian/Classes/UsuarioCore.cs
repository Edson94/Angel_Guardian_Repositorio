using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angel_Guardian.Controllers;
using Angel_Guardian.Models;

namespace Angel_Guardian.Classes
{
    public class UsuarioCore
    {
        private AngelDbContext Db;
        public UsuarioCore(AngelDbContext Db) { this.Db = Db; }
        public Usuario ChecarUsuario(int IdUsuario)
        {
            try { return this.Db.Usuario.FirstOrDefault(e => e.IdUsuario == IdUsuario); }
            catch (Exception) { throw; }
        }
        public Usuario Login(Usuario usuario) {
            Usuario usuarioreturn = new Usuario();
            try {
                usuarioreturn = this.Db.Usuario.FirstOrDefault(e => e.NickName == usuario.NickName);
            }
            catch (Exception) { throw; }
            return usuarioreturn;
        }
        public bool Guardar(Usuario usuario) {
            try {

                Usuario user = this.Db.Usuario.FirstOrDefault(e => e.NickName == usuario.NickName);
                if (user != null)
                    return false;

                this.Db.Usuario.Add(usuario);
                this.Db.SaveChanges();

                return true;
            }
            catch (Exception) { throw; }
        }
        public bool Actualizar(Usuario usuario)
        {
            try {
                Usuario user = this.Db.Usuario.FirstOrDefault(e => e.IdUsuario == usuario.IdUsuario);
                if (user == null)
                    return false;
                //user.NombreUsuario = usuario.NombreUsuario;
                user.ApellidoPaterno = usuario.ApellidoPaterno;
                user.ApellidoMaterno = usuario.ApellidoMaterno;
                user.NickName = String.Concat(user.NombreUsuario.Substring(0, 1).ToLower(), usuario.ApellidoPaterno.ToLower());
                user.Celular = usuario.Celular;
                user.Email = usuario.Email;
                user.Password = usuario.Password;

                this.Db.Update(user);
                this.Db.SaveChanges();

                return true;
            }
            catch (Exception) { throw; }
        }
        public bool Eliminar(Usuario usuario) {
            try {
                Usuario s = this.Db.Usuario.FirstOrDefault(e => e.IdUsuario == usuario.IdUsuario);
                if (s == null)
                    return false;
                this.Db.Usuario.Remove(s);
                this.Db.SaveChanges();
                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
