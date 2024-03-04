using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class ContratoProductoPaquete : Conexion.ConexionSQL
    {
        public ContratoProductoPaquete()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.ContratoProductoPaquetePM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoProductoPaquete_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                    oParametro.Opcion),
                        new SqlParameter("@ContratoProductoPaqueteId", oParametro.ContratoProductoPaqueteId),
                        new SqlParameter("@ContratoProductoId",        oParametro.ContratoProductoId),
                        new SqlParameter("@PaqueteId",                 oParametro.PaqueteId),
                        new SqlParameter("@EstatusId",                 oParametro.EstatusId),
                        new SqlParameter("@PersonaId",                 oParametro.PersonaId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.ContratoProductoPaquete oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoProductoPaquete_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",             Opcion),
                        new SqlParameter("@ContratoProductoId", oBE.ContratoProductoId),
                        new SqlParameter("@PaqueteId",          oBE.PaqueteId),
                        new SqlParameter("@UsuarioCreacionId",  oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.ContratoProductoPaquete oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spContratoProductoPaquete_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                    Opcion),
                        new SqlParameter("@ContratoProductoPaqueteId", oBE.ContratoProductoPaqueteId),
                        new SqlParameter("@ContratoProductoId",        oBE.ContratoProductoId),
                        new SqlParameter("@PaqueteId",                 oBE.PaqueteId),
                        new SqlParameter("@UsuarioModificacionId",     oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",         oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",             oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                 oBE.FechaBaja),
                        new SqlParameter("@EstatusId",                 oBE.EstatusId)
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