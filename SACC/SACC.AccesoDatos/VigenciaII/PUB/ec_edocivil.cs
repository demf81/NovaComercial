using System;
using System.Data;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class ec_edocivil : Conexion.ConexionODBC
    {
        public ec_edocivil()
        {
            NombreConexion = "cxnVigencia";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.ec_edocivil oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = Resource.spec_edocivil_Consultar_PorId;
                oComando.CommandType    = CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.ec_edocivil_id;

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