using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class EmpresaDocumentoTipo : Conexion.ConexionSQL
    {
        public EmpresaDocumentoTipo()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoTipoPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spEmpresaDocumentoTipo_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                          oParametro.Opcion),
                        new SqlParameter("@EmpresaDocumentoTipoId",          oParametro.EmpresaDocumentoTipoId),
                        new SqlParameter("@EmpresaDocumentoTipoDescripcion", oParametro.EmpresaDocumentoTipoDescripcion),
                        new SqlParameter("@EstatusId",                       oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.EmpresaDocumentoTipo oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spEmpresaDocumentoTipo_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                          Opcion),
                        new SqlParameter("@EmpresaDocumentoTipoDescripcion", oBE.EmpresaDocumentoTipoDescripcion),
                        new SqlParameter("@UsuarioCreacionId",               oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.EmpresaDocumentoTipo oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spEmpresaDocumentoTipo_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                          Opcion),
                        new SqlParameter("@EmpresaDocumentoTipoId",          oBE.EmpresaDocumentoTipoId),
                        new SqlParameter("@EmpresaDocumentoTipoDescripcion", oBE.EmpresaDocumentoTipoDescripcion),
                        new SqlParameter("@UsuarioModificacionId",           oBE.UsuarioModificacionId),
                        new SqlParameter("@UsuarioBajaId",                   oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                       oBE.FechaBaja),
                        new SqlParameter("@EstatusId",                       oBE.EstatusId)
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