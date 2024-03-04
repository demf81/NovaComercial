using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class VentaDetalle
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalle> ConsultarGrid(Int32 pVentaDetalleId, Int32 pVentaId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalle> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalle>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.VentaDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.VentaDetallePM
                {
                    Opcion         = (Int16)SqlOpciones.ConsultaGeneral,
                    VentaDetalleId = pVentaDetalleId,
                    VentaId        = pVentaId,
                    EstatusId      = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.VentaDetalle oBD = new AccesoDatos.NovaComercial.SACC.VentaDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalle item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalle>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalle
                            {
                                VentaDetalleId      = Int32.Parse(dr["VentaDetalleId"].ToString()),
                                VentaId             = Int32.Parse(dr["VentaId"].ToString()),
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
                                Iva                 = Decimal.Parse(dr["Iva"].ToString()),
                                SubTotal            = Decimal.Parse(dr["SubTotal"].ToString()),
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
                res.TituloError  = "(LogicaNegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalleConPrecio> ConsultarGridConPrecio(Int32 pVentaDetalleId, Int32 pVentaId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalleConPrecio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalleConPrecio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.VentaDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.VentaDetallePM
                {
                    Opcion         = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    VentaDetalleId = pVentaDetalleId,
                    VentaId        = pVentaId,
                    EstatusId      = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.VentaDetalle oBD = new AccesoDatos.NovaComercial.SACC.VentaDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalleConPrecio item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalleConPrecio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.VentaDetalle.DtoGridVentaDetalleConPrecio
                            {
                                VentaDetalleId      = Int32.Parse(dr["VentaDetalleId"].ToString()),
                                VentaId             = Int32.Parse(dr["VentaId"].ToString()),
                                AreaNegocioId       = Int32.Parse(dr["AreaNegocioId"].ToString()),
                                ServicioId          = Int32.Parse(dr["ServicioId"].ToString()),
                                ItemId              = Int32.Parse(dr["ItemId"].ToString()),
                                ItemDescripcion     = dr["ItemDescripcion"].ToString(),
                                ItemTipoId          = Int16.Parse(dr["ItemTipoId"].ToString()),
                                ItemTipoDescripcion = dr["ItemTipoDescripcion"].ToString(),
                                Cantidad            = Int32.Parse(dr["Cantidad"].ToString()),
                                Costo               = Decimal.Parse(dr["Costo"].ToString()),
                                Precio              = Decimal.Parse(dr["Precio"].ToString()),
                                PrecioConIva        = Decimal.Parse(dr["PrecioConIva"].ToString()),
                                Descuento           = Decimal.Parse(dr["Descuento"].ToString()),
                                CampaniaId          = Int32.Parse(dr["CampaniaId"].ToString()),
                                TarifaId            = Int32.Parse(dr["TarifaId"].ToString()),
                                SubTotal            = Decimal.Parse(dr["SubTotal"].ToString()),
                                SubTotalConIva      = Decimal.Parse(dr["SubTotalConIva"].ToString()),
                                Referencia          = dr["Referencia"].ToString(),
                                Iva                 = Decimal.Parse(dr["Iva"].ToString()),
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
                res.TituloError  = "(LogicaNegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaDetalle.DtoVentaDetalle> ConsultarPorId(Int32 pVentaDetalleId, Int32 pVentaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaDetalle.DtoVentaDetalle> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.VentaDetalle.DtoVentaDetalle>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.VentaDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.VentaDetallePM
                {
                    Opcion         = (Int16)SqlOpciones.ConsultaPorId,
                    VentaDetalleId = pVentaDetalleId,
                    VentaId        = pVentaId
                };

                AccesoDatos.NovaComercial.SACC.VentaDetalle oBD = new AccesoDatos.NovaComercial.SACC.VentaDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.VentaDetalle.DtoVentaDetalle item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.VentaDetalle.DtoVentaDetalle>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.VentaDetalle.DtoVentaDetalle
                            {
                                VentaDetalleId      = Int32.Parse(dr["VentaDetalleId"].ToString()),
                                VentaId             = Int32.Parse(dr["VentaId"].ToString()),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.VentaDetalle obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.VentaDetalle oBD = new AccesoDatos.NovaComercial.SACC.VentaDetalle();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.VentaDetalleId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["VentaDetalleSId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pVentaDetalleId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();
            
            try
            {
                Entidades.NovaComercial.SACC.VentaDetalle oE = new Entidades.NovaComercial.SACC.VentaDetalle
                {
                    VentaDetalleId    = pVentaDetalleId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.VentaDetalle oBD = new AccesoDatos.NovaComercial.SACC.VentaDetalle();
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