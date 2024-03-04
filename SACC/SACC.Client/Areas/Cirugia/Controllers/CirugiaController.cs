using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Cirugia.Controllers
{
    public class CirugiaController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;
        

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");
            
            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion
            
            return View();
        }

        [HttpPost]
        public JsonResult CirugiaGridJson(String pCirugiaDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Cirugia.DtoGridCirugia> res = LogicaNegocio.NovaComercial.dbo.Cirugia.ConsultarGrid(pCirugiaDescripcion, pEstatusId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime   = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [Authorize]
        [HttpGet]
        public ActionResult Edit(Int32 pCirugiaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");
            
            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Cirugia.DtoCirugia> res = LogicaNegocio.NovaComercial.dbo.Cirugia.ConsultarPorId(pCirugiaId);

            //Models.CirugiaModel model = new Models.CirugiaModel();
            
            //if (res.Datos.Count > 0)
            //{
            //    model.CirugiaId          = short.Parse(res.Datos[0].CirugiaId.ToString());
            //    model.CirugiaDescripcion = res.Datos[0].CirugiaDescripcion;
            //    model.Baja               = res.Datos[0].Baja;
            //}
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion
            
            return View();
        }
        
        //[Authorize]
        //[HttpPost]
        //public ActionResult Edit(Models.CirugiaModel model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/Logout");
            
        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
        //    else if (varPermisoValido == -1)
        //        Response.Redirect("~/Home/Logout");
            
        //    if (!ViewData.ModelState.IsValid) return View(model);
            
        //    Entidades.NovaComercial.dbo.Cirugia obj = new Entidades.NovaComercial.dbo.Cirugia
        //    {
        //        CirugiaId             = model.CirugiaId,
        //        CirugiaDescripcion    = model.CirugiaDescripcion,
        //        UsuarioCreacionId     = GetUsuarioId(),
        //        UsuarioModificacionId = GetUsuarioId(),
        //        FechaModificacion     = DateTime.Now
        //    };
            
        //    if (model.Baja == true)
        //        obj.UsuarioBajaId = GetUsuarioId();
            
        //    Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.Cirugia.Guardar(obj);
            
        //    TempData["title"] = "Mensage";
        //    TempData["text"]  = res.Error == false ? res.Mensaje : res.MensajeError;
        //    TempData["type"]  = res.TipoMensaje;
            
        //    #region VARIABLES DE MENU
        //    TempData["lblNombre"] = GetNombreUsuario();
        //    if (HttpContext.Session["Foto"] != null)
        //        TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
        //    #endregion

        //    if (res.Error)
        //        return View(model);
        //    else
        //        return RedirectToAction("Index", "Cirugia");
        //}




        [Authorize]
        [HttpGet]
        public ActionResult Delete(Int32 pCirugiaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");
            
            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Cirugia.DtoCirugia> res = LogicaNegocio.NovaComercial.dbo.Cirugia.ConsultarPorId(pCirugiaId);

            //Models.CirugiaModel model = new Models.CirugiaModel();

            //if (res.Datos.Count > 0)
            //{
            //    model.CirugiaId          = short.Parse(res.Datos[0].CirugiaId.ToString());
            //    model.CirugiaDescripcion = res.Datos[0].CirugiaDescripcion;
            //    model.Baja               = res.Datos[0].Baja;
            //}
            
            ViewBag.Id = pCirugiaId;
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion
            
            return View();
        }
        
        //[Authorize]
        //[HttpPost]
        //public ActionResult Delete(Models.CirugiaModel model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/Logout");
            
        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
        //    else if (varPermisoValido == -1)
        //        Response.Redirect("~/Home/Logout");
            
        //    Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.Cirugia.BajaLogica(model.CirugiaId, GetUsuarioId());
            
        //    TempData["title"] = "Mensage";
        //    TempData["text"] = res.Error == false ? res.Mensaje : res.MensajeError;
        //    TempData["type"] = res.TipoMensaje;
            
        //    #region VARIABLES DE MENU
        //    TempData["lblNombre"] = GetNombreUsuario();
        //    if (HttpContext.Session["Foto"] != null)
        //        TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
        //    #endregion

        //    if (res.Error)
        //        return View(model);
        //    else
        //        return RedirectToAction("Index", "Cirugia");
        //}




        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");
            
            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion
            
            return View();
        }
        
        //[Authorize]
        //[HttpPost]
        //public ActionResult Create(Models.CirugiaModel model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/Logout");
            
        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
        //    else if (varPermisoValido == -1)
        //        Response.Redirect("~/Home/Logout");
            
        //    if (!ViewData.ModelState.IsValid) return View(model);
            
        //    Entidades.NovaComercial.dbo.Cirugia obj = new Entidades.NovaComercial.dbo.Cirugia
        //    {
        //        CirugiaId             = model.CirugiaId,
        //        CirugiaDescripcion    = model.CirugiaDescripcion,
        //        UsuarioCreacionId     = GetUsuarioId(),
        //        UsuarioModificacionId = GetUsuarioId()
        //    };
            
        //    Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.Cirugia.Guardar(obj);
            
        //    TempData["title"] = "Mensage";
        //    TempData["text"]  = res.Error == false ? res.Mensaje : res.MensajeError;
        //    TempData["type"]  = res.TipoMensaje;
            
        //    #region VARIABLES DE MENU
        //    TempData["lblNombre"] = GetNombreUsuario();
        //    if (HttpContext.Session["Foto"] != null)
        //        TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
        //    #endregion

        //    if (res.Error)
        //        return View(model);
        //    else
        //        return RedirectToAction("Index", "Cirugia");
        //}
        



        

        //[Authorize]
        //[HttpPost]
        //public JsonResult CtrlUserCirugiaPaqueteViewJson(Int32 pPaqueteId, String pCirugiaDescripcion)
        //{
        //    List<Entidades.NovaComercial.dbo.PaqueteDetalle> res = LogicaNegocio.NovaComercial.dbo.PaqueteDetalle.Consultar(LogicaNegocio.SqlOpciones.ConsultaCirugias, pPaqueteId, pCirugiaDescripcion, 0, 0);

        //    List<PaqueteDetalle.Models.PaqueteDetalleLista> model = new List<PaqueteDetalle.Models.PaqueteDetalleLista>();
        //    model = res.Select(x => new PaqueteDetalle.Models.PaqueteDetalleLista
        //    {
        //        PaqueteDetalleId = x.PaqueteDetalleId,
        //        ServicioDescripcion = x.CampoComplemento_ServicioDescripcion,
        //        ServicioTipoDescripcion = x.CampoComplemento_ServicioTipoDescripcion,
        //        CantidadCirugia = x.CampoComplemento_CantidadItem
        //    }).ToList();

        //    return Json(new { success = true, result = new { data = model } });
        //}




        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserBusquedaCirugia()
        {
            //return PartialView(new Models.CtrlUserCirugiaModel());
            return PartialView();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserCirugiaJson(Int32 pPaqueteId, String pPaqueteDescripcion, String pCirugiaDescripcion)
        {
            List<Entidades.NovaComercial.dbo.Cirugia> res = new List<Entidades.NovaComercial.dbo.Cirugia>();
            //LogicaNegocio.NovaComercial.dbo.Cirugia.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneral, 0, pCirugiaDescripcion, 0);

            //List<PaqueteDetalle.Models.PaqueteDetalleSeleccion> model = new List<PaqueteDetalle.Models.PaqueteDetalleSeleccion>();
            //model = res.Select(x => new PaqueteDetalle.Models.PaqueteDetalleSeleccion
            //{
            //    PaqueteId           = pPaqueteId,
            //    PaqueteDescripcion  = pPaqueteDescripcion,
            //    ItemTipoId          = 4,
            //    ItemTipoDescripcion = x.CampoComplemento_ItemTipoDescripcion,
            //    ItemId              = x.CirugiaId,
            //    ServicioDescripcion = x.CirugiaDescripcion
            //}).ToList();

            return Json(new { success = true, result = new { data = String.Empty } });
        }




        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserCirugiaConPrecioListJson(String pDescripcion)
        {
            List<Entidades.NovaComercial.dbo.Cirugia> res = new List<Entidades.NovaComercial.dbo.Cirugia>();
            //LogicaNegocio.NovaComercial.dbo.Cirugia.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralConJoin, 0, pDescripcion, 0);

            List<Entidades.helper.Articulo> items = new List<Entidades.helper.Articulo>();
            foreach (Entidades.NovaComercial.dbo.Cirugia item in res)
            {
                items.Add(new Entidades.helper.Articulo
                {
                    VentaUnitariaDetalleId     = 0,
                    VentaUnitariaId            = 0,
                    VentaUnitariaDetalleTipoId = 3,
                    ItemId                     = item.CirugiaId,
                    Cantidad                   = 1,
                    ArticuloDescripcion        = item.CirugiaDescripcion,
                    ArticuloTipoDescripcion    = "N/A",
                    Precio                     = item.CampoComplemento_PrecioVentaPublico,
                    Subtotal                   = item.CampoComplemento_PrecioVentaPublico
                });
            }

            return Json(new { success = true, result = new { data = items } });
        }
    }
}