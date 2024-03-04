using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Medicamento.Controllers
{
    public class MedicamentoController : Client.Controllers.BaseController
    {
        const Int32 _AplicacionId = 167;


        [Authorize]
        [HttpGet]
        public ActionResult Index()
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
            
            return View();
        }

        [HttpPost]
        public JsonResult MedicamentoGridJson(String pMedicamentoDescripcion, Int16 pMedicamentoCuadroTipoId, Int16 pEstatusId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Medicamento.DtoGridMedicamento> res = LogicaNegocio.NovaComercial.dbo.Medicamento.ConsultarGrid(pMedicamentoDescripcion, pMedicamentoCuadroTipoId, pEstatusId);

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
        public ActionResult _CtrlUserBusquedaMedicamento()
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            //Models.CtrlUserMedicamentoModel model = new Models.CtrlUserMedicamentoModel
            //{
            //    CtrlMedicamentoCuadroTipos = MedicamentoCuadroTipo.Controllers.MedicamentoCuadroTipoController.MedicamentoCuadroTipoList(OpcionesCombo.TODOS)
            //};
            
            return PartialView();
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserMedicamentoJson(Int32 pPaqueteId, String pPaqueteDescripcion, String pMedicamentoDescripcion, Int16 pMedicamentoCuadroTipoId)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Medicamento.DtoGridMedicamento> res = LogicaNegocio.NovaComercial.dbo.Medicamento.ConsultarGrid(pMedicamentoDescripcion, pMedicamentoCuadroTipoId, 0);
            
            //List<PaqueteDetalle.Models.PaqueteDetalleSeleccion> model = new List<PaqueteDetalle.Models.PaqueteDetalleSeleccion>();
            //model = res.Datos.Select(x => new PaqueteDetalle.Models.PaqueteDetalleSeleccion
            //{
            //    PaqueteId               = pPaqueteId,
            //    PaqueteDescripcion      = pPaqueteDescripcion,
            //    ItemTipoId              = 3,
            //    ItemTipoDescripcion     = "", //x.CampoComplemento_ItemTipoDescripcion,
            //    ItemId                  = x.MedicamentoId,
            //    ServicioDescripcion     = x.MedicamentoDescripcion,
            //    ServicioTipoDescripcion = x.MedicamentoCuadroTipoDescripcion // .CampoComplemento_MedicamentoCuadroTipoDescripcion
            //}).ToList();
            
            return Json(new { success = true, result = new { data = String.Empty } });
        }
        
        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserMedicamentoConPrecioListJson(String pDescripcion)
        {
            if (GetUsuarioId() == -1)
                Response.Redirect("~/Home/SessionExpirada");

            if (HttpContext.Session["Permisos"] == null)
                Response.Redirect("~/Home/SinPermiso");

            List<Entidades.NovaComercial.dbo.Medicamento> res = new List<Entidades.NovaComercial.dbo.Medicamento>();
            //LogicaNegocio.NovaComercial.dbo.Medicamento.Consultar(LogicaNegocio.SqlOpciones.ConsultaGeneralConJoin, 0, pDescripcion, 0, 0);
            
            List<Entidades.helper.Articulo> items = new List<Entidades.helper.Articulo>();
            foreach (Entidades.NovaComercial.dbo.Medicamento item in res)
            {
                items.Add(new Entidades.helper.Articulo
                {
                    VentaUnitariaDetalleId     = 0,
                    VentaUnitariaId            = 0,
                    VentaUnitariaDetalleTipoId = 6,
                    ItemId                     = item.MedicamentoId,
                    Cantidad                   = 1,
                    ArticuloDescripcion        = item.MedicamentoDescripcion,
                    ArticuloTipoDescripcion    = item.CampoComplemento_MedicamentoCuadroTipoDescripcion,
                    Precio                     = item.PrecioVentaPublico,
                    Subtotal                   = item.PrecioVentaPublico
                });
            }
            
            return Json(new { success = true, result = new { data = items } });
        }
    }
}