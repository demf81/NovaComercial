using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class ContratoCoberturaPaqueteCondicion : Conexion.ConexionSQL
    {
        public ContratoCoberturaPaqueteCondicion()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteCondicionPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoCoberturaPaqueteCondicion_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                              oParametro.Opcion),
                        new SqlParameter("@ContratoCoberturaPaqueteCondicionId", oParametro.ContratoCoberturaPaqueteCondicionId),
                        new SqlParameter("@ContratoCoberturaPaqueteId",          oParametro.ContratoCoberturaPaqueteId),
                        new SqlParameter("@EstatusId",                           oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoCoberturaPaqueteCondicion_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                     Opcion),
                        new SqlParameter("@ContratoCoberturaPaqueteId", oBE.ContratoCoberturaPaqueteId),
                        new SqlParameter("@CoberturaCondicionTipoId",   oBE.CoberturaCondicionTipoId),
                        new SqlParameter("@CoberturaPeriodoTipoId",     oBE.CoberturaPeriodoTipoId),
                        new SqlParameter("@CoberturaCantidadTipoId",    oBE.CoberturaCantidadTipoId),
                        new SqlParameter("@Cantidad",                   oBE.Cantidad),
                        new SqlParameter("@CoberturaCopagoTipoId",      oBE.CoberturaCopagoTipoId),
                        new SqlParameter("@Copago",                     oBE.Copago),
                        new SqlParameter("@UsuarioCreacionId",          oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoCoberturaPaqueteCondicion_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                              Opcion),
                        new SqlParameter("@ContratoCoberturaPaqueteCondicionId", oBE.ContratoCoberturaPaqueteCondicionId),
                       new SqlParameter("@ContratoCoberturaPaqueteId",           oBE.ContratoCoberturaPaqueteId),
                        new SqlParameter("@CoberturaCondicionTipoId",            oBE.CoberturaCondicionTipoId),
                        new SqlParameter("@CoberturaPeriodoTipoId",              oBE.CoberturaPeriodoTipoId),
                        new SqlParameter("@CoberturaCantidadTipoId",             oBE.CoberturaCantidadTipoId),
                        new SqlParameter("@Cantidad",                            oBE.Cantidad),
                        new SqlParameter("@CoberturaCopagoTipoId",               oBE.CoberturaCopagoTipoId),
                        new SqlParameter("@Copago",                              oBE.Copago),
                        new SqlParameter("@UsuarioModificacionId",               oBE.UsuarioModificacionId),
                        new SqlParameter("@UsuarioBajaId",                       oBE.UsuarioBajaId),
                        new SqlParameter("@EstatusId",                           oBE.EstatusId)
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