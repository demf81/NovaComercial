using System;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.EmpresaDatosFiscales.Controllers
{
    public class EmpresaDatosFiscalesController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;

        [Authorize]
        [HttpPost]
        public JsonResult EmpresaDatosFiscalesElementoJson(Int32 pEmpresaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDatosFiscales.DtoEmpresaDatosFiscales> res = LogicaNegocio.NovaComercial.SACC.EmpresaDatosFiscales.ConsultarPorId(pEmpresaId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}