using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SACC.Client.Areas.VentaUnitaria.Controllers
{
    public class VentaUnitariaController : Client.Controllers.BaseController
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

            Models.VentaUnitariaVisualizar model = new Models.VentaUnitariaVisualizar();
            
            model.Estatus = Client.Controllers.RadioController.RadioList("EstatusBusqueda");
            model.Empresas = Empresa.Controllers.EmpresaController.EmpresaList(OpcionesCombo.TODOS);

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View(model);
        }

        [HttpPost]
        public JsonResult VentaUnitariaJson(int pEmpresaId, string pNombre, int pEstatusId)
        {
            List<Entidades.NovaComercial.dbo.VentaUnitaria> res = LogicaNegocio.NovaComercial.dbo.VentaUnitaria.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralVentaUnitariaPersona, 0, pEmpresaId, pNombre, null, pEstatusId);

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

            List<Entidades.NovaComercial.dbo.VentaUnitaria> res = LogicaNegocio.NovaComercial.dbo.VentaUnitaria.Consultar(LogicaNegocio.SqlOpciones.ConsultaVentaUnitariaResumen, pVentaUnitariaId, 0, "", null, 0);

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

            Models.VentaUnitariaModel model = new Models.VentaUnitariaModel();
            
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text  = "[Seleccione...]", Value = "0" });

            model.Contratos          = items;
            model.CoberturaProductos = items;
            model.Paquetes  = items;

            return View(model);
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult Create(Models.VentaUnitariaModel model, List<VentaUnitariaDetalle.Models.VentaUnitariaDetalle> list)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            int varPermisoValido = Nova.SDK.SAI.Permiso.Validar(_AplicacionId, Nova.SDK.PermisoGeneral.AGREGAR, HttpContext.Session["Permisos"] as System.Data.DataTable);
            if (varPermisoValido == 0)
                Response.Redirect("~/Home/SinPermiso");
            else if (varPermisoValido == -1)
                Response.Redirect("~/Home/Logout");

            if (!ViewData.ModelState.IsValid) return View(model);

            Entidades.NovaComercial.dbo.VentaUnitaria obj = new Entidades.NovaComercial.dbo.VentaUnitaria
            {
                VentaUnitariaId = model.VentaUnitariaId,
                VentaUnitariaDescripcion = model.VentaUnitariaDescripcion,
                VentaTipoId = 0,
                ContratanteId = model.EmpresaId,
                TitularId = model.PersonaId,
                PersonaId = model.PersonaId,
                AsociadoId = 0,
                PaqueteId = 0,
                VigenciaInicio = DateTime.Now,
                VigenciaTermino = model.FechaVigencia,
                AutorizacionId = 0,
                EsquemaPrePago = model.EsquemaPrePago,
                CobroAnticipado = model.CobroAnticipado,
                CobroAnticipadoMonto = 0,
                MontoLimite = 0,
                PrecioCobertura = false,
                PorcentajeUtilidad = model.PorcentajeUtilidadSobreTarifa,
                CopagoTipoId = 0,
                PorcentajeCoPago = model.PorcentajeCopagoContratante,
                PorcentajeDescuento = model.PorcentajeDescuentoSobreTarifa,
                Total = model.Total,
                ManejaPrecioLista = false,
                EstatusId = 1,
                UsuarioCreacionId = GetUsuarioId(),
                UsuarioModificacionId = GetUsuarioId()
            };

            List<Entidades.NovaComercial.dbo.VentaUnitariaDetalle> objDetalle = new List<Entidades.NovaComercial.dbo.VentaUnitariaDetalle>();
            foreach (VentaUnitariaDetalle.Models.VentaUnitariaDetalle item in list)
            {
                objDetalle.Add(new Entidades.NovaComercial.dbo.VentaUnitariaDetalle
                {
                    VentaUnitariaDetalleId         = 0,
                    VentaUnitariaId                = 0,
                    VentaUnitariaDetalleTipoId     = item.VentaUnitariaDetalleTipoId,
                    ContratoId                     = model.ContratoId,
                    ContratoCondicionId            = model.wizard_CoberturaProductoId,
                    PaqueteCoberturaId             = item.PaqueteCoberturaId,
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

            Entidades.EntidadJsonResponse res = LogicaNegocio.NovaComercial.dbo.VentaUnitaria.Guardar(obj, objDetalle);

            TempData["title"] = "Mensage";
            TempData["text"]  = res.Error == false ? res.Mensaje : res.MensajeError;
            TempData["type"]  = res.Mensaje;

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return RedirectToAction("Index", "VentaUnitaria", new { Area = "VentaUnitaria" });
        }




        [Authorize]
        [HttpPost]
        public ActionResult CambioVigencia(int pVentaUnitariaId, DateTime pFechaVigencia)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            Entidades.NovaComercial.dbo.VentaUnitaria ventaUnitaria = new Entidades.NovaComercial.dbo.VentaUnitaria
            {
                VentaUnitariaId       = pVentaUnitariaId,
                VigenciaTermino       = pFechaVigencia,
                UsuarioModificacionId = GetUsuarioId(),
                FechaModificacion     = DateTime.Now
            };

            Entidades.EntidadJsonResponse res = LogicaNegocio.NovaComercial.dbo.VentaUnitaria.CambioVigencia(ventaUnitaria);

            this.TempData["title"] = "Mensage";
            this.TempData["text"] = res.Error == false ? res.Mensaje : res.MensajeError;
            this.TempData["type"] = res.Mensaje;

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return RedirectToAction("Index", "VentaUnitaria", new { Area = "VentaUnitaria" });
        }




        [Authorize]
        [HttpPost]
        public ActionResult Reprocesar(int pVentaUnitariaId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/Logout");

            Entidades.EntidadJsonResponse res = LogicaNegocio.NovaComercial.dbo.VentaUnitaria.Reprocesar(pVentaUnitariaId);

            this.TempData["title"] = "Mensage";
            this.TempData["text"] = res.Error == false ? res.Mensaje : res.MensajeError;
            this.TempData["type"] = res.TipoMensaje;

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return RedirectToAction("Index", "VentaUnitaria", new { Area = "VentaUnitaria" });
        }
    }
}