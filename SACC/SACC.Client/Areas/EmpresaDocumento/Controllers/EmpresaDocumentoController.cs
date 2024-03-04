using System;
using System.IO;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.EmpresaDocumento.Controllers
{
    public class EmpresaDocumentoController : SACC.Client.Controllers.BaseController
    {
        readonly Int32 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index(Int32 pEmpresaId, String pEmpresaDescripcion)
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

            ViewBag.EmpresaId          = pEmpresaId;
            ViewBag.EmpresaDescripcion = pEmpresaDescripcion;

            return View();
        }

        [HttpPost]
        public JsonResult EmpresaDocumentoGridJson(Int32 pEmpresaId, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoGridEmpresaDocumento> res = SACC.LogicaNegocio.NovaComercial.SACC.EmpresaDocumento.ConsultarGrid(pEmpresaId, pEstatusId);

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
        public ActionResult Delete(Modelo.NovaComercial.SACC.EmpresaDocumento.DtoEmpresaDocumento model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.EmpresaDocumento.BajaLogica(model.EmpresaDocumentoId, GetUsuarioId());

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

            return PartialView();
        }




        [Authorize]
        [HttpPost]
        public ActionResult CreateUpLoad(Modelo.NovaComercial.SACC.EmpresaDocumento.DtoEmpresaDocumento model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            string nombreArchivo = Path.GetFileNameWithoutExtension(model.ArchivoH.FileName);
            string extension    = Path.GetExtension(model.ArchivoH.FileName);
            byte[] fileData     = null;

            using (var binaryReader = new BinaryReader(model.ArchivoH.InputStream))
            {
                fileData = binaryReader.ReadBytes(model.ArchivoH.ContentLength);
            }

            Entidades.NovaComercial.SACC.EmpresaDocumento obj = new Entidades.NovaComercial.SACC.EmpresaDocumento
            {
                EmpresaId              = model.EmpresaId,
                EmpresaDocumentoId     = model.EmpresaDocumentoId,
                EmpresaArchivoTipoId   = model.EmpresaArchivoTipoId,
                EmpresaDocumentoTipoId = model.EmpresaDocumentoTipoId,
                Archivo                = fileData,
                NombreArchivo          = nombreArchivo,
                Extension              = extension,
                UsuarioCreacionId      = GetUsuarioId(),
            };

            Modelo.ModeloJsonResponse res = SACC.LogicaNegocio.NovaComercial.SACC.EmpresaDocumento.Guardar(obj);

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
        public FileResult DownloadEmpresaDocumento(Int32 pEmpresaDocumentoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumento.DtoEmpresaDocumento> res = LogicaNegocio.NovaComercial.SACC.EmpresaDocumento.ConsultarPorId(pEmpresaDocumentoId);

            return File(res.Datos[0].Archivo, System.Net.Mime.MediaTypeNames.Application.Octet, res.Datos[0].NombreArchivo + res.Datos[0].Extension);
        }
    }
}
