using System;
using System.Data.Odbc;


namespace SACC.AccesoDatos.VigenciaII.PUB
{
    public class tmu_usuarios : Conexion.ConexionODBC
    {
        public tmu_usuarios()
        {
            NombreConexion = "cxnVigencia";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.VigenciaII.PUB.tmu_usuarios oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            string texto = string.Empty;

            oComando.CommandTimeout = 10000;

            switch (Opcion)
            {
                case 1:
                    texto = "SELECT MAX(tmu_folio) as FolioMaximo FROM PUB.tmu_usuarios";
                    oComando.CommandText = texto;
                    break;
                case 2:
                    texto = Resource.sptmu_usuarios_ConsultarPorCurp;
                    oComando.CommandText = texto;
                    oComando.CommandType = System.Data.CommandType.Text;
                    oComando.Parameters.Add("?", OdbcType.Char, 36).Value = oBE.tmu_curp;
                    break;
                default:
                    break;
            }

            try
            {
                if (Conectar())
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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.VigenciaII.PUB.tmu_usuarios oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                DateTime fecha;
                
                oComando.CommandText    = Resource.sptmu_usuarios_Insertar;
                oComando.CommandType    = System.Data.CommandType.Text;
                oComando.CommandTimeout = 10000;

                oComando.Parameters.Add("?", OdbcType.Bit).Value       = oBE.tmu_aplica_fam;
                oComando.Parameters.Add("?", OdbcType.Char, 48).Value  = oBE.tmu_ap_casada;
                oComando.Parameters.Add("?", OdbcType.Char, 48).Value  = oBE.tmu_ap_mat;
                oComando.Parameters.Add("?", OdbcType.Char, 48).Value  = oBE.tmu_ap_pat;
                oComando.Parameters.Add("?", OdbcType.Char, 120).Value = oBE.tmu_calle;
                oComando.Parameters.Add("?", OdbcType.Char, 10).Value  = oBE.tmu_codigopost;
                oComando.Parameters.Add("?", OdbcType.Char, 80).Value  = oBE.tmu_colonia_desc;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value    = oBE.tmu_colonia_id;
                oComando.Parameters.Add("?", OdbcType.Char, 100).Value = oBE.tmu_correoelec;
                oComando.Parameters.Add("?", OdbcType.Char, 36).Value  = oBE.tmu_curp;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value    = oBE.tmu_cvefam;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value    = oBE.tmu_cvefam_ant;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value    = oBE.tmu_cve_estatus;
                oComando.Parameters.Add("?", OdbcType.Char, 4).Value   = oBE.tmu_cve_mov;
                oComando.Parameters.Add("?", OdbcType.Char, 4).Value   = oBE.tmu_depto_id;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value    = oBE.tmu_desc_nomina;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value   = oBE.tmu_edocivil;
                oComando.Parameters.Add("?", OdbcType.Char, 6).Value   = oBE.tmu_empresa_id;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value    = oBE.tmu_Endoso_SIASS;
                oComando.Parameters.Add("?", OdbcType.Char, 80).Value  = oBE.tmu_estado_desc;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value    = oBE.tmu_estado_id;
                oComando.Parameters.Add("?", OdbcType.Char, 8).Value   = oBE.tmu_extension;
                oComando.Parameters.Add("?", OdbcType.Char, 30).Value  = oBE.tmu_fax_movil;

                if (oBE.tmu_fec_alta != null)
                {
                    fecha = new DateTime(oBE.tmu_fec_alta.Value.Year, oBE.tmu_fec_alta.Value.Month, oBE.tmu_fec_alta.Value.Day);
                    oComando.Parameters.Add("?", OdbcType.Date).Value = fecha;
                }
                else
                    oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Now;

                if (oBE.tmu_fec_baja != null)
                {
                    fecha = new DateTime(oBE.tmu_fec_baja.Value.Year, oBE.tmu_fec_baja.Value.Month, oBE.tmu_fec_baja.Value.Day);
                    oComando.Parameters.Add("?", OdbcType.Date).Value = fecha;
                }
                else
                    oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Now;

                if (oBE.tmu_fec_captura != null)
                {
                    fecha = new DateTime(oBE.tmu_fec_captura.Value.Year, oBE.tmu_fec_captura.Value.Month, oBE.tmu_fec_captura.Value.Day);
                    oComando.Parameters.Add("?", OdbcType.Date).Value = fecha;
                }
                else
                    oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Now;

                if (oBE.tmu_fec_fallecimiento != null)
                {
                    fecha = new DateTime(oBE.tmu_fec_fallecimiento.Value.Year, oBE.tmu_fec_fallecimiento.Value.Month, oBE.tmu_fec_fallecimiento.Value.Day);
                    oComando.Parameters.Add("?", OdbcType.Date).Value = fecha;
                }
                else
                    oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Now;

                if (oBE.tmu_fec_naci != null)
                {
                    fecha = new DateTime(oBE.tmu_fec_naci.Value.Year, oBE.tmu_fec_naci.Value.Month, oBE.tmu_fec_naci.Value.Day);
                    oComando.Parameters.Add("?", OdbcType.Date).Value = fecha;
                }
                else
                    oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Now;

                if (oBE.tmu_fec_proceso != null)
                {
                    fecha = new DateTime(oBE.tmu_fec_proceso.Value.Year, oBE.tmu_fec_proceso.Value.Month, oBE.tmu_fec_proceso.Value.Day);
                    oComando.Parameters.Add("?", OdbcType.Date).Value = fecha;
                }
                else
                    oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Now;

                if (oBE.tmu_fec_reactiva != null)
                {
                    fecha = new DateTime(oBE.tmu_fec_reactiva.Value.Year, oBE.tmu_fec_reactiva.Value.Month, oBE.tmu_fec_reactiva.Value.Day);
                    oComando.Parameters.Add("?", OdbcType.Date).Value = fecha;
                }
                else
                    oComando.Parameters.Add("?", OdbcType.Date).Value = DateTime.Now;

                oComando.Parameters.Add("?", OdbcType.Int, 4).Value   = oBE.tmu_folio;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value   = oBE.tmu_hora_cap;
                oComando.Parameters.Add("?", OdbcType.Char, 28).Value = oBE.tmu_Id_Enlace;
                oComando.Parameters.Add("?", OdbcType.Char, 28).Value = oBE.tmu_Id_SIASS;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value   = oBE.tmu_mensaje;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value   = oBE.tmu_motivo_id;
                oComando.Parameters.Add("?", OdbcType.Char, 80).Value = oBE.tmu_municipio_desc;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value   = oBE.tmu_muni_id;
                oComando.Parameters.Add("?", OdbcType.Char, 48).Value = oBE.tmu_nombre;
                oComando.Parameters.Add("?", OdbcType.Char, 16).Value = oBE.tmu_numdir;
                oComando.Parameters.Add("?", OdbcType.Char, 80).Value = oBE.tmu_observa;
                oComando.Parameters.Add("?", OdbcType.Char, 60).Value = oBE.tmu_pais_desc;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value   = oBE.tmu_pais_id;
                oComando.Parameters.Add("?", OdbcType.Char, 6).Value  = oBE.tmu_planta_id;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value   = oBE.tmu_Poliza_SIASS;
                oComando.Parameters.Add("?", OdbcType.Char, 36).Value = oBE.tmu_rfc;
                oComando.Parameters.Add("?", OdbcType.Char, 22).Value = oBE.tmu_segurosoc;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value   = oBE.tmu_servicio_id;
                oComando.Parameters.Add("?", OdbcType.Bit).Value      = oBE.tmu_sexo;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value   = oBE.tmu_socio_id;
                oComando.Parameters.Add("?", OdbcType.Int, 4).Value   = oBE.tmu_socio_id_ant;
                oComando.Parameters.Add("?", OdbcType.Char, 30).Value = oBE.tmu_telefono_casa;
                oComando.Parameters.Add("?", OdbcType.Char, 30).Value = oBE.tmu_telefono_ofi;
                oComando.Parameters.Add("?", OdbcType.Char, 6).Value  = oBE.tmu_tiposang_id;
                oComando.Parameters.Add("?", OdbcType.Char, 2).Value  = oBE.tmu_tipotrab;
                oComando.Parameters.Add("?", OdbcType.Char, 4).Value  = oBE.tmu_tipous_id;
                oComando.Parameters.Add("?", OdbcType.Char, 24).Value = oBE.tmu_usuario_cap;
                
                if (Conectar())
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