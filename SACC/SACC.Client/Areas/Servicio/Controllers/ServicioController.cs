using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace SACC.Client.Areas.Servicio.Controllers
{
    public class ServicioController : Controller
    {
        const Int32 Contrato_AplicacionId = 167;


        public ActionResult Index()
        {
            return View();
        }




        public ActionResult _CtrlUserBusquedaServicio()
        {
            return PartialView();
        }




        [Authorize]
        [HttpPost]
        public JsonResult CtrlUserPaqueteConPrecioGridJson(String pServicioDescripcion, Int16 pServicioTipoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = LogicaNegocio.NovaComercial.dbo.Paquete.ConsultarCtrlUserArticuloConPrecioGrid(pServicioDescripcion, pServicioTipoId, 1);

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
        public JsonResult CtrlUserServicioMedicoConPrecioGridJson(String pServicioDescripcion, Int16 pServicioTipoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = LogicaNegocio.NovaComercial.dbo.Servicio.ConsultarCtrlUserServicioMedicoConPrecioGrid(pServicioDescripcion, pServicioTipoId, 0);

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
        public JsonResult CtrlUserCirugiaConPrecioGridJson(String pServicioDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = LogicaNegocio.NovaComercial.dbo.Cirugia.ConsultarCtrlUserCirugiaConPrecioGrid(pServicioDescripcion, 0);

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
        public JsonResult CtrlUserEstudioConPrecioGridJson(String pServicioDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = LogicaNegocio.NovaComercial.dbo.Estudio.ConsultarCtrlUserEstudioConPrecioGrid(pServicioDescripcion, 0);

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
        public JsonResult CtrlUserMaterialConPrecioGridJson(String pServicioDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = LogicaNegocio.NovaComercial.dbo.Material.ConsultarCtrlUserMaterialConPrecioGrid(pServicioDescripcion, 0);

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
        public JsonResult CtrlUserMedicamentoConPrecioGridJson(String pServicioDescripcion, Int16 pServicioTipoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = LogicaNegocio.NovaComercial.dbo.Medicamento.ConsultarCtrlUserMedicamentoConPrecioGrid(pServicioDescripcion, pServicioTipoId, 0);

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
        public JsonResult CtrlUserServicioAdministrativoConPrecioGridJson(String pServicioDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = LogicaNegocio.NovaComercial.SACC.ServicioAdministrativo.ConsultarCtrlUserArticuloConPrecioGrid(pServicioDescripcion, 1);

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
        public JsonResult CtrlUserSubrogadoConPrecioGridJson(String pServicioDescripcion, Int16 pServicioTipoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = LogicaNegocio.NovaComercial.SACC.ServicioSubrogado.ConsultarCtrlUserArticuloConPrecioGrid(pServicioDescripcion, pServicioTipoId, 1);

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
        public JsonResult CtrlUserProcedimientoConPrecioGridJson(String pServicioDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = LogicaNegocio.NovaComercial.SACC.Procedimiento.ConsultarCtrlUserArticuloConPrecioGrid(pServicioDescripcion, 1);

            Response.StatusCode = (int)(HttpStatusCode.OK);
            res.StatusCode      = (int)(HttpStatusCode.OK);
            res.DelayTime       = true;

            if (res.Error) {
                res.DelayTime    = false;
                res.MuestraAlert = true;
            }

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }




        //[Authorize]
        //[HttpPost]
        //public JsonResult CtrlUSerServicioTarifaJson(Int16 pAreaNegocioId)
        //{
        //    Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserServicioTarifa> res = LogicaNegocio.NovaComercial.SACC.Servicio.ConsultarCtrlUserServicioTarifa(pAreaNegocioId);

        //    if (res.Error)
        //    {
        //        Response.StatusCode = (int)(HttpStatusCode.InternalServerError);
        //        res.StatusCode      = (int)(HttpStatusCode.InternalServerError);
        //    }
        //    else
        //        Response.StatusCode = (int)(HttpStatusCode.OK);

        //    return Json(new { success = (res.Error == false ? true : false), data = res });
        //}



        [HttpPost]
        public JsonResult ServicioComboJson(OpcionesCombo _opcion, String pFiltro)
        {
            List<SelectListItem> items = new List<SelectListItem>();


            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoComboServicio> res = LogicaNegocio.NovaComercial.SACC.Servicio.ConsultarCombo("");


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

            foreach (Modelo.NovaComercial.SACC.Servicio.DtoComboServicio item in res.Datos)
            {
                if (pFiltro == "PAQUETE")
                {
                    if (item.ServicioId == 1)
                    {
                        items.Add(
                            new SelectListItem
                            {
                                Text  = item.ServicioDescripcion.ToString(),
                                Value = item.ServicioId.ToString()
                            }
                        );
                    }
                }
                else if (pFiltro == "SERVICIOS")
                {
                    if (item.ServicioId == 2 || item.ServicioId == 4 || item.ServicioId == 5)
                    {
                        items.Add(
                            new SelectListItem
                            {
                                Text  = item.ServicioDescripcion.ToString(),
                                Value = item.ServicioId.ToString()
                            }
                        );
                    }
                }
                else if (pFiltro == "PROCEDIMIENTOS")
                {
                    if (item.ServicioId == 9)
                    {
                        items.Add(
                            new SelectListItem
                            {
                                Text  = item.ServicioDescripcion.ToString(),
                                Value = item.ServicioId.ToString()
                            }
                        );
                    }
                }
                else if (pFiltro == "MEDICAMENTOS")
                {
                    if (item.ServicioId == 6)
                    {
                        items.Add(
                            new SelectListItem
                            {
                                Text  = item.ServicioDescripcion.ToString(),
                                Value = item.ServicioId.ToString()
                            }
                        );
                    }
                }
                else if (pFiltro == "ADMINISTRATIVOS")
                {
                    if (item.ServicioId == 7)
                    {
                        items.Add(
                            new SelectListItem
                            {
                                Text  = item.ServicioDescripcion.ToString(),
                                Value = item.ServicioId.ToString()
                            }
                        );
                    }
                }
                else
                {
                    items.Add(
                    new SelectListItem
                    {
                        Text  = item.ServicioDescripcion.ToString(),
                        Value = item.ServicioId.ToString()
                    });
                }
            }

            res.Lista = items;

            return Json(new { success = (res.Error == false ? true : false), data = res });
        }
    }
}