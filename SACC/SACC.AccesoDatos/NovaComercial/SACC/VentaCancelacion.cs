using System;
using System.Data;
using System.Data.SqlClient;

namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class VentaCancelacion : Conexion.ConexionSQL
    {
        public VentaCancelacion()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.VentaCancelacion oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spVentaCancelacion_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                       Opcion),
                        new SqlParameter("@VentaId",                      oBE.VentaId),
                        new SqlParameter("@VentaMotivoCancelacionTipoId", oBE.VentaMotivoCancelacionTipoId),
                        new SqlParameter("@Comentario",                   oBE.Comentario),
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
    }
}