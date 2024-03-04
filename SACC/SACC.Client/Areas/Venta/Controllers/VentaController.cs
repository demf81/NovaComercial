using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Venta.Controllers
{
    public class VentaController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167; //251;


        [Authorize]
        [HttpGet]
        public ActionResult Index(Int16 pOpcion)
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

            ViewBag.Opcion = pOpcion;

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult VentaGridJson(String pVentaDescripcion, DateTime? pFechaInicio, DateTime? pFechaFin, Int16 pVentaTipoId, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Venta.DtoGridVenta> res = LogicaNegocio.NovaComercial.SACC.Venta.ConsultarGrid(pVentaDescripcion, pFechaInicio, pFechaFin, pVentaTipoId, pEstatusId);

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
        public ActionResult Edit(Int32 pVentaId)
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

            ViewBag.VentaId = pVentaId;

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Edit(Modelo.NovaComercial.SACC.Venta.DtoVenta model, List<Modelo.NovaComercial.SACC.VentaDetalle.DtoVentaDetalle> modelDetalle)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");

            Entidades.NovaComercial.SACC.Venta oE = new Entidades.NovaComercial.SACC.Venta
            {
                VentaId               = model.VentaId,
                CotizacionId          = model.CotizacionId,
                VentaDescripcion      = model.VentaDescripcion,
                Fecha                 = model.Fecha,
                VentaTipoId           = model.VentaTipoId,
                PersonaId             = model.PersonaId,
                EmpresaId             = model.EmpresaId,
                SubTotal              = model.SubTotal,
                Descuento             = (model.Descuento == null ? 0 : model.Descuento),
                CampaniaId            = (model.CampaniaId == null ? -1 : model.CampaniaId),
                Iva                   = model.Iva,
                Total                 = model.Total,
                Referencia            = model.Referencia,
                UsuarioCreacionId     = GetUsuarioId(),
                UsuarioModificacionId = GetUsuarioId(),
                //VentaEstatusId        = model.VentaEstatusId
            };

            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse(); // LogicaNegocio.NovaComercial.dbo.Venta.Guardar(oE, new Entidades.NovaComercial.SACC.VentaDetalle());

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
        public ActionResult _Delete()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            return PartialView();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Delete(Int32 pVentaId, Int16 pVentaMotivoCancelacionTipoId, String pComentario)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.Venta.Cancelar(pVentaId, GetUsuarioId());

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            if (!res.Error)
            {
                if (res.Id > 0)
                {
                    Entidades.NovaComercial.SACC.VentaCancelacion objCancelacion = new Entidades.NovaComercial.SACC.VentaCancelacion {
                        VentaId                      = res.Id,
                        VentaMotivoCancelacionTipoId = pVentaMotivoCancelacionTipoId,
                        Comentario                   = pComentario,
                        UsuarioCreacionId            = GetUsuarioId()
                    };

                    Modelo.ModeloJsonResponse resCancelar = LogicaNegocio.NovaComercial.SACC.VentaCancelacion.Guardar(objCancelacion);
                }
            }
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
        public ActionResult Create(Int16 pOpcion)
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

            ViewBag.Opcion = pOpcion;

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult Create(Modelo.NovaComercial.SACC.Venta.DtoVenta model, List<Modelo.NovaComercial.SACC.VentaDetalle.DtoVentaDetalle> modelDetalle, List<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoVentaProcedimientoDetalle> modelProcedimientoDetalle)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.SACC.Venta obj = new Entidades.NovaComercial.SACC.Venta
            {
                VentaId           = model.VentaId,
                CotizacionId      = model.CotizacionId,
                VentaDescripcion  = model.VentaDescripcion,
                Fecha             = model.Fecha,
                VentaTipoId       = model.VentaTipoId,
                PersonaId         = model.PersonaId,
                EmpresaId         = model.EmpresaId,
                SubTotal          = model.SubTotal,
                Descuento         = model.Descuento,
                CampaniaId        = model.CampaniaId,
                Iva               = model.Iva,
                Total             = model.Total,
                Referencia        = (model.Referencia == null ? String.Empty : model.Referencia),
                Anticipo          = model.Anticipo,
                UsuarioCreacionId = GetUsuarioId()
            };

            List<Entidades.NovaComercial.SACC.VentaDetalle> objDetalle = new List<Entidades.NovaComercial.SACC.VentaDetalle>();

            foreach (Modelo.NovaComercial.SACC.VentaDetalle.DtoVentaDetalle item in modelDetalle)
            {
                Entidades.NovaComercial.SACC.VentaDetalle _Detalle = new Entidades.NovaComercial.SACC.VentaDetalle
                {
                    VentaDetalleId      = item.VentaDetalleId,
                    VentaId             = item.VentaId,
                    AreaNegocioId       = item.AreaNegocioId,
                    ServicioId          = item.ServicioId,
                    ItemId              = item.ItemId,
                    ItemDescripcion     = item.ItemDescripcion,
                    ItemTipoId          = item.ItemTipoId,
                    ItemTipoDescripcion = item.ItemTipoDescripcion,
                    Cantidad            = item.Cantidad,
                    Costo               = item.Costo,
                    Precio              = item.Precio,
                    Descuento           = item.Descuento,
                    CampaniaId          = item.CampaniaId,
                    TarifaId            = item.TarifaId,
                    Iva                 = item.Iva,
                    SubTotal            = item.SubTotal,
                    Referencia          = (item.Referencia == null ? String.Empty : item.Referencia),
                    Anticipo            = item.Anticipo,
                    Amparada            = item.Amparada,
                    UsuarioCreacionId   = GetUsuarioId()
                };

                objDetalle.Add(_Detalle);
            }

            List<Entidades.NovaComercial.SACC.VentaProcedimientoDetalle> objProcedimientoDetalle = new List<Entidades.NovaComercial.SACC.VentaProcedimientoDetalle>();
            if (modelProcedimientoDetalle == null)
                modelProcedimientoDetalle = new List<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoVentaProcedimientoDetalle>();

            foreach (Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoVentaProcedimientoDetalle item in modelProcedimientoDetalle)
            {
                Entidades.NovaComercial.SACC.VentaProcedimientoDetalle _DetalleProcedimiento = new Entidades.NovaComercial.SACC.VentaProcedimientoDetalle
                {
                    VentaProcedimientoDetalleId     = 0,
                    VentaDetalleId                  = 0,
                    VentaId                         = 0,
                    ProcedimientoDetalleId          = item.ProcedimientoDetalleId,
                    ProcedimientoId                 = item.ProcedimientoId,
                    ServicioId                      = item.ServicioId,
                    ServicioPartidaId               = item.ServicioPartidaId,
                    ProcedimientoDetalleDescripcion = item.ProcedimientoDetalleDescripcion,
                    Posicion                        = item.Posicion,
                    ClaseOperacion                  = item.ClaseOperacion,
                    ElementoId                      = item.ElementoId,
                    Cantidad                        = item.Cantidad,
                    Unidad                          = item.Unidad,
                    CantidadBase                    = item.CantidadBase,
                    Tarifa                          = item.Tarifa,
                    Costo                           = item.Costo,
                    Precio                          = item.Precio,
                    Iva                             = item.Iva,
                    TarifaId                        = item.TarifaId,
                    SubTotal                        = item.SubTotal,
                    Seleccionado                    = item.Seleccionado,
                    UsuarioCreacionId               = GetUsuarioId()
                };

                objProcedimientoDetalle.Add(_DetalleProcedimiento);
            }

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.Venta.Guardar(obj, objDetalle, objProcedimientoDetalle);

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




        [HttpPost]
        public JsonResult VentaElementoJson(Int32 pVentaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Venta.DtoVenta> res = LogicaNegocio.NovaComercial.SACC.Venta.ConsultarPorIdConJoin(pVentaId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }



        [HttpGet]
        public ActionResult _LineaVida()
        {
            return PartialView();
        }
    }
}