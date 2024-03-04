using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SACC.Client.Areas.Seguridad.Controllers
{
    public class SeguridadController : SACC.Client.Controllers.BaseController
    {
        const Int32 Contrato_AplicacionId = 167;


        public ActionResult Index()
        {
            return View();
        }




        [Authorize]
        public ActionResult Perfil()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(Contrato_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            //Models.MiPerfilmodel model = new Models.MiPerfilmodel();

            //List<SACC.Entidades.NovaComercial.PortalEmpresa.Usuario> res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Consultar( SACC.LogicaNegocio.SqlOpciones.ConsultaPorId, GetUsuarioId(), "", "", "", "", 0);

            //model.UsuarioId  = res[0].UsuarioId;
            //model.Nombre     = res[0].Nombre;
            //model.Paterno    = res[0].Paterno;
            //model.Materno    = res[0].Materno;
            //model.Telefono   = res[0].Telefono;
            //model.Correo     = res[0].Correo;
            //model.Contrasena = res[0].Contrasenia;

            return View();
        }




        [Authorize]
        public ActionResult Editar()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(Contrato_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            //Models.MiPerfilmodel model = new Models.MiPerfilmodel();

            //List<SACC.Entidades.NovaComercial.PortalEmpresa.Usuario> res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaPorId, GetUsuarioId(), "", "", "", "", 0);

            //model.UsuarioId  = res[0].UsuarioId;
            //model.Nombre     = res[0].Nombre;
            //model.Paterno    = res[0].Paterno;
            //model.Materno    = res[0].Materno;
            //model.Telefono   = res[0].Telefono;
            //model.Correo     = res[0].Correo;
            //model.Contrasena = res[0].Contrasenia;

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult Editar(FormCollection model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(Contrato_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            return View();
        }




        [Authorize]
        public ActionResult CambioContrasena()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult CambioContrasena(FormCollection model)
        {
            return View();
        }




        [AllowAnonymous]
        public ActionResult RestablecerContrasena()
        {
            return View();
        }
    }
}