using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.ContratoCobertura.Controllers
{
    public class ContratoCoberturaController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index(Int32 pContratoId, String pContratoDescripcion)
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

            ViewBag.ContratoId          = pContratoId;
            ViewBag.ContratoDescripcion = pContratoDescripcion;

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult ContratoCoberturaGridJson(Int32 pContratoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCobertura.DtoGridContratoCobertura> res = LogicaNegocio.NovaComercial.dbo.ContratoCobertura.ConsultarGrid(pContratoId, 1);

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
        public ActionResult Edit(Int32 pContratoCoberturaId, Int32 pContratoId, String pContratoDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            ViewBag.ContratoCoberturaId = pContratoCoberturaId;
            ViewBag.ContratoId          = pContratoId;
            ViewBag.ContratoDescripcion = pContratoDescripcion;

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Edit(Modelo.NovaComercial.dbo.ContratoCobertura.DtoContratoCobertura model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.dbo.ContratoCobertura obj = new Entidades.NovaComercial.dbo.ContratoCobertura
            {
                ContratoCoberturaId            = model.ContratoCoberturaId,
                ContratoId                     = model.ContratoId,
                ContratoCoberturaDescripcion   = model.ContratoCoberturaDescripcion,
                TodoMedicamento                = model.TodoMedicamento,
                TodoMaterial                   = model.TodoMaterial,
                TodoCirugia                    = model.TodoCirugia,
                TodoEstudio                    = model.TodoEstudio,
                TodoServicio                   = model.TodoServicio,
                ContratoCoberturaTipoId        = 1,
                VigenciaDesde                  = model.VigenciaDesde,
                VigenciaHasta                  = model.VigenciaHasta,
                EsquemaPrePago                 = model.EsquemaPrePago,
                CobroAnticipado                = model.CobroAnticipado,
                TarifaId                       = 1,
                PorcentajeUtilidadSobreTarifa  = model.PorcentajeUtilidadSobreTarifa,
                PorcentajeCopagoContratante    = model.PorcentajeCopagoContratante,
                PorcentajeDescuentoSobreTarifa = model.PorcentajeDescuentoSobreTarifa,
                UsuarioModificacionId          = GetUsuarioId(),
                EstatusId                      = model.EstatusId
            };

            if (model.Baja == true)
                obj.UsuarioBajaId = GetUsuarioId();

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.ContratoCobertura.Guardar(obj);

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
        public ActionResult Delete(Int32 pContratoCoberturaId, Int32 pContratoId, String pContratoDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            ViewBag.ContratoId          = pContratoId;
            ViewBag.ContratoDescripcion = pContratoDescripcion;
            ViewBag.ContratoCoberturaId = pContratoCoberturaId;

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult Delete(Modelo.NovaComercial.dbo.ContratoCobertura.DtoContratoCobertura model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.ContratoCobertura.BajaLogica(model.ContratoCoberturaId, GetUsuarioId());

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
        public ActionResult Create(Int32 pContratoId, String pContratoDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            ViewBag.ContratoId          = pContratoId;
            ViewBag.ContratoDescripcion = pContratoDescripcion;

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult Create(Modelo.NovaComercial.dbo.ContratoCobertura.DtoContratoCobertura model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.dbo.ContratoCobertura obj = new Entidades.NovaComercial.dbo.ContratoCobertura
            {
                ContratoCoberturaId            = model.ContratoCoberturaId,
                ContratoId                     = model.ContratoId,
                ContratoCoberturaDescripcion   = model.ContratoCoberturaDescripcion,
                TodoMedicamento                = model.TodoMedicamento,
                TodoMaterial                   = model.TodoMaterial,
                TodoCirugia                    = model.TodoCirugia,
                TodoEstudio                    = model.TodoEstudio,
                TodoServicio                   = model.TodoServicio,
                ContratoCoberturaTipoId        = 1,
                VigenciaDesde                  = model.VigenciaDesde,
                VigenciaHasta                  = model.VigenciaDesde.AddYears(1),
                EsquemaPrePago                 = model.EsquemaPrePago,
                CobroAnticipado                = model.CobroAnticipado,
                TarifaId                       = 1,
                PorcentajeUtilidadSobreTarifa  = model.PorcentajeUtilidadSobreTarifa,
                PorcentajeCopagoContratante    = model.PorcentajeCopagoContratante,
                PorcentajeDescuentoSobreTarifa = model.PorcentajeDescuentoSobreTarifa,
                UsuarioCreacionId              = GetUsuarioId(),
                UsuarioModificacionId          = GetUsuarioId()
            };

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.ContratoCobertura.Guardar(obj);

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
        public JsonResult ContratoCoberturaElementoJson(Int32 pContratoCoberturaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCobertura.DtoContratoCobertura> res = LogicaNegocio.NovaComercial.dbo.ContratoCobertura.ConsultarPorId(pContratoCoberturaId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        //[HttpGet]
        //public ActionResult _CtrlContratoDefault()
        //{
        //    return PartialView();
        //}




        [HttpPost]
        public JsonResult ContratoCoberturaList(OpcionesCombo _opcion, int pContratoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCobertura.DtoComboContratoCobertura> res = LogicaNegocio.NovaComercial.dbo.ContratoCobertura.ConsultarCombo(pContratoId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            if (_opcion == OpcionesCombo.TODOS)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = "[TODOS]",
                        Value = "0"
                    }
                );
            }

            if (_opcion == OpcionesCombo.SELECCIONE)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = "[Seleccione...]",
                        Value = "0"
                    }
                );
            }

            foreach (Modelo.NovaComercial.dbo.ContratoCobertura.DtoComboContratoCobertura item in res.Datos)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.ContratoCoberturaDescripcion.ToString(),
                        Value = item.ContratoCoberturaId.ToString()
                    }
                );
            }

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        //[HttpPost]
        //public JsonResult ContratoCoberturaItem(int pContratoCoberturaId)
        //{
        //    List<SACC.Entidades.NovaComercial.dbo.ContratoCobertura> res = SACC.LogicaNegocio.NovaComercial.dbo.ContratoCobertura.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneral, pContratoCoberturaId, 0, "", 0);

        //    return Json(new { success = true, result = new { data = res } });
        //}




        //[HttpGet]
        //public ActionResult _CtrlUserContratoCobertura()
        //{
        //    return PartialView();
        //}
    }
}