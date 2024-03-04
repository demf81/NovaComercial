using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class EmpresaPlanta : Conexion.ConexionSQL
    {
        public EmpresaPlanta()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.EmpresaPlantaPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spEmpresaPlanta_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                   oParametro.Opcion),
                        new SqlParameter("@EmpresaPlantaId",          oParametro.EmpresaPlantaId),
                        new SqlParameter("@EmpresaPlantaDescripcion", oParametro.EmpresaPlantaDescripcion),
                        new SqlParameter("@EmpresaId",                oParametro.EmpresaId),
                        new SqlParameter("@EstatusId",                oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.EmpresaPlanta oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spEmpresaPlanta_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                   Opcion),
                        new SqlParameter("@EmpresaPlantaDescripcion", oBE.EmpresaPlantaDescripcion),
                        new SqlParameter("@EmpresaId",                oBE.EmpresaId),
                        new SqlParameter("@CodigoVigencia",           oBE.CodigoVigencia),
                        new SqlParameter("@Real",                     oBE.Real),
                        new SqlParameter("@CodigoAlternoNexus",       oBE.CodigoAlternoNexus),
                        new SqlParameter("@EmpresaNexusId",           oBE.EmpresaNexusId),
                        new SqlParameter("@UsuarioCreacionId",        oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.EmpresaPlanta oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spEmpresaPlanta_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                   Opcion),
                        new SqlParameter("@EmpresaPlantaId",          oBE.EmpresaPlantaId),
                        new SqlParameter("@EmpresaPlantaDescripcion", oBE.EmpresaPlantaDescripcion),
                        new SqlParameter("@EmpresaId",                oBE.EmpresaId),
                        new SqlParameter("@CodigoVigencia",           oBE.CodigoVigencia),
                        new SqlParameter("@Real",                     oBE.Real),
                        new SqlParameter("@CodigoAlternoNexus",       oBE.CodigoAlternoNexus),
                        new SqlParameter("@EmpresaNexusId",           oBE.EmpresaNexusId),
                        new SqlParameter("@UsuarioModificacionId",    oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",        oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",            oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                oBE.FechaBaja),
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