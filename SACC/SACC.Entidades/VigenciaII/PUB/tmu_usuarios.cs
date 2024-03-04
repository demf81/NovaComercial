using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class tmu_usuarios
    {
        public tmu_usuarios()
        {
            _tmu_aplica_fam     = false;
            _tmu_ap_casada      = string.Empty;
            _tmu_ap_mat         = string.Empty;
            _tmu_ap_pat         = string.Empty;
            _tmu_calle          = string.Empty;
            _tmu_codigopost     = string.Empty;
            _tmu_colonia_desc   = string.Empty;
            _tmu_colonia_id     = 0;
            _tmu_correoelec     = string.Empty;
            _tmu_curp           = string.Empty;
            _tmu_cvefam         = 0;
            _tmu_cvefam_ant     = 0;
            _tmu_cve_estatus    = 0;
            _tmu_cve_mov        = string.Empty;
            _tmu_depto_id       = string.Empty;
            _tmu_desc_nomina    = 0;
            _tmu_edocivil       = string.Empty;
            _tmu_empresa_id     = string.Empty;
            _tmu_Endoso_SIASS   = 0;
            _tmu_estado_desc    = string.Empty;
            _tmu_estado_id      = 0;
            _tmu_extension      = string.Empty;
            _tmu_fax_movil      = string.Empty;
            _tmu_folio          = 0;
            _tmu_hora_cap       = 0;
            _tmu_Id_Enlace      = string.Empty;
            _tmu_Id_SIASS       = string.Empty;
            _tmu_mensaje        = 0;
            _tmu_motivo_id      = 0;
            _tmu_municipio_desc = string.Empty;
            _tmu_muni_id        = 0;
            _tmu_nombre         = string.Empty;
            _tmu_numdir         = string.Empty;
            _tmu_observa        = string.Empty;
            _tmu_pais_desc      = string.Empty;
            _tmu_pais_id        = 0;
            _tmu_planta_id      = string.Empty;
            _tmu_Poliza_SIASS   = 0;
            _tmu_rfc            = string.Empty;
            _tmu_segurosoc      = string.Empty;
            _tmu_servicio_id    = 0;
            _tmu_sexo           = false;
            _tmu_socio_id       = 0;
            _tmu_socio_id_ant   = 0;
            _tmu_telefono_casa  = string.Empty;
            _tmu_telefono_ofi   = string.Empty;
            _tmu_tiposang_id    = string.Empty;
            _tmu_tipotrab       = string.Empty;
            _tmu_tipous_id      = string.Empty;
            _tmu_usuario_cap    = string.Empty;
        }


        Boolean _tmu_aplica_fam;
        public Boolean tmu_aplica_fam { get { return _tmu_aplica_fam; } set { _tmu_aplica_fam = value; } }


        String _tmu_ap_casada;
        [StringLength(48)]
        public String tmu_ap_casada { get { return _tmu_ap_casada; } set { _tmu_ap_casada = value; } }


        String _tmu_ap_mat;
        [StringLength(48)]
        public String tmu_ap_mat { get { return _tmu_ap_mat; } set { _tmu_ap_mat = value; } }


        String _tmu_ap_pat;
        [StringLength(48)]
        public String tmu_ap_pat { get { return _tmu_ap_pat; } set { _tmu_ap_pat = value; } }


        String _tmu_calle;
        [StringLength(120)]
        public String tmu_calle { get { return _tmu_calle; } set { _tmu_calle = value; } }


        String _tmu_codigopost;
        [StringLength(10)]
        public String tmu_codigopost { get { return _tmu_codigopost; } set { _tmu_codigopost = value; } }


        String _tmu_colonia_desc;
        [StringLength(80)]
        public String tmu_colonia_desc { get { return _tmu_colonia_desc; } set { _tmu_colonia_desc = value; } }


        Int32 _tmu_colonia_id;
        public Int32 tmu_colonia_id { get { return _tmu_colonia_id; } set { _tmu_colonia_id = value; } }


        String _tmu_correoelec;
        [StringLength(100)]
        public String tmu_correoelec { get { return _tmu_correoelec; } set { _tmu_correoelec = value; } }


        String _tmu_curp;
        [StringLength(18)]
        public String tmu_curp { get { return _tmu_curp; } set { _tmu_curp = value; } }


        Int32 _tmu_cvefam;
        public Int32 tmu_cvefam { get { return _tmu_cvefam; } set { _tmu_cvefam = value; } }


        Int32 _tmu_cvefam_ant;
        public Int32 tmu_cvefam_ant { get { return _tmu_cvefam_ant; } set { _tmu_cvefam_ant = value; } }


        Int32 _tmu_cve_estatus;
        public Int32 tmu_cve_estatus { get { return _tmu_cve_estatus; } set { _tmu_cve_estatus = value; } }


        String _tmu_cve_mov;
        [StringLength(4)]
        public String tmu_cve_mov { get { return _tmu_cve_mov; } set { _tmu_cve_mov = value; } }


        String _tmu_depto_id;
        [StringLength(4)]
        public String tmu_depto_id { get { return _tmu_depto_id; } set { _tmu_depto_id = value; } }


        Int32 _tmu_desc_nomina;
        public Int32 tmu_desc_nomina { get { return _tmu_desc_nomina; } set { _tmu_desc_nomina = value; } }


        String _tmu_edocivil;
        [StringLength(2)]
        public String tmu_edocivil { get { return _tmu_edocivil; } set { _tmu_edocivil = value; } }


        String _tmu_empresa_id;
        [StringLength(6)]
        public String tmu_empresa_id { get { return _tmu_empresa_id; } set { _tmu_empresa_id = value; } }


        Int32 _tmu_Endoso_SIASS;
        public Int32 tmu_Endoso_SIASS { get { return _tmu_Endoso_SIASS; } set { _tmu_Endoso_SIASS = value; } }


        String _tmu_estado_desc;
        [StringLength(80)]
        public String tmu_estado_desc { get { return _tmu_estado_desc; } set { _tmu_estado_desc = value; } }


        Int32 _tmu_estado_id;
        public Int32 tmu_estado_id { get { return _tmu_estado_id; } set { _tmu_estado_id = value; } }


        String _tmu_extension;
        [StringLength(8)]
        public String tmu_extension { get { return _tmu_extension; } set { _tmu_extension = value; } }


        String _tmu_fax_movil;
        [StringLength(30)]
        public String tmu_fax_movil { get { return _tmu_fax_movil; } set { _tmu_fax_movil = value; } }


        DateTime? _tmu_fec_alta;
        public DateTime? tmu_fec_alta { get { return _tmu_fec_alta; } set { _tmu_fec_alta = value; } }


        DateTime? _tmu_fec_baja;
        public DateTime? tmu_fec_baja { get { return _tmu_fec_baja; } set { _tmu_fec_baja = value; } }


        DateTime? _tmu_fec_captura;
        public DateTime? tmu_fec_captura { get { return _tmu_fec_captura; } set { _tmu_fec_captura = value; } }


        DateTime? _tmu_fec_fallecimiento;
        public DateTime? tmu_fec_fallecimiento { get { return _tmu_fec_fallecimiento; } set { _tmu_fec_fallecimiento = value; } }


        DateTime? _tmu_fec_naci;
        public DateTime? tmu_fec_naci { get { return _tmu_fec_naci; } set { _tmu_fec_naci = value; } }


        DateTime? _tmu_fec_proceso;
        public DateTime? tmu_fec_proceso { get { return _tmu_fec_proceso; } set { _tmu_fec_proceso = value; } }


        DateTime? _tmu_fec_reactiva;
        public DateTime? tmu_fec_reactiva { get { return _tmu_fec_reactiva; } set { _tmu_fec_reactiva = value; } }


        Int32 _tmu_folio;
        public Int32 tmu_folio { get { return _tmu_folio; } set { _tmu_folio = value; } }


        Int32 _tmu_hora_cap;
        public Int32 tmu_hora_cap { get { return _tmu_hora_cap; } set { _tmu_hora_cap = value; } }


        String _tmu_Id_Enlace;
        [StringLength(28)]
        public String tmu_Id_Enlace { get { return _tmu_Id_Enlace; } set { _tmu_Id_Enlace = value; } }


        String _tmu_Id_SIASS;
        [StringLength(28)]
        public String tmu_Id_SIASS { get { return _tmu_Id_SIASS; } set { _tmu_Id_SIASS = value; } }


        Int32 _tmu_mensaje;
        public Int32 tmu_mensaje { get { return _tmu_mensaje; } set { _tmu_mensaje = value; } }


        Int32 _tmu_motivo_id;
        public Int32 tmu_motivo_id { get { return _tmu_motivo_id; } set { _tmu_motivo_id = value; } }


        String _tmu_municipio_desc;
        [StringLength(80)]
        public String tmu_municipio_desc { get { return _tmu_municipio_desc; } set { _tmu_municipio_desc = value; } }


        Int32 _tmu_muni_id;
        public Int32 tmu_muni_id { get { return _tmu_muni_id; } set { _tmu_muni_id = value; } }


        String _tmu_nombre;
        [StringLength(48)]
        public String tmu_nombre { get { return _tmu_nombre; } set { _tmu_nombre = value; } }


        String _tmu_numdir;
        [StringLength(16)]
        public String tmu_numdir { get { return _tmu_numdir; } set { _tmu_numdir = value; } }


        String _tmu_observa;
        [StringLength(80)]
        public String tmu_observa { get { return _tmu_observa; } set { _tmu_observa = value; } }


        String _tmu_pais_desc;
        [StringLength(60)]
        public String tmu_pais_desc { get { return _tmu_pais_desc; } set { _tmu_pais_desc = value; } }


        Int32 _tmu_pais_id;
        public Int32 tmu_pais_id { get { return _tmu_pais_id; } set { _tmu_pais_id = value; } }


        String _tmu_planta_id;
        [StringLength(6)]
        public String tmu_planta_id { get { return _tmu_planta_id; } set { _tmu_planta_id = value; } }


        Int32 _tmu_Poliza_SIASS;
        public Int32 tmu_Poliza_SIASS { get { return _tmu_Poliza_SIASS; } set { _tmu_Poliza_SIASS = value; } }


        String _tmu_rfc;
        [StringLength(36)]
        public String tmu_rfc { get { return _tmu_rfc; } set { _tmu_rfc = value; } }


        String _tmu_segurosoc;
        [StringLength(22)]
        public String tmu_segurosoc { get { return _tmu_segurosoc; } set { _tmu_segurosoc = value; } }


        Int32 _tmu_servicio_id;
        public Int32 tmu_servicio_id { get { return _tmu_servicio_id; } set { _tmu_servicio_id = value; } }


        Boolean? _tmu_sexo;
        public Boolean? tmu_sexo { get { return _tmu_sexo; } set { _tmu_sexo = value; } }


        Int32 _tmu_socio_id;
        public Int32 tmu_socio_id { get { return _tmu_socio_id; } set { _tmu_socio_id = value; } }


        Int32 _tmu_socio_id_ant;
        public Int32 tmu_socio_id_ant { get { return _tmu_socio_id_ant; } set { _tmu_socio_id_ant = value; } }


        String _tmu_telefono_casa;
        [StringLength(30)]
        public String tmu_telefono_casa { get { return _tmu_telefono_casa; } set { _tmu_telefono_casa = value; } }


        String _tmu_telefono_ofi;
        [StringLength(30)]
        public String tmu_telefono_ofi { get { return _tmu_telefono_ofi; } set { _tmu_telefono_ofi = value; } }


        String _tmu_tiposang_id;
        [StringLength(6)]
        public String tmu_tiposang_id { get { return _tmu_tiposang_id; } set { _tmu_tiposang_id = value; } }


        String _tmu_tipotrab;
        [StringLength(2)]
        public String tmu_tipotrab { get { return _tmu_tipotrab; } set { _tmu_tipotrab = value; } }


        String _tmu_tipous_id;
        [StringLength(4)]
        public String tmu_tipous_id { get { return _tmu_tipous_id; } set { _tmu_tipous_id = value; } }


        String _tmu_usuario_cap;
        [StringLength(24)]
        public String tmu_usuario_cap { get { return _tmu_usuario_cap; } set { _tmu_usuario_cap = value; } }
    }
}