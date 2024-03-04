using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class Empresa : Conexion.ConexionSQL
    {
        public Empresa()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.EmpresaPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spEmpresa_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",             oParametro.Opcion),
                        new SqlParameter("@EmpresaId",          oParametro.EmpresaId),
                        new SqlParameter("@EmpresaDescripcion", oParametro.EmpresaDescripcion),
                        new SqlParameter("@EstatusId",          oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.Empresa oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spEmpresa_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",             Opcion),
                        new SqlParameter("@EmpresaDescripcion", oBE.EmpresaDescripcion),
                        new SqlParameter("@Codigo",             oBE.Codigo),
                        new SqlParameter("@EmpresaTipoId",      oBE.EmpresaTipoId),
                        new SqlParameter("@MetodoPagoId",       oBE.MetodoPagoId),
                        new SqlParameter("@FormaPagoId",        oBE.FormaPagoId),
                        new SqlParameter("@FrecuenciaPagoId",   oBE.FrecuenciaPagoId),
                        new SqlParameter("@DiaPago",            oBE.DiaPago),
                        new SqlParameter("@EmpresaVigenciaId",  oBE.EmpresaVigenciaId),
                        new SqlParameter("@InicioOperaciones",  oBE.InicioOperaciones),
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.Empresa oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spEmpresa_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@EmpresaId",             oBE.EmpresaId),
                        new SqlParameter("@EmpresaDescripcion",    oBE.EmpresaDescripcion),
                        new SqlParameter("@Codigo",                oBE.Codigo),
                        new SqlParameter("@EmpresaTipoId",         oBE.EmpresaTipoId),
                        new SqlParameter("@MetodoPagoId",          oBE.MetodoPagoId),
                        new SqlParameter("@FormaPagoId",           oBE.FormaPagoId),
                        new SqlParameter("@FrecuenciaPagoId",      oBE.FrecuenciaPagoId),
                        new SqlParameter("@DiaPago",               oBE.DiaPago),
                        new SqlParameter("@InicioOperaciones",     oBE.InicioOperaciones),
                        new SqlParameter("@EmpresaVigenciaId",     oBE.EmpresaVigenciaId),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",     oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",             oBE.FechaBaja),
                        new SqlParameter("@EstatusId",             oBE.EstatusId)
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