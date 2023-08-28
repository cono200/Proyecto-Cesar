using Microsoft.AspNetCore.Mvc;
using FinaliPB.Datos;
using FinaliPB.Models;
using FinaliPB.Recursos;
//Referencia para el trabajo con Autentication por cokies
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
namespace FinaliPB.Controllers
{
    public class LoginRController : Controller
    {
        LoginUsuario logR = new LoginUsuario();

        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registro(UsuarioModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            model.Contraseña = Utilidades.EncriptarContraseña(model.Contraseña);
            bool crearUsuario = logR.Registro(model);
            if(!crearUsuario)
            {
                ViewData["Mensaje"] = "El correo ingresado ya se encuentra registrado";
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string correo,string contraseña)
        {
            UsuarioModel usuario = logR.ValidarUsuario(correo, Utilidades.EncriptarContraseña(contraseña));
           // UsuarioModel usuario = logR.ValidarUsuario(correo, contraseña);
            if(usuario.IdUsuario == 0)
            {
                ViewData["Mensaje"] = "El correo o la contraseña no son los correctos";
                return View();
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,usuario.Nombre)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };
            await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), properties);

            return RedirectToAction("index", "Home");
        }
        public IActionResult CambiarContraseña()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CambiarContraseña(string correo,string contraseña)
        {
            bool respuesta = logR.CambiarContraseña(correo, Utilidades.EncriptarContraseña(contraseña));
            if(!respuesta)
            {
                ViewData["Mensaje"] = "El correo no existe";
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
