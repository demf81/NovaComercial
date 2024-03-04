using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.ContratoCoberturaPaquete.Controllers
{
    public class ContratoCoberturaPaqueteController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index(Int32 pContratoCoberturaId, String pContratoCoberturaDescripcion, Int32 pContratoId, String pContratoDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            ViewBag.ContratoCoberturaId          = pContratoCoberturaId;
            ViewBag.ContratoCoberturaDescripcion = pContratoCoberturaDescripcion;
            ViewBag.ContratoId                   = pContratoId;
            ViewBag.ContratoDescripcion          = pContratoDescripcion;

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult ContratoCoberturaPaqueteJson(Int32 pContratoCoberturaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaquete> res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaquete.ConsultarGrid(pContratoCoberturaId, -1, 1);

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

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
        [HttpPost]
        public JsonResult Delete(Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoContratoCoberturaPaquete model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaquete.BajaLogica(model.ContratoCoberturaPaqueteId, GetUsuarioId());

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;
            res.MuestraAlert    = true;

            if (res.Error) {
                res.DelayTime = false;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [Authorize]
        [HttpPost]
        public JsonResult Create(List<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoContratoCoberturaPaquete> list)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            if (list.Count > 0)
            {
                foreach (Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoContratoCoberturaPaquete item in list)
                {
                    Entidades.NovaComercial.dbo.ContratoCoberturaPaquete obj = new Entidades.NovaComercial.dbo.ContratoCoberturaPaquete
                    {
                        ContratoCoberturaPaqueteId = 0,
                        ContratoCoberturaId        = item.ContratoCoberturaId,
                        PaqueteId                  = item.PaqueteId,
                        UsuarioCreacionId          = GetUsuarioId()
                    };

                    res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaquete.Guardar(obj);
                    if (res.Error) break;
                }
            }

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;
            res.MuestraAlert    = true;

            if (res.Error) {
                res.DelayTime = false;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserContratoCoberturaPaquete()
        {
            //Models.CtrlUserContratoCoberturaPaquete model = new Models.CtrlUserContratoCoberturaPaquete();
            //model.TipoArticulos = VentaUnitariaDetalleTipo.Controllers.VentaUnitariaDetalleTipoController.VentaUnitariaDetalleTipoList(OpcionesCombo.SELECCIONE).Where(x => !x.Text.Equals("PAQUETE") || x.Text.Equals("[Seleccione...]")).ToList();

            return PartialView();
        }




        [Authorize]
        [HttpPost]
        public JsonResult ContratoCoberturaPaquetePorContrato(Int32 pContratoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaqueteContrato> res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaquete.ConsultarGridPorContrato(pContratoId, 1);

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        //[Authorize]
        //[HttpPost]
        //public JsonResult ContratoCoberturaPaqueteList(OpcionesCombo _opcion, int pContratoCoberturaId)
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();

        //    List<SACC.Entidades.NovaComercial.dbo.ContratoCoberturaPaquete> res = SACC.LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaquete.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralConJoin, 0, pContratoCoberturaId, 0, null, null, null, null, null, 0);

        //    if (_opcion == OpcionesCombo.TODOS)
        //    {
        //        items.Add(
        //            new SelectListItem
        //            {
        //                Text  = "[TODOS]",
        //                Value = "0"
        //            }
        //        );
        //    }

        //    if (_opcion == OpcionesCombo.SELECCIONE)
        //    {
        //        items.Add(
        //            new SelectListItem
        //            {
        //                Text  = "[Seleccione...]",
        //                Value = "0"
        //            }
        //        );
        //    }

        //    foreach (SACC.Entidades.NovaComercial.dbo.ContratoCoberturaPaquete item in res)
        //    {
        //        items.Add(
        //            new SelectListItem
        //            {
        //                Text  = item.CampoComplemento_PaqueteDescripcion.ToString(),
        //                Value = item.PaqueteId.ToString()
        //            }
        //        );
        //    }

        //    return Json(new { success = true, result = new { data = items } });
        //}









        //[Authorize]
        //[HttpPost]
        //public JsonResult MedicamentoAmparadoJson(int pMedicamentoId, int pPaqueteId)
        //{
        //    List<SACC.Entidades.NovaComercial.dbo.ContratoCoberturaPaquete> res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaquete.Consultar(LogicaNegocio.SqlOpciones.ConsultaMedicamentoAmparado, 0, 0, pPaqueteId, pMedicamentoId, null, null, null, null, 0);

        //    return Json(new { success = true, result = new { data = res } });
        //}




        //[Authorize]
        //[HttpPost]
        //public JsonResult MaterialAmparadoJson(int pMaterialId, int pPaqueteId)
        //{
        //    List<SACC.Entidades.NovaComercial.dbo.ContratoCoberturaPaquete> res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaquete.Consultar(LogicaNegocio.SqlOpciones.ConsultaMaterialAmparado, 0, 0, pPaqueteId, null, pMaterialId, null, null, null, 0);

        //    return Json(new { success = true, result = new { data = res } });
        //}




        //[Authorize]
        //[HttpPost]
        //public JsonResult CirugiaAmparadoJson(int pCirugiaId, int pPaqueteId)
        //{
        //    List<SACC.Entidades.NovaComercial.dbo.ContratoCoberturaPaquete> res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaquete.Consultar(LogicaNegocio.SqlOpciones.ConsultaCirugiaAmparado, 0, 0, pPaqueteId, null, null, pCirugiaId, null, null, 0);

        //    return Json(new { success = true, result = new { data = res } });
        //}




        //[Authorize]
        //[HttpPost]
        //public JsonResult EstudioAmparadoJson(int pEstudioId, int pPaqueteId)
        //{
        //    List<SACC.Entidades.NovaComercial.dbo.ContratoCoberturaPaquete> res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaquete.Consultar(LogicaNegocio.SqlOpciones.ConsultaEstudioAmparado, 0, 0, pPaqueteId, null, null, null, pEstudioId, null, 0);

        //    return Json(new { success = true, result = new { data = res } });
        //}




        //[Authorize]
        //[HttpPost]
        //public JsonResult ServicioAmparadoJson(int pServicioId, int pPaqueteId)
        //{
        //    List<SACC.Entidades.NovaComercial.dbo.ContratoCoberturaPaquete> res = LogicaNegocio.NovaComercial.dbo.ContratoCoberturaPaquete.Consultar(LogicaNegocio.SqlOpciones.ConsultaServicioAmparado, 0, 0, pPaqueteId, null, null, null, null, pServicioId, 0);

        //    return Json(new { success = true, result = new { data = res } });
        //}
    }
}