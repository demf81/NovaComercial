using System;
using System.Data;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class ed_estados : Conexion.ConexionODBC
    {
        public ed_estados()
        {
            NombreConexion = "cxnVigencia";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.ed_estados oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                string texto = Resource.sped_estados_Consultar_PorNombre;

                oComando.CommandText    = texto;
                oComando.CommandType    = CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.ed_nombre;

                if (this.Conectar())
                {
                    OdbcDataAdapter daResultado = new OdbcDataAdapter(oComando);
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