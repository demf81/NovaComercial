using System;
using System.Data;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
   public class mvst_movigsercct : Conexion.ConexionODBC
    {
        public mvst_movigsercct()
        {
            NombreConexion = "cxnVigencia";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.mvst_movigsercct oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = "PUB.spmvst_movigsercct_Consultar";
                oComando.CommandType    = CommandType.StoredProcedure;
                oComando.CommandTimeout = 10000;

            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.MensajeError = ex.Message;
            }

            return oEntidadResponse;
        }


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.VigenciaII.PUB.mvst_movigsercct oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                string texto = Resource.spmvst_movigsercct_Insertar;

                oComando.CommandText    = texto;
                oComando.CommandType    = CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.mvst_contrat_id;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.mvst_contrato_id;
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.mvst_fec_mov.Value.Month.ToString() + "/" + oBE.mvst_fec_mov.Value.Day.ToString() + "/" + oBE.mvst_fec_mov.Value.Year.ToString());
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.mvst_hora_mov;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.mvst_mot_post;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.mvst_motivo_id;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.mvst_orig_vigen;
                oComando.Parameters.Add("?", OdbcType.Int, 2).Value = oBE.mvst_servicio_id;
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.mvst_socio_id;
                oComando.Parameters.Add("?", OdbcType.Char, 12).Value = oBE.mvst_usuario;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.mvst_vigencia;

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