using System;
using System.Data.Odbc;

namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class ti_titulares : Conexion.ConexionODBC
    {
        public ti_titulares()
        {
            NombreConexion = "cxnVigencia";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.ti_titulares oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = Resource.spti_titulares_Consultar_PorId;
                oComando.CommandType    = System.Data.CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.ti_socio_id;

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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.VigenciaII.PUB.ti_titulares oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText    = Resource.spti_titulares_Insertar;
                oComando.CommandType    = System.Data.CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Char, 60).Value = oBE.ti_calle;
                oComando.Parameters.Add("?", OdbcType.Char, 100).Value = oBE.ti_campos_act;
                oComando.Parameters.Add("?", OdbcType.Char, 5).Value = oBE.ti_codigopost;
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.ti_colonia_id;
                oComando.Parameters.Add("?", OdbcType.Char, 50).Value = oBE.ti_correoelec;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.ti_depto_id;
                oComando.Parameters.Add("?", OdbcType.Char, 1).Value = oBE.ti_edocivil;
                oComando.Parameters.Add("?", OdbcType.Char, 3).Value = oBE.ti_empresa_id;
                oComando.Parameters.Add("?", OdbcType.Char, 4).Value = oBE.ti_extension;
                oComando.Parameters.Add("?", OdbcType.Char, 15).Value = oBE.ti_fax;
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.ti_fec_alta.Value.Month.ToString() + "/" + oBE.ti_fec_alta.Value.Day.ToString() + "/" + oBE.ti_fec_alta.Value.Year.ToString());
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.ti_fecing_emp.Value.Month.ToString() + "/" + oBE.ti_fecing_emp.Value.Day.ToString() + "/" + oBE.ti_fecing_emp.Value.Year.ToString());
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.ti_fec_alta.Value.Month.ToString() + "/" + oBE.ti_fec_alta.Value.Day.ToString() + "/" + oBE.ti_fec_alta.Value.Year.ToString());
                oComando.Parameters.Add("?", OdbcType.Int, 2).Value = oBE.ti_gpofam;
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.ti_hora_act;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.ti_muni_id;
                oComando.Parameters.Add("?", OdbcType.Char, 80).Value = oBE.ti_nombrecompleto;
                oComando.Parameters.Add("?", OdbcType.Char, 8).Value = oBE.ti_numdir;
                oComando.Parameters.Add("?", OdbcType.Char, 3).Value = oBE.ti_planta_id;
                oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.ti_rfc;
                oComando.Parameters.Add("?", OdbcType.Char, 11).Value = oBE.ti_segusoc;
                oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.ti_socio_id;
                oComando.Parameters.Add("?", OdbcType.Char, 15).Value = oBE.ti_telefono_casa;
                oComando.Parameters.Add("?", OdbcType.Char, 15).Value = oBE.ti_telefono_ofi;
                oComando.Parameters.Add("?", OdbcType.Char, 1).Value = oBE.ti_tipotrab;
                oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Parse(oBE.ti_ult_act.Value.Month.ToString() + "/" + oBE.ti_ult_act.Value.Day.ToString() + "/" + oBE.ti_ult_act.Value.Year.ToString());
                oComando.Parameters.Add("?", OdbcType.Char, 12).Value = oBE.ti_usuario_act;
                
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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.VigenciaII.PUB.ti_titulares oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            string texto = string.Empty;

            try
            {
                switch (Opcion)
                {
                    case 1:
                        texto = Resource.spti_titulares_Actualizar_Todo_PorId;
                        
                        oComando.Parameters.Add("?", OdbcType.Char, 80).Value = oBE.ti_nombrecompleto;
                        oComando.Parameters.Add("?", OdbcType.Char, 60).Value = oBE.ti_calle;
                        oComando.Parameters.Add("?", OdbcType.Char, 8).Value = oBE.ti_numdir;
                        oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.ti_colonia_id;
                        oComando.Parameters.Add("?", OdbcType.Char, 5).Value = oBE.ti_codigopost;
                        oComando.Parameters.Add("?", OdbcType.Char, 15).Value = oBE.ti_telefono_casa;
                        oComando.Parameters.Add("?", OdbcType.Char, 15).Value = oBE.ti_telefono_ofi;
                        oComando.Parameters.Add("?", OdbcType.Char, 4).Value = oBE.ti_extension;
                        oComando.Parameters.Add("?", OdbcType.Char, 15).Value = oBE.ti_fax;
                        oComando.Parameters.Add("?", OdbcType.Char, 50).Value = oBE.ti_correoelec;
                        oComando.Parameters.Add("?", OdbcType.Int, 2).Value = oBE.ti_gpofam;
                        oComando.Parameters.Add("?", OdbcType.Char, 1).Value = oBE.ti_edocivil;
                        oComando.Parameters.Add("?", OdbcType.Char, 100).Value = oBE.ti_campos_act;
                        oComando.Parameters.Add("?", OdbcType.Text).Value = oBE.ti_rfc;
                        oComando.Parameters.Add("?", OdbcType.Char, 3).Value = oBE.ti_empresa_id;
                        oComando.Parameters.Add("?", OdbcType.Char, 3).Value = oBE.ti_planta_id;
                        oComando.Parameters.Add("?", OdbcType.Char, 2).Value = oBE.ti_depto_id;
                        DateTime fecha = new DateTime(oBE.ti_fecing_emp.Value.Year, oBE.ti_fecing_emp.Value.Month, oBE.ti_fecing_emp.Value.Day);
                        oComando.Parameters.Add("?", OdbcType.Date).Value = fecha;
                        oComando.Parameters.Add("?", OdbcType.Int, 4).Value = oBE.ti_muni_id;
                        oComando.Parameters.Add("?", OdbcType.Char, 11).Value = oBE.ti_segusoc;
                        oComando.Parameters.Add("?", OdbcType.Char, 1).Value = oBE.ti_tipotrab;
                        oComando.Parameters.Add("?", OdbcType.Date).Value = oBE.ti_ult_act;
                        oComando.Parameters.Add("?", OdbcType.Char, 12).Value = oBE.ti_usuario_act;
                        oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.ti_hora_act;
                        oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.ti_socio_id;
                        break;
                    case 2:
                        texto = Resource.spti_titulares_Actualizar_GopFam_PorId;

                        oComando.Parameters.Add("?", OdbcType.Int, 2).Value = oBE.ti_gpofam;
                        oComando.Parameters.Add("?", OdbcType.Int, 6).Value = oBE.ti_socio_id;
                        break;
                    default:
                        break;
                }

                oComando.CommandText = texto;
                oComando.CommandType = System.Data.CommandType.Text;
                oComando.CommandTimeout = 10000;


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