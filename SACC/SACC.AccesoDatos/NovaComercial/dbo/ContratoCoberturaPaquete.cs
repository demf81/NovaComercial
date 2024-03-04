using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class ContratoCoberturaPaquete : Conexion.ConexionSQL
    {
        public ContratoCoberturaPaquete()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaquetePM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoCoberturaPaquete_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                     oParametro.Opcion),
                        new SqlParameter("@ContratoCoberturaPaqueteId", oParametro.ContratoCoberturaPaqueteId),
                        new SqlParameter("@ContratoCoberturaId",        oParametro.ContratoCoberturaId),
                        new SqlParameter("@PaqueteId",                  oParametro.PaqueteId),
                        new SqlParameter("@ContratoId",                 oParametro.ContratoId),
                        new SqlParameter("@EstatusId",                  oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.ContratoCoberturaPaquete oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoCoberturaPaquete_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",              Opcion),
                        new SqlParameter("@ContratoCoberturaId", oBE.ContratoCoberturaId),
                        new SqlParameter("@PaqueteId",           oBE.PaqueteId),
                        new SqlParameter("@UsuarioCreacionId",   oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.ContratoCoberturaPaquete oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoCoberturaPaquete_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                     Opcion),
                        new SqlParameter("@ContratoCoberturaPaqueteId", oBE.ContratoCoberturaPaqueteId),
                        new SqlParameter("@ContratoCoberturaId",        oBE.ContratoCoberturaId),
                        new SqlParameter("@PaqueteId",                  oBE.PaqueteId),
                        new SqlParameter("@UsuarioModificacionId",      oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",          oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",              oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                  oBE.FechaBaja),
                        new SqlParameter("@EstatusId",                  oBE.EstatusId),
                        new SqlParameter("@ContratoId",                 -1),
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