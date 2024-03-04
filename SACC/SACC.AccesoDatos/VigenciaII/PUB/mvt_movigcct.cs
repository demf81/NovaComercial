using System;
using System.Data;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class mvt_movigcct : Conexion.ConexionODBC
    {
        public mvt_movigcct()
        {
            NombreConexion = "cxnVigencia";
        }


        //public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.mvt_movigcct oBE)
        //{
        //    Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

        //    try
        //    {
        //        DataSet dsResultado = new DataSet();
        //        oComando.CommandText = "PUB.spmvt_movigcct_Consultar";
        //        oComando.CommandType = System.Data.CommandType.StoredProcedure;

        //        //oComando.Parameters.Clear();
        //        //oParametro = new System.Data.SqlClient.SqlParameter("@Opcion", System.Data.SqlDbType.SmallInt);
        //        //oParametro.Value = Opcion;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_contrato_id", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_contrato_id;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_contrat_id", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_contrat_id;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_fec_mov", System.Data.SqlDbType.Date);
        //        //oParametro.Value = oBE.mvt_fec_mov;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_hora_mov", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_hora_mov;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_motivo_id", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_motivo_id;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_mot_post", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_mot_post;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_orig_vigen", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_orig_vigen;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_socio_id", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_socio_id;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_usuario", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_usuario;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_vigencia", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_vigencia;
        //        //oComando.Parameters.Add(oParametro);

        //        //if (this.Conectar())
        //        //{
        //        //    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
        //        //    daResultado.Fill(oEntidadResponse.dsResultado);
        //        //    Desconectar();
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        oEntidadResponse.Error = true;
        //        oEntidadResponse.MensajeError = ex.Message;
        //        //BusinessUtils.Logger.WriteLogFile(ex.Message);
        //    }

        //    return oEntidadResponse;
        //}

        
        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.VigenciaII.PUB.mvt_movigcct oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                string texto = Resource.spmvt_movigcct_Insertar;

                oComando.CommandText    = texto;
                oComando.CommandType    = CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.mvt_contrat_id;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.mvt_contrato_id;
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.mvt_fec_mov.Value.Month.ToString() + "/" + oBE.mvt_fec_mov.Value.Day.ToString() + "/" + oBE.mvt_fec_mov.Value.Year);
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.mvt_hora_mov;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.mvt_mot_post;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.mvt_motivo_id;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.mvt_orig_vigen;
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.mvt_socio_id;
                oComando.Parameters.Add("?", OdbcType.Char, 12).Value = oBE.mvt_usuario;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.mvt_vigencia;
                
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


        //public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.VigenciaII.PUB.mvt_movigcct oBE)
        //{
        //    Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

        //    try
        //    {
        //        DataSet dsResultado = new DataSet();
        //        oComando.CommandText = "PUB.spmvt_movigcct_Actualizar";
        //        oComando.CommandType = System.Data.CommandType.StoredProcedure;

        //        //oComando.Parameters.Clear();
        //        //oParametro = new System.Data.SqlClient.SqlParameter("@Opcion", System.Data.SqlDbType.SmallInt);
        //        //oParametro.Value = Opcion;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_contrato_id", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_contrato_id;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_contrat_id", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_contrat_id;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_fec_mov", System.Data.SqlDbType.Date);
        //        //oParametro.Value = oBE.mvt_fec_mov;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_hora_mov", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_hora_mov;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_motivo_id", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_motivo_id;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_mot_post", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_mot_post;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_orig_vigen", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_orig_vigen;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_socio_id", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_socio_id;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_usuario", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_usuario;
        //        //oComando.Parameters.Add(oParametro);

        //        //oParametro = new System.Data.SqlClient.SqlParameter("@mvt_vigencia", System.Data.SqlDbType.VarChar);
        //        //oParametro.Value = oBE.mvt_vigencia;
        //        //oComando.Parameters.Add(oParametro);

        //        //if (this.Conectar())
        //        //{
        //        //    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
        //        //    daResultado.Fill(oEntidadResponse.dsResultado);
        //        //    Desconectar();
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        oEntidadResponse.Error = true;
        //        oEntidadResponse.MensajeError = ex.Message;
        //        //BusinessUtils.Logger.WriteLogFile(ex.Message);
        //    }

        //    return oEntidadResponse;
        //}
    }
}