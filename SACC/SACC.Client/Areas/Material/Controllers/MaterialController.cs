using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Material.Controllers
{
    public class MaterialController : Client.Controllers.BaseController
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
        public JsonResult MaterialGridJson(String pMaterialDescripcion, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Material.DtoGridMaterial> res = LogicaNegocio.NovaComercial.dbo.Material.ConsultarGrid(pMaterialDescripcion, pEstatusId);

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
        public ActionResult Visualizer()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            return View();
        }




        

        //[Authorize]
        //[HttpPost]
        //public JsonResult CtrlUserMaterialPaqueteViewJson(Int32 pPaqueteId, String pMaterialDescripcion)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/SessionExpirada");

        //    if (HttpContext.Session["Permisos"] == null)
        //        Response.Redirect("~/Home/SinPermiso");

        //    List<Entidades.NovaComercial.dbo.PaqueteDetalle> res = LogicaNegocio.NovaComercial.dbo.PaqueteDetalle.Consultar(LogicaNegocio.SqlOpciones.ConsultaMateriales, pPaqueteId, pMaterialDescripcion, 0, 0);

        //    List<PaqueteDetalle.Models.PaqueteDetalleLista> model = new List<PaqueteDetalle.Models.PaqueteDetalleLista>();
        //    model = res.Select(x => new PaqueteDetalle.Models.PaqueteDetalleLista
        //    {
        //        PaqueteDetalleId        = x.PaqueteDetalleId,
        //        ServicioDescripcion     = x.CampoComplemento_ServicioDescripcion,
        //        ServicioTipoDescripcion = x.CampoComplemento_ServicioTipoDescripcion,
        //        CantidadMaterial        = x.CampoComplemento_CantidadItem
        //    }).ToList();

        //    return Json(new { success = true, result = new { data = model } });
        //}




        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserBusquedaMaterial()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            return PartialView();
        }
                
        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserMaterialJson(Int32 pPaqueteId, String pPaqueteDescripcion, String pMaterialDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Material.DtoGridMaterial> res = LogicaNegocio.NovaComercial.dbo.Material.ConsultarGrid(pMaterialDescripcion, 0);
            
            //List<PaqueteDetalle.Models.PaqueteDetalleSeleccion> model = new List<PaqueteDetalle.Models.PaqueteDetalleSeleccion>();
            //model = res.Datos.Select(x => new PaqueteDetalle.Models.PaqueteDetalleSeleccion
            //{
            //    PaqueteId           = pPaqueteId,
            //    PaqueteDescripcion  = pPaqueteDescripcion,
            //    ItemTipoId          = 2,
            //    ItemTipoDescripcion = "", //x.CampoComplemento_ItemTipoDescripcion,
            //    ItemId              = x.MaterialId,
            //    ServicioDescripcion = x.MaterialDescripcion
            //}).ToList();
            
            return Json(new { success = true, result = new { data = String.Empty } });
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserMaterialConPrecioListJson(String pDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            List<Entidades.NovaComercial.dbo.Material> res = new List<Entidades.NovaComercial.dbo.Material>();
            //LogicaNegocio.NovaComercial.dbo.Material.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralConJoin, 0, pDescripcion, 0);
            
            List<Entidades.helper.Articulo> items = new List<Entidades.helper.Articulo>();
            foreach (Entidades.NovaComercial.dbo.Material item in res)
            {
                items.Add(new Entidades.helper.Articulo
                {
                    VentaUnitariaDetalleId     = 0,
                    VentaUnitariaId            = 0,
                    VentaUnitariaDetalleTipoId = 5,
                    ItemId                     = item.MaterialId,
                    Cantidad                   = 1,
                    ArticuloDescripcion        = item.MaterialDescripcion,
                    ArticuloTipoDescripcion    = "N/A",
                    Precio                     = item.PrecioVentaPublico,
                    Subtotal                   = item.PrecioVentaPublico
                });
            }
            
            return Json(new { success = true, result = new { data = items } });
        }
    }
}