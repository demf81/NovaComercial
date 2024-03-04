using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class CotizacionProcedimientoDetalle
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalle> ConsultarGrid(Int32 pCotizacionDetalleId, Int32 pCotizacionId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalle> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalle>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.CotizacionProcedimientoDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.CotizacionProcedimientoDetallePM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneral,
                    CotizacionDetalleId = pCotizacionDetalleId,
                    CotizacionId        = pCotizacionId,
                    EstatusId           = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.CotizacionProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.CotizacionProcedimientoDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalle item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalle>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalle
                            {
                                CotizacionProcedimientoDetalleId = Int32.Parse(dr["CotizacionProcedimientoDetalleId"].ToString()),
                                CotizacionDetalleId              = Int32.Parse(dr["CotizacionDetalleId"].ToString()),
                                CotizacionId                     = Int32.Parse(dr["CotizacionId"].ToString()),
                                ProcedimientoId                  = Int32.Parse(dr["ProcedimientoId"].ToString()),
                                ServicioId                       = Int32.Parse(dr["ServicioId"].ToString()),
                                ServicioPartidaId                = dr["ServicioPartidaId"].ToString(),
                                ProcedimientoDetalleDescripcion  = dr["ProcedimientoDetalleDescripcion"].ToString(),
                                Posicion                         = Int32.Parse(dr["Posicion"].ToString()),
                                ClaseOperacion                   = dr["ClaseOperacion"].ToString(),
                                ElementoId                       = dr["ElementoId"].ToString(),
                                CantidadOriginal                 = Decimal.Parse(dr["CantidadOriginal"].ToString()),
                                Cantidad                         = Decimal.Parse(dr["Cantidad"].ToString()),
                                Unidad                           = dr["Unidad"].ToString(),
                                CantidadBase                     = Decimal.Parse(dr["CantidadBase"].ToString()),
                                Tarifa                           = Decimal.Parse(dr["Tarifa"].ToString()),
                                Costo                            = Decimal.Parse(dr["Costo"].ToString()),
                                Precio                           = Decimal.Parse(dr["Precio"].ToString()),
                                Iva                              = Decimal.Parse(dr["Iva"].ToString()),
                                TarifaId                         = Int32.Parse(dr["TarifaId"].ToString()),
                                SubTotal                         = Decimal.Parse(dr["SubTotal"].ToString()),
                                Seleccionado                     = Boolean.Parse(dr["Seleccionado"].ToString()),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalleConPrecio> ConsultarGridConPrecio(Int32 pCotizacionDetalleId, Int32 pCotizacionId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalleConPrecio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalleConPrecio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.CotizacionProcedimientoDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.CotizacionProcedimientoDetallePM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    CotizacionDetalleId = pCotizacionDetalleId,
                    CotizacionId        = pCotizacionId,
                    EstatusId           = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.CotizacionProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.CotizacionProcedimientoDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalleConPrecio item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalleConPrecio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoGridCotizacionProcedimientoDetalleConPrecio
                            {
                                CotizacionProcedimientoDetalleId = Int32.Parse(dr["CotizacionProcedimientoDetalleId"].ToString()),
                                CotizacionDetalleId              = Int32.Parse(dr["CotizacionDetalleId"].ToString()),
                                CotizacionId                     = Int32.Parse(dr["CotizacionId"].ToString()),
                                ProcedimientoDetalleId           = Int32.Parse(dr["ProcedimientoDetalleId"].ToString()),
                                ProcedimientoId                  = Int32.Parse(dr["ProcedimientoId"].ToString()),
                                ServicioId                       = Int32.Parse(dr["ServicioId"].ToString()),
                                ServicioPartidaId                = dr["ServicioPartidaId"].ToString(),
                                ProcedimientoDetalleDescripcion  = dr["ProcedimientoDetalleDescripcion"].ToString(),
                                Posicion                         = Int32.Parse(dr["Posicion"].ToString()),
                                ClaseOperacion                   = dr["ClaseOperacion"].ToString(),
                                ElementoId                       = dr["ElementoId"].ToString(),
                                CantidadOriginal                 = Decimal.Parse(dr["CantidadOriginal"].ToString()),
                                Cantidad                         = Decimal.Parse(dr["Cantidad"].ToString()),
                                Unidad                           = dr["Unidad"].ToString(),
                                CantidadBase                     = Decimal.Parse(dr["CantidadBase"].ToString()),
                                Tarifa                           = Decimal.Parse(dr["Tarifa"].ToString()),
                                Costo                            = Decimal.Parse(dr["Costo"].ToString()),
                                Precio                           = Decimal.Parse(dr["Precio"].ToString()),
                                PrecioConIva                     = Decimal.Parse(dr["PrecioConIva"].ToString()),
                                Iva                              = Decimal.Parse(dr["Iva"].ToString()),
                                TarifaId                         = Int32.Parse(dr["TarifaId"].ToString()),
                                SubTotal                         = Decimal.Parse(dr["SubTotal"].ToString()),
                                SubTotalConIva                   = Decimal.Parse(dr["SubTotalConIva"].ToString()),
                                Seleccionado                     = Boolean.Parse(dr["Seleccionado"].ToString()),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle> ConsultarPorId(Int32 pCotizacionDetalleId, Int32 pCotizacionId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.CotizacionProcedimientoDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.CotizacionProcedimientoDetallePM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaPorId,
                    CotizacionDetalleId = pCotizacionDetalleId,
                    CotizacionId        = pCotizacionId
                };

                AccesoDatos.NovaComercial.SACC.CotizacionProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.CotizacionProcedimientoDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle.DtoCotizacionProcedimientoDetalle
                            {
                                CotizacionDetalleId = Int32.Parse(dr["CotizacionDetalleId"].ToString()),
                                CotizacionId        = Int32.Parse(dr["CotizacionId"].ToString()),
                                //AreaNegocioId       = Int32.Parse(dr["AreaNegocioId"].ToString()),
                                ServicioId          = Int32.Parse(dr["ServicioId"].ToString()),
                                //ItemId              = Int32.Parse(dr["ItemId"].ToString()),
                                //ItemDescripcion     = dr["ItemDescripcion"].ToString(),
                                //ItemTipoId          = Int16.Parse(dr["ItemTipoId"].ToString()),
                                //ItemTipoDescripcion = dr["ItemTipoDescripcion"].ToString(),
                                Cantidad            = Int32.Parse(dr["Cantidad"].ToString()),
                                Costo               = Decimal.Parse(dr["Costo"].ToString()),
                                Precio              = Decimal.Parse(dr["Precio"].ToString()),
                                //Descuento           = Decimal.Parse(dr["Descuento"].ToString()),
                                //CampaniaId          = Int32.Parse(dr["CampaniaId"].ToString()),
                                TarifaId            = Int32.Parse(dr["TarifaId"].ToString()),
                                SubTotal            = Decimal.Parse(dr["SubTotal"].ToString()),
                                //Iva                 = Decimal.Parse(dr["Iva"].ToString()),
                                //Total               = (Decimal.Parse(dr["Precio"].ToString()) * Int32.Parse(dr["Cantidad"].ToString())),
                                //Amparada            = Boolean.Parse(dr["Amparada"].ToString()),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.CotizacionProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.CotizacionProcedimientoDetalle();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.CotizacionProcedimientoDetalleId == 0)
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
                        res.TituloError  = response.TituloError;
                        res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                        res.TipoMensaje  = "warning";
                    }
                    else
                    {
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["CotizacionProcedimientoDetalleId"].ToString());
                        res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
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
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - El registro no se pudo guardar/actualizar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pCotizacionProcedimientoDetalleId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle oE = new Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle
                {
                    //CotizacionDetalleId = pCotizacionDetalleId,
                    UsuarioBajaId       = pUsuarioId,
                    FechaModificacion   = DateTime.Now,
                    FechaBaja           = DateTime.Now,
                    Baja                = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.CotizacionProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.CotizacionProcedimientoDetalle();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["CotizacionDetalleId"].ToString());
                    res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                    res.MensajeError = response.MensajeError;
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