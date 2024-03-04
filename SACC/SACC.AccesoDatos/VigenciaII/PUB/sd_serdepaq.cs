using System;
using System.Data;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class sd_serdepaq : Conexion.ConexionODBC
    {
        public sd_serdepaq()
        {
            NombreConexion = "cxnVigencia";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.sd_serdepaq oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                if (Opcion == 1)
                {
                    oComando.CommandText    = Resource.spsd_serdepaq_Consultar_PorId;
                    oComando.CommandType    = CommandType.Text;
                    oComando.CommandTimeout = 10000;

                    oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.sd_paquete_id;
                }

                if (Opcion == 2)
                {
                    if (oBE.procesotitular)
                    {
                        oComando.CommandText = Resource.spsd_serdepaq_Consultar_PorSocioId;
                        oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.socio_id.ToString();
                    }
                    else
                    {
                        oComando.CommandText = Resource.spsd_serdepaq_Consultar_PorSocioClaveFamId;
                        oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.socio_id.ToString();
                        oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.clavefamiliar.ToString();
                    }

                    oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.co_contrat_id;
                    oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.co_contrato_id;
                }

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


        //public Entidades.EntidadResponse Consultar(short Opcion, int Socio, int claveFamiliar, Entidades.VigenciaII.PUB.co_contratos contrato, bool procesoTitular = false)
        //{
        //    Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();
        //    string texto = string.Empty;
        //    oComando.CommandType = System.Data.CommandType.Text;
        //    try
        //    {
        //        if (procesoTitular)
        //        {
        //            oComando.CommandText = Properties.Resources.spsd_serdepaq_Consultar_PorSocioId;
        //            oComando.Parameters.Add("?", OdbcType.Text).Value = Socio.ToString();
        //        }
        //        else
        //        {
        //            oComando.CommandText = Properties.Resources.spsd_serdepaq_Consultar_PorSocioClaveFamId;
        //            oComando.Parameters.Add("?", OdbcType.Text).Value = Socio.ToString();
        //            oComando.Parameters.Add("?", OdbcType.Text).Value = claveFamiliar.ToString();
        //        }

        //        oComando.Parameters.Add("?", OdbcType.Text).Value = contrato.co_contrat_id;
        //        oComando.Parameters.Add("?", OdbcType.Text).Value = contrato.co_contrato_id;

        //        if (this.Conectar())
        //        {
        //            OdbcDataAdapter daResultado = new OdbcDataAdapter(oComando);
        //            daResultado.Fill(oEntidadResponse.Resultado);
        //            Desconectar();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oEntidadResponse.Error = true;
        //        oEntidadResponse.MensajeError = ex.Message;
        //        //BusinessUtils.Logger.WriteLogFile(ex.Message);
        //    }

        //    return oEntidadResponse;
        //}

        
        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.VigenciaII.PUB.sd_serdepaq oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = "PUB.spsd_serdepaq_Insertar";
                oComando.CommandType    = CommandType.StoredProcedure;
                oComando.CommandTimeout = 10000;

                //oComando.Parameters.Clear();
                //oParametro = new System.Data.SqlClient.SqlParameter("@Opcion", System.Data.SqlDbType.SmallInt);
                //oParametro.Value = Opcion;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@sd_paquete_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.sd_paquete_id;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@sd_servicio_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.sd_servicio_id;
                //oComando.Parameters.Add(oParametro);

                //if (this.Conectar())
                //{
                //    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                //    daResultado.Fill(oEntidadResponse.dsResultado);
                //    Desconectar();
                //}
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.MensajeError = ex.Message;
            }

            return oEntidadResponse;
        }


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.VigenciaII.PUB.sd_serdepaq oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = "PUB.spsd_serdepaq_Actualizar";
                oComando.CommandType    = CommandType.StoredProcedure;
                oComando.CommandTimeout = 10000;

                //oComando.Parameters.Clear();
                //oParametro = new System.Data.SqlClient.SqlParameter("@Opcion", System.Data.SqlDbType.SmallInt);
                //oParametro.Value = Opcion;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@sd_paquete_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.sd_paquete_id;
                //oComando.Parameters.Add(oParametro);

                //oParametro = new System.Data.SqlClient.SqlParameter("@sd_servicio_id", System.Data.SqlDbType.VarChar);
                //oParametro.Value = oBE.sd_servicio_id;
                //oComando.Parameters.Add(oParametro);

                //if (this.Conectar())
                //{
                //    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                //    daResultado.Fill(oEntidadResponse.dsResultado);
                //    Desconectar();
                //}
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