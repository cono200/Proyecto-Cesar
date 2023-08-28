using Microsoft.AspNetCore.Mvc;
using FinaliPB.Models;
using FinaliPB.Datos;

namespace FinaliPB.Controllers
{
    public class LibroController : Controller
    {

        LibroDatos _Libros = new LibroDatos();

        /*------------------------LISTAR LIBRO------------------------------------------------------*/
        public IActionResult Listar()
        {

            var Obte = _Libros.Listar();
            return View(Obte);

        }
        public IActionResult Index()
        {

            var Obte = _Libros.Listar();
            return View(Obte);

        }


        /*-----------------------CONSULTA LIBRO-------------------------------------------------------*/

        /*
         public IActionResult ObtenerLi(int IdLibro)
         {

             var Obte = _Libros.obtenerLi(IdLibro);
             return View(Obte);
             if(!ModelState.IsValid)
             {
                return View(Obte);
             }
            else
            {
                return View();
            }
         }
        */


        public IActionResult Consultar(int IdLibro)
        {

            var Obte = _Libros.Obtener(IdLibro);
            return View(Obte);
        }


        /*MODIFICAR LIBROS---------------------hjv----------------------------------*/

        public IActionResult Modificar(int IdLibro)
        {
            LibroModel _libros = _Libros.Obtener(IdLibro);
            return View(_libros);
        }
        [HttpPost]

        public IActionResult Modificar(LibroModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (model.IdLibro != 0)
            {
                var EditLibros = _Libros.Editar(model);
                if (EditLibros)
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
        /*ELIMINAR LIBROS--------------------------------------------------------*/
        public IActionResult Eliminar(int IdLibro)
        {
            LibroModel _libros = _Libros.Obtener(IdLibro);
            return View(_libros);
        }
        [HttpPost]
        public IActionResult Eliminar(LibroModel model)
        {
            var elim = _Libros.eliminar(model.IdLibro);
            if (elim)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        /*AÑADIR LIBROS-----------------------------------------------------*/
        [HttpGet]
        public IActionResult Añadir()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Añadir(LibroModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool GuarLibro = _Libros.Añadir(model);
            if (GuarLibro)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }


        }

    }
}
