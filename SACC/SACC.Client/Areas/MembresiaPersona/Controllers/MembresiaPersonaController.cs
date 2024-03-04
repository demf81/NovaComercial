using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.MembresiaPersona.Controllers
{
    public class MembresiaPersonaController : Client.Controllers.BaseController
    {
        const int _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index(Int32 pMembresiaId, String pNumSocio, String pContratante, Int16 pCantidadAfiliadosRegistrados, Int16 pCantidadAfiliadosAmparados, Int16 pCantidadAdicional, Int16 pMembresiaEstatusId)
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

            ViewBag.MembresiaId                  = pMembresiaId;
            ViewBag.NumSocio                     = pNumSocio;
            ViewBag.Contratante                  = pContratante;
            ViewBag.CantidadAfiliadosRegistrados = pCantidadAfiliadosRegistrados;
            ViewBag.CantidadAfiliadosAmparados   = pCantidadAfiliadosAmparados - pCantidadAdicional;
            ViewBag.CantidadAdicional            = pCantidadAdicional;
            ViewBag.MembresiaEstatusId           = pMembresiaEstatusId;

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult MembresiaPersonaGridJson(Int32 pMembresiaId, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.VISUALIZAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaPersona.DtoGridMembresiaPersona> res = LogicaNegocio.NovaComercial.SACC.MembresiaPersona.ConsultarGrid(pMembresiaId, pEstatusId);

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
        public JsonResult Create(List<Modelo.NovaComercial.SACC.MembresiaPersona.DtoMembresiaPersona> Lista)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            int Contador   = 0;
            bool EsTitular = false;

            List<Modelo.NovaComercial.SACC.MembresiaPersona.DtoMembresiaPersona> lista = Lista;
            lista.Sort((x, y) => x.NumSocio.CompareTo(y.NumSocio));
            
            foreach (Modelo.NovaComercial.SACC.MembresiaPersona.DtoMembresiaPersona item in lista)
            {
                if (Contador == 0)
                    EsTitular = true;
                else
                    EsTitular = false;

                Entidades.NovaComercial.SACC.MembresiaPersona obj = new Entidades.NovaComercial.SACC.MembresiaPersona
                {
                    MembresiaPersonaId = item.MembresiaPersonaId,
                    MembresiaId        = item.MembresiaId,
                    PersonaId          = item.PersonaId,
                    EsTitular          = EsTitular,
                    UsuarioCreacionId  = GetUsuarioId()
                };

                res = LogicaNegocio.NovaComercial.SACC.MembresiaPersona.Guardar(obj);
                Contador++;

                if (res.Error) break;
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
        public JsonResult Delete(Modelo.NovaComercial.SACC.MembresiaPersona.DtoMembresiaPersona model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.ELIMINAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse res = LogicaNegocio.NovaComercial.SACC.MembresiaPersona.BajaLogica(model.MembresiaPersonaId, GetUsuarioId());

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
    }
}