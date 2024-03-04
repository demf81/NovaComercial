using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class ti_titulares
    {
        public ti_titulares()
        {
            _ti_calle          = string.Empty;
            _ti_campos_act     = string.Empty;
            _ti_codigopost     = string.Empty;
            _ti_colonia_id     = 0;
            _ti_correoelec     = string.Empty;
            _ti_depto_id       = string.Empty;
            _ti_edocivil       = string.Empty;
            _ti_empresa_id     = string.Empty;
            _ti_extension      = string.Empty;
            _ti_fax            = string.Empty;
            _ti_gpofam         = 0;
            _ti_hora_act       = string.Empty;
            _ti_muni_id        = 0;
            _ti_nombrecompleto = string.Empty;
            _ti_numdir         = string.Empty;
            _ti_planta_id      = string.Empty;
            _ti_rfc            = string.Empty;
            _ti_segusoc        = string.Empty;
            _ti_socio_id       = 0;
            _ti_telefono_casa  = string.Empty;
            _ti_telefono_ofi   = string.Empty;
            _ti_tipotrab       = string.Empty;
            _ti_usuario_act    = string.Empty;
        }


        Int32 _ti_socio_id;
        public Int32 ti_socio_id { get { return _ti_socio_id; } set { _ti_socio_id = value; } }


        String _ti_nombrecompleto;
        [StringLength(80)]
        public String ti_nombrecompleto { get { return _ti_nombrecompleto; } set { _ti_nombrecompleto = value; } }


        String _ti_empresa_id;
        [StringLength(3)]
        public String ti_empresa_id { get { return _ti_empresa_id; } set { _ti_empresa_id = value; } }


        String _ti_planta_id;
        [StringLength(3)]
        public String ti_planta_id { get { return _ti_planta_id; } set { _ti_planta_id = value; } }


        String _ti_depto_id;
        [StringLength(2)]
        public String ti_depto_id { get { return _ti_depto_id; } set { _ti_depto_id = value; } }


        DateTime? _ti_fec_alta;
        public DateTime? ti_fec_alta { get { return _ti_fec_alta; } set { _ti_fec_alta = value; } }


        DateTime? _ti_fecing_gpo;
        public DateTime? ti_fecing_gpo { get { return _ti_fecing_gpo; } set { _ti_fecing_gpo = value; } }


        DateTime? _ti_fecing_emp;
        public DateTime? ti_fecing_emp { get { return _ti_fecing_emp; } set { _ti_fecing_emp = value; } }


        String _ti_tipotrab;
        [StringLength(1)]
        public String ti_tipotrab { get { return _ti_tipotrab; } set { _ti_tipotrab = value; } }


        Int32 _ti_gpofam;
        public Int32 ti_gpofam { get { return _ti_gpofam; } set { _ti_gpofam = value; } }


        String _ti_edocivil;
        [StringLength(1)]
        public String ti_edocivil { get { return _ti_edocivil; } set { _ti_edocivil = value; } }


        String _ti_segusoc;
        [StringLength(11)]
        public String ti_segusoc { get { return _ti_segusoc; } set { _ti_segusoc = value; } }


        String _ti_rfc;
        [StringLength(20)]
        public String ti_rfc { get { return _ti_rfc; } set { _ti_rfc = value; } }


        String _ti_calle;
        [StringLength(60)]
        public String ti_calle { get { return _ti_calle; } set { _ti_calle = value; } }


        String _ti_numdir;
        [StringLength(8)]
        public String ti_numdir { get { return _ti_numdir; } set { _ti_numdir = value; } }


        String _ti_codigopost;
        [StringLength(5)]
        public String ti_codigopost { get { return _ti_codigopost; } set { _ti_codigopost = value; } }


        Int32 _ti_colonia_id;
        public Int32 ti_colonia_id { get { return _ti_colonia_id; } set { _ti_colonia_id = value; } }


        Int32 _ti_muni_id;
        public Int32 ti_muni_id { get { return _ti_muni_id; } set { _ti_muni_id = value; } }


        String _ti_telefono_casa;
        [StringLength(15)]
        public String ti_telefono_casa { get { return _ti_telefono_casa; } set { _ti_telefono_casa = value; } }


        String _ti_telefono_ofi;
        [StringLength(15)]
        public String ti_telefono_ofi { get { return _ti_telefono_ofi; } set { _ti_telefono_ofi = value; } }


        String _ti_extension;
        [StringLength(4)]
        public String ti_extension { get { return _ti_extension; } set { _ti_extension = value; } }


        String _ti_fax;
        [StringLength(15)]
        public String ti_fax { get { return _ti_fax; } set { _ti_fax = value; } }


        String _ti_correoelec;
        [StringLength(50)]
        public String ti_correoelec { get { return _ti_correoelec; } set { _ti_correoelec = value; } }


        DateTime? _ti_ult_act;
        public DateTime? ti_ult_act { get { return _ti_ult_act; } set { _ti_ult_act = value; } }


        String _ti_hora_act;
        [StringLength(6)]
        public String ti_hora_act { get { return _ti_hora_act; } set { _ti_hora_act = value; } }


        String _ti_usuario_act;
        [StringLength(12)]
        public String ti_usuario_act { get { return _ti_usuario_act; } set { _ti_usuario_act = value; } }


        String _ti_campos_act;
        [StringLength(100)]
        public String ti_campos_act { get { return _ti_campos_act; } set { _ti_campos_act = value; } }
    }
}