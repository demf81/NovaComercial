using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class Estudio : Conexion.ConexionSQL
    {
        public Estudio()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.EstudioPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spEstudio_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",             oParametro.Opcion),
                        new SqlParameter("@EstudioId",          oParametro.EstudioId),
                        new SqlParameter("@EstudioDescripcion", oParametro.EstudioDescripcion),
                        //new SqlParameter("@Baja",               oParametro.Baja)
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
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.Estudio oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spEstudio_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@EstudioDescripcion",    oBE.EstudioDescripcion),
                        new SqlParameter("@Codigo",                oBE.Codigo),
                        new SqlParameter("@Mnemonico",             oBE.Mnemonico),
                        new SqlParameter("@SeccionId",             oBE.SeccionId),
                        new SqlParameter("@RequiereConfirmacion",  oBE.RequiereConfirmacion),
                        new SqlParameter("@ServicioId",            oBE.ServicioId),
                        new SqlParameter("@UsuarioCreacionId",     oBE.UsuarioCreacionId),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId)
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
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.Estudio oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spEstudio_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@EstudioId",             oBE.EstudioId),
                        new SqlParameter("@EstudioDescripcion",    oBE.EstudioDescripcion),
                        new SqlParameter("@Codigo",                oBE.Codigo),
                        new SqlParameter("@Mnemonico",             oBE.Mnemonico),
                        new SqlParameter("@SeccionId",             oBE.SeccionId),
                        new SqlParameter("@RequiereConfirmacion",  oBE.RequiereConfirmacion),
                        new SqlParameter("@ServicioId",            oBE.ServicioId),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",     oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",             oBE.FechaBaja),
                        new SqlParameter("@Baja",                  oBE.Baja)
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