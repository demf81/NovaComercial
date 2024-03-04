using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.ServicioMedico.Controllers
{
    public class ServicioMedicoController : Client.Controllers.BaseController
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
        public JsonResult ServicioGridJson(String pServicioDescripcion, Int16 pServicioTipoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Servicio.DtoGridServicio> res = LogicaNegocio.NovaComercial.dbo.Servicio.ConsultarGrid(pServicioDescripcion, pServicioTipoId, pEstatusId);

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
        public ActionResult _CtrlUserBusquedaServicioMedico()
        {
            return PartialView();
        }

        [Authorize]
        [HttpPost]
        public JsonResult _CtrlUserBusquedaServicioMedicoJson(Int32 pPaqueteId, String pPaqueteDescripcion, String pServicioDescripcion, Int16 pServicioTipoId)
        {
            //Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Servicio.DtoGridServicio> res = LogicaNegocio.NovaComercial.dbo.Servicio.ConsultarGrid(pServicioDescripcion, pServicioTipoId, 0);
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleView> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleView>();// LogicaNegocio.NovaComercial.dbo.PaqueteDetalle.ConsultarDetallePorServicio(pPaqueteId, 1, pServicioDescripcion, pServicioTipoId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });

            //List<PaqueteDetalle.Models.PaqueteDetalleSeleccion> model = new List<PaqueteDetalle.Models.PaqueteDetalleSeleccion>();
            //model = res.Datos.Select(x => new PaqueteDetalle.Models.PaqueteDetalleSeleccion
            //{
            //    PaqueteId               = pPaqueteId,
            //    PaqueteDescripcion      = pPaqueteDescripcion,
            //    ItemTipoId              = 1,
            //    ItemTipoDescripcion     = x.ServicioDescripcion,// .CampoComplemento_ItemTipoDescripcion,
            //    ItemId                  = x.ServicioId,
            //    ServicioDescripcion     = x.ServicioDescripcion,
            //    ServicioTipoDescripcion = x.ServicioTipoDescripcion  //.CampoComplemento_ServicioTipoDescripcion
            //}).ToList();

            //return Json(new { success = true, result = new { data = model } });
        }




        //[Authorize]
        //[HttpPost]
        //public JsonResult CtrlUserServicioPaqueteViewJson(Int32 pPaqueteId, String pServicioDescripcion, Int16 pServicioTipoId)
        //{
        //    List<Entidades.NovaComercial.dbo.PaqueteDetalle> res = LogicaNegocio.NovaComercial.dbo.PaqueteDetalle.Consultar(LogicaNegocio.SqlOpciones.ConsultaServicios, pPaqueteId, pServicioDescripcion, pServicioTipoId, 0);

        //    List<PaqueteDetalle.Models.PaqueteDetalleLista> model = new List<PaqueteDetalle.Models.PaqueteDetalleLista>();
        //    model= res.Select(x => new PaqueteDetalle.Models.PaqueteDetalleLista
        //    {
        //        PaqueteDetalleId        = x.PaqueteDetalleId,
        //        ServicioDescripcion     = x.CampoComplemento_ServicioDescripcion,
        //        ServicioTipoDescripcion = x.CampoComplemento_ServicioTipoDescripcion,
        //        CantidadServicio        = x.CampoComplemento_CantidadItem
        //    }).ToList();

        //    return Json(new { success = true, result = new { data = model } });
        //}




        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserServicioConPrecioListJson(String pDescripcion)
        {
            List<Entidades.NovaComercial.dbo.Servicio> res = new List<Entidades.NovaComercial.dbo.Servicio>();
            //LogicaNegocio.NovaComercial.dbo.Servicio.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralConJoin, 0, pDescripcion, 0, 0);

            List<Entidades.helper.Articulo> items = new List<Entidades.helper.Articulo>();
            foreach (Entidades.NovaComercial.dbo.Servicio item in res)
            {
                items.Add(new Entidades.helper.Articulo
                {
                    VentaUnitariaDetalleId     = 0,
                    VentaUnitariaId            = 0,
                    VentaUnitariaDetalleTipoId = 2,
                    ItemId                     = item.ServicioId,
                    Cantidad                   = 1,
                    ArticuloDescripcion        = item.ServicioDescripcion,
                    ArticuloTipoDescripcion    = item.CampoComplemento_ServicioTipoDescripcion,
                    Precio                     = item.PrecioVentaPublico,
                    Subtotal                   = item.PrecioVentaPublico
                });
            }

            return Json(new { success = true, result = new { data = items } });
        }
    }
}