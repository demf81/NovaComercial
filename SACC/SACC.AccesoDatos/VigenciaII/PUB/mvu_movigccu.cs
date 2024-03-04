using System;
using System.Data;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class mvu_movigccu : Conexion.ConexionODBC
    {
        public mvu_movigccu()
        {
            NombreConexion = "cxnVigencia";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.mvu_movigccu oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = "PUB.spmvu_movigccu_Consultar";
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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.VigenciaII.PUB.mvu_movigccu oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = Resource.spmvu_movigccu_Insertar;
                oComando.CommandType    = CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.mvu_contrat_id;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.mvu_contrato_id;
                oComando.Parameters.Add("?", OdbcType.Int, 2).Value = oBE.mvu_cvefam;
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.mvu_fec_mov.Value.Month.ToString() + "/" + oBE.mvu_fec_mov.Value.Day.ToString() + "/" + oBE.mvu_fec_mov.Value.Year.ToString());
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.mvu_hora_mov;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.mvu_mot_post;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.mvu_motivo_id;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.mvu_orig_vigen;
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.mvu_socio_id;
                oComando.Parameters.Add("?", OdbcType.Char, 12).Value = oBE.mvu_usuario;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.mvu_vigencia;
                
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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.VigenciaII.PUB.mvu_movigccu oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = "PUB.spmvu_movigccu_Actualizar";
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
    }
}