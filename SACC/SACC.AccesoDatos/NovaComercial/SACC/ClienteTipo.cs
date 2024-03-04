using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class ClienteTipo : Conexion.ConexionSQL
    {
        public ClienteTipo()
        {
            NombreConexion = "cxnSACC";
        }

        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.ClienteTipoPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spClienteTipo_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                 oParametro.Opcion),
                        new SqlParameter("@ClienteTipoId",          oParametro.ClienteTipoId),
                        new SqlParameter("@ClienteTipoDescripcion", oParametro.ClienteTipoDescripcion),
                        new SqlParameter("@EstatusId",              oParametro.EstatusId)
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
    }
}