using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class ProcedimientoDetalle
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoGridProcedimientoDetalle> ConsultarGrid(Int32 pProcedimientoId, String pProcedimientoDetalleDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoGridProcedimientoDetalle> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoGridProcedimientoDetalle>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ProcedimientoDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.ProcedimientoDetallePM
                {
                    Opcion                          = (Int16)SqlOpciones.ConsultaGeneral,
                    ProcedimientoId                 = pProcedimientoId,
                    ProcedimientoDetalleDescripcion = pProcedimientoDetalleDescripcion,
                    EstatusId                       = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.ProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.ProcedimientoDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoGridProcedimientoDetalle item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoGridProcedimientoDetalle>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoGridProcedimientoDetalle
                            {
                                ProcedimientoDetalleId          = Int32.Parse(dr["ProcedimientoDetalleId"].ToString()),
                                Posicion                        = Int16.Parse(dr["Posicion"].ToString()),
                                ClaseOperacion                  = dr["ClaseOperacion"].ToString(),
                                ElementoId                      = dr["ElementoId"].ToString(),
                                ProcedimientoDetalleDescripcion = dr["ProcedimientoDetalleDescripcion"].ToString(),
                                Cantidad                        = Decimal.Parse(dr["Cantidad"].ToString()),
                                Unidad                          = dr["Unidad"].ToString(),
                                Costo                           = Decimal.Parse(dr["Costo"].ToString()),
                                SubTotal                        = Decimal.Parse(dr["Subtotal"].ToString()),
                                EstatusId                       = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoGridProcedimientoDetalleConPrecio> ConsultarGridConPrecio(Int32 pProcedimientoId, String pProcedimientoDetalleDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoGridProcedimientoDetalleConPrecio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoGridProcedimientoDetalleConPrecio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ProcedimientoDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.ProcedimientoDetallePM
                {
                    Opcion                          = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    ProcedimientoId                 = pProcedimientoId,
                    ProcedimientoDetalleDescripcion = pProcedimientoDetalleDescripcion,
                    EstatusId                       = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.ProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.ProcedimientoDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoGridProcedimientoDetalleConPrecio item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoGridProcedimientoDetalleConPrecio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoGridProcedimientoDetalleConPrecio
                            {
                                ProcedimientoDetalleId          = Int32.Parse(dr["ProcedimientoDetalleId"].ToString()),
                                ServicioId                      = Int32.Parse(dr["ServicioId"].ToString()),
                                ServicioPartidaId               = dr["ServicioPartidaId"].ToString(),
                                ProcedimientoDetalleDescripcion = dr["ProcedimientoDetalleDescripcion"].ToString(),
                                Posicion                        = Int16.Parse(dr["Posicion"].ToString()),
                                ClaseOperacion                  = dr["ClaseOperacion"].ToString(),
                                ElementoId                      = dr["ElementoId"].ToString(),
                                CantidadOriginal                = Decimal.Parse(dr["CantidadOriginal"].ToString()),
                                Cantidad                        = Decimal.Parse(dr["Cantidad"].ToString()),
                                Unidad                          = dr["Unidad"].ToString(),
                                CantidadBase                    = Decimal.Parse(dr["CantidadBase"].ToString()),
                                Tarifa                          = Decimal.Parse(dr["Tarifa"].ToString()),
                                TarifaId                        = Int32.Parse(dr["TarifaId"].ToString()),
                                Costo                           = Decimal.Parse(dr["Costo"].ToString()),
                                Precio                          = Decimal.Parse(dr["Precio"].ToString()),
                                PrecioConIva                    = Decimal.Parse(dr["PrecioConIva"].ToString()),
                                Iva                             = Decimal.Parse(dr["Iva"].ToString()),
                                SubTotal                        = Decimal.Parse(dr["SubTotal"].ToString()),
                                SubTotalConIva                  = Decimal.Parse(dr["SubTotalConIva"].ToString()),
                                EstatusId                       = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoProcedimientoDetalle> ConsultarPorId(Int32 pProcedimientoDetalleId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoProcedimientoDetalle> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoProcedimientoDetalle>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ProcedimientoDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.ProcedimientoDetallePM
                {
                    Opcion = (Int16)SqlOpciones.ConsultaPorId,
                    ProcedimientoDetalleId = pProcedimientoDetalleId
                };

                AccesoDatos.NovaComercial.SACC.ProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.ProcedimientoDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoProcedimientoDetalle item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoProcedimientoDetalle>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.ProcedimientoDetalle.DtoProcedimientoDetalle
                            {
                                ProcedimientoDetalleId          = Int32.Parse(dr["ProcedimientoDetalleId"].ToString()),
                                ProcedimientoDetalleDescripcion = dr["ProcedimientoDetalleDescripcion"].ToString(),
                                EstatusId                       = Int16.Parse(dr["EstatusId"].ToString())
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
                    res.TipoMensaje  =  "error";
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.ProcedimientoDetalle obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.ProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.ProcedimientoDetalle();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ProcedimientoDetalleId == 0)
                {
                    response = oBD.Insertar((short)SqlOpciones.Insertar, obj);
                }
                else
                {
                    if (obj.Baja == true)
                    {
                        obj.UsuarioBajaId = obj.UsuarioBajaId;
                    }

                    response = oBD.Actualizar((short)SqlOpciones.Actualizar, obj);
                }

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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ProcedimientoDetalleId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pProcedimientoDetalleId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.ProcedimientoDetalle oE = new Entidades.NovaComercial.SACC.ProcedimientoDetalle
                {
                    ProcedimientoDetalleId = pProcedimientoDetalleId,
                    UsuarioBajaId          = pUsuarioId,
                    FechaModificacion      = DateTime.Now,
                    FechaBaja              = DateTime.Now,
                    Baja                   = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.ProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.ProcedimientoDetalle();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ProcedimientoDetalleId"].ToString());
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
    }
}