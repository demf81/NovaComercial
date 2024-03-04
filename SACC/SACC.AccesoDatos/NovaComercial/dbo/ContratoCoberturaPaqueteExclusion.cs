using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class ContratoCoberturaPaqueteExclusion : Conexion.ConexionSQL
    {
        public ContratoCoberturaPaqueteExclusion()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteExclusionPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoCoberturaPaqueteExclusion_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                              oParametro.Opcion),
                        new SqlParameter("@ContratoCoberturaPaqueteExclusionId", oParametro.ContratoCoberturaPaqueteExclusionId),
                        new SqlParameter("@ContratoCoberturaPaqueteId",          oParametro.ContratoCoberturaPaqueteId),
                        new SqlParameter("@PaqueteId",                           oParametro.PaqueteId),
                        new SqlParameter("@ItemDescripcion",                     oParametro.ItemDescripcion),
                        new SqlParameter("@Excluido",                            oParametro.Excluido),
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoCoberturaPaqueteExclusion_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                     Opcion),
                        new SqlParameter("@ContratoCoberturaPaqueteId", oBE.ContratoCoberturaPaqueteId),
                        //new SqlParameter("@ContratoCoberturaId",        oBE.ContratoCoberturaId),
                        //new SqlParameter("@ContratoId",                 oBE.ContratoId),
                        new SqlParameter("@PaqueteId",                  oBE.PaqueteId),
                        new SqlParameter("@PaqueteDetalleId",           oBE.PaqueteDetalleId),
                        new SqlParameter("@ItemTipoId",                 oBE.ItemTipoId),
                        new SqlParameter("@ItemId",                     oBE.ItemId),
                        new SqlParameter("@ServicioId",                 oBE.ServicioId),
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoCoberturaPaqueteExclusion_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                              Opcion),
                        new SqlParameter("@ContratoCoberturaPaqueteExclusionId", oBE.ContratoCoberturaPaqueteExclusionId),
                        new SqlParameter("@UsuarioBajaId",                       oBE.UsuarioBajaId),
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