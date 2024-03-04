using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PortalEmpresa.Client.Controllers
{
    public class HomeController : PortalEmpresa.Client.Controllers.BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                List<SACC.Entidades.NovaComercial.PortalEmpresa.Usuario> res = null;
                res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Consultar(SACC.LogicaNegocio.SqlOpciones.AutenticaUsaurio, 0, "", "", "", model.Correo, 0);

                if (res != null && res.Count > 0)
                {
                    if (Nova.SDK.Utils.Encriptacion.Encriptar(model.Contrasenia) == res[0].Contrasenia)
                    {
                        FormsAuthentication.SetAuthCookie(model.Correo, false);

                        SetUsuarioId(res[0].UsuarioId);
                        SetContratoId(res[0].CampoComplemento_ContratoId);
                        SetNombreUsuario(res[0].Paterno + " " + res[0].Materno + ", " + res[0].Nombre);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["title"] = "Mensaje";
                        TempData["text"]  = "La contrase%C3%B1a es incorrecta";
                        TempData["type"]  = "warning";
                    }
                }
                else
                {
                    TempData["title"] = "Mensaje";
                    TempData["text"]  = "El usaurio no existe";
                    TempData["type"]  = "warning";
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            foreach (var cookie in HttpContext.Request.Cookies.AllKeys)
            {
                HttpContext.Request.Cookies.Remove(cookie);
            }
            foreach (var cookie in HttpContext.Response.Cookies.AllKeys)
            {
                HttpContext.Response.Cookies.Remove(cookie);
            }

            FormsAuthentication.SignOut();

            return Redirect("~/");
        }
    }
}
