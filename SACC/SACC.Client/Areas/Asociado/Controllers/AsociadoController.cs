using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Asociado.Controllers
{
    public class AsociadoController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult AsociadoGridJson(String pCurp, String pNombre, String pNumSocio)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Asociado.DtoGridAsociado> res = SACC.LogicaNegocio.NovaComercial.dbo.Asociado.ConsultarGrid(pCurp, pNombre, pNumSocio);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserAsociado()
        {
            return PartialView();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult AsociadoJson(string pSocioId, string pCveFamiliar, string pNombre)
        {
            List<SACC.Entidades.NovaComercial.dbo.Asociado> res = LogicaNegocio.NovaComercial.dbo.Asociado.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralAsociado, 0, "", pSocioId, pCveFamiliar, pNombre, 0);

            return Json(new { success = true, result = new { data = res } });
        }




        [HttpPost]
        public JsonResult ImportacionBajoDemanda()
        {
            SACC.Entidades.EntidadJsonResponse res = SACC.LogicaNegocio.NovaComercial.dbo.Asociado.ImportarBajoDemanda();

            return Json(new { success = true, result = new { data = res } });
        }
    }
}