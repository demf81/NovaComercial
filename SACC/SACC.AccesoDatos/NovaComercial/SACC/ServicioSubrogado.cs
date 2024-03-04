using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class ServicioSubrogado : Conexion.ConexionSQL
    {
        public ServicioSubrogado()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spServicioSubrogado_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                       oParametro.Opcion),
                        new SqlParameter("@ServicioSubrogadoId",          oParametro.ServicioSubrogadoId),
                        new SqlParameter("@ServicioSubrogadoDescripcion", oParametro.ServicioSubrogadoDescripcion),
                        new SqlParameter("@ServicioSubrogadoTipoId",      oParametro.ServicioSubrogadoTipoId),
                        new SqlParameter("@EstatusId",                    oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.ServicioSubrogado oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spServicioSubrogado_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                       Opcion),
                        new SqlParameter("@ServicioSubrogadoDescripcion", oBE.ServicioSubrogadoDescripcion),
                        new SqlParameter("@Codigo",                       oBE.Codigo),
                        new SqlParameter("@Costo",                        oBE.Costo),
                        new SqlParameter("@UsuarioCreacionId",            oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.ServicioSubrogado oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spServicioSubrogado_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                       Opcion),
                        new SqlParameter("@ServicioSubrogadoId",          oBE.ServicioSubrogadoId),
                        new SqlParameter("@ServicioSubrogadoDescripcion", oBE.ServicioSubrogadoDescripcion),
                        new SqlParameter("@Codigo",                       oBE.Codigo),
                        new SqlParameter("@Costo",                        oBE.Costo),
                        new SqlParameter("@UsuarioModificacionId",        oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",            oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",                oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                    oBE.FechaBaja),
                        new SqlParameter("@EstatusId",                    oBE.EstatusId)
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