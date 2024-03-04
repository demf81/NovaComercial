using System;
using System.Data;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class co_contratos : Conexion.ConexionODBC
    {
        public co_contratos()
        {
            NombreConexion = "cxnVigencia";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.co_contratos oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = Resource.spco_contratos_Consultar_PorId;
                oComando.CommandType    = CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.co_empresa_id;
                oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.co_planta_id;

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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.VigenciaII.PUB.co_contratos oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = "PUB.spco_contratos_Insertar";
                oComando.CommandType    = CommandType.StoredProcedure;
                oComando.CommandTimeout = 10000;

                //oComando.Parameters.Clear();
                //oParametro = new System.Data.SqlClient.SqlParameter("@Opcion", System.Data.SqlDbType.SmallInt);
                //oParametro.Value = Opcion;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_campos_act", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_campos_act;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_cliente_sap", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_cliente_sap;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_contrato_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_contrato_id;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_contrat_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_contrat_id;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_desc", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_desc;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_empresa_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_empresa_id;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_fec_alta", System.Data.SqlDbType.Date);
                //oParametro.Value = oBE.co_fec_alta;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_fec_baja", System.Data.SqlDbType.Date);
                //oParametro.Value = oBE.co_fec_baja;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_fec_reactiva", System.Data.SqlDbType.Date);
                //oParametro.Value = oBE.co_fec_reactiva;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_hora_act", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_hora_act;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_orig_vigen", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_orig_vigen;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_paquete_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_paquete_id;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_planta_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_planta_id;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_tipocont", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_tipocont;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_tipo_enlace", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_tipo_enlace;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_ult_act", System.Data.SqlDbType.Date);
                //oParametro.Value = oBE.co_ult_act;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_usuario_act", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_usuario_act;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_vigencia", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_vigencia;
                //oComando.Parameters.Add(oParametro);

                //if (this.Conectar())
                //{
                //    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                //    daResultado.Fill(oEntidadResponse.dsResultado);
                //}
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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.VigenciaII.PUB.co_contratos oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = "PUB.spco_contratos_Actualizar";
                oComando.CommandType    = CommandType.StoredProcedure;
                oComando.CommandTimeout = 10000;

                //oComando.Parameters.Clear();
                //oParametro = new System.Data.SqlClient.SqlParameter("@Opcion", System.Data.SqlDbType.SmallInt);
                //oParametro.Value = Opcion;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_campos_act", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_campos_act;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_cliente_sap", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_cliente_sap;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_contrato_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_contrato_id;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_contrat_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_contrat_id;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_desc", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_desc;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_empresa_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_empresa_id;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_fec_alta", System.Data.SqlDbType.Date);
                //oParametro.Value = oBE.co_fec_alta;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_fec_baja", System.Data.SqlDbType.Date);
                //oParametro.Value = oBE.co_fec_baja;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_fec_reactiva", System.Data.SqlDbType.Date);
                //oParametro.Value = oBE.co_fec_reactiva;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_hora_act", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_hora_act;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_orig_vigen", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_orig_vigen;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_paquete_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_paquete_id;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_planta_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_planta_id;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_tipocont", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_tipocont;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_tipo_enlace", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_tipo_enlace;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_ult_act", System.Data.SqlDbType.Date);
                //oParametro.Value = oBE.co_ult_act;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_usuario_act", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_usuario_act;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@co_vigencia", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.co_vigencia;
                //oComando.Parameters.Add(oParametro);

                //if (this.Conectar())
                //{
                //    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                //    daResultado.Fill(oEntidadResponse.dsResultado);
                //}
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