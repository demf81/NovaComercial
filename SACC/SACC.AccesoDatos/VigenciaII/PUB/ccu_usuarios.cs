using System;
using System.Data;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class ccu_usuarios : Conexion.ConexionODBC
    {
        public ccu_usuarios()
        {
            NombreConexion = "cxnVigencia";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.ccu_usuarios oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();
            String texto    = String.Empty;

            try
            {
                switch (Opcion)
                {
                    case 1:
                        texto = Resource.spccu_usuarios_Consultar_PorId;
                        oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.ccu_contrat_id;
                        oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.ccu_contrato_id;
                        break;
                    case 2:
                        texto = Resource.spccu_usuarios_Consultar_Count_PorId;
                        break;
                    case 3:
                        texto = "SELECT TOP 100 cu.ccu_fec_baja, cu.ccu_vigencia, cu.ccu_socio_id, cu.ccu_cvefam FROM pub.ccu_usuarios cu WHERE cu.ccu_socio_id = " + oBE.ccu_socio_id.ToString() + " AND cu.ccu_cvefam = " + oBE.ccu_cvefam.ToString() + " AND cu.ccu_vigencia = 'AC'";
                        break;
                    default:
                        break;
                }

                oComando.CommandText = texto;
                oComando.CommandType = System.Data.CommandType.Text;

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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.VigenciaII.PUB.ccu_usuarios oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = ""; // Resource.spccu_usuarios_Inserta;
                oComando.CommandType    = CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Char, 100).Value = oBE.ccu_campos_act;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.ccu_contrat_id;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.ccu_contrato_id;
                oComando.Parameters.Add("?", OdbcType.Int, 2).Value = oBE.ccu_cvefam;
                oComando.Parameters.Add("?", OdbcType.Int, 7).Value = oBE.ccu_desc_nomina;
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.ccu_fec_alta.Value.Month.ToString() + "/" + oBE.ccu_fec_alta.Value.Day.ToString() + "/" + oBE.ccu_fec_alta.Value.Year.ToString());

                if (!oBE.ccu_fec_baja.HasValue)
                {
                    var nullableparam = new OdbcParameter("?", DBNull.Value);

                    nullableparam.IsNullable = true;
                    nullableparam.OdbcType   = OdbcType.Date;
                    nullableparam.Direction  = ParameterDirection.Input;

                    oComando.Parameters.Add(nullableparam);
                }
                else
                    oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.ccu_fec_baja.Value.Month.ToString() + "/" + oBE.ccu_fec_baja.Value.Day.ToString() + "/" + oBE.ccu_fec_baja.Value.Year.ToString());

                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.ccu_hora_act;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.ccu_orig_vigen;
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.ccu_socio_id;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.ccu_tipocont;
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.ccu_ult_act.Value.Month.ToString() + "/" + oBE.ccu_ult_act.Value.Day.ToString() + "/" + oBE.ccu_ult_act.Value.Year.ToString());
                oComando.Parameters.Add("?", OdbcType.Char, 12).Value = oBE.ccu_usuario_act;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.ccu_vigencia;

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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.VigenciaII.PUB.ccu_usuarios oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            string texto = string.Empty;

            oComando.CommandType    = CommandType.Text;
            oComando.CommandTimeout = 10000;

            try
            {
                switch (Opcion)
                {
                    case 1:
                        if (oBE.ccu_vigencia == "BA")
                        {
                            texto = Resource.spccu_usuarios_Actualizar_Baja;
                            oComando.Parameters.Add("?", OdbcType.Date).Value = oBE.ccu_fec_baja;
                        }
                        if (oBE.ccu_vigencia == "AC")
                        {
                            texto = Resource.spccu_usuarios_Actualizar_Reactivacion;
                            oComando.Parameters.Add("?", OdbcType.Date).Value = oBE.ccu_fec_reactiva;
                        }
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }

                oComando.Parameters.Add("?", OdbcType.Date).Value = oBE.ccu_ult_act;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.ccu_hora_act;
                oComando.Parameters.Add("?", OdbcType.Char, 24).Value = oBE.ccu_usuario_act;
                oComando.Parameters.Add("?", OdbcType.Char, 200).Value = oBE.ccu_campos_act;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.ccu_socio_id;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.ccu_cvefam;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.ccu_contrat_id;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.ccu_contrato_id;
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