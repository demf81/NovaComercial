using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class ContratoProducto : Conexion.ConexionSQL
    {
        public ContratoProducto()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.ContratoProductoPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoProducto_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                      oParametro.Opcion),
                        new SqlParameter("@ContratoProductoId",          oParametro.ContratoProductoId),
                        new SqlParameter("@ContratoId",                  oParametro.ContratoId),
                        new SqlParameter("@ContratoProductoDescripcion", oParametro.ContratoProductoDescripcion),
                        new SqlParameter("@EstatusId",                   oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.ContratoProducto oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoProducto_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                         Opcion),
                        new SqlParameter("@ContratoId",                     oBE.ContratoId),
                        new SqlParameter("@ContratoProductoDescripcion",    oBE.ContratoProductoDescripcion),
                        new SqlParameter("@EsquemaPrePago",                 oBE.EsquemaPrePago),
                        new SqlParameter("@CobroAnticipado",                oBE.CobroAnticipado),
                        new SqlParameter("@TarifaId",                       oBE.TarifaId),
                        new SqlParameter("@PorcentajeUtilidadSobreTarifa",  oBE.PorcentajeUtilidadSobreTarifa),
                        new SqlParameter("@PorcentajeCopagoContratante",    oBE.PorcentajeCopagoContratante),
                        new SqlParameter("@PorcentajeDescuentoSobreTarifa", oBE.PorcentajeDescuentoSobreTarifa),
                        new SqlParameter("@UsuarioCreacionId",              oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.ContratoProducto oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoProducto_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                         Opcion),
                        new SqlParameter("@ContratoProductoId",             oBE.ContratoProductoId),
                        new SqlParameter("@ContratoId",                     oBE.ContratoId),
                        new SqlParameter("@ContratoProductoDescripcion",    oBE.ContratoProductoDescripcion),
                        new SqlParameter("@EsquemaPrePago",                 oBE.EsquemaPrePago),
                        new SqlParameter("@CobroAnticipado",                oBE.CobroAnticipado),
                        new SqlParameter("@TarifaId",                       oBE.TarifaId),
                        new SqlParameter("@PorcentajeUtilidadSobreTarifa",  oBE.PorcentajeUtilidadSobreTarifa),
                        new SqlParameter("@PorcentajeCopagoContratante",    oBE.PorcentajeCopagoContratante),
                        new SqlParameter("@PorcentajeDescuentoSobreTarifa", oBE.PorcentajeDescuentoSobreTarifa),
                        new SqlParameter("@UsuarioModificacionId",          oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",              oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",                  oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                      oBE.FechaBaja),
                        new SqlParameter("@Baja",                           oBE.Baja),
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