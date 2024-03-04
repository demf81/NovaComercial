using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.ServicioAdministrativo.Controllers
{
    public class ServicioAdministrativoController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 251; // falta actualizar el Id


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
        public JsonResult ServicioAdministrativoGridJson(String pServicioAdministrativoDescripcion, String pCodigo, Int16 pEstatusId)
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

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoGridServicioAdministrativo> res = LogicaNegocio.NovaComercial.SACC.ServicioAdministrativo.ConsultarGrid(pServicioAdministrativoDescripcion, pCodigo, -1);

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
        public ActionResult Edit(Int16 pServicioAdministrativoId)
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

            ViewBag.ServicioAdministrativoId = pServicioAdministrativoId;

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult Edit(Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoServicioAdministrativo model)
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
            
            Entidades.NovaComercial.SACC.ServicioAdministrativo obj = new Entidades.NovaComercial.SACC.ServicioAdministrativo
            {
                ServicioAdministrativoId          = model.ServicioAdministrativoId,
                ServicioAdministrativoDescripcion = model.ServicioAdministrativoDescripcion,
                Codigo                            = model.Codigo,
                Costo                             = model.Costo,
                UsuarioCreacionId                 = GetUsuarioId(),
                UsuarioModificacionId             = GetUsuarioId(),
                FechaModificacion                 = DateTime.Now,
                EstatusId                         = model.EstatusId
            };
            
            if (model.Baja == true)
                obj.UsuarioBajaId = GetUsuarioId();

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.ServicioAdministrativo.Guardar(obj);
            
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
        public ActionResult Delete(Int16 pServicioAdministrativoId)
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

            ViewBag.ServicioAdministrativoId = pServicioAdministrativoId;

            return View();
        }
                
        [Authorize]
        [HttpPost]
        public JsonResult Delete(Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoServicioAdministrativo model)
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

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.ServicioAdministrativo.BajaLogica(model.ServicioAdministrativoId, GetUsuarioId());

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
        public JsonResult Create(Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoServicioAdministrativo model)
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
            
            Entidades.NovaComercial.SACC.ServicioAdministrativo obj = new Entidades.NovaComercial.SACC.ServicioAdministrativo
            {
                ServicioAdministrativoId          = model.ServicioAdministrativoId,
                ServicioAdministrativoDescripcion = model.ServicioAdministrativoDescripcion,
                Codigo                            = model.Codigo,
                Costo                             = model.Costo,
                UsuarioCreacionId                 = GetUsuarioId()
            };

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.ServicioAdministrativo.Guardar(obj);
            
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
        public JsonResult ServicioAdministrativoElementoJson(Int32 pServicioAdministrativoId)
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

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoServicioAdministrativo> res = LogicaNegocio.NovaComercial.SACC.ServicioAdministrativo.ConsultarPorId(pServicioAdministrativoId);

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
        //public JsonResult ServicioAdministrativoComboJson(OpcionesCombo _opcion)
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();

        //    Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoComboServicioAdministrativo> res = LogicaNegocio.NovaComercial.SACC.ServicioAdministrativo.ConsultarCombo("");

        //    if (res.Error)
        //    {
        //        res.StatusCode = (int)(HttpStatusCode.InternalServerError);
        //        res.StatusCode      = (int)(HttpStatusCode.InternalServerError);
        //        res.MuestraAlert    = true;
        //    }
        //    else
        //    {
        //        res.StatusCode = (int)(HttpStatusCode.OK);

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

        //        foreach (Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoComboServicioAdministrativo item in res.Datos)
        //        {
        //            items.Add(
        //                new SelectListItem
        //                {
        //                    Text  = item.ServicioAdministrativoDescripcion.ToString(),
        //                    Value = item.ServicioAdministrativoId.ToString()
        //                });
        //        }

        //        res.Lista = items;
        //    }

        //    return Json(new { success = (res.Error == false ? true : false), data = res });
        //}
    }
}
