using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class ServicioAdministrativo : Conexion.ConexionSQL
    {
        public ServicioAdministrativo()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.ServicioAdministrativoPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spServicioAdministrativo_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                            oParametro.Opcion),
                        new SqlParameter("@ServicioAdministrativoId",          oParametro.ServicioAdministrativoId),
                        new SqlParameter("@ServicioAdministrativoDescripcion", oParametro.ServicioAdministrativoDescripcion),
                        new SqlParameter("@EstatusId",                         oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.ServicioAdministrativo oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spServicioAdministrativo_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                            Opcion),
                        new SqlParameter("@ServicioAdministrativoDescripcion", oBE.ServicioAdministrativoDescripcion),
                        new SqlParameter("@Codigo",                            oBE.Codigo),
                        new SqlParameter("@Costo",                             oBE.Costo),
                        new SqlParameter("@UsuarioCreacionId",                 oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.ServicioAdministrativo oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spServicioAdministrativo_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                            Opcion),
                        new SqlParameter("@ServicioAdministrativoId",          oBE.ServicioAdministrativoId),
                        new SqlParameter("@ServicioAdministrativoDescripcion", oBE.ServicioAdministrativoDescripcion),
                        new SqlParameter("@Codigo",                            oBE.Codigo),
                        new SqlParameter("@Costo",                             oBE.Costo),
                        new SqlParameter("@UsuarioModificacionId",             oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",                 oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",                     oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                         oBE.FechaBaja),
                        new SqlParameter("@EstatusId",                         oBE.EstatusId)
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
