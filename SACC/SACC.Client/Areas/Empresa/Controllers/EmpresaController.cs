using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Empresa.Controllers
{
    public class EmpresaController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index(
            //Int32 pClienteId, String pClienteDescripcion
            )
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

            //ViewBag.ClienteId          = pClienteId;
            //ViewBag.ClienteDescripcion = pClienteDescripcion;

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult EmpresaGridJson(String pEmpresaDescripcion, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoGridEmpresa> res = SACC.LogicaNegocio.NovaComercial.SACC.Empresa.ConsultarGrid(pEmpresaDescripcion, pEstatusId);

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
        public ActionResult Edit(int pEmpresaId)
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

            ViewBag.EmpresaId = pEmpresaId;

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Modelo.NovaComercial.SACC.Empresa.DtoEmpresa model, Modelo.NovaComercial.SACC.EmpresaDatosFiscales.DtoEmpresaDatosFiscales modelDF)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.SACC.Empresa obj = new Entidades.NovaComercial.SACC.Empresa
            {
                EmpresaId             = model.EmpresaId,
                EmpresaDescripcion    = model.EmpresaDescripcion,
                Codigo                = model.Codigo,
                EmpresaTipoId         = model.EmpresaTipoId,
                MetodoPagoId          = model.MetodoPagoId,
                FormaPagoId           = model.FormaPagoId,
                FrecuenciaPagoId      = model.FrecuenciaPagoId,
                DiaPago               = model.DiaPago,
                EmpresaVigenciaId     = model.EmpresaVigenciaId,
                EstatusId             = model.EstatusId,
                UsuarioModificacionId = GetUsuarioId()
            };

            Entidades.NovaComercial.SACC.EmpresaDatosFiscales objDF = new Entidades.NovaComercial.SACC.EmpresaDatosFiscales
            {
                EmpresaId              = modelDF.EmpresaId,
                EmpresaDatosFiscalesId = modelDF.EmpresaDatosFiscalesId,
                RazonSocial            = modelDF.RazonSocial,
                RFC                    = modelDF.RFC,
                PaisId                 = modelDF.PaisId,
                EstadoId               = modelDF.EstadoId,
                MunicipioId            = modelDF.MunicipioId,
                Colonia                = modelDF.Colonia,
                Calle                  = modelDF.Calle,
                NumeroExterior         = modelDF.NumeroExterior,
                NumeroInterior         = modelDF.NumeroInterior,
                CodigoPostal           = modelDF.CodigoPostal,
                CorreoElectronico      = modelDF.CorreoElectronico,
                UsuarioCreacionId      = GetUsuarioId(),
                UsuarioModificacionId  = GetUsuarioId()
            };

            if (model.Baja == true)
                obj.UsuarioBajaId = GetUsuarioId();

            Modelo.ModeloJsonResponse res = SACC.LogicaNegocio.NovaComercial.SACC.Empresa.Guardar(obj, objDF);

            #region SE INSERTA EN TEMPORAL DE NEXUS
            if (res.Id > 0)
            {
                char pad = '0';

                SACC.Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa objEmpresa = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa
                {
                    iCodigo              = res.Id,
                    vcCodigoAlterno      = "4000SAC" + res.Id.ToString().PadLeft(3, pad),
                    vcNombreComercial    = obj.EmpresaDescripcion,
                    vcDireccion          = "",
                    IdColonia            = 0,
                    vcCodigoPostal       = "",
                    vcZona               = "",
                    vcTelefono1          = "",
                    vcTelefono2          = "",
                    vcFax                = "",
                    IdTipoEmpresa        = 1,
                    bFideicomitente      = false,
                    bEnLinea             = true,
                    bActivo              = true,
                    vcCorreoElectronico  = "",
                    iEnLineaSiass        = 0,
                    vcGrupoSAP           = "",
                    vcSectorSAP          = "",
                    vcZonaSAP            = "",
                    vcRamoIndustrialSAP  = "",
                    vcOficinaVentaSAP    = "",
                    IdMovimiento         = 0,
                    dtFechaCreacion      = DateTime.Now,
                    dtFechaActualizacion = DateTime.Now,
                    bProceso             = false
                };

                Entidades.EntidadJsonResponse resTranDatosEmpresa = new Entidades.EntidadJsonResponse();
                resTranDatosEmpresa = LogicaNegocio.Nova_ServiciosMedicos.dbo.TranDatosEmpresa.Guardar(objEmpresa);
            }
            #endregion

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
        public ActionResult Delete(int pEmpresaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            ViewBag.EmpresaId = pEmpresaId;

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult Delete(Modelo.NovaComercial.SACC.Empresa.DtoEmpresa model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.Empresa.BajaLogica(model.EmpresaId, GetUsuarioId());

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
        
        [Authorize]
        [HttpPost]
        public ActionResult Create(Modelo.NovaComercial.SACC.Empresa.DtoEmpresa model, Modelo.NovaComercial.SACC.EmpresaDatosFiscales.DtoEmpresaDatosFiscales modelDF)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.SACC.Empresa obj = new Entidades.NovaComercial.SACC.Empresa
            {
                EmpresaId          = model.EmpresaId,
                EmpresaDescripcion = model.EmpresaDescripcion,
                Codigo             = model.Codigo,
                EmpresaTipoId      = model.EmpresaTipoId,
                MetodoPagoId       = model.MetodoPagoId,
                FormaPagoId        = model.FormaPagoId,
                FrecuenciaPagoId   = model.FrecuenciaPagoId,
                DiaPago            = model.DiaPago,
                EmpresaVigenciaId  = model.EmpresaVigenciaId,
                InicioOperaciones  = model.InicioOperaciones,
                UsuarioCreacionId  = GetUsuarioId(),
            };

            Entidades.NovaComercial.SACC.EmpresaDatosFiscales objDF = new Entidades.NovaComercial.SACC.EmpresaDatosFiscales
            {
                EmpresaId              = modelDF.EmpresaId,
                EmpresaDatosFiscalesId = modelDF.EmpresaDatosFiscalesId,
                RazonSocial            = modelDF.RazonSocial,
                RFC                    = modelDF.RFC,
                PaisId                 = modelDF.PaisId,
                EstadoId               = modelDF.EstadoId,
                MunicipioId            = modelDF.MunicipioId,
                Colonia                = modelDF.Colonia,
                Calle                  = modelDF.Calle,
                NumeroExterior         = modelDF.NumeroExterior,
                NumeroInterior         = modelDF.NumeroInterior,
                CodigoPostal           = modelDF.CodigoPostal,
                CorreoElectronico      = modelDF.CorreoElectronico,
                UsuarioCreacionId      = GetUsuarioId(),
                UsuarioModificacionId = GetUsuarioId()
            };

            Modelo.ModeloJsonResponse res = SACC.LogicaNegocio.NovaComercial.SACC.Empresa.Guardar(obj, objDF);

            #region SE INSERTA EN TEMPORAL DE NEXUS
            if (res.Id > 0)
            {
                char pad = '0';

                Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa objEmpresa = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa
                {
                    iCodigo              = res.Id,
                    vcCodigoAlterno      = "0400SAC" + res.Id.ToString().PadLeft(3, pad),
                    vcNombreComercial    = obj.EmpresaDescripcion,
                    vcDireccion          = "",
                    IdColonia            = 0,
                    vcCodigoPostal       = "",
                    vcZona               = "",
                    vcTelefono1          = "",
                    vcTelefono2          = "",
                    vcFax                = "",
                    IdTipoEmpresa        = 1,
                    bFideicomitente      = false,
                    bEnLinea             = true,
                    bActivo              = true,
                    vcCorreoElectronico  = "",
                    iEnLineaSiass        = 0,
                    vcGrupoSAP           = "",
                    vcSectorSAP          = "",
                    vcZonaSAP            = "",
                    vcRamoIndustrialSAP  = "",
                    vcOficinaVentaSAP    = "",
                    IdMovimiento         = 0,
                    dtFechaCreacion      = DateTime.Now,
                    dtFechaActualizacion = DateTime.Now,
                    bProceso             = false
                };

                Entidades.EntidadJsonResponse restranDatosEmpresa = LogicaNegocio.Nova_ServiciosMedicos.dbo.TranDatosEmpresa.Guardar(objEmpresa);
            }
            #endregion

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
        public JsonResult EmpresaElementoJson(Int32 pEmpresaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoEmpresa> res = LogicaNegocio.NovaComercial.SACC.Empresa.ConsultarPorId(pEmpresaId);

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
        public ActionResult _CtrlUserBusquedaEmpresa()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            return PartialView();
        }

        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserBusquedaEmpresaJson(String pEmpresaDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoCtrlUserBusquedaEmpresaGrid> res = LogicaNegocio.NovaComercial.SACC.Empresa.CtrlUserBuscarEmpresaJson(pEmpresaDescripcion);

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
        public ActionResult _CtrlUserEmpresaCoberturaCondicion()
        {
            return PartialView();
        }




        public static List<SelectListItem> EmpresaList(OpcionesCombo _opcion)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            List<SACC.Entidades.NovaComercial.dbo.Empresa> res = SACC.LogicaNegocio.NovaComercial.dbo.Empresa.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneral, 0, "", 0);

            if (_opcion == OpcionesCombo.TODOS)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = "[TODOS]",
                        Value = "0"
                    }
                );
            }

            if (_opcion == OpcionesCombo.SELECCIONE)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text = "[Seleccione...]",
                        Value = "0"
                    }
                );
            }

            foreach (SACC.Entidades.NovaComercial.dbo.Empresa item in res)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.EmpresaDescripcion.ToString(),
                        Value = item.EmpresaId.ToString()
                    }
                );
            }

            return items;
        }
    }
}