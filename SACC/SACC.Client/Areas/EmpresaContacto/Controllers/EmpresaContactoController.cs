using System;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.EmpresaContacto.Controllers
{
    public class EmpresaContactoController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult _Edit(
            //Int16 pEmpresaContactoId
        )
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

            //ViewBag.EmpresaContactoId = pEmpresaContactoId;

            return PartialView();
        }

        [Authorize]
        [HttpPost]
        public JsonResult Edit(Modelo.NovaComercial.SACC.EmpresaContacto.DtoEmpresaContacto model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.SACC.EmpresaContacto obj = new Entidades.NovaComercial.SACC.EmpresaContacto
            {
                EmpresaContactoId       = model.EmpresaContactoId,
                EmpresaId               = model.EmpresaId,
                Nombre                  = model.Nombre,
                Paterno                 = model.Paterno,
                Materno                 = model.Materno,
                DepartamentoDescripcion = model.DepartamentoDescripcion,
                ContactoTipoId          = model.ContactoTipoId,
                Telefono                = model.Telefono,
                Extension               = model.Extension,
                CorreoElectronico       = model.CorreoElectronico,
                EstatusId               = model.EstatusId,
                UsuarioCreacionId       = GetUsuarioId()
            };

            if (model.Baja == true)
                obj.UsuarioBajaId = GetUsuarioId();

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.EmpresaContacto.Guardar(obj);

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
        public JsonResult Delete(Modelo.NovaComercial.SACC.EmpresaContacto.DtoEmpresaContacto model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.EmpresaContacto.BajaLogica(model.EmpresaContactoId, GetUsuarioId());

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
        public ActionResult _Create()
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

            return PartialView();
        }

        [Authorize]
        [HttpPost]
        public JsonResult Create(Modelo.NovaComercial.SACC.EmpresaContacto.DtoEmpresaContacto model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.SACC.EmpresaContacto obj = new Entidades.NovaComercial.SACC.EmpresaContacto
            {
                EmpresaContactoId       = model.EmpresaContactoId,
                EmpresaId               = model.EmpresaId,
                Nombre                  = model.Nombre,
                Paterno                 = model.Paterno,
                Materno                 = model.Materno,
                DepartamentoDescripcion = model.DepartamentoDescripcion,
                ContactoTipoId          = model.ContactoTipoId,
                Telefono                = model.Telefono,
                Extension               = model.Extension,
                CorreoElectronico       = model.CorreoElectronico,
                UsuarioCreacionId       = GetUsuarioId()
            };

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.EmpresaContacto.Guardar(obj);

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
        public JsonResult EmpresaContactoElementoJson(Int32 pEmpresaContactoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaContacto.DtoEmpresaContacto> res = LogicaNegocio.NovaComercial.SACC.EmpresaContacto.ConsultarPorId(pEmpresaContactoId);

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
        public ActionResult _CtrlUserEmpresaContactoView()
        {
            return PartialView();
        }

        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserEmpresaContactoViewJson(Int32 pEmpresaId,  Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaContacto.DtoCtrlUserEmpresaContactoView> res = LogicaNegocio.NovaComercial.SACC.EmpresaContacto.ConsultarDetallePorEmpresa(pEmpresaId, pEstatusId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}