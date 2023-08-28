using Microsoft.AspNetCore.Mvc;
using FinaliPB.Models;
using FinaliPB.Datos;


namespace FinaliPB.Controllers
{
    public class PrestamoController : Controller
    {

        Prestamo_Datos _prestamoDatos = new Prestamo_Datos();

        //------------------------------------------------------------LISTAR
        public IActionResult ListarPrestamos()
        {
            
                var list = _prestamoDatos.ListaPrestamo();
                return View(list);
            
        }
        //---------------------------------------------------------------OBTENER
        public IActionResult Obtener(int IdLibro)
        {

            var Obte = _prestamoDatos.ObtenerPrestamo(IdLibro);
            return View(Obte);
        }


        //---------------------------------------------------------------------------GUARDAR/AÑADIR
      
        public IActionResult GuardarPrestamo(PrestamoModel model)
        {
            var respuesta = _prestamoDatos.Prestamo_Guardar(model);
            if (respuesta)
            {
                return RedirectToAction("ListarPrestamos");
            }
            else
            {
                return View();
            }
        }

        //------------------------------------------------------------------------------------ELIMINAR
        public IActionResult EliminarPrestamos(int IdPrestamo)
        {
            var prestamo = _prestamoDatos.ObtenerPrestamo(IdPrestamo);
            return View(prestamo);
        }
        [HttpPost]
        public IActionResult EliminarPrestamos(PrestamoModel model)
        {
            var elim = _prestamoDatos.Prestamo_Eliminar(model.IdPrestamo);
            if (elim)
            {
                return RedirectToAction("ListarPrestamos");
            }
            else
            {
                return View();
            }
        }

        //---------------------------------------------------------------------EDITAR
        [HttpGet]
        public IActionResult EditarPrestamos(int IdPrestamo)
        {
            var prestamo = _prestamoDatos.ObtenerPrestamo(IdPrestamo);
            return View(prestamo);
        }
        [HttpPost]
        public IActionResult EditarPrestamos(PrestamoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool GuarLibro = _prestamoDatos.Prestamo_Guardar(model);
            if (GuarLibro)
            {
                return RedirectToAction("ListarPrestamos");
            }
            else
            {
                return View();
            }


        }

        /*
        public IActionResult ModificarPrestamo(int IdPrestamo)
        {
            PrestamoModel _prestamo = _prestamoDatos.ObtenerPrestamo(IdPrestamo);
            return View(_prestamo);
        }
        [HttpPost]
        public IActionResult ModificarLi(PrestamoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _prestamoDatos.Modificar_Presatamo(model);
            if (respuesta)
            {
                return RedirectToAction("ListarPrestamos");
            }
            else
            {
                return View();
            }

        }*/
        
    }
}
