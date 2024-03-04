using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class cms_socio
    {
        public cms_socio()
        {
            _cms_apellidomat = string.Empty;
            _cms_apellidopat = string.Empty;
            _cms_area        = string.Empty;
            _cms_cvefam      = string.Empty;
            _cms_depto_id    = string.Empty;
            _cms_edocivil    = string.Empty;
            _cms_empresa_id  = string.Empty;
            _cms_gpofam      = string.Empty;
            _cms_hora_comp   = string.Empty;
            _cms_nombre      = string.Empty;
            _cms_planta_id   = string.Empty;
            _cms_socio_id    = string.Empty;
            _cms_vigencia    = string.Empty;
        }


        String _cms_apellidomat;
        [StringLength(48)]
        public String cms_apellidomat { get { return _cms_apellidomat; } set { _cms_apellidomat = value; } }


        String _cms_apellidopat;
        [StringLength(48)]
        public String cms_apellidopat { get { return _cms_apellidopat; } set { _cms_apellidopat = value; } }


        String _cms_area;
        [StringLength(30)]
        public String cms_area { get { return _cms_area; } set { _cms_area = value; } }


        String _cms_cvefam;
        [StringLength(4)]
        public String cms_cvefam { get { return _cms_cvefam; } set { _cms_cvefam = value; } }


        String _cms_depto_id;
        [StringLength(4)]
        public String cms_depto_id { get { return _cms_depto_id; } set { _cms_depto_id = value; } }


        String _cms_edocivil;
        [StringLength(2)]
        public String cms_edocivil { get { return _cms_edocivil; } set { _cms_edocivil = value; } }


        String _cms_empresa_id;
        [StringLength(6)]
        public String cms_empresa_id { get { return _cms_empresa_id; } set { _cms_empresa_id = value; } }


        DateTime? _cms_fec_alta;
        public DateTime? cms_fec_alta { get { return _cms_fec_alta; } set { _cms_fec_alta = value; } }


        DateTime? _cms_fec_baja;
        public DateTime? cms_fec_baja { get { return _cms_fec_baja; } set { _cms_fec_baja = value; } }


        DateTime? _cms_fec_comp;
        public DateTime? cms_fec_comp { get { return _cms_fec_comp; } set { _cms_fec_comp = value; } }


        DateTime? _cms_fec_naci;
        public DateTime? cms_fec_naci { get { return _cms_fec_naci; } set { _cms_fec_naci = value; } }


        DateTime? _cms_fec_reactiva;
        public DateTime? cms_fec_reactiva { get { return _cms_fec_reactiva; } set { _cms_fec_reactiva = value; } }


        String _cms_gpofam;
        [StringLength(4)]
        public String cms_gpofam { get { return _cms_gpofam; } set { _cms_gpofam = value; } }


        String _cms_hora_comp;
        [StringLength(4)]
        public String cms_hora_comp { get { return _cms_hora_comp; } set { _cms_hora_comp = value; } }


        String _cms_nombre;
        [StringLength(48)]
        public String cms_nombre { get { return _cms_nombre; } set { _cms_nombre = value; } }


        String _cms_planta_id;
        [StringLength(6)]
        public String cms_planta_id { get { return _cms_planta_id; } set { _cms_planta_id = value; } }


        Boolean _cms_sexo;
        public Boolean cms_sexo { get { return _cms_sexo; } set { _cms_sexo = value; } }


        String _cms_socio_id;
        [StringLength(4)]
        public String cms_socio_id { get { return _cms_socio_id; } set { _cms_socio_id = value; } }


        String _cms_vigencia;
        [StringLength(4)]
        public String cms_vigencia { get { return _cms_vigencia; } set { _cms_vigencia = value; } }
    }
}