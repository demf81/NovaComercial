using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.Seguridad.Controllers
{
    public class SeguridadController : PortalEmpresa.Client.Controllers.BaseController
    {
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult Perfil()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            Models.MiPerfilModel model = new Models.MiPerfilModel();

            List<SACC.Entidades.NovaComercial.PortalEmpresa.Usuario> res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Consultar( SACC.LogicaNegocio.SqlOpciones.ConsultaPorId, GetUsuarioId(), "", "", "", "", 0);

            model.UsuarioId  = res[0].UsuarioId;
            model.Nombre     = res[0].Nombre;
            model.Paterno    = res[0].Paterno;
            model.Materno    = res[0].Materno;
            model.Telefono   = res[0].Telefono;
            model.Correo     = res[0].Correo;
            model.Contrasena = res[0].Contrasenia;

            return View(model);
        }




        [Authorize]
        public ActionResult Editar()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            Models.MiPerfilModel model = new Models.MiPerfilModel();

            List<SACC.Entidades.NovaComercial.PortalEmpresa.Usuario> res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaPorId, GetUsuarioId(), "", "", "", "", 0);

            model.UsuarioId          = res[0].UsuarioId;
            model.Nombre             = res[0].Nombre;
            model.Paterno            = res[0].Paterno;
            model.Materno            = res[0].Materno;
            model.Telefono           = res[0].Telefono;
            model.Correo             = res[0].Correo;
            model.Contrasena         = res[0].Contrasenia;
            model.FechaVigenciaDesde = res[0].FechaVigenciaDesde;
            model.FechaVigenciaHasta = res[0].FechaVigenciaHasta;
            return View(model);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Editar(Models.MiPerfilModel model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            SACC.Entidades.NovaComercial.PortalEmpresa.Usuario obj = new SACC.Entidades.NovaComercial.PortalEmpresa.Usuario();
            obj.UsuarioId          = model.UsuarioId;
            obj.Nombre             = model.Nombre;
            obj.Paterno            = model.Paterno;
            obj.Materno            = model.Materno;
            obj.Telefono           = model.Telefono;
            obj.Correo             = model.Correo;
            obj.Contrasenia        = model.Contrasena;
            obj.FechaVigenciaDesde = model.FechaVigenciaDesde;
            obj.FechaVigenciaHasta = model.FechaVigenciaHasta;

            SACC.Entidades.EntidadJsonResponse res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Guardar(SACC.LogicaNegocio.SqlOpciones.Actualizar, obj);

            TempData["title"] = "Mensaje";
            TempData["text"] = res.Error == false ? res.Mensaje : res.MensajeError;
            TempData["type"] = res.TipoMensaje;

            return View(model);
        }




        [Authorize]
        public ActionResult CambioContrasena()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            Models.CambioContrasenaModel model = new Models.CambioContrasenaModel();

            List<SACC.Entidades.NovaComercial.PortalEmpresa.Usuario> res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaPorId, GetUsuarioId(), "", "", "", "", 0);

            model.UsuarioId  = res[0].UsuarioId;
            model.Correo     = res[0].Correo;
            model.Contrasena = res[0].Contrasenia;

            return View(model);
        }


        [Authorize]
        [HttpPost]
        public ActionResult CambioContrasena(Models.CambioContrasenaModel model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            if(!ViewData.ModelState.IsValid)
                return View(model);

            if (model.NuevaContrasena != model.ConfirmarContrasena)
            {
                TempData["title"] = "Mensaje";
                TempData["text"]  = "La contrase%C3%Ba es incorecta";
                TempData["type"]  = "error";
            }
            else if (model.Contrasena == Nova.SDK.Utils.Encriptacion.Encriptar(model.NuevaContrasena))
            {
                TempData["title"] = "Mensaje";
                TempData["text"] = "La nueva contrase%C3%B1a no puede ser igual a la actual.";
                TempData["type"]  = "error";
            }
            else
            {
                SACC.Entidades.NovaComercial.PortalEmpresa.Usuario obj = new SACC.Entidades.NovaComercial.PortalEmpresa.Usuario();
                obj.UsuarioId   = model.UsuarioId;
                obj.Contrasenia = Nova.SDK.Utils.Encriptacion.Encriptar(model.NuevaContrasena);

                SACC.Entidades.EntidadJsonResponse res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Guardar(SACC.LogicaNegocio.SqlOpciones.CambioContrasena, obj);

                TempData["title"] = "Mensaje";
                TempData["text"]  = res.Error == false ? res.Mensaje : res.MensajeError;
                TempData["type"]  = res.TipoMensaje;

                return RedirectToAction("Perfil", "Seguridad");
            }

            return View(model);
        }




        [AllowAnonymous]
        public ActionResult RestablecerContrasena()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult RestablecerContrasena(Models.MiPerfilModel model)
        {
            return View(model);
        }
    }
}