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
                    return View("MenuAdmBuscar");
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

            //Genero genero = new Genero();
            //genero.Genero1 = "LGTBI";

            //context.Add(genero);
            //context.SaveChanges();

            //var gen = (from s in context.Generos 
            //           where s.IdGenero == 1 
            //           select s); 
            ////pruebsa


            //Genero nuevoGen = gen.SingleOrDefault();

            //nuevoGen.Genero1 = "Binario";

            //context.Update(nuevoGen);
            //context.SaveChanges();

            //context.Remove(nuevoGen);
            //context.SaveChanges();

            return View();
        }

        public IActionResult OlvidarContrasena()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreaMenuRegistro(Usuario usuario)
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

            if(us!= null)
                return View(us);
            else
            {
                ViewBag.documento = context.Documento.Tolist();
                return View();
            }
        }

        public IActionResult MenuAdmModificar()
        {
            return View();
        }

        public IActionResult Reportes()
        {
            return View();
        }
    }
}
