using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Estudio.Controllers
{
    public class EstudioController : Client.Controllers.BaseController
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
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion
            
            return View();
        }

        [HttpPost]
        public JsonResult EstudioGridJson(String pEstudioDescripcion, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Estudio.DtoGridEstudio> res = LogicaNegocio.NovaComercial.dbo.Estudio.ConsultarGrid(pEstudioDescripcion, pEstatusId);

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
        public ActionResult Edit(Int32 pEstudioId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");
            
            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            
            List<Entidades.NovaComercial.dbo.Estudio> res = new List<Entidades.NovaComercial.dbo.Estudio>();
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion
            
            return View();
        }
        
        //[Authorize]
        //[HttpPost]
        //public ActionResult Edit(Models.EstudioModel model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/Logout");
            
        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
        //    else if (varPermisoValido == -1)
        //        Response.Redirect("~/Home/Logout");
            
        //    if (!ViewData.ModelState.IsValid) return View(model);
            
        //    Entidades.NovaComercial.dbo.Estudio obj = new Entidades.NovaComercial.dbo.Estudio
        //    {
        //        EstudioId             = model.EstudioId,
        //        EstudioDescripcion    = model.EstudioDescripcion,
        //        UsuarioCreacionId     = GetUsuarioId(),
        //        UsuarioModificacionId = GetUsuarioId(),
        //        FechaModificacion     = DateTime.Now
        //    };
            
        //    if (model.Baja == true)
        //        obj.UsuarioBajaId = GetUsuarioId();
            
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();
        //    res = LogicaNegocio.NovaComercial.dbo.Estudio.Guardar(obj);
            
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
        //        return RedirectToAction("Index", "Estudio");
        //}




        [Authorize]
        [HttpGet]
        public ActionResult Delete(Int32 pEstudioId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            
            List<Entidades.NovaComercial.dbo.Estudio> res = new List<Entidades.NovaComercial.dbo.Estudio>();
            
            ViewBag.Id = pEstudioId;
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion
            
            return View();
        }
        
        //[Authorize]
        //[HttpPost]
        //public ActionResult Delete(Models.EstudioModel model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/Logout");
            
        //    int varPermisoValido =  Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
        //    else if (varPermisoValido == -1)
        //        Response.Redirect("~/Home/Logout");
            
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();
        //    res = LogicaNegocio.NovaComercial.dbo.Estudio.BajaLogica(model.EstudioId, GetUsuarioId());
            
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
        //        return RedirectToAction("Index", "Estudio");
        //}




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

        //[Authorize]
        //[HttpPost]
        //public ActionResult Create(Models.EstudioModel model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/Logout");

        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
        //    else if (varPermisoValido == -1)
        //        Response.Redirect("~/Home/Logout");

        //    if (!ViewData.ModelState.IsValid) return View(model);

        //    Entidades.NovaComercial.dbo.Estudio obj = new Entidades.NovaComercial.dbo.Estudio
        //    {
        //        EstudioId             = model.EstudioId,
        //        EstudioDescripcion    = model.EstudioDescripcion,
        //        UsuarioCreacionId     = GetUsuarioId(),
        //        UsuarioModificacionId = GetUsuarioId()
        //    };

        //    Entidades.EntidadJsonResponse res = LogicaNegocio.NovaComercial.dbo.Estudio.Guardar(obj);

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
        //        return RedirectToAction("Index", "Estudio");
        //}

        
        
        
        [Authorize]
        [HttpGet]
        public ActionResult Visualizer()
        {
            return View();
        }




        




        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserBusquedaEstudio()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            return View();
        }

        //[Authorize]
        //[HttpPost]
        //public JsonResult CtrlUserEstudioPaqueteViewJson(Int32 pPaqueteId, String pEstudioDescripcion)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/SessionExpirada");

        //    if (HttpContext.Session["Permisos"] == null)
        //        Response.Redirect("~/Home/SinPermiso");

        //    List<Entidades.NovaComercial.dbo.PaqueteDetalle> res = LogicaNegocio.NovaComercial.dbo.PaqueteDetalle.Consultar(LogicaNegocio.SqlOpciones.ConsultaEstudios, pPaqueteId, pEstudioDescripcion, 0, 0);
            
        //    List<PaqueteDetalle.Models.PaqueteDetalleLista> model = new List<PaqueteDetalle.Models.PaqueteDetalleLista>();
        //    model = res.Select(x => new PaqueteDetalle.Models.PaqueteDetalleLista
        //    {
        //        PaqueteDetalleId        = x.PaqueteDetalleId,
        //        ServicioDescripcion     = x.CampoComplemento_ServicioDescripcion,
        //        ServicioTipoDescripcion = x.CampoComplemento_ServicioTipoDescripcion,
        //        CantidadEstudio         = x.CampoComplemento_CantidadItem
        //    }).ToList();
            
        //    return Json(new { success = true, result = new { data = model } });
        //}
        
        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserEstudioJson(Int32 pPaqueteId, String pPaqueteDescripcion, String pEstudioDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            List<Entidades.NovaComercial.dbo.Estudio> res = new List<Entidades.NovaComercial.dbo.Estudio>();
            //LogicaNegocio.NovaComercial.dbo.Estudio.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneral, 0, pEstudioDescripcion, 0);
            
            //List<PaqueteDetalle.Models.PaqueteDetalleSeleccion> model = new List<PaqueteDetalle.Models.PaqueteDetalleSeleccion>();
            //model = res.Select(x => new PaqueteDetalle.Models.PaqueteDetalleSeleccion
            //{
            //    PaqueteId           = pPaqueteId,
            //    PaqueteDescripcion  = pPaqueteDescripcion,
            //    ItemTipoId          = 5,
            //    ItemTipoDescripcion = x.CampoComplemento_ItemTipoDescripcion,
            //    ItemId              = x.EstudioId,
            //    ServicioDescripcion = x.EstudioDescripcion
            //}).ToList();
            
            return Json(new { success = true, result = new { data = String.Empty } });
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserEstudioConPrecioListJson(String pDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            List<Entidades.NovaComercial.dbo.Estudio> res = new List<Entidades.NovaComercial.dbo.Estudio>();
            //LogicaNegocio.NovaComercial.dbo.Estudio.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralConJoin, 0, pDescripcion, 0);
            
            List<Entidades.helper.Articulo> items = new List<Entidades.helper.Articulo>();
            foreach (Entidades.NovaComercial.dbo.Estudio item in res)
            {
                items.Add(new Entidades.helper.Articulo
                {
                    VentaUnitariaDetalleId     = 0,
                    VentaUnitariaId            = 0,
                    VentaUnitariaDetalleTipoId = 4,
                    ItemId                     = item.EstudioId,
                    Cantidad                   = 1,
                    ArticuloDescripcion        = item.EstudioDescripcion,
                    ArticuloTipoDescripcion    = "N/A",
                    Precio                     = item.CampoComplemento_PrecioVentaPublico,
                    Subtotal                   = item.CampoComplemento_PrecioVentaPublico
                });
            }
            
            return Json(new { success = true, result = new { data = items } });
        }
    }
}