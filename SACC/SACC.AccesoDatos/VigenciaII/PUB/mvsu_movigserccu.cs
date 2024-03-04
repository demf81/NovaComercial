using System;
using System.Data;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class mvsu_movigserccu : Conexion.ConexionODBC
    {
        public mvsu_movigserccu()
        {
            NombreConexion = "cxnVigencia";
        }


        //public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.mvsu_movigserccu oBE)
        //{
        //    Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

        //    try
        //    {
        //        DataSet dsResultado = new DataSet();
        //        oComando.CommandText = "PUB.spmvsu_movigserccu_Consultar";
        //        oComando.CommandType = System.Data.CommandType.StoredProcedure;


        //    }
        //    catch (Exception ex)
        //    {
        //        oEntidadResponse.Error = true;
        //        oEntidadResponse.MensajeError = ex.Message;
        //        //BusinessUtils.Logger.WriteLogFile(ex.Message);
        //    }

        //    return oEntidadResponse;
        //}

        
        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.VigenciaII.PUB.mvsu_movigserccu oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = Resource.spmvsu_movigserccu_Insertar;
                oComando.CommandType    = CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.mvsu_contrat_id;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.mvsu_contrato_id;
                oComando.Parameters.Add("?", OdbcType.Int, 2).Value = oBE.mvsu_cvefam;
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.mvsu_fec_mov.Value.Month.ToString() + "/" + oBE.mvsu_fec_mov.Value.Day.ToString() + "/" + oBE.mvsu_fec_mov.Value.Year.ToString());
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.mvsu_hora_mov;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.mvsu_mot_post;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.mvsu_motivo_id;
                oComando.Parameters.Add("?", OdbcType.Char, 12).Value = oBE.mvsu_orig_vigen;
                oComando.Parameters.Add("?", OdbcType.Int, 2).Value = oBE.mvsu_servicio_id;
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.mvsu_socio_id;
                oComando.Parameters.Add("?", OdbcType.Char, 12).Value = oBE.mvsu_usuario;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.mvsu_vigencia;

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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.VigenciaII.PUB.mvsu_movigserccu oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = "PUB.spmvsu_movigserccu_Actualizar";
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