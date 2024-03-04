using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class Venta
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Venta.DtoGridVenta> ConsultarGrid(String pVentaDescripcion, DateTime? pFechaInicio, DateTime? pFechaFin, Int16 pVentaTipoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Venta.DtoGridVenta> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Venta.DtoGridVenta>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.VentaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.VentaPM
                {
                    Opcion           = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    VentaDescripcion = pVentaDescripcion,
                    FechaInicio      = pFechaInicio,
                    FechaFin         = pFechaFin,
                    VentaTipoId      = pVentaTipoId,
                    EstatusId        = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.Venta oBD = new AccesoDatos.NovaComercial.SACC.Venta();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Venta.DtoGridVenta item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Venta.DtoGridVenta>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Venta.DtoGridVenta
                            {
                                VentaId              = Int32.Parse(dr["VentaId"].ToString()),
                                VentaDescripcion     = dr["VentaDescripcion"].ToString(),
                                Fecha                = dr["Fecha"].ToString(),
                                VentaTipoId          = Int16.Parse(dr["VentaTipoId"].ToString()),
                                VentaTipoDescripcion = dr["VentaTipoDescripcion"].ToString(),
                                PersonaNombre        = dr["PersonaNombre"].ToString(),
                                EmpresaNombre        = dr["EmpresaNombre"].ToString(),
                                SubTotal             = Decimal.Parse(dr["SubTotal"].ToString()),
                                Descuento            = Decimal.Parse(dr["Descuento"].ToString()),
                                Iva                  = Decimal.Parse(dr["Iva"].ToString()),
                                Total                = Decimal.Parse(dr["Total"].ToString()),
                                Anticipo             = Decimal.Parse(dr["Anticipo"].ToString()),
                                VentaEstatusId       = Int16.Parse(dr["VentaEstatusId"].ToString())
                            };

                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaNegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Venta.DtoVenta> ConsultarPorId(Int32 pVentaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Venta.DtoVenta> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Venta.DtoVenta>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.VentaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.VentaPM
                {
                    Opcion  = (Int16)SqlOpciones.ConsultaPorId,
                    VentaId = pVentaId
                };

                AccesoDatos.NovaComercial.SACC.Venta oBD = new AccesoDatos.NovaComercial.SACC.Venta();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Venta.DtoVenta item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Venta.DtoVenta>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Venta.DtoVenta
                            {
                                VentaId          = Int32.Parse(dr["VentaId"].ToString()),
                                VentaDescripcion = dr["VentaDescripcion"].ToString(),
                                Fecha            = DateTime.Parse(dr["Fecha"].ToString()),
                                VentaTipoId      = Int16.Parse(dr["VentaTipoId"].ToString()),
                                PersonaId        = Int32.Parse(dr["PersonaId"].ToString()),
                                EmpresaId        = Int32.Parse(dr["EmpresaId"].ToString()),
                                SubTotal         = Decimal.Parse(dr["SubTotal"].ToString()),
                                Descuento        = Decimal.Parse(dr["Descuento"].ToString()),
                                CampaniaId       = Int32.Parse(dr["CampaniaId"].ToString()),
                                Iva              = Decimal.Parse(dr["Iva"].ToString()),
                                Total            = Decimal.Parse(dr["Total"].ToString()),
                                VentaEstatusId   = Int16.Parse(dr["VentaEstatusId"].ToString())
                            };

                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Venta.DtoVenta> ConsultarPorIdConJoin(Int32 pVentaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Venta.DtoVenta> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Venta.DtoVenta>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.VentaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.VentaPM
                {
                    Opcion  = (Int16)SqlOpciones.ConsultaPorIdConJoin,
                    VentaId = pVentaId
                };

                AccesoDatos.NovaComercial.SACC.Venta oBD = new AccesoDatos.NovaComercial.SACC.Venta();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Venta.DtoVenta item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Venta.DtoVenta>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Venta.DtoVenta
                            {
                                VentaId          = Int32.Parse(dr["VentaId"].ToString()),
                                VentaDescripcion = dr["VentaDescripcion"].ToString(),
                                Fecha            = DateTime.Parse(dr["Fecha"].ToString()),
                                VentaTipoId      = Int16.Parse(dr["VentaTipoId"].ToString()),
                                PersonaId        = Int32.Parse(dr["PersonaId"].ToString()),
                                PersonaNombre    = dr["PErsonaNombre"].ToString(),
                                EmpresaId        = Int32.Parse(dr["EmpresaId"].ToString()),
                                EmpresaNombre    = dr["EmpresaNombre"].ToString(),
                                SubTotal         = Decimal.Parse(dr["SubTotal"].ToString()),
                                Descuento        = Decimal.Parse(dr["Descuento"].ToString()),
                                CampaniaId       = Int32.Parse(dr["CampaniaId"].ToString()),
                                Iva              = Decimal.Parse(dr["Iva"].ToString()),
                                Total            = Decimal.Parse(dr["Total"].ToString()),
                                VentaEstatusId   = Int16.Parse(dr["VentaEstatusId"].ToString())
                            };

                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.Venta obj, List<Entidades.NovaComercial.SACC.VentaDetalle> objDetalle, List<Entidades.NovaComercial.SACC.VentaProcedimientoDetalle> objProcedimientoDetalle)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.Venta oBD = new AccesoDatos.NovaComercial.SACC.Venta();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                AccesoDatos.NovaComercial.SACC.VentaDetalle oBD_Detalle = new AccesoDatos.NovaComercial.SACC.VentaDetalle();
                Modelo.ModeloResponse responseDetalle = new Modelo.ModeloResponse();

                AccesoDatos.NovaComercial.SACC.VentaProcedimientoDetalle oBD_ProcedimientoDetalle = new AccesoDatos.NovaComercial.SACC.VentaProcedimientoDetalle();
                Modelo.ModeloResponse responseProcedimientoDetalle = new Modelo.ModeloResponse();

                AccesoDatos.DUtil oUtil = new AccesoDatos.DUtil();

                if (obj.VentaId == 0)
                {
                    response = oBD.Insertar((short)SqlOpciones.Insertar, obj);

                    if (!response.Error)
                    {
                        var _VentaId = int.Parse(response.Resultado.Tables[0].Rows[0]["VentaId"].ToString());

                        if (_VentaId > 0)
                        {
                            foreach (Entidades.NovaComercial.SACC.VentaDetalle itemDetalle in objDetalle)
                            {
                                itemDetalle.VentaId = _VentaId;

                                if (itemDetalle.VentaDetalleId == 0)
                                {
                                    responseDetalle = oBD_Detalle.Insertar((short)SqlOpciones.Insertar, itemDetalle);

                                    var _VentaDetalleId = int.Parse(responseDetalle.Resultado.Tables[0].Rows[0]["VentaDetalleId"].ToString());

                                    if (_VentaDetalleId > 0)
                                    {
                                        if (itemDetalle.ServicioId == 9)
                                        {
                                            foreach (Entidades.NovaComercial.SACC.VentaProcedimientoDetalle itemProcedimientoDetalle in objProcedimientoDetalle)
                                            {
                                                if (itemDetalle.ItemId == itemProcedimientoDetalle.ProcedimientoId)
                                                {
                                                    itemProcedimientoDetalle.VentaDetalleId = _VentaDetalleId;
                                                    itemProcedimientoDetalle.VentaId        = _VentaId;

                                                    responseProcedimientoDetalle = oBD_ProcedimientoDetalle.Insertar((short)SqlOpciones.Insertar, itemProcedimientoDetalle);
                                                }
                                            }
                                        }
                                    }
                                }


                                if (itemDetalle.VentaDetalleId > 0)
                                {
                                    responseDetalle = oBD_Detalle.Actualizar((short)SqlOpciones.Actualizar, itemDetalle);

                                    var _VentaDetalleId = int.Parse(responseDetalle.Resultado.Tables[0].Rows[0]["VentaDetalleId"].ToString());

                                    if (_VentaDetalleId > 0)
                                    {
                                        if (itemDetalle.ServicioId == 9)
                                        {
                                            foreach (Entidades.NovaComercial.SACC.VentaProcedimientoDetalle itemProcedimientoDetalle in objProcedimientoDetalle)
                                            {
                                                if (itemDetalle.ItemId == itemProcedimientoDetalle.ProcedimientoId)
                                                {
                                                    itemProcedimientoDetalle.VentaDetalleId = _VentaDetalleId;
                                                    itemProcedimientoDetalle.VentaId        = _VentaId;

                                                    responseProcedimientoDetalle = oBD_ProcedimientoDetalle.Actualizar((short)SqlOpciones.Insertar, itemProcedimientoDetalle);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            oUtil.EjecutaNonQuery("EXEC [SACC].[spTaskVenta_Procesar] @VentaId=" + _VentaId + ";");
                        }
                    }
                }
                else
                {
                    if (obj.Baja == true)
                    {
                        obj.UsuarioBajaId = obj.UsuarioBajaId;
                    }

                    response = oBD.Actualizar((short)SqlOpciones.Actualizar, obj);

                    if (!response.Error)
                    {
                        var _VentaId = int.Parse(response.Resultado.Tables[0].Rows[0]["VentaId"].ToString());

                        if (_VentaId > 0)
                        {
                            foreach (Entidades.NovaComercial.SACC.VentaDetalle item in objDetalle)
                            {
                                item.VentaId = _VentaId;

                                if (item.VentaDetalleId == 0)
                                    responseDetalle = oBD_Detalle.Insertar((short)SqlOpciones.Insertar, item);

                                if (item.VentaDetalleId > 0)
                                    responseDetalle = oBD_Detalle.Actualizar((short)SqlOpciones.Actualizar, item);
                            }
                        }
                    }
                }

                if (!response.Error)
                {
                    if (response.Resultado.Tables[0].Rows[0]["Error"].ToString() == "True")
                    {
                        res.Error        = true;
                        res.TituloError  = response.TituloError;
                        res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                        res.TipoMensaje  = "warning";
                    }
                    else
                    {
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["VentaId"].ToString());
                        res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;
                    res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - El registro no se pudo guardar/actualizar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pVentaId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.Venta oE = new Entidades.NovaComercial.SACC.Venta
                {
                    VentaId           = pVentaId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.Venta oBD = new AccesoDatos.NovaComercial.SACC.Venta();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["VentaId"].ToString());
                    res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                    res.MensajeError = response.Resultado.Tables[0].Rows[0]["Error"].ToString();
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse Cancelar(Int32 pVentaId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.Venta oE = new Entidades.NovaComercial.SACC.Venta
                {
                    VentaId               = pVentaId,
                    UsuarioModificacionId = pUsuarioId,
                    UsuarioBajaId         = pUsuarioId,
                };

                AccesoDatos.NovaComercial.SACC.Venta oBD = new AccesoDatos.NovaComercial.SACC.Venta();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.CancelaVenta, oE);

                if (!response.Error)
                {
                    if (response.Resultado.Tables[0].Rows[0]["Error"].ToString() == "True")
                    {
                        res.Error        = true;
                        res.TituloError  = "(LogicaLegocio) - El registro no se pudo guardar/actualizar.";
                        res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                        res.TipoMensaje  = "warning";
                    }
                    else
                    {
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["VentaId"].ToString());
                        res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                    res.MensajeError = response.Resultado.Tables[0].Rows[0]["Error"].ToString();
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error = true;
                res.TituloError = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje = "error";
            }

            return res;
        }
    }
}