using Microsoft.AspNetCore.Mvc;
using FinaliPB.Models;
using FinaliPB.Datos;
using Proyecto_Editorial.Datos;

namespace Proyecto_Biblioteca.Controllers
{

    public class EditorialController : Controller
    {
        EditorialDatos _EditorialDatos = new EditorialDatos();

        //--------------------------------------------------------------LISTAR

        public IActionResult Listado()
        {
            var Lista = _EditorialDatos.Listar();
            return View(Lista);
        }
        

        //--------------------------------------------------------------GUARDAR
        [HttpGet]
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Guardar(EditorialModel model)
        {
            var respuesta = _EditorialDatos.GuardarEditorial(model);
            if (respuesta)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                return View();
            }
        }

        //--------------------------------------------------------------OBTENER
        /*
        [HttpGet]

        public IActionResult Obtener()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Obtener(EditorialModel model)
        {
            var respuesta = _EditorialDatos.ObtenerEditorial(model);
            if (respuesta)
            {
                return RedirectToAction("AcciónExitosa");
            }
            else
            {
                return View("");
            }
        }
        */
        //--------------------------------------------------------------EDITAR

        [HttpGet]

        public IActionResult Editar(int IdEditorial)
        {
            var respuesta = _EditorialDatos.ObtenerEditorial(IdEditorial);
            return View(respuesta);
        }

        [HttpPost]

        public IActionResult Editar(EditorialModel model)
        {
            var respuesta = _EditorialDatos.EditarEditorial(model);
            if (respuesta)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                return View();
            }
        }

        //--------------------------------------------------------------ELIMINAR
        [HttpGet]
        public IActionResult Eliminar(int IdEditorial)
        {
            var _Editorial = _EditorialDatos.ObtenerEditorial(IdEditorial);
            return View(_Editorial);
        }

        [HttpPost]

        public IActionResult Eliminar(EditorialModel model)
        {
            var respuesta = _EditorialDatos.EliminarEditorial(model.IdEditorial);
            if (respuesta)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                return View();
            }
        }
    }
}