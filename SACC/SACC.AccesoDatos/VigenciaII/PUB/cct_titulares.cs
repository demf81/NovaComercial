using System;
using System.Data;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class cct_titulares : Conexion.ConexionODBC
    {
        public cct_titulares()
        {
            NombreConexion = "cxnVigencia";
        }


        //public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.cct_titulares oBE)
        //{
        //    Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

        //    try
        //    {
        //        string texto = Properties.Resources.spcct_titulares_Consultar_PorId;

        //        oComando.CommandText = texto;
        //        oComando.CommandType = System.Data.CommandType.Text;
        //        oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.cct_contrat_id;
        //        oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.cct_contrato_id;
        //        oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.cct_socio_id;

        //        if (this.Conectar())
        //        {
        //            OdbcDataAdapter daResultado = new OdbcDataAdapter(oComando);
        //            daResultado.Fill(oEntidadResponse.Resultado);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oEntidadResponse.Error = true;
        //        oEntidadResponse.MensajeError = ex.Message;
        //        //BusinessUtils.Logger.WriteLogFile(ex.Message);
        //    }
        //    finally
        //    {
        //        Desconectar();
        //    }

        //    return oEntidadResponse;
        //}


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.VigenciaII.PUB.cct_titulares oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                string texto = Resource.spcct_titulares_Insertar;

                oComando.CommandText    = texto;
                oComando.CommandType    = CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Char, 100).Value = oBE.cct_campos_act;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.cct_contrat_id;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.cct_contrato_id;
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.cct_fec_alta.Value.Month.ToString() + "/" + oBE.cct_fec_alta.Value.Day.ToString() + "/" + oBE.cct_fec_alta.Value.Year.ToString());

                if (!oBE.cct_fec_baja.HasValue)
                {
                    var nullableparam = new OdbcParameter("?", DBNull.Value);

                    nullableparam.IsNullable = true;
                    nullableparam.OdbcType   = OdbcType.Date;
                    nullableparam.Direction  = ParameterDirection.Input;

                    oComando.Parameters.Add(nullableparam);
                }
                else
                    oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.cct_fec_baja.Value.Month.ToString() + "/" + oBE.cct_fec_baja.Value.Day.ToString() + "/" + oBE.cct_fec_baja.Value.Year.ToString());

                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.cct_hora_act;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.cct_orig_vigen;
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.cct_socio_id;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.cct_tipocont;
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.cct_ult_act.Value.Month.ToString() + "/" + oBE.cct_ult_act.Value.Day.ToString() + "/" + oBE.cct_ult_act.Value.Year.ToString());
                oComando.Parameters.Add("?", OdbcType.Char, 12).Value = oBE.cct_usuario_act;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.cct_vigencia;

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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.VigenciaII.PUB.cct_titulares oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            DateTime fecha;
            string texto = string.Empty;

            try
            {
                oComando.CommandType    = CommandType.Text;
                oComando.CommandTimeout = 10000;

                switch (Opcion)
                {
                    case 1:
                        if (oBE.cct_vigencia == "BA")
                        {
                            texto = Resource.spcct_titulares_Actualizar_Baja;
                            fecha = new DateTime(oBE.cct_fec_baja.Value.Year, oBE.cct_fec_baja.Value.Month, oBE.cct_fec_baja.Value.Day);
                            oComando.Parameters.Add("?", OdbcType.Date).Value = fecha;
                        }
                        if (oBE.cct_vigencia == "AC")
                        {
                            texto = Resource.spcct_titulares_Actualizar_Reactivacion;
                            fecha = new DateTime(oBE.cct_fec_reactiva.Value.Year, oBE.cct_fec_reactiva.Value.Month, oBE.cct_fec_reactiva.Value.Day);
                            oComando.Parameters.Add("?", OdbcType.Date).Value = fecha;
                        }
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }

                fecha = new DateTime(oBE.cct_ult_act.Value.Year, oBE.cct_ult_act.Value.Month, oBE.cct_ult_act.Value.Day);
                oComando.Parameters.Add("?", OdbcType.Date).Value = fecha;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.cct_hora_act;
                oComando.Parameters.Add("?", OdbcType.Char, 24).Value = oBE.cct_usuario_act;
                oComando.Parameters.Add("?", OdbcType.Char, 200).Value = oBE.cct_campos_act;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.cct_socio_id;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.cct_contrat_id;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.cct_contrato_id;

                oComando.CommandText = texto;

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