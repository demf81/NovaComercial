using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class su_serdeusu
    {
        public su_serdeusu()
        {
            _su_campos_act  = string.Empty;
            _su_contrato_id = 0;
            _su_contrat_id  = 0;
            _su_cvefam      = 0;
            _su_hora_act    = string.Empty;
            _su_orig_vigen  = string.Empty;
            _su_servicio_id = 0;
            _su_socio_id    = 0;
            _su_usuario_act = string.Empty;
            _su_vigencia    = string.Empty;
        }


        Int32 _su_contrat_id;
        public Int32 su_contrat_id { get { return _su_contrat_id; } set { _su_contrat_id = value; } }


        Int32 _su_contrato_id;
        public Int32 su_contrato_id { get { return _su_contrato_id; } set { _su_contrato_id = value; } }


        Int32 _su_socio_id;
        public Int32 su_socio_id { get { return _su_socio_id; } set { _su_socio_id = value; } }


        Int32 _su_cvefam;
        public Int32 su_cvefam { get { return _su_cvefam; } set { _su_cvefam = value; } }


        Int32 _su_servicio_id;
        public Int32 su_servicio_id { get { return _su_servicio_id; } set { _su_servicio_id = value; } }


        String _su_vigencia;
        [StringLength(2)]
        public String su_vigencia { get { return _su_vigencia; } set { _su_vigencia = value; } }


        String _su_orig_vigen;
        [StringLength(2)]
        public String su_orig_vigen { get { return _su_orig_vigen; } set { _su_orig_vigen = value; } }


        DateTime? _su_fec_alta;
        public DateTime? su_fec_alta { get { return _su_fec_alta; } set { _su_fec_alta = value; } }


        DateTime? _su_fec_baja;
        public DateTime? su_fec_baja { get { return _su_fec_baja; } set { _su_fec_baja = value; } }


        DateTime? _su_fec_reactiva;
        public DateTime? su_fec_reactiva { get { return _su_fec_reactiva; } set { _su_fec_reactiva = value; } }


        DateTime? _su_ult_act;
        public DateTime? su_ult_act { get { return _su_ult_act; } set { _su_ult_act = value; } }


        String _su_hora_act;
        [StringLength(6)]
        public String su_hora_act { get { return _su_hora_act; } set { _su_hora_act = value; } }


        String _su_usuario_act;
        [StringLength(12)]
        public String su_usuario_act { get { return _su_usuario_act; } set { _su_usuario_act = value; } }


        String _su_campos_act;
        [StringLength(100)]
        public String su_campos_act { get { return _su_campos_act; } set { _su_campos_act = value; } }
    }
}