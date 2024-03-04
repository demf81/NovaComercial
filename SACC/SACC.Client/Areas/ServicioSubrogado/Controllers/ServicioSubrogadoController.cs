using System;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.ServicioSubrogado.Controllers
{
    public class ServicioSubrogadoController : Client.Controllers.BaseController
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
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion
            
            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult ServicioSubrogadoGridJson(String pServicioSubrogadoDescripcion, String pCodigo, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogado.DtoGridServicioSubrogado> res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogado.ConsultarGrid(pServicioSubrogadoDescripcion, pCodigo, pEstatusId);

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
        public ActionResult Edit(Int16 pServicioSubrogadoId)
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
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            ViewBag.ServicioSubrogadoId = pServicioSubrogadoId;

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Edit(Modelo.NovaComercial.SACC.ServicioSubrogado.DtoServicioSubrogado model)
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
            
            Entidades.NovaComercial.SACC.ServicioSubrogado obj = new Entidades.NovaComercial.SACC.ServicioSubrogado
            {
                ServicioSubrogadoId          = model.ServicioSubrogadoId,
                ServicioSubrogadoDescripcion = model.ServicioSubrogadoDescripcion,
                Codigo                       = model.Codigo,
                ServicioSubrogadoTipoId      = model.ServicioSubrogadoTipoId,
                Costo                        = model.Costo,
                UsuarioCreacionId            = GetUsuarioId(),
                UsuarioModificacionId        = GetUsuarioId(),
                FechaModificacion            = DateTime.Now
            };
            
            if (model.Baja == true)
                obj.UsuarioBajaId = GetUsuarioId();

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogado.Guardar(obj);
            
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
        public ActionResult Delete(Int16 pServicioSubrogadoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            ViewBag.ServicioSubrogadoId = pServicioSubrogadoId;

            return View();
        }
                
        [Authorize]
        [HttpPost]
        public JsonResult Delete(Modelo.NovaComercial.SACC.ServicioSubrogado.DtoServicioSubrogado model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogado.BajaLogica(model.ServicioSubrogadoId, GetUsuarioId());

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
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");
            
            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion
            
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Create(Modelo.NovaComercial.SACC.ServicioSubrogado.DtoServicioSubrogado model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");
            
            Entidades.NovaComercial.SACC.ServicioSubrogado obj = new Entidades.NovaComercial.SACC.ServicioSubrogado
            {
                ServicioSubrogadoId          = model.ServicioSubrogadoId,
                ServicioSubrogadoDescripcion = model.ServicioSubrogadoDescripcion,
                Codigo                       = model.Codigo,
                ServicioSubrogadoTipoId      = model.ServicioSubrogadoTipoId,
                Costo                        = model.Costo,
                UsuarioCreacionId            = GetUsuarioId()
            };

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogado.Guardar(obj);
            
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
        public JsonResult ServicioSubrogadoElementoJson(Int32 pServicioSubrogadoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            //else if (varPermisoValido == -1)
            //    Response.Redirect("~/Home/Logout");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogado.DtoServicioSubrogado> res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogado.ConsultarPorId(pServicioSubrogadoId);

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
        //public JsonResult ServicioSubrogadoComboJson(OpcionesCombo _opcion)
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();

        //    Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogado.DtoComboServicioSubrogado> res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogado.ConsultarCombo("");

        //    if (res.Error)
        //    {
        //        Response.StatusCode = (int)(HttpStatusCode.InternalServerError);
        //        res.StatusCode      = (int)(HttpStatusCode.InternalServerError);
        //        res.MuestraAlert    = true;
        //    }
        //    else
        //    {
        //        Response.StatusCode = (int)(HttpStatusCode.OK);

        //        if (_opcion == OpcionesCombo.TODOS)
        //        {
        //            items.Add(
        //                new SelectListItem
        //                {
        //                    Text  = "[TODOS]",
        //                    Value = "0"
        //                }
        //            );
        //        }

        //        if (_opcion == OpcionesCombo.SELECCIONE)
        //        {
        //            items.Add(
        //                new SelectListItem
        //                {
        //                    Text  = "[Seleccione...]",
        //                    Value = "0"
        //                }
        //            );
        //        }

        //        foreach (Modelo.NovaComercial.SACC.ServicioSubrogado.DtoComboServicioSubrogado item in res.Datos)
        //        {
        //            items.Add(
        //                new SelectListItem
        //                {
        //                    Text  = item.ServicioSubrogadoDescripcion.ToString(),
        //                    Value = item.ServicioSubrogadoId.ToString()
        //                });
        //        }

        //        res.Lista = items;
        //    }

        //    return Json(new { success = (res.Error == false ? true : false), data = res });
        //}
    }
}