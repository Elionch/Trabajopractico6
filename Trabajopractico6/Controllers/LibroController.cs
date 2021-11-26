using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trabajopractico6.Models;

namespace Trabajopractico6.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            try
            {
                using (var db = new LibroEntities())
                {
                    return View(db.InfoLibro.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(InfoLibro a)

        { 
            if (!ModelState.IsValid)

                return View();
            try
            {
                
                using (var db = new LibroEntities())
                {
                    a.Titulo = a.Titulo.ToUpper();
                    db.InfoLibro.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el alumno " + ex.Message);
                return View();
            }
        }
        public ActionResult Editar(int id)

        { 
            if (!ModelState.IsValid)

                return View();
            try
            {
                
                using (var db = new LibroEntities())
                {
                  
                    InfoLibro alu = db.InfoLibro.Find(id);
                    return View(alu);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el alumno " + ex.Message);
                return View();
            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(InfoLibro a)
        {
            try
            {
                using (var db = new LibroEntities())
                {
                    InfoLibro alu = db.InfoLibro.Find();
                    alu.Titulo = a.Titulo;
                    alu.Autor = a.Autor;
                    alu.ISBN = a.ISBN;
                    alu.Paginas = a.Paginas;
                    alu.Edicion = a.Edicion;
                    alu.Editorial = a.Editorial;
                    alu.Lugar = a.Lugar;
                    alu.Fecha_edicion = a.Fecha_edicion;

                    db.SaveChanges();

                    return RedirectToAction("index");
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }

        public ActionResult Detalles(int id)
        {
            using (var db = new LibroEntities())
            {

                InfoLibro alu = db.InfoLibro.Find(id);
                return View(alu);
            }

        }


        public ActionResult Eliminar(int id)
        {
            using (var db = new LibroEntities())
            {

                InfoLibro alu = db.InfoLibro.Find(id);
                db.InfoLibro.Remove(alu);
                db.SaveChanges();

                return RedirectToAction("index");
            }

        }
    }
}
  