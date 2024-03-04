using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class us_usuarios
    {
        public us_usuarios()
        {
            _Id_Enlace              = string.Empty;
            _Id_SIASS               = string.Empty;
            _us_apellidomat         = string.Empty;
            _us_apellidopat         = string.Empty;
            _us_cadena_confirmacion = string.Empty;
            _us_calle               = string.Empty;
            _us_campos_act          = string.Empty;
            _us_codigopost          = string.Empty;
            _us_colonia_desc        = string.Empty;
            _us_colonia_id          = 0;
            _us_correoelec          = string.Empty;
            _us_curp                = string.Empty;
            _us_cvefam              = 0;
            _us_edocivil            = string.Empty;
            _us_extension           = string.Empty;
            _us_fax_movil           = string.Empty;
            _us_hora_act            = string.Empty;
            _us_muni_id             = 0;
            _us_nombre              = string.Empty;
            _us_numdir              = string.Empty;
            _us_pais_id             = 0;
            _us_pass_www            = string.Empty;
            _us_pregunta            = string.Empty;
            _us_respuesta           = string.Empty;
            _us_rfc                 = string.Empty;
            _us_socio_id            = 0;
            _us_telefono_casa       = string.Empty;
            _us_telefono_ofi        = string.Empty;
            _us_tiposang_id         = string.Empty;
            _us_tipous_id           = string.Empty;
            _us_usuario_act         = string.Empty;
        }


        Int32 _us_socio_id;
        public Int32 us_socio_id { get { return _us_socio_id; } set { _us_socio_id = value; } }


        Int32 _us_cvefam;
        public Int32 us_cvefam { get { return _us_cvefam; } set { _us_cvefam = value; } }


        string _us_apellidopat;
        [StringLength(24)]
        public string us_apellidopat { get { return _us_apellidopat; } set { _us_apellidopat = value; } }


        string _us_apellidomat;
        [StringLength(24)]
        public string us_apellidomat { get { return _us_apellidomat; } set { _us_apellidomat = value; } }


        string _us_nombre;
        [StringLength(24)]
        public string us_nombre { get { return _us_nombre; } set { _us_nombre = value; } }


        Boolean _us_sexo;
        public Boolean us_sexo { get { return _us_sexo; } set { _us_sexo = value; } }


        string _us_tiposang_id;
        [StringLength(3)]
        public string us_tiposang_id { get { return _us_tiposang_id; } set { _us_tiposang_id = value; } }


        DateTime? _us_fec_naci;
        public DateTime? us_fec_naci { get { return _us_fec_naci; } set { _us_fec_naci = value; } }


        DateTime? _us_fec_fallecimiento;
        public DateTime? us_fec_fallecimiento { get { return _us_fec_fallecimiento; } set { _us_fec_fallecimiento = value; } }


        string _us_edocivil;
        [StringLength(1)]
        public string us_edocivil { get { return _us_edocivil; } set { _us_edocivil = value; } }


        string _us_tipous_id;
        [StringLength(2)]
        public string us_tipous_id { get { return _us_tipous_id; } set { _us_tipous_id = value; } }


        Boolean _us_Beca;
        public Boolean us_Beca { get { return _us_Beca; } set { _us_Beca = value; } }


        Boolean _us_estudiante;
        public Boolean us_estudiante { get { return _us_estudiante; } set { _us_estudiante = value; } }


        string _us_curp;
        [StringLength(18)]
        public String us_curp { get { return _us_curp; } set { _us_curp = value; } }


        DateTime? _us_fec_alta;
        public DateTime? us_fec_alta { get { return _us_fec_alta; } set { _us_fec_alta = value; } }


        DateTime? _us_ult_act;
        public DateTime? us_ult_act { get { return _us_ult_act; } set { _us_ult_act = value; } }

        string _us_hora_act;
        [StringLength(6)]
        public string us_hora_act { get { return _us_hora_act; } set { _us_hora_act = value; } }

        string _us_usuario_act;
        [StringLength(12)]
        public string us_usuario_act { get { return _us_usuario_act; } set { _us_usuario_act = value; } }


        string _us_campos_act;
        [StringLength(100)]
        public string us_campos_act { get { return _us_campos_act; } set { _us_campos_act = value; } }


        string _us_pass_www;
        [StringLength(50)]
        public string us_pass_www { get { return _us_pass_www; } set { _us_pass_www = value; } }


        string _us_respuesta;
        [StringLength(50)]
        public string us_respuesta { get { return _us_respuesta; } set { _us_respuesta = value; } }


        string _Id_Enlace;
        [StringLength(14)]
        public string Id_Enlace { get { return _Id_Enlace; } set { _Id_Enlace = value; } }


        string _Id_SIASS;
        [StringLength(14)]
        public string Id_SIASS { get { return _Id_SIASS; } set { _Id_SIASS = value; } }


        string _us_rfc;
        [StringLength(18)]
        public string us_rfc { get { return _us_rfc; } set { _us_rfc = value; } }


        string _us_calle;
        [StringLength(60)]
        public string us_calle { get { return _us_calle; } set { _us_calle = value; } }


        string _us_numdir;
        [StringLength(8)]
        public string us_numdir { get { return _us_numdir; } set { _us_numdir = value; } }


        string _us_codigopost;
        [StringLength(5)]
        public string us_codigopost { get { return _us_codigopost; } set { _us_codigopost = value; } }


        Int32 _us_colonia_id;
        public Int32 us_colonia_id { get { return _us_colonia_id; } set { _us_colonia_id = value; } }


        string _us_colonia_desc;
        [StringLength(35)]
        public string us_colonia_desc { get { return _us_colonia_desc; } set { _us_colonia_desc = value; } }


        Int32 _us_muni_id;
        public Int32 us_muni_id { get { return _us_muni_id; } set { _us_muni_id = value; } }


        string _us_telefono_casa;
        [StringLength(15)]
        public string us_telefono_casa { get { return _us_telefono_casa; } set { _us_telefono_casa = value; } }


        string _us_telefono_ofi;
        [StringLength(15)]
        public string us_telefono_ofi { get { return _us_telefono_ofi; } set { _us_telefono_ofi = value; } }


        string _us_extension;
        [StringLength(4)]
        public string us_extension { get { return _us_extension; } set { _us_extension = value; } }


        string _us_fax_movil;
        [StringLength(15)]
        public string us_fax_movil { get { return _us_fax_movil; } set { _us_fax_movil = value; } }


        string _us_correoelec;
        [StringLength(50)]
        public string us_correoelec { get { return _us_correoelec; } set { _us_correoelec = value; } }


        string _us_pregunta;
        [StringLength(70)]
        public string us_pregunta { get { return _us_pregunta; } set { _us_pregunta = value; } }


        Boolean _us_curp_provisional;
        public Boolean us_curp_provisional { get { return _us_curp_provisional; } set { _us_curp_provisional = value; } }


        Int32 _us_pais_id;
        public Int32 us_pais_id { get { return _us_pais_id; } set { _us_pais_id = value; } }


        Boolean _us_correo_confirmado;
        public Boolean us_correo_confirmado { get { return _us_correo_confirmado; } set { _us_correo_confirmado = value; } }


        string _us_cadena_confirmacion;
        [StringLength(10)]
        public string us_cadena_confirmacion { get { return _us_cadena_confirmacion; } set { _us_cadena_confirmacion = value; } }
    }
}