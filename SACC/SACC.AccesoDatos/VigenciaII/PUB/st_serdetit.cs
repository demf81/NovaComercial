using System;
using System.Data;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class st_serdetit : Conexion.ConexionODBC
    {
        public st_serdetit()
        {
            NombreConexion = "cxnVigencia";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.st_serdetit oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = Resource.spst_serdetit_Consultar_PorId;
                oComando.CommandType    = CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.st_socio_id;
                oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.st_contrat_id;
                oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.st_contrato_id;
                oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.st_servicio_id;

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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.VigenciaII.PUB.st_serdetit oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = Resource.spst_serdetit_Insertar;
                oComando.CommandType    = CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Char, 100).Value = oBE.st_campos_act;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.st_contrat_id;
                oComando.Parameters.Add("?", OdbcType.Int, 3).Value = oBE.st_contrato_id;
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.st_fec_alta.Value.Month.ToString() + "/" + oBE.st_fec_alta.Value.Day.ToString() + "/" + oBE.st_fec_alta.Value.Year.ToString());
                
                if (!oBE.st_fec_baja.HasValue)
                {
                    var nullableparam = new OdbcParameter("?", DBNull.Value);
                    nullableparam.IsNullable = true;
                    nullableparam.OdbcType = OdbcType.Date;
                    nullableparam.Direction = ParameterDirection.Input;

                    oComando.Parameters.Add(nullableparam);
                }
                else
                    oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.st_fec_baja.Value.Month.ToString() + "/" + oBE.st_fec_baja.Value.Day.ToString() + "/" + oBE.st_fec_baja.Value.Year.ToString());

                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.st_hora_act;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.st_orig_vigen;
                oComando.Parameters.Add("?", OdbcType.Int, 2).Value = oBE.st_servicio_id;
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.st_socio_id;
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.st_ult_act.Value.Month.ToString() + "/" + oBE.st_ult_act.Value.Day.ToString() + "/" + oBE.st_ult_act.Value.Year.ToString());
                oComando.Parameters.Add("?", OdbcType.Char, 12).Value = oBE.st_usuario_act;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.st_vigencia;
                
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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.VigenciaII.PUB.st_serdetit oBE)
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
                        break;
                    case 2:
                        if (oBE.st_vigencia == "BA")
                        {
                            texto = Resource.spst_serdetit_Actualizar_Baja;
                            oComando.Parameters.Add("?", OdbcType.Date).Value = oBE.st_fec_baja;
                        }
                        if (oBE.st_vigencia == "AC")
                        {
                            texto = Resource.spst_serdetit_Actualizar_Reactivacion;
                            oComando.Parameters.Add("?", OdbcType.Date).Value = oBE.st_fec_reactiva;
                        }
                        break;
                    default:
                        break;
                }

                oComando.Parameters.Add("?", OdbcType.Date).Value = oBE.st_ult_act;
                oComando.Parameters.Add("?", OdbcType.Char, 24).Value = oBE.st_usuario_act;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.st_hora_act;
                oComando.Parameters.Add("?", OdbcType.Char, 200).Value = oBE.st_campos_act;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.st_socio_id;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.st_contrat_id;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.st_contrato_id;

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