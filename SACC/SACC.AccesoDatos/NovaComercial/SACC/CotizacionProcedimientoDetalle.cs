using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class CotizacionProcedimientoDetalle : Conexion.ConexionSQL
    {
        public CotizacionProcedimientoDetalle()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.CotizacionProcedimientoDetallePM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spCotizacionProcedimientoDetalle_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",              oParametro.Opcion),
                        new SqlParameter("@CotizacionDetalleId", oParametro.CotizacionDetalleId),
                        new SqlParameter("@CotizacionId",        oParametro.CotizacionId),
                        new SqlParameter("@EstatusId",           oParametro.EstatusId)
                    }
                );

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.TituloError  = "Error SQL - La consulta no se pudo ejecutar";
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spCotizacionProcedimientoDetalle_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                          Opcion),
                        new SqlParameter("@CotizacionDetalleId",             oBE.CotizacionDetalleId),
                        new SqlParameter("@CotizacionId",                    oBE.CotizacionId),
                        new SqlParameter("@ProcedimientoDetalleId",          oBE.ProcedimientoDetalleId),
                        new SqlParameter("@ProcedimientoId",                 oBE.ProcedimientoId),
                        new SqlParameter("@ServicioId",                      oBE.ServicioId),
                        new SqlParameter("@ServicioPartidaId",               oBE.ServicioPartidaId),
                        new SqlParameter("@ProcedimientoDetalleDescripcion", oBE.ProcedimientoDetalleDescripcion),
                        new SqlParameter("@Posicion",                        oBE.Posicion),
                        new SqlParameter("@ClaseOperacion",                  oBE.ClaseOperacion),
                        new SqlParameter("@ElementoId",                      oBE.ElementoId),
                        new SqlParameter("@CantidadOriginal",                oBE.CantidadOriginal),
                        new SqlParameter("@Cantidad",                        oBE.Cantidad),
                        new SqlParameter("@Unidad",                          oBE.Unidad),
                        new SqlParameter("@CantidadBase",                    oBE.CantidadBase),
                        new SqlParameter("@Tarifa",                          oBE.Tarifa),
                        new SqlParameter("@Costo",                           oBE.Costo),
                        new SqlParameter("@Precio",                          oBE.Precio),
                        new SqlParameter("@Iva",                             oBE.Iva),
                        new SqlParameter("@TarifaId",                        oBE.TarifaId),
                        new SqlParameter("@SubTotal",                        oBE.SubTotal),
                        new SqlParameter("@Seleccionado",                    oBE.Seleccionado),
                        new SqlParameter("@UsuarioCreacionId",               oBE.UsuarioCreacionId)
                    }
                );

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.TituloError  = "Error SQL - El registro no se pudo insertar.";
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.CotizacionProcedimientoDetalle oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spCotizacionProcedimintoDetalle_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                           Opcion),
                        new SqlParameter("@CotizacionProcedimientoDetalleId", oBE.CotizacionProcedimientoDetalleId),
                        new SqlParameter("@CotizacionDetalleId",              oBE.CotizacionDetalleId),
                        new SqlParameter("@CotizacionId",                     oBE.CotizacionId),
                        new SqlParameter("@Cantidad",                         oBE.Cantidad),
                        new SqlParameter("@Costo",                            oBE.Costo),
                        new SqlParameter("@Precio",                           oBE.Precio),
                        new SqlParameter("@Iva",                              oBE.Iva),
                        new SqlParameter("@SubTotal",                         oBE.SubTotal),
                        new SqlParameter("@Seleccionado",                     oBE.Seleccionado),
                        new SqlParameter("@UsuarioModificacionId",            oBE.UsuarioModificacionId),
                        new SqlParameter("@UsuarioBajaId",                    oBE.UsuarioBajaId)
                    }
                );

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.TituloError  = "Error SQL - El registro no se pudo actualizar.";
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }
    }
}