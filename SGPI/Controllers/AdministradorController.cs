using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using System.Linq; 

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SGPIDBContext context = new SGPIDBContext();

        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            var usuario = context.Usuarios
                .Where(consulta => consulta.NumeroDocumento == user.NumeroDocumento
                        && consulta.Password == user.Password).FirstOrDefault();

            if (usuario != null)
            {
                if (usuario.IdRol == 1)
                {
                    //Redirige a la vista principal de Administrador
                    return Redirect("Administrador/MenuAdmBuscar");
                }

                else if (usuario.IdRol == 2)
                {
                    //Redirige a la vista principal de Coordinador
                    return Redirect("Coordinador/MenuCoordinadorBuscar");
                }

                else if (usuario.IdRol == 3)
                {
                    //Redirige a la vista de Estudiante
                    return Redirect("Estudiante/ActualizarEstudiante");
                }
                else {
                }
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult OlvidarContrasena()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MenuRegistro(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            return View();
        }

        public IActionResult MenuRegistro()
        {
            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            return View();
        }

        public IActionResult MenuAdmBuscar()
        {
            ViewBag.documento = context.Documentos.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MenuAdmBuscar(Usuario usuario)
        {
            var us = context.Usuarios
                .Where(u => u.NumeroDocumento == usuario.NumeroDocumento
                && usuario.IdDoc == usuario.IdDoc).FirstOrDefault();

            if (us != null)
            {
                ViewBag.documento = context.Documentos.ToList();
                return View(us);
            }
            else
            {
                ViewBag.documento = context.Documentos.ToList();
                return View();
            }
        }

        public IActionResult MenuAdmModificar(int? IdUsuario)
        {
            Usuario usuario = context.Usuarios.Find(IdUsuario);
            if (usuario != null)
            {
                ViewBag.genero = context.Generos.ToList();
                ViewBag.rol = context.Rols.ToList();
                ViewBag.documento = context.Documentos.ToList();
                ViewBag.programa = context.Programas.ToList();
                return View(usuario);
            }

            else
                return Redirect("Administrador/MenuAdmBuscar");
        }

        [HttpPost]
        public IActionResult MenuAdmModificar(Usuario user)
        {
            context.Update(user);
            context.SaveChanges();

            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            return Redirect("MenuAdmBuscar");
        }
        public IActionResult Delete(Usuario usuario)
        {
            context.Remove(usuario);
            context.SaveChanges();
            return Redirect("MenuAdmBuscar");
        }
        public IActionResult Reportes()
        {
            return View();
        }
    }
}
