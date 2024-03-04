using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.ContratoProductoPaquete.Controllers
{
    public class ContratoProductoPaqueteController : SACC.Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index(Int32 pContratoProductoId, String pContratoProductoDescripcion, Int32 pContratoId, String pContratoDescripcion)
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

            ViewBag.ContratoProductoId          = pContratoProductoId;
            ViewBag.ContratoProductoDescripcion = pContratoProductoDescripcion;
            ViewBag.ContratoId                  = pContratoId;
            ViewBag.ContratoDescripcion         = pContratoDescripcion;

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult ContratoProductoPaqueteJson(Int32 pContratoProductoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaquete> res = LogicaNegocio.NovaComercial.dbo.ContratoProductoPaquete.ConsultarGrid(pContratoProductoId, -1, 1);

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
        public JsonResult Delete(Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoContratoProductoPaquete model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.dbo.ContratoProductoPaquete.BajaLogica(model.ContratoProductoPaqueteId, GetUsuarioId());

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
        public JsonResult Create(List<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoContratoProductoPaquete> list)
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
                foreach (Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoContratoProductoPaquete item in list)
                {
                    Entidades.NovaComercial.dbo.ContratoProductoPaquete obj = new Entidades.NovaComercial.dbo.ContratoProductoPaquete
                    {
                        ContratoProductoPaqueteId = 0,
                        ContratoProductoId        = item.ContratoProductoId,
                        PaqueteId                 = item.PaqueteId,
                        UsuarioCreacionId         = GetUsuarioId(),
                        UsuarioModificacionId     = GetUsuarioId()
                    };

                    res = LogicaNegocio.NovaComercial.dbo.ContratoProductoPaquete.Guardar(obj);
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
        [HttpPost]
        public JsonResult ContratoProductoPaquetePaqueteJson(OpcionesCombo _opcion, Int32 pContratoProductoId, Int32 pPersonaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoComboContratoProductoPaquete> res = LogicaNegocio.NovaComercial.dbo.ContratoProductoPaquete.ConsultarCombo(pContratoProductoId, pPersonaId);

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
                        Value = "-1"
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

            foreach (Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoComboContratoProductoPaquete item in res.Datos)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.PaqueteDescripcion.ToString(),
                        Value = item.PaqueteId.ToString()
                    }
                );
            }

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [Authorize]
        [HttpPost]
        public JsonResult ContratoProductoPaqueteConPrecioList(Int32 pContratoProductoId, Int32 pPaqueteId, Int32 pPersonaId, String pDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaqueteVentaUnitaria> res = LogicaNegocio.NovaComercial.dbo.ContratoProductoPaquete.ConsultarPorContratoProducto(pContratoProductoId, pPaqueteId);

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

            //List<SACC.Entidades.NovaComercial.dbo.ContratoProductoPaquete> res = SACC.LogicaNegocio.NovaComercial.dbo.ContratoProductoPaquete.Consultar(LogicaNegocio.SqlOpciones.ConsiltaGeneralContratoProductoPaquete, 0, pContratoProductoId, pPaqueteId, pPersonaId, 0);

            //List<Entidades.helper.Articulo> items = new List<Entidades.helper.Articulo>();
            //foreach (SACC.Entidades.NovaComercial.dbo.ContratoProductoPaquete item in res)
            //{
            //    items.Add(new Entidades.helper.Articulo
            //    {
            //        VentaUnitariaDetalleId     = 0,
            //        VentaUnitariaId            = 0,
            //        VentaUnitariaDetalleTipoId = 1,
            //        ItemId                     = item.PaqueteId,
            //        Cantidad                   = 1,
            //        ArticuloDescripcion        = item.CampoComplemento_PaqueteDescripcion,
            //        Precio                     = item.CampoComplemento_PrecioVentaPublico,
            //        Subtotal                   = item.CampoComplemento_PrecioVentaPublico,
            //        Amparado                   = true
            //    });
            //}

            //return Json(new { success = true, result = new { data = items } });
        }
    }
}


//[HttpPost]
//public JsonResult ContratoProductoPaqueteJson(int pContratoProductoId)
//{
//    if (GetUsuarioId() == -1)
//        Response.Redirect("~/Home/SessionExpirada");

//    if (HttpContext.Session["Permisos"] == null)
//        Response.Redirect("~/Home/SinPermiso");

//    List<SACC.Entidades.NovaComercial.dbo.ContratoProductoPaquete> res = LogicaNegocio.NovaComercial.dbo.ContratoProductoPaquete.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralConJoin, 0, pContratoProductoId, 0, 0, 0);

//    return Json(new { success = true, result = new { data = res } });
//}




//[HttpPost]
//public JsonResult ContratoProductoPaqueteList(OpcionesCombo _opcion, int pContratoProductoId, int pPersonaId)
//{
//    if (GetUsuarioId() == -1)
//        Response.Redirect("~/Home/SessionExpirada");

//    if (HttpContext.Session["Permisos"] == null)
//        Response.Redirect("~/Home/SinPermiso");

//    List<SelectListItem> items = new List<SelectListItem>();

//    List<SACC.Entidades.NovaComercial.dbo.ContratoProductoPaquete> res = SACC.LogicaNegocio.NovaComercial.dbo.ContratoProductoPaquete.Consultar(LogicaNegocio.SqlOpciones.ConsiltaGeneralContratoProductoPaquete, 0, pContratoProductoId, 0, pPersonaId, 0);

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

//    foreach (SACC.Entidades.NovaComercial.dbo.ContratoProductoPaquete item in res)
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
//[HttpGet]
//public ActionResult _CtrlUserContratoProductoPaquete()
//{
//    if (GetUsuarioId() == -1)
//        Response.Redirect("~/Home/SessionExpirada");

//    if (HttpContext.Session["Permisos"] == null)
//        Response.Redirect("~/Home/SinPermiso");

//    Models.CtrlUserContratoProductoPaquete model = new Models.CtrlUserContratoProductoPaquete();
//    model.TipoArticulos = VentaUnitariaDetalleTipo.Controllers.VentaUnitariaDetalleTipoController.VentaUnitariaDetalleTipoList(OpcionesCombo.SELECCIONE).Where(x => x.Text.Equals("PAQUETE") || x.Text.Equals("[Seleccione...]")).ToList();

//    return PartialView(model);
//}