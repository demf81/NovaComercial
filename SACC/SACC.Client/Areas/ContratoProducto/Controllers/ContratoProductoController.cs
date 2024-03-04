using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.ContratoProducto.Controllers
{
    public class ContratoProductoController : Client.Controllers.BaseController
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
        public JsonResult ContratoProductoGridJson(Int32 pContratoId)
        {

            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoGridContratoProducto> res = LogicaNegocio.NovaComercial.dbo.ContratoProducto.ConsultarGrid(pContratoId, 1);

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
        public ActionResult Edit(Int32 pContratoProductoId, Int32 pContratoId, String pContratoDescripcion)
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

            ViewBag.ContratoProductoId  = pContratoProductoId;
            ViewBag.ContratoId          = pContratoId;
            ViewBag.ContratoDescripcion = pContratoDescripcion;

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Edit(Modelo.NovaComercial.dbo.ContratoProducto.DtoContratoProducto model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.dbo.ContratoProducto obj = new Entidades.NovaComercial.dbo.ContratoProducto
            {
                ContratoProductoId             = model.ContratoProductoId,
                ContratoId                     = model.ContratoId,
                ContratoProductoDescripcion    = model.ContratoProductoDescripcion,
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

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.ContratoProducto.Guardar(obj);

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
        public ActionResult Delete(Int32 pContratoProductoId, Int32 pContratoId, String pContratoDescripcion)
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

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Delete(Int32 pContratoProductoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.ContratoProducto.BajaLogica(pContratoProductoId, GetUsuarioId());

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
        public ActionResult Create(int pContratoId, string pContratoDescripcion)
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

            ViewBag.ContratoId = pContratoId;
            ViewBag.ContratoDescripcion = pContratoDescripcion;

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult Create(Modelo.NovaComercial.dbo.ContratoProducto.DtoContratoProducto model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.dbo.ContratoProducto obj = new Entidades.NovaComercial.dbo.ContratoProducto
            {
                ContratoProductoId             = model.ContratoProductoId,
                ContratoId                     = model.ContratoId,
                ContratoProductoDescripcion    = model.ContratoProductoDescripcion,
                EsquemaPrePago                 = model.EsquemaPrePago,
                CobroAnticipado                = model.CobroAnticipado,
                TarifaId                       = 1,
                PorcentajeUtilidadSobreTarifa  = model.PorcentajeUtilidadSobreTarifa,
                PorcentajeCopagoContratante    = model.PorcentajeCopagoContratante,
                PorcentajeDescuentoSobreTarifa = model.PorcentajeDescuentoSobreTarifa,
                UsuarioCreacionId              = GetUsuarioId(),
                UsuarioModificacionId          = GetUsuarioId()
            };

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.ContratoProducto.Guardar(obj);

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
        public JsonResult ContratoProductoElementoJson(Int32 pContratoProductoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoContratoProducto> res = LogicaNegocio.NovaComercial.dbo.ContratoProducto.ConsultarPorId(pContratoProductoId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [HttpPost]
        public JsonResult ContratoProductoList(OpcionesCombo _opcion, int pContratoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoComboContratoProducto> res = LogicaNegocio.NovaComercial.dbo.ContratoProducto.ConsultarCombo(pContratoId);

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

            foreach (Modelo.NovaComercial.dbo.ContratoProducto.DtoComboContratoProducto item in res.Datos)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.ContratoProductoDescripcion.ToString(),
                        Value = item.ContratoProductoId.ToString()
                    }
                );
            }

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        //[HttpPost]
        //public JsonResult ContratoProductoItem(int pContratoProductoId)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/SessionExpirada");

        //    if (HttpContext.Session["Permisos"] == null)
        //        Response.Redirect("~/Home/SinPermiso");

        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");

        //    Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoContratoProducto> res = SACC.LogicaNegocio.NovaComercial.dbo.ContratoProducto.ConsultarPorId(pContratoProductoId);

        //    return Json(new { success = true, result = new { data = res } });
        //}
    }




        //[HttpPost]
        //public JsonResult ContratoProductoList(OpcionesCombo _opcion, int pContratoId)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/SessionExpirada");

        //    if (HttpContext.Session["Permisos"] == null)
        //        Response.Redirect("~/Home/SinPermiso");

        //    List<SelectListItem> items = new List<SelectListItem>();

        //    List<SACC.Entidades.NovaComercial.dbo.ContratoProducto> res = SACC.LogicaNegocio.NovaComercial.dbo.ContratoProducto.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneral, 0, pContratoId, "", 0);

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

        //    foreach (SACC.Entidades.NovaComercial.dbo.ContratoProducto item in res)
        //    {
        //        items.Add(
        //            new SelectListItem
        //            {
        //                Text  = item.ContratoProductoDescripcion.ToString(),
        //                Value = item.ContratoProductoId.ToString()
        //            }
        //        );
        //    }

        //    return Json(new { success = true, result = new { data = items } });
        //}
}