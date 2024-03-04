using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.PortalEmpresa
{
    public class Usuario : Conexion.ConexionSQL
    {
        public Usuario()
        {
            NombreConexion = "cxnSACC";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.NovaComercial.PortalEmpresa.Usuario oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "PortalEmpresa.spUsuario_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",             Opcion),
                        new SqlParameter("@UsuarioId",          oBE.UsuarioId),
                        new SqlParameter("@Nombre",             oBE.Nombre),
                        new SqlParameter("@Paterno",            oBE.Paterno),
                        new SqlParameter("@Materno",            oBE.Materno),
                        new SqlParameter("@Telefono",           oBE.Telefono),
                        new SqlParameter("@Correo",             oBE.Correo),
                        new SqlParameter("@Contrasenia",        oBE.Contrasenia),
                        new SqlParameter("@FechaVigenciaDesde", oBE.FechaVigenciaDesde),
                        new SqlParameter("@FechaVigenciaHasta", oBE.FechaVigenciaHasta),
                        new SqlParameter("@Baja",               oBE.Baja)
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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.NovaComercial.PortalEmpresa.Usuario oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "PortalEmpresa.spUsuario_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",             Opcion),
                        new SqlParameter("@Nombre",             oBE.Nombre),
                        new SqlParameter("@Paterno",            oBE.Paterno),
                        new SqlParameter("@Materno",            oBE.Materno),
                        new SqlParameter("@Telefono",           oBE.Telefono),
                        new SqlParameter("@Correo",             oBE.Correo),
                        new SqlParameter("@Contrasenia",        oBE.Contrasenia),
                        new SqlParameter("@FechaVigenciaDesde", oBE.FechaVigenciaDesde),
                        new SqlParameter("@FechaVigenciaHasta", oBE.FechaVigenciaHasta),
                        new SqlParameter("@UsuarioCreacionId",  oBE.UsuarioCreacionId),
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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.NovaComercial.PortalEmpresa.Usuario oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "PortalEmpresa.spUsuario_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@UsuarioId",             oBE.UsuarioId),
                        new SqlParameter("@Nombre",                oBE.Nombre),
                        new SqlParameter("@Paterno",               oBE.Paterno),
                        new SqlParameter("@Materno",               oBE.Materno),
                        new SqlParameter("@Telefono",              oBE.Telefono),
                        new SqlParameter("@Correo",                oBE.Correo),
                        new SqlParameter("@Contrasenia",           oBE.Contrasenia),
                        new SqlParameter("@FechaVigenciaDesde",    oBE.FechaVigenciaDesde),
                        new SqlParameter("@FechaVigenciaHasta",    oBE.FechaVigenciaHasta),
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