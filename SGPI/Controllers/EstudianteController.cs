using Microsoft.AspNetCore.Mvc;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {
        SGPIDBContext context = new SGPIDBContext();
        public IActionResult ActualizarEstudiante(int? IdUsuario)
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
                ViewBag.genero = context.Generos.ToList();
                ViewBag.rol = context.Rols.ToList();
                ViewBag.documento = context.Documentos.ToList();
                ViewBag.programa = context.Programas.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult ActualizarEstudiante(Usuario user)
        {
            context.Update(user);
            context.SaveChanges();

            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            return View();
        }
        public IActionResult PagosEstudiante()
        {
            return View();
        }
    }
}
