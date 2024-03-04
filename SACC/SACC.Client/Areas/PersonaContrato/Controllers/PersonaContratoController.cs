using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.PersonaContrato.Controllers
{
    public class PersonaContratoController : SACC.Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index(int pPersonaId, string pNombre)
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

            ViewBag.PersonaId = pPersonaId;
            ViewBag.Nombre    = pNombre;

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult PersonaContratoGridJson(Int32 pPersonaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContrato> res = SACC.LogicaNegocio.NovaComercial.dbo.PersonaContrato.ConsultarGrid(0, pPersonaId, 0, 1);

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
        public JsonResult ActivaCobertura(List<Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContratoCoberturaDefault> list)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = null;

            if (list.Count > 0)
            {
                foreach (Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContratoCoberturaDefault item in list)
                {
                    Entidades.NovaComercial.dbo.PersonaContrato obj = new Entidades.NovaComercial.dbo.PersonaContrato
                    {
                        PersonaContratoId     = item.PersonaContratoId,
                        PersonaId             = item.PersonaId,
                        ContratoId            = item.ContratoId,
                        ContratoCoberturaId   = item.ContratoCoberturaId,
                        PaqueteId             = item.PaqueteId,
                        UsuarioCreacionId     = GetUsuarioId(),
                        UsuarioModificacionId = GetUsuarioId()
                    };

                    res = LogicaNegocio.NovaComercial.dbo.PersonaContrato.AvtivaCobertura(obj);
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

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }


        [Authorize]
        [HttpGet]
        public ActionResult Delete(int pPersonaContratoId, string pContrato, int pPersonaId, string pNombre)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            //Models.PersonaContratoModel model = new Models.PersonaContratoModel();
            //model.PersonaContratoId = pPersonaContratoId;
            //model.ContratoDescripcion = pContrato;
            //model.PersonaId = pPersonaId;
            //model.Nombre = pNombre;

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
            //return RedirectToAction("Index", new { @pPersonaId = model.PersonaId, @pNopmbre = @model.Nombre});
        }

        //[Authorize]
        //[HttpPost]
        //public ActionResult Delete(Models.PersonaContratoModel model)
        //{
        //    if (GetUsuarioId() == -1)
        //        Response.Redirect("~/Home/SessionExpirada");

        //    if (HttpContext.Session["Permisos"] == null)
        //        Response.Redirect("~/Home/SinPermiso");

        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();
        //    //res = SACC.LogicaNegocio.NovaComercial.dbo.PersonaContrato.BajaLogica(model.PersonaContratoId, GetUsuarioId());

        //    TempData["title"] = "Mensage";
        //    TempData["text"] = res.Error == false ? res.Mensaje : res.MensajeError;
        //    TempData["type"] = res.TipoMensaje;

        //    #region VARIABLES DE MENU
        //    TempData["lblNombre"] = GetNombreUsuario();
        //    if (HttpContext.Session["Foto"] != null)
        //        TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
        //    #endregion

        //    return RedirectToAction("Index", "PersonaContrato", new { Area = "PersonaContrato", @pPersonaId = model.PersonaId, @pNombre = @model.Nombre });
        //}




        [Authorize]
        [HttpPost]
        public JsonResult Create(List<Modelo.NovaComercial.dbo.PersonaContrato.DtoPersonaContrato> list)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = null;

            #region SE ASIGNAN LOS LOS CONTRATOS A LA PERSONAS
            if (list.Count > 0)
            {
                foreach (Modelo.NovaComercial.dbo.PersonaContrato.DtoPersonaContrato item in list)
                {
                    Entidades.NovaComercial.dbo.PersonaContrato obj = new Entidades.NovaComercial.dbo.PersonaContrato
                    {
                        PersonaContratoId     = 0,
                        PersonaId             = item.PersonaId,
                        ContratoId            = item.ContratoId,
                        UsuarioCreacionId     = GetUsuarioId(),
                        UsuarioModificacionId = GetUsuarioId()
                    };

                    res = LogicaNegocio.NovaComercial.dbo.PersonaContrato.Guardar(obj);
                        if (res.Error) break;
                }
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
        public ActionResult _CtrlUserPersonaCobertura()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult PersonaContratoCoberturaJson(int pPersonaId)
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

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoGridPersonaContratoCoberturaDefault> res = SACC.LogicaNegocio.NovaComercial.dbo.PersonaContrato.ConsultarCoberturaPorPersonaGrid(pPersonaId);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });

            //List<SACC.Entidades.NovaComercial.dbo.PersonaContrato> res = new List<Entidades.NovaComercial.dbo.PersonaContrato>();// LogicaNegocio.NovaComercial.dbo.PersonaContrato.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralCoberturaDefault, 0, pPersonaId, 0, 0);

            //List<Models.PersonaContratoCoberturaDefault> model = new List<Models.PersonaContratoCoberturaDefault>();
            //model = res.Select(x => new PersonaContrato.Models.PersonaContratoCoberturaDefault
            //{
            //    Seleccionado                 = x.CampoComplemento_Seleccionado,
            //    PersonaContratoId            = x.PersonaContratoId,
            //    PersonaId                    = x.PersonaId,
            //    NombreCompleto               = x.CampoComplemento_NombreCompleto,
            //    ContratoId                   = x.ContratoId,
            //    ContratoDescripcion          = x.CampoComplemento_ContratoDescripcion,
            //    ContratoCoberturaId          = x.ContratoCoberturaId,
            //    ContratoCoberturaDescripcion = x.CampoComplemento_ContratoCoberturaDescripcion,
            //    PaqueteId                    = x.CampoComplemento_PaqueteId,
            //    PaqueteDescripcion           = x.CampoComplemento_PaqueteDescripcion
            //}).ToList();

            //return Json(new { success = true, result = new { data = model } });
        }


        //[Authorize]
        //[HttpPost]
        //public JsonResult PersonaContratoList(OpcionesCombo _opcion, int pPersonaId)
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();

        //    List<SACC.Entidades.NovaComercial.dbo.PersonaContrato> res = new List<Entidades.NovaComercial.dbo.PersonaContrato>();// SACC.LogicaNegocio.NovaComercial.dbo.PersonaContrato.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralConJoin, 0, pPersonaId, 0, 0);

        //    if (_opcion == OpcionesCombo.TODOS)
        //    {
        //        items.Add(
        //            new SelectListItem
        //            {
        //                Text = "[TODOS]",
        //                Value = "0"
        //            }
        //        );
        //    }

        //    if (_opcion == OpcionesCombo.SELECCIONE)
        //    {
        //        items.Add(
        //            new SelectListItem
        //            {
        //                Text = "[Seleccione...]",
        //                Value = "0"
        //            }
        //        );
        //    }

        //    foreach (SACC.Entidades.NovaComercial.dbo.PersonaContrato item in res)
        //    {
        //        items.Add(
        //            new SelectListItem
        //            {
        //                Text = "", //item.CampoComplemento_ContratoDescripcion.ToString(),
        //                Value = item.ContratoId.ToString()
        //            }
        //        );
        //    }

        //    return Json(new { success = true, result = new { data = items } });
        //}
        [Authorize]
        [HttpPost]
        public JsonResult PersonaContratoComboJson(OpcionesCombo _opcion, Int32 pPersonaId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PersonaContrato.DtoComboPersonaContratoContrato> res = LogicaNegocio.NovaComercial.dbo.PersonaContrato.ConsultarComboContrato(pPersonaId);

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

            foreach (Modelo.NovaComercial.dbo.PersonaContrato.DtoComboPersonaContratoContrato item in res.Datos)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text  = item.ContratoDescripcion.ToString(),
                        Value = item.ContratoId.ToString()
                    }
                );
            }

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        [Authorize]
        [HttpPost]
        public JsonResult InactivaCobertura(Int32 pPersonaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Entidades.NovaComercial.dbo.PersonaContrato obj = new Entidades.NovaComercial.dbo.PersonaContrato
            {
                PersonaContratoId     = 0,
                PersonaId             = pPersonaId,
                UsuarioBajaId         = GetUsuarioId(),
                UsuarioModificacionId = GetUsuarioId()
            };

            Modelo.ModeloJsonResponse res = SACC.LogicaNegocio.NovaComercial.dbo.PersonaContrato.InactivaCobertura(obj);

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;
            res.MuestraAlert    = true;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}
