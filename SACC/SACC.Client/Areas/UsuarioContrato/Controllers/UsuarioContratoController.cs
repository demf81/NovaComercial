using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace SACC.Client.Areas.UsuarioContrato.Controllers
{
    public class UsuarioContratoController : SACC.Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index(int pUsuarioId, string pNombre)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            //Models.UsuarioContratoVisualizar model = new Models.UsuarioContratoVisualizar();

            //model.UsuarioId = pUsuarioId;
            //model.Nombre    = pNombre;

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }

        [HttpPost]
        public JsonResult UsuarioContratoJson(int pUsuarioId)
        {
            List<SACC.Entidades.NovaComercial.PortalEmpresa.UsuarioContrato> res = LogicaNegocio.NovaComercial.PortalEmpresa.UsuarioContrato.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralConJoin, 0, pUsuarioId, 0);

            return Json(new { success = true, result = new { data = res } });
        }




        [Authorize]
        [HttpGet]
        public ActionResult Delete(int pUsuarioContratoId, int pUsuarioId, string pNombre, int pContratoId, string pcontratoDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            //Models.UsuarioContratoModel model = new Models.UsuarioContratoModel();
            //model.UsuarioContratoId   = pUsuarioContratoId;
            //model.UsuarioId           = pUsuarioId;
            //model.Nombre              = pNombre;
            //model.ContratoId          = pContratoId;
            //model.ContratoDescripcion = pcontratoDescripcion;

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }
        
        //[Authorize]
        //[HttpPost]
        //public ActionResult Delete(Models.UsuarioContratoModel model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/Logout");

        //    SACC.Entidades.EntidadJsonResponse res = new SACC.Entidades.EntidadJsonResponse();
        //    res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.UsuarioContrato.BajaLogica(model.UsuarioContratoId, GetUsuarioId());

        //    TempData["title"] = "Mensage";
        //    TempData["text"] = res.Error == false ? res.Mensaje : res.MensajeError;
        //    TempData["type"] = res.TipoMensaje;

        //    #region VARIABLES DE MENU
        //    TempData["lblNombre"] = GetNombreUsuario();
        //    if (HttpContext.Session["Foto"] != null)
        //        TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
        //    #endregion

        //    return RedirectToAction("Index", "UsuarioContrato", new { Area = "UsuarioContrato", @pUsuarioId = model.UsuarioId, @pNombre = @model.Nombre });
        //}




        [Authorize]
        [HttpPost]
        public JsonResult Create(
            //List<Contrato.Models.ContratoSeleccion> list
            Int32 ContratoId
            )
        {
            #region SE ASIGNAN LOS LOS CONTRATOS A LA EMPRESA
            //if (list.Count > 0)
            //{
            //    SACC.Entidades.EntidadJsonResponse res = null;
            //    var seleccionados = list.Where(x => x.Seleccionado.Equals(true));

            //    foreach (Contrato.Models.ContratoSeleccion item in seleccionados)
            //    {
            //        if (item.Seleccionado)
            //        {
            //            SACC.Entidades.NovaComercial.PortalEmpresa.UsuarioContrato obj = new SACC.Entidades.NovaComercial.PortalEmpresa.UsuarioContrato();
            //            obj.UsuarioContratoId     = 0;
            //            obj.UsuarioId             = item.EntidadId;
            //            obj.ContratoId            = item.ContratoId;
            //            obj.UsuarioCreacionId     = GetUsuarioId();
            //            obj.UsuarioModificacionId = GetUsuarioId();

            //            res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.UsuarioContrato.Guardar(obj);
            //            if (res.Error) break;
            //        }
            //    }
            //}
            #endregion

            //Models.UsuarioContratoVisualizar model = new Models.UsuarioContratoVisualizar();
            //model.UsuarioId = list[0].EntidadId;
            //model.Nombre    = list[0].EntidadDescripcion;

            //return Json(new { success = true, result = new { data = model } });
            return Json(new { success = true, result = new { data = String.Empty } });
        }
    }
}