using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.PersonaPaquete.Controllers
{
    public class PersonaPaqueteController : PortalEmpresa.Client.Controllers.BaseController
    {
        [Authorize]
        [HttpGet]
        public ActionResult Index(int pPersonaId, string pNombre)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            Models.PersonaPaqueteVisualizar model = new Models.PersonaPaqueteVisualizar();

            model.PersonaId = pPersonaId;
            model.Nombre    = pNombre;

            return View(model);
        }




        [Authorize]
        [HttpGet]
        public ActionResult Delete(int pPersonaPaqueteId, int pPersonaId, string pNombre, int pPaqueteId, string pPaqueteDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            Models.PersonaPaqueteModel model = new Models.PersonaPaqueteModel();
            model.PersonaPaqueteId   = pPersonaPaqueteId;
            model.PersonaId          = pPersonaId;
            model.PersonaDescripcion = pNombre;
            model.PaqueteId          = pPaqueteId;
            model.PaqueteDescripcion = pPaqueteDescripcion;

            return View(model);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Delete(Models.PersonaPaqueteModel model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            SACC.Entidades.EntidadJsonResponse res = new SACC.Entidades.EntidadJsonResponse();
            res = SACC.LogicaNegocio.NovaComercial.dbo.PersonaPaquete.BajaLogica(model.PersonaPaqueteId, GetUsuarioId());

            TempData["title"] = "Mensage";
            TempData["text"] = res.Error == false ? res.Mensaje : res.MensajeError;
            TempData["type"] = res.TipoMensaje;

            return RedirectToAction("Index", "PersonaPaquete", new { Area = "PersonaPaquete", @pPersonaId = model.PersonaId, @pNombre= @model.PersonaDescripcion });
        }




        [Authorize]
        [HttpPost]
        public JsonResult Create(List<Paquete.Models.PaqueteSeleccion> list)
        {
            #region SE ASIGNAN LOS LOS CONTRATOS A LA EMPRESA
            if (list.Count > 0)
            {
                SACC.Entidades.EntidadJsonResponse res = null;
                var seleccionados = list.Where(x => x.Seleccionado.Equals(true));

                foreach (Paquete.Models.PaqueteSeleccion item in seleccionados)
                {
                    if (item.Seleccionado)
                    {
                        SACC.Entidades.NovaComercial.dbo.PersonaPaquete obj = new SACC.Entidades.NovaComercial.dbo.PersonaPaquete();
                        obj.PersonaPaqueteId      = 0;
                        obj.PersonaId             = item.PersonaId;
                        obj.ContratoProductoId    = item.ContratoProductoId;
                        obj.PaqueteId             = item.PaqueteId;
                        obj.ContratoId            = item.ContratoId;
                        obj.UsuarioCreacionId     = GetUsuarioId();
                        obj.UsuarioModificacionId = GetUsuarioId();

                        res = SACC.LogicaNegocio.NovaComercial.dbo.PersonaPaquete.Guardar(obj);
                        if (res.Error) break;
                    }
                }
            }
            #endregion

            Models.PersonaPaqueteVisualizar model = new Models.PersonaPaqueteVisualizar();
            model.PersonaId = list[0].PersonaId;
            model.Nombre    = list[0].Nombre;

            return Json(new { success = true, result = new { data = model } });
        }




        [HttpPost]
        public JsonResult PersonaPaqueteJson(int pPersonaId)
        {
            List<SACC.Entidades.NovaComercial.dbo.PersonaPaquete> res = SACC.LogicaNegocio.NovaComercial.dbo.PersonaPaquete.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaGeneralConJoin, 0, pPersonaId, GetContratoId(), 0);

            return Json(new { success = true, result = new { data = res } });
        }
    }
}
