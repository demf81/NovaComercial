using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class ProcedimientoDetalle : Conexion.ConexionSQL
    {
        public ProcedimientoDetalle()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.ProcedimientoDetallePM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spProcedimientoDetalle_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                 oParametro.Opcion),
                        new SqlParameter("@ProcedimientoDetalleId", oParametro.ProcedimientoDetalleId),
                        new SqlParameter("@ProcedimientoId",        oParametro.ProcedimientoId),
                        new SqlParameter("@EstatusId",              oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.ProcedimientoDetalle oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spProcedimientoDetalle_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                          Opcion),
                        new SqlParameter("@ProcedimientoId",                 oBE.ProcedimientoId),
                        new SqlParameter("@ServicioId",                      oBE.ServicioId),
                        new SqlParameter("@ServicioPartidaId",               oBE.ServicioPartidaId),
                        new SqlParameter("@ProcedimientoDetalleDescripcion", oBE.ProcedimientoDetalleDescripcion),
                        new SqlParameter("@Posicion",                        oBE.Posicion),
                        new SqlParameter("@ClaseOperacion",                  oBE.ClaseOperacion),
                        new SqlParameter("@ElementoId",                      oBE.ElementoId),
                        new SqlParameter("@Cantidad",                        oBE.Cantidad),
                        new SqlParameter("@Unidad",                          oBE.Unidad),
                        new SqlParameter("@CantidadBase",                    oBE.CantidadBase),
                        new SqlParameter("@Tarifa",                          oBE.Tarifa),
                        new SqlParameter("@Subtotal",                        oBE.Subtotal),
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.ProcedimientoDetalle oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spProcedimientoDetalle_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                          Opcion),
                        new SqlParameter("@ProcedimientoDetalleId",          oBE.ProcedimientoDetalleId),
                        new SqlParameter("@ProcedimientoId",                 oBE.ProcedimientoId),
                        new SqlParameter("@ServicioId",                      oBE.ServicioId),
                        new SqlParameter("@ServicioPartidaId",               oBE.ServicioPartidaId),
                        new SqlParameter("@ProcedimientoDetalleDescripcion", oBE.ProcedimientoDetalleDescripcion),
                        new SqlParameter("@Posicion",                        oBE.Posicion),
                        new SqlParameter("@ClaseOperacion",                  oBE.ClaseOperacion),
                        new SqlParameter("@ElementoId",                      oBE.ElementoId),
                        new SqlParameter("@Cantidad",                        oBE.Cantidad),
                        new SqlParameter("@Unidad",                          oBE.Unidad),
                        new SqlParameter("@CantidadBase",                    oBE.CantidadBase),
                        new SqlParameter("@Tarifa",                          oBE.Tarifa),
                        new SqlParameter("@Subtotal",                        oBE.Subtotal),
                        new SqlParameter("@UsuarioModificacionId",           oBE.UsuarioModificacionId),
                        new SqlParameter("@UsuarioBajaId",                   oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                       oBE.FechaBaja),
                        new SqlParameter("@EstatusId",                       oBE.EstatusId)
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