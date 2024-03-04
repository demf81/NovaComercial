using System;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class us_usuarios : Conexion.ConexionODBC
    {
        public Entidades.EntidadResponse Consultar(short Opcion, SACC.Entidades.VigenciaII.PUB.us_usuarios oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            string texto = string.Empty;

            oComando.CommandTimeout = 10000;

            try
            {

                switch (Opcion)
                {
                    case 1:
                        texto = Resource.spus_usuarios_ConsultaPorCURP;

                        oComando.CommandText = texto;
                        oComando.CommandType = System.Data.CommandType.Text;
                        oComando.Parameters.Add("?", OdbcType.Char, 36).Value = oBE.us_curp;

                        break;
                    case 2:
                        texto = Resource.spus_usuarios_ConsultaPorId;

                        oComando.CommandText = texto;
                        oComando.CommandType = System.Data.CommandType.Text;
                        oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.us_socio_id;
                        oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.us_cvefam;

                        break;
                    default:
                        break;
                }

                if (Conectar())
                {
                    OdbcDataAdapter daResultado = new OdbcDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }
    }
}