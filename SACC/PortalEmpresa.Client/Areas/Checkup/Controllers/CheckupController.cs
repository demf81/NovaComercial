using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PortalEmpresa.Client.Areas.Checkup.Controllers
{
    public class CheckupController : PortalEmpresa.Client.Controllers.BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            //List<SACC.Entidades.NovaComercial.dbo.Asociado> res = null; // SACC.LogicaNegocio.NovaComercial.dbo.Asociado.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaPersonaPorCURP, GetUsuarioId(), "", 0, 0);

            Models.CheckupPersonaBuscar model = new Models.CheckupPersonaBuscar();
            //model.Grid = res.Select(x => new Models.CheckupPersonaBuscarLista
            //{
            //    PersonaId       = x.AsociadoId,
            //    ApellidoPaterno = x.ApellidoPaterno,
            //    ApellidoMaterno = x.ApellidoMaterno,
            //    Nombre          = x.Nombre,
            //    Genero          = x.SexoId == 1 ? "Femenino" : "Masculino",
            //    Edad            = x.CampoComplemento_Edad,
            //    Estatus         = x.Baja == false ? "Activo" : "Inactivo"
            //}).ToList();

            //return Json(new { success = true, data = model.Grid, message = "" });
            return View(model);
        }

        [Authorize]
        [HttpPost]
        //public ActionResult Index(FormCollection collection)
        public ActionResult Index(Models.CheckupPersonaBuscar _m)
        {
            //List<SACC.Entidades.NovaComercial.dbo.Asociado> res = SACC.LogicaNegocio.NovaComercial.dbo.Asociado.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaPersonaAsociado, GetUsuarioId(), collection["Nombre"], 0, 0);

            Models.CheckupPersonaBuscar model = new Models.CheckupPersonaBuscar();
            //model.Grid = res.Select(x => new Models.CheckupPersonaBuscarLista
            //{
            //    PersonaId = x.AsociadoId,
            //    ApellidoPaterno = x.ApellidoPaterno,
            //    ApellidoMaterno = x.ApellidoMaterno,
            //    Nombre = x.Nombre,
            //    Genero = x.SexoId == 1 ? "Femenino" : "Masculino",
            //    Edad = x.Edad,
            //    Estatus = x.Baja == false ? "Activo" : "Inactivo"
            //}).ToList();

            return View(model);

            //List<Models.CheckupPersonaBuscarLista> model = new List<Models.CheckupPersonaBuscarLista>();

            //model = res.Select(x => new Models.CheckupPersonaBuscarLista
            //{
            //    PersonaId = x.AsociadoId,
            //    ApellidoPaterno = x.ApellidoPaterno,
            //    ApellidoMaterno = x.ApellidoMaterno,
            //    Nombre = x.Nombre,
            //    Genero = x.SexoId == 1 ? "Femenino" : "Masculino",
            //    Edad = x.Edad,
            //    Estatus = x.Baja == false ? "Activo" : "Inactivo"
            //}).ToList();

            //var _data = new JavaScriptSerializer().Serialize(res.Select(m => new { m.AsociadoId, m.ApellidoPaterno, m.ApellidoMaterno, m.Nombre, m.SexoId, m.Edad, m.Baja }).ToArray());

            //return Json(new { success = true, data = _data, message = "" });
        }

        [Authorize]
        public ActionResult Protocolo(List<Models.CheckupPersonaBuscarLista> lista)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Protocolo(Models.CheckupPersonaBuscar model)
        {
            return View();
        }
    }
}