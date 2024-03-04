using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalEmpresa.Client.Areas.Persona.Controllers
{
    public class PersonaController : PortalEmpresa.Client.Controllers.BaseController
    {
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            //List<SACC.Entidades.NovaComercial.dbo.Persona> res = SACC.LogicaNegocio.NovaComercial.dbo.Persona.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaPoblacion, 0, -1, -1, "", "", null, GetContratoId(), 0);

            //Models.PersonaVisualizar model = new Models.PersonaVisualizar();
            //model.Estatus = PortalEmpresa.Client.Controllers.RadioController.RadioList("EstatusBusqueda");

            return View();
        }




        [Authorize]
        [HttpGet]
        public ActionResult Edit(int pPersonaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            //List<SACC.Entidades.NovaComercial.dbo.Persona> res = SACC.LogicaNegocio.NovaComercial.dbo.Persona.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaPoblacionPorId, pPersonaId, -1 ,-1, "", "", null, GetContratoId(), 0);

            //Models.PersonaModel model = new Models.PersonaModel();

            //if (res.Count > 0)
            //{
            //    model.PersonaId       = int.Parse(res[0].PersonaId.ToString());
            //    model.Nombre          = res[0].Nombre;
            //    model.Paterno         = res[0].Paterno;
            //    model.Materno         = res[0].Materno;
            //    model.Genero          = res[0].Genero;
            //    model.FechaNacimiento = res[0].FechaNacimiento;
            //    model.CURP            = res[0].CURP;
            //}
            
            //ViewBag.Id = model.PersonaId;

            //if (res[0].CampoComplemento_ContratoId == GetContratoId())
            //    ViewBag.EnPoblacion = 1;
            //else
            //    ViewBag.EnPoblacion = 0;

            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult Edit(Models.PersonaModel model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            //if (!ViewData.ModelState.IsValid) return View(model);

            
            //if (model.Baja == true)
            //{
            //    // validar que no tenga programado checkup

            //    // dar de baja el registro en tabla persona
            //}

            #region ASOCIA PERSONA A EMPRESA
            //SACC.Entidades.EntidadJsonResponse resPersona = new SACC.Entidades.EntidadJsonResponse();
            //SACC.Entidades.NovaComercial.dbo.PersonaContrato objPersona = new SACC.Entidades.NovaComercial.dbo.PersonaContrato();
            //objPersona.PersonaContratoId     = 0;
            //objPersona.PersonaId             = model.PersonaId;
            //objPersona.ContratoId            = GetContratoId();
            //objPersona.ContratoCoberturaId   = 0;
            //objPersona.PaqueteId             = 0;
            //objPersona.UsuarioCreacionId     = GetUsuarioId();
            //objPersona.UsuarioModificacionId = GetUsuarioId();
            
            //resPersona = SACC.LogicaNegocio.NovaComercial.dbo.PersonaContrato.Guardar(SACC.LogicaNegocio.SqlOpciones.Insertar, objPersona);
            #endregion

            //TempData["title"] = "Mensaje";
            //TempData["text"]  = resPersona.Error == false ? resPersona.Mensaje : resPersona.MensajeError;
            //TempData["type"]  = resPersona.TipoMensaje;

            //if (!resPersona.Error)
            //    ViewBag.EnPoblacion = 1;
            //else
            //    ViewBag.EnPoblacion = 0;

            return RedirectToAction("Index", "Persona");
        }




        [Authorize]
        [HttpGet]
        public ActionResult EditV(int pPersonaId, string pNombre, string pPaterno, string pMaterno, Boolean pGenero, DateTime pFechaNacimiento, string pCURP, string pSocioId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            ViewBag.Id = pPersonaId;

            Models.PersonaModel persona = new Models.PersonaModel();
            persona.PersonaId       = pPersonaId;
            persona.Nombre          = pNombre;
            persona.Paterno         = pPaterno;
            persona.Materno         = pMaterno;
            persona.Genero          = pGenero;
            persona.FechaNacimiento = pFechaNacimiento;
            persona.CURP            = pCURP;
            persona.SocioId         = pSocioId;

            return View(persona);
        }


        [Authorize]
        [HttpPost]
        public ActionResult EditV(Models.PersonaModel model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            if (!ViewData.ModelState.IsValid) return View(model);

            #region SE INSERTA EN SACC PERSONA
            SACC.Entidades.NovaComercial.dbo.Persona obj = new SACC.Entidades.NovaComercial.dbo.Persona();
            obj.PersonaId             = model.PersonaId;
            obj.Nombre                = model.Nombre;
            obj.Paterno               = model.Paterno;
            obj.Materno               = model.Materno;
            obj.Genero                = model.Genero;
            obj.FechaNacimiento       = model.FechaNacimiento.Value;
            obj.CURP                  = model.CURP;
            obj.UsuarioCreacionId     = GetUsuarioId();
            obj.UsuarioModificacionId = GetUsuarioId();

            SACC.Entidades.EntidadJsonResponse resPersona = new SACC.Entidades.EntidadJsonResponse();// SACC.LogicaNegocio.NovaComercial.dbo.Persona.Guardar(obj);
            #endregion


            if (resPersona.Id > 0)
            {
                #region SE ASIGNA EL CONTRATO A LA NUEVA PERSONA
                SACC.Entidades.NovaComercial.dbo.PersonaContrato pc = new SACC.Entidades.NovaComercial.dbo.PersonaContrato();
                pc.PersonaContratoId     = 0;
                pc.PersonaId             = resPersona.Id;
                pc.ContratoId            = GetContratoId();
                pc.PersonaContratoId     = 0;
                pc.UsuarioCreacionId     = GetUsuarioId();
                pc.UsuarioModificacionId = GetUsuarioId();

                SACC.Entidades.EntidadJsonResponse resPersonaContrato = new SACC.Entidades.EntidadJsonResponse();// SACC.LogicaNegocio.NovaComercial.dbo.PersonaContrato.Guardar(SACC.LogicaNegocio.SqlOpciones.Insertar, pc);
                #endregion

                #region SE INSERTA LA PERSONA EN REGISTRO CHECKUP
                SACC.Entidades.Registro.dbo.CheckUp_Persona objPersona = new SACC.Entidades.Registro.dbo.CheckUp_Persona();
                objPersona.PersonaId             = 0;
                objPersona.TerniumId             = 0;
                objPersona.NovaId                = int.Parse(model.SocioId);
                objPersona.Nombre                = obj.Paterno + " " + obj.Materno + ", " + obj.Nombre;
                objPersona.Estatus               = true;
                objPersona.Correo                = string.Empty;
                objPersona.TelefonoOficina       = string.Empty;
                objPersona.TelefonoOtro          = string.Empty;
                objPersona.Genero                = obj.Genero == true ? "M" : "F";
                objPersona.PlantaId              = 73;
                objPersona.NombreSupervisor      = string.Empty;
                objPersona.FechaNacimiento       = obj.FechaNacimiento;
                objPersona.FechaCheckUpAnterior  = null;
                objPersona.SACC_PersonaId        = resPersona.Id;
                objPersona.UsuarioCreacionId     = GetUsuarioId();
                objPersona.UsuarioModificacionId = GetUsuarioId();
                objPersona.Baja                  = false;

                SACC.Entidades.EntidadJsonResponse resRegistro = SACC.LogicaNegocio.Registro.dbo.CheckUp_Persona.Guardar(objPersona);
                #endregion
            }

            return RedirectToAction("Index", "Persona");
        }




        [Authorize]
        public ActionResult Delete(int pPersonaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            SACC.Entidades.EntidadJsonResponse res = new SACC.Entidades.EntidadJsonResponse();
            //res = SACC.LogicaNegocio.NovaComercial.dbo.Persona.BajaLogica(pPersonaId, GetUsuarioId());

            TempData["title"] = "Mensaje";
            TempData["text"]  = res.Error == false ? res.Mensaje : res.MensajeError;
            TempData["type"]  = res.TipoMensaje;

            //Models.PersonaVisualizar model = new Models.PersonaVisualizar();
            //model.Estatus = PortalEmpresa.Client.Controllers.RadioController.RadioList("EstatusBusqueda");

            return RedirectToAction("Index", "Persona");
        }




        [Authorize]
        [HttpGet]
        public ActionResult Create(string pCURP)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            Models.PersonaModel model = new Models.PersonaModel();
            model.PersonaId = 0;
            model.CURP      = pCURP;

            return View(model);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Create(Models.PersonaModel model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            if (!ViewData.ModelState.IsValid) return View(model);

            #region SE INSERTA EN SACC PERSONA
            SACC.Entidades.NovaComercial.dbo.Persona obj = new SACC.Entidades.NovaComercial.dbo.Persona();
            obj.PersonaId             = model.PersonaId;
            obj.Nombre                = model.Nombre;
            obj.Paterno               = model.Paterno;
            obj.Materno               = model.Materno;
            obj.Genero                = model.Genero;
            obj.FechaNacimiento       = model.FechaNacimiento.Value;
            obj.CURP                  = model.CURP;
            obj.UsuarioCreacionId     = GetUsuarioId();
            obj.UsuarioModificacionId = GetUsuarioId();

            SACC.Entidades.EntidadJsonResponse resPersona = new SACC.Entidades.EntidadJsonResponse();// SACC.LogicaNegocio.NovaComercial.dbo.Persona.Guardar(obj);
            #endregion


            if (resPersona.Id > 0)
            {
                #region SE ASIGNA EL CONTRATO A LA NUEVA PERSONA
                SACC.Entidades.NovaComercial.dbo.PersonaContrato pc = new SACC.Entidades.NovaComercial.dbo.PersonaContrato();
                pc.PersonaContratoId     = 0;
                pc.PersonaId             = resPersona.Id;
                pc.ContratoId            = GetContratoId();
                pc.PersonaContratoId     = 0;
                pc.UsuarioCreacionId     = GetUsuarioId();
                pc.UsuarioModificacionId = GetUsuarioId();

                SACC.Entidades.EntidadJsonResponse resPersonaContrato = new SACC.Entidades.EntidadJsonResponse();// SACC.LogicaNegocio.NovaComercial.dbo.PersonaContrato.Guardar(SACC.LogicaNegocio.SqlOpciones.Insertar, pc);
                #endregion

                #region OBTIENE EL FOLIO PARA VIGENCIA
                int pNovaId = 0;
                SACC.Entidades.NovaComercial.dbo.PersonaNumeroSocio objPersonaNumeroSocio = new SACC.Entidades.NovaComercial.dbo.PersonaNumeroSocio();
                objPersonaNumeroSocio.NumeroSocioId = 0;
                objPersonaNumeroSocio.PersonaId     = resPersona.Id;

                pNovaId = SACC.LogicaNegocio.NovaComercial.dbo.PersonaNumeroSocio.ObtieneConsecutivo(objPersonaNumeroSocio);
                #endregion

                #region SE INSERTA LA PERSONA EN REGISTRO CHECKUP
                SACC.Entidades.Registro.dbo.CheckUp_Persona objPersona = new SACC.Entidades.Registro.dbo.CheckUp_Persona();
                objPersona.PersonaId             = 0;
                objPersona.TerniumId             = 0;
                objPersona.NovaId                = pNovaId;
                objPersona.Nombre                = obj.Paterno + " " + obj.Materno + ", " + obj.Nombre;
                objPersona.Estatus               = true;
                objPersona.Correo                = string.Empty;
                objPersona.TelefonoOficina       = string.Empty;
                objPersona.TelefonoOtro          = string.Empty;
                objPersona.Genero                = obj.Genero == true ? "M" : "F";
                objPersona.PlantaId              = 73;
                objPersona.NombreSupervisor      = string.Empty;
                objPersona.FechaNacimiento       = obj.FechaNacimiento;
                objPersona.FechaCheckUpAnterior  = null;
                objPersona.SACC_PersonaId        = resPersona.Id;
                objPersona.UsuarioCreacionId     = GetUsuarioId();
                objPersona.UsuarioModificacionId = GetUsuarioId();
                objPersona.Baja                  = false;

                SACC.Entidades.EntidadJsonResponse resRegistro = SACC.LogicaNegocio.Registro.dbo.CheckUp_Persona.Guardar(objPersona);
                #endregion

                #region INSERTA EN TEMPORAL DE VIGENCIA
                SACC.Entidades.VigenciaII.PUB.tmu_usuarios objPersonaVigencia = new SACC.Entidades.VigenciaII.PUB.tmu_usuarios();
                objPersonaVigencia.tmu_aplica_fam        = false;
                objPersonaVigencia.tmu_ap_casada         = string.Empty;
                objPersonaVigencia.tmu_ap_mat            = obj.Materno;
                objPersonaVigencia.tmu_ap_pat            = obj.Paterno;
                objPersonaVigencia.tmu_calle             = string.Empty;
                objPersonaVigencia.tmu_codigopost        = "0";
                objPersonaVigencia.tmu_colonia_desc      = "Por Definir";
                objPersonaVigencia.tmu_colonia_id        = 8469;
                objPersonaVigencia.tmu_correoelec        = string.Empty;
                objPersonaVigencia.tmu_curp              = obj.CURP;
                objPersonaVigencia.tmu_cvefam            = 0;
                objPersonaVigencia.tmu_cvefam_ant        = 0;
                objPersonaVigencia.tmu_cve_estatus       = 0;
                objPersonaVigencia.tmu_cve_mov           = "AL";
                objPersonaVigencia.tmu_depto_id          = string.Empty;
                objPersonaVigencia.tmu_desc_nomina       = 0;
                objPersonaVigencia.tmu_edocivil          = "S";
                objPersonaVigencia.tmu_empresa_id        = "BCH";
                objPersonaVigencia.tmu_Endoso_SIASS      = 0;
                objPersonaVigencia.tmu_estado_desc       = "Por Definir";
                objPersonaVigencia.tmu_estado_id         = 19;
                objPersonaVigencia.tmu_extension         = "0";
                objPersonaVigencia.tmu_fax_movil         = "0";
                objPersonaVigencia.tmu_fec_alta          = DateTime.Now;
                objPersonaVigencia.tmu_fec_baja          = null;
                objPersonaVigencia.tmu_fec_captura       = DateTime.Now;
                objPersonaVigencia.tmu_fec_fallecimiento = null;
                objPersonaVigencia.tmu_fec_naci          = obj.FechaNacimiento;
                objPersonaVigencia.tmu_fec_proceso       = DateTime.Now;
                objPersonaVigencia.tmu_fec_reactiva      = null;
                objPersonaVigencia.tmu_folio             = 0; // funcion para obtener el maximo de esa tabla
                //objPersonaVigencia.tmu_hora_cap
                objPersonaVigencia.tmu_Id_Enlace         = string.Empty;
                objPersonaVigencia.tmu_Id_SIASS          = string.Empty;
                objPersonaVigencia.tmu_mensaje           = 0;
                objPersonaVigencia.tmu_motivo_id         = 0;
                objPersonaVigencia.tmu_municipio_desc    = "Por Definir";
                objPersonaVigencia.tmu_muni_id           = 2450;
                objPersonaVigencia.tmu_nombre            = obj.Nombre;
                objPersonaVigencia.tmu_numdir            = string.Empty;
                objPersonaVigencia.tmu_observa           = string.Empty;
                objPersonaVigencia.tmu_pais_desc         = "MÉXICO";
                objPersonaVigencia.tmu_pais_id           = 1;
                objPersonaVigencia.tmu_planta_id         = "999";
                objPersonaVigencia.tmu_Poliza_SIASS      = 0;
                objPersonaVigencia.tmu_rfc               = string.Empty;
                objPersonaVigencia.tmu_segurosoc         = string.Empty;
                objPersonaVigencia.tmu_servicio_id       = 0;
                objPersonaVigencia.tmu_sexo              = obj.Genero;
                objPersonaVigencia.tmu_socio_id          = pNovaId;
                objPersonaVigencia.tmu_socio_id_ant      = 0;
                objPersonaVigencia.tmu_telefono_casa     = string.Empty;
                objPersonaVigencia.tmu_telefono_ofi      = string.Empty;
                objPersonaVigencia.tmu_tiposang_id       = string.Empty;
                objPersonaVigencia.tmu_tipotrab          = string.Empty;
                objPersonaVigencia.tmu_tipous_id         = "TI";
                objPersonaVigencia.tmu_usuario_cap       = "PortalEmpresa";

                SACC.Entidades.EntidadJsonResponse resVigencia = SACC.LogicaNegocio.VigenciaII.PUB.tmu_usuarios.Guardar(objPersonaVigencia);
                #endregion
            }

            return RedirectToAction("Index", "Persona");
        }




        [HttpPost]
        public JsonResult PersonaJson(string pNombre)
        {
            List<SACC.Entidades.NovaComercial.dbo.Persona> res = new List<SACC.Entidades.NovaComercial.dbo.Persona>();// SACC.LogicaNegocio.NovaComercial.dbo.Persona.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaPoblacion, 0, -1, -1, pNombre, "", null, GetContratoId(), 0);

            return Json(new { success = true, result = new { data = res } });
        }




        [Authorize]
        public ActionResult BuscarCURP()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            Models.PersonaBuscarCURP model = new Models.PersonaBuscarCURP();
            model.TipoBusqueda = false;

            return View(model);
        }

        
        [Authorize]
        [HttpPost]
        public ActionResult BuscarCURP(Models.PersonaBuscarCURP model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            if (!ViewData.ModelState.IsValid) return View(model);

            #region SE BUSCA EL CURP EN LA TABLA DE PERSONA
            List<SACC.Entidades.NovaComercial.dbo.Persona> res = null;
            //res = SACC.LogicaNegocio.NovaComercial.dbo.Persona.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaPersonaPorCURP, 0, -1, -1, "", model.CURP, null, GetContratoId(), 0);
            
            if (res.Count > 0)
            {
                if (res[0].CampoComplemento_ContratoId == GetContratoId())
                    ViewBag.EnPoblacion = 1;
                else
                    ViewBag.EnPoblacion = 0;

                return RedirectToAction("Edit", "Persona", new { @pPersonaId = res[0].PersonaId });
            }
            #endregion


            #region SE BUSCA EL CURP EN LA TABLA DE TMU_USUARIOS
            res = SACC.LogicaNegocio.VigenciaII.PUB.tmu_usuarios.BuscarPorCURP(model.CURP);
            if (res.Count > 0)
            {
                TempData["title"] = "Mensaje";
                TempData["text"] = "El CURP esta pendiente de procesar; consulte al area de Operaciones";
                TempData["type"] = "warning";

                return View(model);

                //var _res = res.Where(x => int.Parse(x.CampoComplemento_SocioId) > 0).FirstOrDefault();

                //return RedirectToAction("EditV", "Persona", new { @pPersonaId = _res.PersonaId, @pNombre = _res.Nombre, @pPaterno = _res.Paterno, @pMaterno = _res.Materno, @pGenero = _res.Genero, @pFechaNacimiento = _res.FechaNacimiento, @pCURP = _res.CURP, @pSocioId = _res.CampoComplemento_SocioId });
            }
            //else
            //{
            //    return RedirectToAction("Create", "Persona", new { @pCURP = model.CURP });
            //}
            #endregion


            #region SE BUSCA EL CURP EN LA TABLA DE US_USUARIOS
            res = SACC.LogicaNegocio.VigenciaII.PUB.us_usuarios.BuscarPorCURP(model.CURP);
            if (res.Count > 0)
            {
                var _res  = res.Where(x => int.Parse(x.CampoComplemento_SocioId) > 0).FirstOrDefault();

                return RedirectToAction("EditV", "Persona", new { @pPersonaId = _res.PersonaId, @pNombre = _res.Nombre, @pPaterno = _res.Paterno, @pMaterno = _res.Materno, @pGenero = _res.Genero, @pFechaNacimiento = _res.FechaNacimiento, @pCURP = _res.CURP, @pSocioId = _res.CampoComplemento_SocioId });
            }
            else
            {
                return RedirectToAction("Create", "Persona", new { @pCURP = model.CURP });
            }
            #endregion
        }



        
        [Authorize]
        public ActionResult BuscarSocio()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            Models.PersonaBuscarSocio model = new Models.PersonaBuscarSocio();
            model.TipoBusqueda = true;

            return View(model);
        }


        [Authorize]
        [HttpPost]
        public ActionResult BuscarSocio(Models.PersonaBuscarSocio model)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            if (!ViewData.ModelState.IsValid) return View(model);

            List<SACC.Entidades.NovaComercial.dbo.Persona> resVigencia = new List<SACC.Entidades.NovaComercial.dbo.Persona>();
            resVigencia = SACC.LogicaNegocio.VigenciaII.PUB.us_usuarios.BuscarPorId(model.SocioId, model.ClaveFamiliar);

            model.TipoBusqueda = true;

            if (resVigencia.Count > 0)
            {
                if (resVigencia[0].CURP == "")
                {
                    return RedirectToAction("Create", "Persona", new { @pCURP = "" });
                }

                List<SACC.Entidades.NovaComercial.dbo.Persona> res = null;
                //res = SACC.LogicaNegocio.NovaComercial.dbo.Persona.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaPersonaPorCURP, 0, -1, -1, "", resVigencia[0].CURP, null, GetContratoId(), 0);

                if (res.Count > 0)
                {
                    var _res = res.Where(x => x.CampoComplemento_ContratoId == GetContratoId()).FirstOrDefault();

                    if (_res.CampoComplemento_ContratoId == GetContratoId())
                        ViewBag.EnPoblacion = 1;
                    else
                        ViewBag.EnPoblacion = 0;

                    return RedirectToAction("Edit", "Persona", new { @pPersonaId = _res.PersonaId });
                }
                else
                {
                    var _res = resVigencia.Where(x => int.Parse(x.CampoComplemento_SocioId) > 0).FirstOrDefault();

                    return RedirectToAction("EditV", "Persona", new { @pPersonaId = _res.PersonaId, @pNombre = _res.Nombre, @pPaterno = _res.Paterno, @pMaterno = _res.Materno, @pGenero = _res.Genero, @pFechaNacimiento = _res.FechaNacimiento, @pCURP = _res.CURP, @pSocioId = _res.CampoComplemento_SocioId });
                }
            }
            else
            {
                TempData["title"] = "Mensaje";
                TempData["text"]  = "El n%C3%BAmero de socio no existe";
                TempData["type"]  = "warning";

                return View(model);
            }
        }
    }
}