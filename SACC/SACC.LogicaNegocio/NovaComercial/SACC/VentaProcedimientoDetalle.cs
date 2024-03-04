using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class VentaProcedimientoDetalle
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalle> ConsultarGrid(Int32 pVentaDetalleId, Int32 pVentaId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalle> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalle>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.VentaProcedimientoDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.VentaProcedimientoDetallePM
                {
                    Opcion         = (Int16)SqlOpciones.ConsultaGeneral,
                    VentaDetalleId = pVentaDetalleId,
                    VentaId        = pVentaId,
                    EstatusId      = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.VentaProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.VentaProcedimientoDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalle item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalle>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalle
                            {
                                VentaProcedimientoDetalleId     = Int32.Parse(dr["VentaProcedimientoDetalleId"].ToString()),
                                VentaDetalleId                  = Int32.Parse(dr["VentaDetalleId"].ToString()),
                                VentaId                         = Int32.Parse(dr["VentaId"].ToString()),
                                ProcedimientoId                 = Int32.Parse(dr["ProcedimientoId"].ToString()),
                                ServicioId                      = Int32.Parse(dr["ServicioId"].ToString()),
                                ServicioPartidaId               = dr["ServicioPartidaId"].ToString(),
                                ProcedimientoDetalleDescripcion = dr["ProcedimientoDetalleDescripcion"].ToString(),
                                Posicion                        = Int32.Parse(dr["Posicion"].ToString()),
                                ClaseOperacion                  = dr["ClaseOperacion"].ToString(),
                                ElementoId                      = dr["ElementoId"].ToString(),
                                CantidadOriginal                = Decimal.Parse(dr["CantidadOriginal"].ToString()),
                                Cantidad                        = Decimal.Parse(dr["Cantidad"].ToString()),
                                Unidad                          = dr["Unidad"].ToString(),
                                CantidadBase                    = Decimal.Parse(dr["CantidadBase"].ToString()),
                                Tarifa                          = Decimal.Parse(dr["Tarifa"].ToString()),
                                Costo                           = Decimal.Parse(dr["Costo"].ToString()),
                                Precio                          = Decimal.Parse(dr["Precio"].ToString()),
                                Iva                             = Decimal.Parse(dr["Iva"].ToString()),
                                TarifaId                        = Int32.Parse(dr["TarifaId"].ToString()),
                                SubTotal                        = Decimal.Parse(dr["SubTotal"].ToString()),
                                Seleccionado                    = Boolean.Parse(dr["Seleccionado"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalleConPrecio> ConsultarGridConPrecio(Int32 pVentaDetalleId, Int32 pVentaId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalleConPrecio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalleConPrecio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.VentaProcedimientoDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.VentaProcedimientoDetallePM
                {
                    Opcion         = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    VentaDetalleId = pVentaDetalleId,
                    VentaId        = pVentaId,
                    EstatusId      = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.VentaProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.VentaProcedimientoDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalleConPrecio item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalleConPrecio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoGridVentaProcedimientoDetalleConPrecio
                            {
                                VentaProcedimientoDetalleId     = Int32.Parse(dr["VentaProcedimientoDetalleId"].ToString()),
                                VentaDetalleId                  = Int32.Parse(dr["VentaDetalleId"].ToString()),
                                VentaId                         = Int32.Parse(dr["VentaId"].ToString()),
                                ProcedimientoId                 = Int32.Parse(dr["ProcedimientoId"].ToString()),
                                ServicioId                      = Int32.Parse(dr["ServicioId"].ToString()),
                                ServicioPartidaId               = dr["ServicioPartidaId"].ToString(),
                                ProcedimientoDetalleDescripcion = dr["ProcedimientoDetalleDescripcion"].ToString(),
                                Posicion                        = Int32.Parse(dr["Posicion"].ToString()),
                                ClaseOperacion                  = dr["ClaseOperacion"].ToString(),
                                ElementoId                      = dr["ElementoId"].ToString(),
                                CantidadOriginal                = Decimal.Parse(dr["CantidadOriginal"].ToString()),
                                Cantidad                        = Decimal.Parse(dr["Cantidad"].ToString()),
                                Unidad                          = dr["Unidad"].ToString(),
                                CantidadBase                    = Decimal.Parse(dr["CantidadBase"].ToString()),
                                Tarifa                          = Decimal.Parse(dr["Tarifa"].ToString()),
                                Costo                           = Decimal.Parse(dr["Costo"].ToString()),
                                Precio                          = Decimal.Parse(dr["Precio"].ToString()),
                                PrecioConIva                    = Decimal.Parse(dr["Precio"].ToString()) + Decimal.Parse(dr["Iva"].ToString()),
                                Iva                             = Decimal.Parse(dr["Iva"].ToString()),
                                TarifaId                        = Int32.Parse(dr["TarifaId"].ToString()),
                                SubTotal                        = Decimal.Parse(dr["SubTotal"].ToString()),
                                SubTotalConIva                  = Decimal.Parse(dr["SubTotalConIva"].ToString()) + Decimal.Parse(dr["Iva"].ToString()),
                                Seleccionado                    = Boolean.Parse(dr["Seleccionado"].ToString()),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoVentaProcedimientoDetalle> ConsultarPorId(Int32 pVentaDetalleId, Int32 pVentaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoVentaProcedimientoDetalle> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoVentaProcedimientoDetalle>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.VentaProcedimientoDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.VentaProcedimientoDetallePM
                {
                    Opcion         = (Int16)SqlOpciones.ConsultaPorId,
                    VentaDetalleId = pVentaDetalleId,
                    VentaId        = pVentaId
                };

                AccesoDatos.NovaComercial.SACC.VentaProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.VentaProcedimientoDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoVentaProcedimientoDetalle item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoVentaProcedimientoDetalle>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.VentaProcedimientoDetalle.DtoVentaProcedimientoDetalle
                            {
                                VentaDetalleId = Int32.Parse(dr["VentaDetalleId"].ToString()),
                                VentaId = Int32.Parse(dr["VentaId"].ToString()),
                                //AreaNegocioId       = Int32.Parse(dr["AreaNegocioId"].ToString()),
                                ServicioId = Int32.Parse(dr["ServicioId"].ToString()),
                                //ItemId              = Int32.Parse(dr["ItemId"].ToString()),
                                //ItemDescripcion     = dr["ItemDescripcion"].ToString(),
                                //ItemTipoId          = Int16.Parse(dr["ItemTipoId"].ToString()),
                                //ItemTipoDescripcion = dr["ItemTipoDescripcion"].ToString(),
                                Cantidad = Int32.Parse(dr["Cantidad"].ToString()),
                                Costo = Decimal.Parse(dr["Costo"].ToString()),
                                Precio = Decimal.Parse(dr["Precio"].ToString()),
                                //Descuento           = Decimal.Parse(dr["Descuento"].ToString()),
                                //CampaniaId          = Int32.Parse(dr["CampaniaId"].ToString()),
                                TarifaId = Int32.Parse(dr["TarifaId"].ToString()),
                                SubTotal = Decimal.Parse(dr["SubTotal"].ToString()),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.VentaProcedimientoDetalle obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.VentaProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.VentaProcedimientoDetalle();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.VentaProcedimientoDetalleId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["VentaProcedimientoDetalleId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pVentaProcedimientoDetalleId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.VentaProcedimientoDetalle oE = new Entidades.NovaComercial.SACC.VentaProcedimientoDetalle
                {
                    //VentaDetalleId = pVentaDetalleId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.VentaProcedimientoDetalle oBD = new AccesoDatos.NovaComercial.SACC.VentaProcedimientoDetalle();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["VentaDetalleId"].ToString());
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