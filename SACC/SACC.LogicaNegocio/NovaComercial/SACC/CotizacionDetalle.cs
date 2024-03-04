using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class CotizacionDetalle
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalle> ConsultarGrid(Int64 pCotizacionDetalleId, Int64 pCotizacionId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalle> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalle>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.CotizacionDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.CotizacionDetallePM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    CotizacionDetalleId = pCotizacionDetalleId,
                    CotizacionId        = pCotizacionId,
                    EstatusId           = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.CotizacionDetalle oBD = new AccesoDatos.NovaComercial.SACC.CotizacionDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalle item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalle>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalle
                            {
                                CotizacionDetalleId = Int32.Parse(dr["CotizacionDetalleId"].ToString()),
                                CotizacionId        = Int32.Parse(dr["CotizacionId"].ToString()),
                                AreaNegocioId       = Int32.Parse(dr["AreaNegocioId"].ToString()),
                                ServicioId          = Int32.Parse(dr["ServicioId"].ToString()),
                                ItemId              = Int32.Parse(dr["ItemId"].ToString()),
                                ItemDescripcion     = dr["ItemDescripcion"].ToString(),
                                ItemTipoId          = Int16.Parse(dr["ItemTipoId"].ToString()),
                                ItemTipoDescripcion = dr["ItemTipoDescripcion"].ToString(),
                                Cantidad            = Int32.Parse(dr["Cantidad"].ToString()),
                                Costo               = Decimal.Parse(dr["Costo"].ToString()),
                                Precio              = Decimal.Parse(dr["Precio"].ToString()),
                                Descuento           = Decimal.Parse(dr["Descuento"].ToString()),
                                CampaniaId          = Int32.Parse(dr["CampaniaId"].ToString()),
                                TarifaId            = Int32.Parse(dr["TarifaId"].ToString()),
                                SubTotal            = Decimal.Parse(dr["SubTotal"].ToString()),
                                Iva                 = Decimal.Parse(dr["Iva"].ToString()),
                                Amparada            = Boolean.Parse(dr["Amparada"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalleConPrecio> ConsultarGridConPredio(Int64 pCotizacionDetalleId, Int64 pCotizacionId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalleConPrecio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalleConPrecio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.CotizacionDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.CotizacionDetallePM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    CotizacionDetalleId = pCotizacionDetalleId,
                    CotizacionId        = pCotizacionId,
                    EstatusId           = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.CotizacionDetalle oBD = new AccesoDatos.NovaComercial.SACC.CotizacionDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalleConPrecio item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalleConPrecio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.CotizacionDetalle.DtoGridCotizacionDetalleConPrecio
                            {
                                CotizacionDetalleId = Int32.Parse(dr["CotizacionDetalleId"].ToString()),
                                CotizacionId        = Int32.Parse(dr["CotizacionId"].ToString()),
                                AreaNegocioId       = Int32.Parse(dr["AreaNegocioId"].ToString()),
                                ServicioId          = Int32.Parse(dr["ServicioId"].ToString()),
                                ItemId              = Int32.Parse(dr["ItemId"].ToString()),
                                ItemDescripcion     = dr["ItemDescripcion"].ToString(),
                                ItemTipoId          = Int16.Parse(dr["ItemTipoId"].ToString()),
                                ItemTipoDescripcion = dr["ItemTipoDescripcion"].ToString(),
                                Cantidad            = Int32.Parse(dr["Cantidad"].ToString()),
                                Costo               = Decimal.Parse(dr["Costo"].ToString()),
                                Precio              = Decimal.Parse(dr["Precio"].ToString()),
                                PrecioConIva        = Decimal.Parse(dr["PrecioConIVa"].ToString()),
                                Descuento           = Decimal.Parse(dr["Descuento"].ToString()),
                                CampaniaId          = Int32.Parse(dr["CampaniaId"].ToString()),
                                TarifaId            = Int32.Parse(dr["TarifaId"].ToString()),
                                SubTotal            = Decimal.Parse(dr["SubTotal"].ToString()),
                                SubTotalConIva      = Decimal.Parse(dr["SubTotalConIva"].ToString()),
                                Iva                 = Decimal.Parse(dr["Iva"].ToString()),
                                Amparada            = Boolean.Parse(dr["Amparada"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoCotizacionDetalle> ConsultarPorId(Int64 pCotizacionDetalleId, Int64 pCotizacionId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoCotizacionDetalle> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoCotizacionDetalle>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.CotizacionDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.CotizacionDetallePM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaPorId,
                    CotizacionDetalleId = pCotizacionDetalleId,
                    CotizacionId        = pCotizacionId
                };

                AccesoDatos.NovaComercial.SACC.CotizacionDetalle oBD = new AccesoDatos.NovaComercial.SACC.CotizacionDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.CotizacionDetalle.DtoCotizacionDetalle item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.CotizacionDetalle.DtoCotizacionDetalle>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.CotizacionDetalle.DtoCotizacionDetalle
                            {
                                CotizacionDetalleId = Int32.Parse(dr["CotizacionDetalleId"].ToString()),
                                CotizacionId        = Int32.Parse(dr["CotizacionId"].ToString()),
                                AreaNegocioId       = Int32.Parse(dr["AreaNegocioId"].ToString()),
                                ServicioId          = Int32.Parse(dr["ServicioId"].ToString()),
                                ItemId              = Int32.Parse(dr["ItemId"].ToString()),
                                ItemDescripcion     = dr["ItemDescripcion"].ToString(),
                                ItemTipoId          = Int16.Parse(dr["ItemTipoId"].ToString()),
                                ItemTipoDescripcion = dr["ItemTipoDescripcion"].ToString(),
                                Cantidad            = Int32.Parse(dr["Cantidad"].ToString()),
                                Costo               = Decimal.Parse(dr["Costo"].ToString()),
                                Precio              = Decimal.Parse(dr["Precio"].ToString()),
                                Descuento           = Decimal.Parse(dr["Descuento"].ToString()),
                                CampaniaId          = Int32.Parse(dr["CampaniaId"].ToString()),
                                TarifaId            = Int32.Parse(dr["TarifaId"].ToString()),
                                SubTotal            = Decimal.Parse(dr["SubTotal"].ToString()),
                                //Iva                 = Decimal.Parse(dr["Iva"].ToString()),
                                //Total               = (Decimal.Parse(dr["Precio"].ToString()) * Int32.Parse(dr["Cantidad"].ToString())),
                                Amparada            = Boolean.Parse(dr["Amparada"].ToString()),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.CotizacionDetalle obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.CotizacionDetalle oBD = new AccesoDatos.NovaComercial.SACC.CotizacionDetalle();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.CotizacionDetalleId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["CotizacionDetalleId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pCotizacionDetalleId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();
            
            try
            {
                Entidades.NovaComercial.SACC.CotizacionDetalle oE = new Entidades.NovaComercial.SACC.CotizacionDetalle
                {
                    CotizacionDetalleId = pCotizacionDetalleId,
                    UsuarioBajaId       = pUsuarioId,
                    FechaModificacion   = DateTime.Now,
                    FechaBaja           = DateTime.Now,
                    Baja                = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.CotizacionDetalle oBD = new AccesoDatos.NovaComercial.SACC.CotizacionDetalle();
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