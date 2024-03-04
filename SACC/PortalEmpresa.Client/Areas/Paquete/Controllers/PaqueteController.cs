using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.Paquete.Controllers
{
    public class PaqueteController : PortalEmpresa.Client.Controllers.BaseController
    {
        [Authorize]
        [HttpGet]
        public ActionResult _CtrlUserPaquete()
        {
            List<Models.PaqueteSeleccion> model = new List<Models.PaqueteSeleccion>();

            return PartialView(model);
        }


        [HttpPost]
        public ActionResult CtrlUserPaqueteJson(int pPersonaId, string pNombre)
        {
            List<SACC.Entidades.NovaComercial.dbo.PersonaPaquete> res = null;

            res = SACC.LogicaNegocio.NovaComercial.dbo.PersonaPaquete.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsiltaGeneralContratoProductoPaquete, 0, pPersonaId, GetContratoId(), 0);
            

            List<Models.PaqueteSeleccion> model = new List<Models.PaqueteSeleccion>();
            model = res.Select(x => new Models.PaqueteSeleccion
            {
                Seleccionado       = x.CampoComplemento_Seleccionado,
                ContratoProductoId = x.ContratoProductoId,
                PersonaId          = pPersonaId,
                Nombre             = pNombre,
                ContratoId         = GetContratoId(),
                PaqueteId          = x.PaqueteId,
                //PaqueteDescripcion = x.CampoComplemento_PaqueteDescripcion,
            }).ToList();

            return Json(new { success = true, result = new { data = model } });
        }
    }
}