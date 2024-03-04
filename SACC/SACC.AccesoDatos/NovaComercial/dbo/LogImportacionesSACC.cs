using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class LogImportacionesSACC : Conexion.ConexionSQL
    {
        public LogImportacionesSACC()
        {
            NombreConexion = "cxnSACC";
        }


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.LogImportacionesSACC oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spLogImportacionesSACC_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@Proceso",               oBE.Proceso),
                        new SqlParameter("@Inicio",                oBE.Inicio),
                        new SqlParameter("@Fin",                   oBE.Fin),
                        new SqlParameter("@ErrorEstatus",          oBE.ErrorEstatus),
                        new SqlParameter("@Mensaje",               oBE.Mensaje),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId)
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