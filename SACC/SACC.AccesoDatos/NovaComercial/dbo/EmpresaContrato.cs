using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class EmpresaContrato : Conexion.ConexionSQL
    {
        public EmpresaContrato()
        {
            NombreConexion = "cxnSACC";
        }


        public  Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.EmpresaContratoPM oParametro)
        {
             Modelo.ModeloResponse oEntidadResponse = new  Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spEmpresaContrato_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",            oParametro.Opcion),
                        new SqlParameter("@EmpresaContratoId", oParametro.EmpresaContratoId),
                        new SqlParameter("@EmpresaId",         oParametro.EmpresaId),
                        new SqlParameter("@ContratoId",        oParametro.ContratoId),
                        new SqlParameter("@EstatusId",         oParametro.EstatusId)
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


        public  Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.EmpresaContrato oBE)
        {
             Modelo.ModeloResponse oEntidadResponse = new  Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spEmpresaContrato_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",            Opcion),
                        new SqlParameter("@EmpresaId",         oBE.EmpresaId),
                        new SqlParameter("@ContratoId",        oBE.ContratoId),
                        new SqlParameter("@UsuarioCreacionId", oBE.UsuarioCreacionId)
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


        public  Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.EmpresaContrato oBE)
        {
             Modelo.ModeloResponse oEntidadResponse = new  Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spEmpresaContrato_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@EmpresaContratoId",     oBE.EmpresaContratoId),
                        new SqlParameter("@EmpresaId",             oBE.EmpresaId),
                        new SqlParameter("@ContratoId",            oBE.ContratoId),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),
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