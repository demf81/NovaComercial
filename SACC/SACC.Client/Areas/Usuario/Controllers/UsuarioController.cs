using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SACC.Client.Areas.Usuario.Controllers
{
    public class UsuarioController : SACC.Client.Controllers.BaseController
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

            //List<SACC.Entidades.NovaComercial.PortalEmpresa.Usuario> res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneral, 0, "", "", "", "", 0);

            //Models.UsuarioVisualizar model = new Models.UsuarioVisualizar();
            //model.Grid = res.Select(x => new Models.UsuarioLista
            //{
            //    UsuarioId          = x.UsuarioId,
            //    Nombre             = x.Nombre,
            //    Paterno            = x.Paterno,
            //    Materno            = x.Materno,
            //    Correo             = x.Correo,
            //    FechaVigenciaHasta = x.FechaVigenciaHasta,
            //    Estatus            = x.Baja == false ? "Activo" : "Inactivo"
            //}).ToList();

            //model.Estatus = SACC.Client.Controllers.RadioController.RadioList("EstatusBusqueda");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }

        [HttpPost]
        public JsonResult UsuarioJson(string pUsuarioNombre, int pEstatusId)
        {
            List<SACC.Entidades.NovaComercial.PortalEmpresa.Usuario> res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneral, 0, pUsuarioNombre, "", "", "", pEstatusId);

            return Json(new { success = true, result = new { data = res } });
        }




        [Authorize]
        [HttpGet]
        public ActionResult Edit(int pUsuarioId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            List<SACC.Entidades.NovaComercial.PortalEmpresa.Usuario> res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaPorId, pUsuarioId, "", "", "", "", 0);

            //Models.UsuarioModel model = new Models.UsuarioModel();

            //model.VigenciaDesde = DateTime.Now;
            //model.VigenciaHasta = DateTime.Now;

            //if (res.Count > 0)
            //{
            //    model.UsuarioId = int.Parse(res[0].UsuarioId.ToString());
            //    model.Nombre             = res[0].Nombre;
            //    model.Paterno            = res[0].Paterno;
            //    model.Materno            = res[0].Materno;
            //    model.Correo             = res[0].Correo;
            //    model.Contrasena         = Nova.SDK.Utils.Encriptacion.Desencriptar(res[0].Contrasenia);
            //    model.VigenciaDesde = res[0].FechaVigenciaDesde;
            //    model.VigenciaHasta = res[0].FechaVigenciaHasta;
            //    model.Baja               = res[0].Baja;
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
        //public ActionResult Edit(Models.UsuarioModel model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/Logout");

        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
        //    else if (varPermisoValido == -1)
        //        Response.Redirect("~/Home/Logout");

        //    TempData["title"] = "Mensage";
        //    TempData["text"] = "Fecha Desde: " + model.VigenciaDesde + " Fecha Hasta: " + model.VigenciaHasta;
        //    TempData["type"] = "success";

        //    if (!ViewData.ModelState.IsValid) return View(model);

        //    SACC.Entidades.NovaComercial.PortalEmpresa.Usuario obj = new SACC.Entidades.NovaComercial.PortalEmpresa.Usuario();
        //    obj.UsuarioId             = model.UsuarioId;
        //    obj.Nombre                = model.Nombre;
        //    obj.Paterno               = model.Paterno;
        //    obj.Materno               = model.Materno;
        //    obj.Telefono              = model.Telefono;
        //    obj.Correo                = model.Correo;
        //    obj.Contrasenia           = Nova.SDK.Utils.Encriptacion.Encriptar(model.Contrasena);
        //    obj.FechaVigenciaDesde    = model.VigenciaDesde.Value;
        //    obj.FechaVigenciaHasta    = model.VigenciaHasta.Value;
        //    obj.UsuarioCreacionId     = GetUsuarioId();
        //    obj.UsuarioModificacionId = GetUsuarioId();
        //    obj.FechaModificacion     = DateTime.Now;

        //    if (model.Baja == true)
        //        obj.UsuarioBajaId = GetUsuarioId();

        //    SACC.Entidades.EntidadJsonResponse res = new SACC.Entidades.EntidadJsonResponse();
        //    res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Guardar(LogicaNegocio.SqlOpciones.Actualizar, obj);

        //    TempData["title"] = "Mensage";
        //    TempData["text"]  = res.Error == false ? res.Mensaje : res.MensajeError;
        //    TempData["type"]  = res.TipoMensaje;

        //    #region VARIABLES DE MENU
        //    TempData["lblNombre"] = GetNombreUsuario();
        //    if (HttpContext.Session["Foto"] != null)
        //        TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
        //    #endregion

        //    return RedirectToAction("Index", "Usuario");
        //}




        [Authorize]
        [HttpGet]
        public ActionResult Delete(int pUsuarioId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            List<SACC.Entidades.NovaComercial.PortalEmpresa.Usuario> res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaPorId, pUsuarioId, "", "", "", "", 0);

            //Models.UsuarioModel model = new Models.UsuarioModel();

            //if (res.Count > 0)
            //{
            //    model.UsuarioId          = int.Parse(res[0].UsuarioId.ToString());
            //    model.Nombre             = res[0].Nombre;
            //    model.Paterno            = res[0].Paterno;
            //    model.Materno            = res[0].Materno;
            //    model.Correo             = res[0].Correo;
            //    model.Contrasena         = res[0].Contrasenia;
            //    model.VigenciaDesde = res[0].FechaVigenciaDesde;
            //    model.VigenciaHasta = res[0].FechaVigenciaHasta;
            //    model.Baja               = res[0].Baja;
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
        //public ActionResult Delete(Models.UsuarioModel model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/Logout");

        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
        //    else if (varPermisoValido == -1)
        //        Response.Redirect("~/Home/Logout");

        //    SACC.Entidades.EntidadJsonResponse res = new SACC.Entidades.EntidadJsonResponse();
        //    res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.BajaLogica(model.UsuarioId, GetUsuarioId());

        //    TempData["title"] = "Mensage";
        //    TempData["text"] = res.Error == false ? res.Mensaje : res.MensajeError;
        //    TempData["type"] = res.TipoMensaje;

        //    #region VARIABLES DE MENU
        //    TempData["lblNombre"] = GetNombreUsuario();
        //    if (HttpContext.Session["Foto"] != null)
        //        TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
        //    #endregion

        //    return Redirect("Index");
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

            //Models.UsuarioModel model = new Models.UsuarioModel();

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }
        
        //[Authorize]
        //[HttpPost]
        //public ActionResult Create(Models.UsuarioModel model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/Logout");

        //    int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
        //    if (varPermisoValido == 0)
        //        Response.Redirect("~/Home/SinPermiso");
        //    else if (varPermisoValido == -1)
        //        Response.Redirect("~/Home/Logout");

        //    if (!ViewData.ModelState.IsValid) return View(model);

        //    SACC.Entidades.NovaComercial.PortalEmpresa.Usuario obj = new SACC.Entidades.NovaComercial.PortalEmpresa.Usuario();
        //    obj.UsuarioId             = model.UsuarioId;
        //    obj.Nombre                = model.Nombre;
        //    obj.Paterno               = model.Paterno;
        //    obj.Materno               = model.Materno;
        //    obj.Telefono              = model.Telefono;
        //    obj.Correo                = model.Correo;
        //    obj.Contrasenia           = Nova.SDK.Utils.Encriptacion.Encriptar(model.Contrasena);
        //    obj.FechaVigenciaDesde    = model.VigenciaDesde.Value;
        //    obj.FechaVigenciaHasta    = model.VigenciaHasta.Value;
        //    obj.UsuarioCreacionId     = GetUsuarioId();
        //    obj.UsuarioModificacionId = GetUsuarioId();

        //    SACC.Entidades.EntidadJsonResponse res = SACC.LogicaNegocio.NovaComercial.PortalEmpresa.Usuario.Guardar(LogicaNegocio.SqlOpciones.Insertar, obj);

        //    TempData["title"] = "Mensage";
        //    TempData["text"]  = res.Error == false ? res.Mensaje : res.MensajeError;
        //    TempData["type"]  = res.TipoMensaje;

        //    #region VARIABLES DE MENU
        //    TempData["lblNombre"] = GetNombreUsuario();
        //    if (HttpContext.Session["Foto"] != null)
        //        TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
        //    #endregion

        //    return RedirectToAction("Index", "Usuario");
        //}
    }
}