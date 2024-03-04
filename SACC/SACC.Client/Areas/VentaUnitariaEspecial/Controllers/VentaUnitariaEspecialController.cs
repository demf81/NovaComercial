using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SACC.Client.Areas.VentaUnitariaEspecial.Controllers
{
    public class VentaUnitariaEspecialController : SACC.Client.Controllers.BaseController
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

            Models.VentaUnitariaEspecialVisualizar model = new Models.VentaUnitariaEspecialVisualizar();
            
            model.Estatus = SACC.Client.Controllers.RadioController.RadioList("EstatusBusqueda");
            model.Empresas = Empresa.Controllers.EmpresaController.EmpresaList(OpcionesCombo.TODOS);

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View(model);
        }

        [HttpPost]
        public JsonResult VentaUnitariaEspecialJson(int pEmpresaId, int pEstatusId)
        {
            List<SACC.Entidades.NovaComercial.dbo.VentaUnitaria> res = SACC.LogicaNegocio.NovaComercial.dbo.VentaUnitaria.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralVentaUnitariaAsociado, 0, pEmpresaId, "", null, pEstatusId);

            return Json(new { success = true, result = new { data = res } });
        }




        [Authorize]
        [HttpGet]
        public ActionResult Edit(int pVentaUnitariaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.EDITAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            List<SACC.Entidades.NovaComercial.dbo.VentaUnitaria> res = SACC.LogicaNegocio.NovaComercial.dbo.VentaUnitaria.Consultar(SACC.LogicaNegocio.SqlOpciones.ConsultaVentaUnitariaResumen, pVentaUnitariaId, 0, "", null, 0);

            Models.VentaUnitariaResumen model = new Models.VentaUnitariaResumen();

            if (res.Count > 0)
            {
                model.VentaUnitariaId                = res[0].VentaUnitariaId;
                model.VentaUnitariaDescripcion       = res[0].VentaUnitariaDescripcion;
                model.EmpresaId                      = res[0].ContratanteId;
                model.Empresa                        = res[0].CampoComplemento_EmpresaDescripcion;
                model.TipoServicio                   = res[0].CampoComplemento_ServicioTipoDescripcion.ToString();
                model.PersonaId                      = res[0].PersonaId.Value;
                model.Nombre                         = res[0].CampoComplemento_NombreCompleto;
                model.ContratoId                     = res[0].CampoComplemento_ContratoId;
                model.Contrato                       = res[0].CampoComplemento_ContratoDescripcion;
                model.FechaVigencia                  = res[0].VigenciaTermino.Value;
                model.EsquemaPrePago                 = res[0].EsquemaPrePago;
                model.CobroAnticipado                = res[0].CobroAnticipado;
                model.PorcentajeUtilidadSobreTarifa  = res[0].PorcentajeUtilidad;
                model.PorcentajeCopagoContratante    = res[0].PorcentajeCoPago.Value;
                model.PorcentajeDescuentoSobreTarifa = res[0].PorcentajeDescuento.Value;
                model.Total                          = res[0].Total.Value;

            }

            return View(model);
        }



        
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

            Models.VentaUnitariaEspecialModel model = new Models.VentaUnitariaEspecialModel();

            model.EmpresaPlantas = new List<SelectListItem>();// EmpresaPlanta.Controllers.EmpresaPlantaController.EmpresaPlantaList(OpcionesCombo.SELECCIONE);
            
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text  = "[Seleccione...]", Value = "0" });

            model.Contratos = items;
            model.Productos = items;
            model.Paquetes  = items;

            return View(model);
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult Create(Models.VentaUnitariaEspecialModel model, List<VentaUnitariaEspecialDetalle.Models.VentaUnitariaEspecialDetalleModel> list)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            if (!ViewData.ModelState.IsValid) return View(model);

            SACC.Entidades.NovaComercial.dbo.VentaUnitaria obj = new SACC.Entidades.NovaComercial.dbo.VentaUnitaria();
            obj.VentaUnitariaId          = model.VentaUnitariaId;
            obj.VentaUnitariaDescripcion = model.VentaUnitariaDescripcion;
            obj.VentaTipoId              = 0;
            obj.ContratanteId            = model.EmpresaId;
            obj.TitularId                = model.PersonaId;
            obj.PersonaId                = null;
            obj.AsociadoId               = model.PersonaId;
            obj.PaqueteId                = 0;
            obj.VigenciaInicio           = DateTime.Now;
            obj.VigenciaTermino          = model.FechaVigencia;
            obj.AutorizacionId           = 0;
            obj.EsquemaPrePago           = model.EsquemaPrePago;
            obj.CobroAnticipado          = model.CobroAnticipado;
            obj.CobroAnticipadoMonto     = 0;
            obj.MontoLimite              = 0;
            obj.PrecioCobertura          = false;
            obj.PorcentajeUtilidad       = model.PorcentajeUtilidadSobreTarifa;
            obj.CopagoTipoId             = 0;
            obj.PorcentajeCoPago         = model.PorcentajeCopagoContratante;
            obj.PorcentajeDescuento      = model.PorcentajeDescuentoSobreTarifa;
            obj.Total                    = model.Total;
            obj.ManejaPrecioLista        = false;
            obj.EstatusId                = 1;
            obj.UsuarioCreacionId        = GetUsuarioId();
            obj.UsuarioModificacionId    = GetUsuarioId();

            List<SACC.Entidades.NovaComercial.dbo.VentaUnitariaDetalle> objDetalle = new List<SACC.Entidades.NovaComercial.dbo.VentaUnitariaDetalle>();
            foreach (VentaUnitariaEspecialDetalle.Models.VentaUnitariaEspecialDetalleModel item in list)
            {
                objDetalle.Add(new SACC.Entidades.NovaComercial.dbo.VentaUnitariaDetalle
                {
                    VentaUnitariaDetalleId         = 0,
                    VentaUnitariaId                = 0,
                    VentaUnitariaDetalleTipoId     = item.VentaUnitariaDetalleTipoId,
                    ContratoId                     = model.ContratoId,
                    ContratoCondicionId            = model.wizard_ContratoProductoId,
                    PaqueteCoberturaId             = 0,
                    Amparado                       = item.Amparado,
                    EsquemaPrePago                 = obj.EsquemaPrePago,
                    CobroAnticipado                = obj.CobroAnticipado,
                    TarifaId                       = 1,
                    PorcentajeUtilidadSobreTarifa  = obj.PorcentajeUtilidad,
                    PorcentajeCopagoContratante    = obj.PorcentajeCoPago,
                    PorcentajeDescuentoSobreTarifa = obj.PorcentajeDescuento,
                    itemId                         = item.itemId,
                    Cantidad                       = item.Cantidad,
                    UsuarioCreacionId              = GetUsuarioId(),
                    UsuarioModificacionId          = GetUsuarioId()
                });
            }

            SACC.Entidades.EntidadJsonResponse res = SACC.LogicaNegocio.NovaComercial.dbo.VentaUnitaria.Guardar(obj, objDetalle);

            TempData["title"] = "Mensage";
            TempData["text"]  = res.Error == false ? res.Mensaje : res.MensajeError;
            TempData["type"]  = res.Mensaje;

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return RedirectToAction("Index", "VentaUnitariaEspecial", new { Area = "VentaUnitariaEspecial" });
        }
    }
}