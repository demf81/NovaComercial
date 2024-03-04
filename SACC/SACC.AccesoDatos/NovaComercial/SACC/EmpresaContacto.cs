using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class EmpresaContacto : Conexion.ConexionSQL
    {
        public EmpresaContacto()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.EmpresaContactoPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spEmpresaContacto_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",            oParametro.Opcion),
                        new SqlParameter("@EmpresaContactoId", oParametro.EmpresaContactoId),
                        new SqlParameter("@EmpresaId",         oParametro.EmpresaId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.EmpresaContacto oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spEmpresaContacto_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                  Opcion),
                        new SqlParameter("@EmpresaId",               oBE.EmpresaId),
                        new SqlParameter("@Nombre",                  oBE.Nombre),
                        new SqlParameter("@Paterno",                 oBE.Paterno),
                        new SqlParameter("@Materno",                 oBE.Materno),
                        new SqlParameter("@DepartamentoDescripcion", oBE.DepartamentoDescripcion),
                        new SqlParameter("@ContactoTipoId",          oBE.ContactoTipoId),
                        new SqlParameter("@Telefono",                oBE.Telefono),
                        new SqlParameter("@Extension",               oBE.Extension),
                        new SqlParameter("@CorreoElectronico",       oBE.CorreoElectronico),
                        new SqlParameter("@UsuarioCreacionId",       oBE.UsuarioCreacionId)
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

        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.EmpresaContacto oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spEmpresaContacto_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                  Opcion),
                        new SqlParameter("@EmpresaId",               oBE.EmpresaId),
                        new SqlParameter("@EmpresaContactoId",       oBE.EmpresaContactoId),
                        new SqlParameter("@ContactoTipoId",          oBE.ContactoTipoId),
                        new SqlParameter("@Nombre",                  oBE.Nombre),
                        new SqlParameter("@Paterno",                 oBE.Paterno),
                        new SqlParameter("@Materno",                 oBE.Materno),
                        new SqlParameter("@DepartamentoDescripcion", oBE.DepartamentoDescripcion),
                        new SqlParameter("@Telefono",                oBE.Telefono),
                        new SqlParameter("@Extension",               oBE.Extension),
                        new SqlParameter("@CorreoElectronico",       oBE.CorreoElectronico),
                        new SqlParameter("@UsuarioModificacionId",   oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",       oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",           oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",               oBE.FechaBaja),
                        new SqlParameter("@EstatusId",               oBE.EstatusId)
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