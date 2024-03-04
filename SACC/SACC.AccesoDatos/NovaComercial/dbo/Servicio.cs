using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class Servicio : Conexion.ConexionSQL
    {
        public Servicio()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.ServicioPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spServicio_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",              oParametro.Opcion),
                        new SqlParameter("@ServicioId",          oParametro.ServicioId),
                        new SqlParameter("@ServicioDescripcion", oParametro.ServicioDescripcion),
                        new SqlParameter("@ServicioTipoId",      oParametro.ServicioTipoId),
                        //new SqlParameter("@Baja",                oParametro.Baja)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.Servicio oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spServicio_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",              Opcion),
                        new SqlParameter("@ServicioDescripcion", oBE.ServicioDescripcion),
                        new SqlParameter("@ServicioTipoId",      oBE.ServicioTipoId),
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
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.Servicio oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spServicio_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@ServicioId",            oBE.ServicioId),
                        new SqlParameter("@ServicioDescripcion",   oBE.ServicioDescripcion),
                        new SqlParameter("@ServicioTipoId",        oBE.ServicioTipoId),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",     oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",             oBE.FechaBaja),
                        new SqlParameter("@Baja",                  oBE.Baja),
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
