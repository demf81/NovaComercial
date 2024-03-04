using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Cotizacion.Controllers
{
    public class CotizacionController : Client.Controllers.BaseController
    {
        const int _AplicacionId = 167;


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

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult CotizacionGridJson(String pCotizacionDescripcion, DateTime? pFechaInicio, DateTime? pFechaFin, Int16 pCotizacionTipoId, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cotizacion.DtoGridCotizacion> res = LogicaNegocio.NovaComercial.SACC.Cotizacion.ConsultarGrid(pCotizacionDescripcion, pFechaInicio, pFechaFin, pCotizacionTipoId, pEstatusId);

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
        public ActionResult _CtrlUserViewCotizacion()
        {
            return PartialView();
        }




        [Authorize]
        [HttpGet]
        public ActionResult Edit(Int32 pCotizacionId)
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

            ViewBag.CotizacionId = pCotizacionId;

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult Edit(Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion model, List<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoCotizacionDetalle> modelDetalle, List<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle> modelProcedimientoDetalle)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.SACC.Cotizacion obj = new Entidades.NovaComercial.SACC.Cotizacion
            {
                CotizacionId          = model.CotizacionId,
                CotizacionDescripcion = model.CotizacionDescripcion,
                Fecha                 = model.Fecha,
                CotizacionTipoId      = model.CotizacionTipoId,
                PersonaId             = model.PersonaId,
                PersonaNombre         = (model.PersonaNombre == null ? "" : model.PersonaNombre),
                Telefono              = (model.Telefono == null ? "" : model.Telefono),
                CorreoElectronico     = (model.CorreoElectronico == null ? "" : model.CorreoElectronico),
                Contacto              = (model.Contacto == null ? "" : model.Contacto),
                EmpresaId             = model.EmpresaId,
                EmpresaNombre         = (model.EmpresaNombre == null ? "" : model.EmpresaNombre),
                SubTotal              = Math.Round(model.SubTotal / Decimal.Parse("1.16"), 2),
                Descuento             = model.Descuento,
                CampaniaId            = model.CampaniaId,
                Iva                   = Math.Round((model.SubTotal / Decimal.Parse("1.16")) * Decimal.Parse("0.16"), 2),
                Total                 = model.Total,
                UsuarioCreacionId     = GetUsuarioId(),
                UsuarioModificacionId = GetUsuarioId(),
                CotizacionEstatusId   = model.CotizacionEstatusId
            };

            List<Entidades.NovaComercial.SACC.CotizacionDetalle> objDetalle = new List<Entidades.NovaComercial.SACC.CotizacionDetalle>();
            foreach (Modelo.NovaComercial.SACC.CotizacionDetalle.DtoCotizacionDetalle item in modelDetalle)
            {
                Entidades.NovaComercial.SACC.CotizacionDetalle _Detalle = new Entidades.NovaComercial.SACC.CotizacionDetalle
                {
                    CotizacionDetalleId   = item.CotizacionDetalleId,
                    CotizacionId          = item.CotizacionId,
                    AreaNegocioId         = item.AreaNegocioId,
                    ServicioId            = item.ServicioId,
                    ItemId                = item.ItemId,
                    ItemDescripcion       = item.ItemDescripcion,
                    ItemTipoId            = item.ItemTipoId,
                    ItemTipoDescripcion   = item.ItemTipoDescripcion,
                    Cantidad              = item.Cantidad,
                    Costo                 = item.Costo,
                    Precio                = item.Precio,
                    Descuento             = item.Descuento,
                    CampaniaId            = item.CampaniaId,
                    TarifaId              = item.TarifaId,
                    Iva                   = item.Iva,
                    SubTotal              = item.SubTotal,
                    Amparada              = item.Amparada,
                    UsuarioModificacionId = GetUsuarioId(),
                };

                objDetalle.Add(_Detalle);
            }

            List<Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle> objProcedimientoDetalle = new List<Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle>();
            if (modelProcedimientoDetalle == null)
                modelProcedimientoDetalle = new List<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle>();

            foreach (Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle item in modelProcedimientoDetalle)
            {
                Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle _DetalleProcedimiento = new Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle
                {
                    CotizacionProcedimientoDetalleId = item.CotizacionProcedimientoDetalleId,
                    CotizacionDetalleId              = item.CotizacionId,
                    CotizacionId                     = item.CotizacionId,
                    ProcedimientoDetalleId           = item.ProcedimientoDetalleId,
                    ProcedimientoId                  = item.ProcedimientoId,
                    ServicioId                       = item.ServicioId,
                    ServicioPartidaId                = item.ServicioPartidaId,
                    ProcedimientoDetalleDescripcion  = item.ProcedimientoDetalleDescripcion,
                    Posicion                         = item.Posicion,
                    ClaseOperacion                   = item.ClaseOperacion,
                    ElementoId                       = item.ElementoId,
                    Cantidad                         = item.Cantidad,
                    Unidad                           = item.Unidad,
                    CantidadBase                     = item.CantidadBase,
                    Tarifa                           = item.Tarifa,
                    Costo                            = item.Costo,
                    Precio                           = item.Precio,
                    Iva                              = Math.Round((item.Precio * item.Cantidad) * Decimal.Parse("0.16"), 2),
                    TarifaId                         = item.TarifaId,
                    SubTotal                         = Math.Round(item.Precio * item.Cantidad, 2),
                    Seleccionado                     = item.Seleccionado,
                    UsuarioModificacionId            = GetUsuarioId()
                };

                objProcedimientoDetalle.Add(_DetalleProcedimiento);
            }

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.Cotizacion.Guardar(obj, objDetalle, objProcedimientoDetalle);

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
        public ActionResult Delete(Int32 pCotizacionId)
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

            ViewBag.CotizacionId = pCotizacionId;

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Delete(Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.Cotizacion.BajaLogica(model.CotizacionId, GetUsuarioId());

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
        public ActionResult Create()
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
            
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Create(Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion model, List<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoCotizacionDetalle> modelDetalle, List<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle> modelProcedimientoDetalle)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.SACC.Cotizacion obj = new Entidades.NovaComercial.SACC.Cotizacion
            {
                CotizacionId          = model.CotizacionId,
                CotizacionDescripcion = model.CotizacionDescripcion,
                Fecha                 = model.Fecha,
                CotizacionTipoId      = model.CotizacionTipoId,
                PersonaId             = model.PersonaId,
                PersonaNombre         = (model.PersonaNombre == null ? "" : model.PersonaNombre),
                Telefono              = (model.Telefono == null ? "" : model.Telefono),
                CorreoElectronico     = (model.CorreoElectronico == null ? "" : model.CorreoElectronico),
                Contacto              = (model.Contacto == null ? "" : model.Contacto),
                EmpresaId             = model.EmpresaId,
                EmpresaNombre         = (model.EmpresaNombre == null ? "" : model.EmpresaNombre),
                SubTotal              = model.SubTotal,
                Descuento             = model.Descuento,
                CampaniaId            = model.CampaniaId,
                Iva                   = model.Iva,
                Total                 = model.Total,
                UsuarioCreacionId     = GetUsuarioId()
            };

            List<Entidades.NovaComercial.SACC.CotizacionDetalle> objDetalle = new List<Entidades.NovaComercial.SACC.CotizacionDetalle>();
            foreach (Modelo.NovaComercial.SACC.CotizacionDetalle.DtoCotizacionDetalle item in modelDetalle)
            {
                Entidades.NovaComercial.SACC.CotizacionDetalle _Detalle = new Entidades.NovaComercial.SACC.CotizacionDetalle
                {
                    CotizacionDetalleId   = item.CotizacionDetalleId,
                    CotizacionId          = item.CotizacionId,
                    AreaNegocioId         = item.AreaNegocioId,
                    ServicioId            = item.ServicioId,
                    ItemId                = item.ItemId,
                    ItemDescripcion       = item.ItemDescripcion,
                    ItemTipoId            = item.ItemTipoId,
                    ItemTipoDescripcion   = item.ItemTipoDescripcion,
                    Cantidad              = item.Cantidad,
                    Costo                 = Math.Round(item.Costo, 2),
                    Precio                = Math.Round(item.PrecioConIva / Decimal.Parse("1.16"), 2),
                    Descuento             = item.Descuento,
                    CampaniaId            = item.CampaniaId,
                    TarifaId              = item.TarifaId,
                    Iva                   = Math.Round(((item.PrecioConIva / Decimal.Parse("1.16")) * item.Cantidad) * Decimal.Parse("0.16"), 2),
                    SubTotal              = Math.Round((item.PrecioConIva / Decimal.Parse("1.16")) * item.Cantidad, 2),
                    Amparada              = item.Amparada,
                    UsuarioCreacionId     = GetUsuarioId()
                };

                objDetalle.Add(_Detalle);
            }

            List<Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle> objProcedimientoDetalle = new List<Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle>();
            if (modelProcedimientoDetalle == null)
                modelProcedimientoDetalle = new List<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle>();

            foreach (Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle item in modelProcedimientoDetalle)
            {
                //if (item.ProcedimientoDetalleDescripcion == "MED.ESP.(GASTROENTEROLOGO)")
                //{
                //    var x = 1;
                //}
                   

                Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle _DetalleProcedimiento = new Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle
                {
                    CotizacionProcedimientoDetalleId = 0,
                    CotizacionDetalleId              = 0,
                    CotizacionId                     = 0,
                    ProcedimientoDetalleId           = item.ProcedimientoDetalleId,
                    ProcedimientoId                  = item.ProcedimientoId,
                    ServicioId                       = item.ServicioId,
                    ServicioPartidaId                = item.ServicioPartidaId,
                    ProcedimientoDetalleDescripcion  = item.ProcedimientoDetalleDescripcion,
                    Posicion                         = item.Posicion,
                    ClaseOperacion                   = item.ClaseOperacion,
                    ElementoId                       = item.ElementoId,
                    Cantidad                         = item.Cantidad,
                    Unidad                           = item.Unidad,
                    CantidadBase                     = item.CantidadBase,
                    Tarifa                           = item.Tarifa,
                    Costo                            = item.Costo,
                    Precio                           = Math.Round(item.Precio / Decimal.Parse("1.16"), 2),
                    Iva                              = Math.Round(((item.Precio / Decimal.Parse("1.16")) * item.Cantidad) * Decimal.Parse("0.16"), 2),
                    TarifaId                         = item.TarifaId,
                    SubTotal                         = Math.Round((item.Precio / Decimal.Parse("1.16")) * item.Cantidad, 2),
                    Seleccionado                     = item.Seleccionado,
                    UsuarioCreacionId                = GetUsuarioId()
                };

                objProcedimientoDetalle.Add(_DetalleProcedimiento);
            }

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.Cotizacion.Guardar(obj, objDetalle, objProcedimientoDetalle);
            
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
        public JsonResult CotizacionElementoJson(Int32 pCotizacionId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cotizacion.DtoCotizacion> res = LogicaNegocio.NovaComercial.SACC.Cotizacion.ConsultarPorIdConJoin(pCotizacionId);

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
        public ActionResult CreatePDF()
        {
            return View();
        }

        


        public FileResult CreatePDFJson(Int64 parCotizacionId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            LogicaNegocio.NovaComercial.SACC.Cotizacion.CreatePDF(parCotizacionId, GetCorreoElectronico());


            string path = ConfigurationManager.AppSettings["DirectorioPrincipal"].ToString() + "\\Plantilla\\Cotizacion" + parCotizacionId.ToString() + ".pdf";
            byte[] bytes = System.IO.File.ReadAllBytes(path);


            return File(bytes, "application/octet-stream", "Cotizacion" + parCotizacionId.ToString() + ".pdf");
        }
    }
}