using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class Asociado : Conexion.ConexionSQL
    {
        public Asociado()
        {
            NombreConexion = "cxnSACC";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.NovaComercial.dbo.Asociado oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spAsociado_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                  Opcion),
                        new SqlParameter("@AsociadoId",              oBE.AsociadoId),
                        new SqlParameter("@AsociadoTipoId",          oBE.AsociadoTipoId),
                        new SqlParameter("@CodigoVigencia",          oBE.CodigoVigencia),
                        new SqlParameter("@Curp",                    oBE.Curp),
                        new SqlParameter("@Nombre",                  oBE.Nombre),
                        new SqlParameter("@ApellidoPaterno",         oBE.ApellidoPaterno),
                        new SqlParameter("@ApellidoMaterno",         oBE.ApellidoMaterno),
                        new SqlParameter("@Telefono",                oBE.Telefono),
                        new SqlParameter("@Telefono2",               oBE.Telefono2),
                        new SqlParameter("@Poliza",                  oBE.Poliza),
                        new SqlParameter("@NoPoliza",                oBE.NoPoliza),
                        new SqlParameter("@SexoId",                  oBE.SexoId),
                        new SqlParameter("@EstadoCivilId",           oBE.EstadoCivilId),
                        new SqlParameter("@FechaNacimiento",         oBE.FechaNacimiento),
                        new SqlParameter("@Confidencial",            oBE.Confidencial),
                        new SqlParameter("@RequiereEmpresa",         oBE.RequiereEmpresa),
                        new SqlParameter("@ReqExpedienteFisico",     oBE.ReqExpedienteFisico),
                        new SqlParameter("@AsociadoClasificacionId", oBE.AsociadoClasificacionId),
                        new SqlParameter("@Contratante",             oBE.Contratante),
                        new SqlParameter("@InstitucionId",           oBE.InstitucionId),
                        new SqlParameter("@NacionalidadId",          oBE.NacionalidadId),
                        new SqlParameter("@TitularId",               oBE.TitularId),
                        new SqlParameter("@TitularPersona",          oBE.TitularPersona),
                        new SqlParameter("@ClaveFamiliar",           oBE.ClaveFamiliar),
                        new SqlParameter("@ServicioSuspendido",      oBE.ServicioSuspendido),
                        new SqlParameter("@CorreoElectronico",       oBE.CorreoElectronico),
                        new SqlParameter("@TelefonoMovil",           oBE.TelefonoMovil),
                        new SqlParameter("@CurpTemporal",            oBE.CurpTemporal),
                        new SqlParameter("@Baja",                    oBE.Baja)
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


        public Modelo.ModeloResponse ConsultarGrid(Modelo.Parametro.NovaComercial.dbo.AsociadoPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spAsociado_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",   oParametro.Opcion),
                        new SqlParameter("@Curp",     oParametro.Curp),
                        new SqlParameter("@Nombre",   oParametro.Nombre),
                        new SqlParameter("@NumSocio", oParametro.NumSocio)
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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.Asociado oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spAsociado_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                  Opcion),
                        new SqlParameter("@AsociadoTipoId",          oBE.AsociadoTipoId),
                        new SqlParameter("@CodigoVigencia",          oBE.CodigoVigencia),
                        new SqlParameter("@Curp",                    oBE.Curp),
                        new SqlParameter("@Nombre",                  oBE.Nombre),
                        new SqlParameter("@ApellidoPaterno",         oBE.ApellidoPaterno),
                        new SqlParameter("@ApellidoMaterno",         oBE.ApellidoMaterno),
                        new SqlParameter("@Telefono",                oBE.Telefono),
                        new SqlParameter("@Telefono2",               oBE.Telefono2),
                        new SqlParameter("@Poliza",                  oBE.Poliza),
                        new SqlParameter("@NoPoliza",                oBE.NoPoliza),
                        new SqlParameter("@SexoId",                  oBE.SexoId),
                        new SqlParameter("@EstadoCivilId",           oBE.EstadoCivilId),
                        new SqlParameter("@FechaNacimiento",         oBE.FechaNacimiento),
                        new SqlParameter("@Confidencial",            oBE.Confidencial),
                        new SqlParameter("@RequiereEmpresa",         oBE.RequiereEmpresa),
                        new SqlParameter("@ReqExpedienteFisico",     oBE.ReqExpedienteFisico),
                        new SqlParameter("@AsociadoClasificacionId", oBE.AsociadoClasificacionId),
                        new SqlParameter("@Contratante",             oBE.Contratante),
                        new SqlParameter("@InstitucionId",           oBE.InstitucionId),
                        new SqlParameter("@NacionalidadId",          oBE.NacionalidadId),
                        new SqlParameter("@Baja",                    oBE.Baja),
                        new SqlParameter("@TitularId",               oBE.TitularId),
                        new SqlParameter("@TitularPersona",          oBE.TitularPersona),
                        new SqlParameter("@ClaveFamiliar",           oBE.ClaveFamiliar),
                        new SqlParameter("@ServicioSuspendido",      oBE.ServicioSuspendido),
                        new SqlParameter("@CorreoElectronico",       oBE.CorreoElectronico),
                        new SqlParameter("@TelefonoMovil",           oBE.TelefonoMovil),
                        new SqlParameter("@CurpTemporal",            oBE.CurpTemporal),
                        new SqlParameter("@UsuarioCreacionId",       oBE.UsuarioCreacionId)
                    }
                );

                if (this.Conectar())
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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.Asociado oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spAsociado_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                  Opcion),
                        new SqlParameter("@AsociadoId",              oBE.AsociadoId),
                        new SqlParameter("@AsociadoTipoId",          oBE.AsociadoTipoId),
                        new SqlParameter("@CodigoVigencia",          oBE.CodigoVigencia),
                        new SqlParameter("@Curp",                    oBE.Curp),
                        new SqlParameter("@Nombre",                  oBE.Nombre),
                        new SqlParameter("@ApellidoPaterno",         oBE.ApellidoPaterno),
                        new SqlParameter("@ApellidoMaterno",         oBE.ApellidoMaterno),
                        new SqlParameter("@Telefono",                oBE.Telefono),
                        new SqlParameter("@Telefono2",               oBE.Telefono2),
                        new SqlParameter("@Poliza",                  oBE.Poliza),
                        new SqlParameter("@NoPoliza",                oBE.NoPoliza),
                        new SqlParameter("@SexoId",                  oBE.SexoId),
                        new SqlParameter("@EstadoCivilId",           oBE.EstadoCivilId),
                        new SqlParameter("@FechaNacimiento",         oBE.FechaNacimiento),
                        new SqlParameter("@Confidencial",            oBE.Confidencial),
                        new SqlParameter("@RequiereEmpresa",         oBE.RequiereEmpresa),
                        new SqlParameter("@ReqExpedienteFisico",     oBE.ReqExpedienteFisico),
                        new SqlParameter("@AsociadoClasificacionId", oBE.AsociadoClasificacionId),
                        new SqlParameter("@Contratante",             oBE.Contratante),
                        new SqlParameter("@InstitucionId",           oBE.InstitucionId),
                        new SqlParameter("@NacionalidadId",          oBE.NacionalidadId),
                        new SqlParameter("@TitularId",               oBE.TitularId),
                        new SqlParameter("@TitularPersona",          oBE.TitularPersona),
                        new SqlParameter("@ClaveFamiliar",           oBE.ClaveFamiliar),
                        new SqlParameter("@ServicioSuspendido",      oBE.ServicioSuspendido),
                        new SqlParameter("@CorreoElectronico",       oBE.CorreoElectronico),
                        new SqlParameter("@TelefonoMovil",           oBE.TelefonoMovil),
                        new SqlParameter("@CurpTemporal",            oBE.CurpTemporal),
                        new SqlParameter("@UsuarioModificacionId",   oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",       oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",           oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",               oBE.FechaBaja),
                        new SqlParameter("@Baja",                    oBE.Baja)
                    }
                );

                if (this.Conectar())
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


        public void EjecutaNonQuery(string StrQuery)
        {
            try
            {
                oComando.CommandText = StrQuery;
                oComando.CommandType = CommandType.Text;

                if (this.Conectar())
                {
                    oComando.CommandTimeout = 100000;
                    oComando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Desconectar();
            }
        }
    }
}