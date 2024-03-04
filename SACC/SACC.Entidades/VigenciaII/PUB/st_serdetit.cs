using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class st_serdetit
    {
        public st_serdetit()
        {
            _st_campos_act  = string.Empty;
            _st_contrato_id = 0;
            _st_contrat_id  = 0;
            _st_hora_act    = string.Empty;
            _st_orig_vigen  = string.Empty;
            _st_servicio_id = 0;
            _st_socio_id    = 0;
            _st_usuario_act = string.Empty;
            _st_vigencia    = string.Empty;
        }


        Int32 _st_contrat_id;
        public Int32 st_contrat_id { get { return _st_contrat_id; } set { _st_contrat_id = value; } }


        Int32 _st_contrato_id;
        public Int32 st_contrato_id { get { return _st_contrato_id; } set { _st_contrato_id = value; } }


        Int32 _st_socio_id;
        public Int32 st_socio_id { get { return _st_socio_id; } set { _st_socio_id = value; } }


        Int32 _st_servicio_id;
        public Int32 st_servicio_id { get { return _st_servicio_id; } set { _st_servicio_id = value; } }


        String _st_vigencia;
        [StringLength(2)]
        public String st_vigencia { get { return _st_vigencia; } set {_st_vigencia = value; } }


        String _st_orig_vigen;
        [StringLength(2)]
        public String st_orig_vigen { get { return _st_orig_vigen; } set { _st_orig_vigen = value; } }


        DateTime? _st_fec_alta;
        public DateTime? st_fec_alta { get { return _st_fec_alta; } set { _st_fec_alta = value; } }


        DateTime? _st_fec_baja;
        public DateTime? st_fec_baja { get { return _st_fec_baja; } set { _st_fec_baja = value; } }


        DateTime? _st_fec_reactiva;
        public DateTime? st_fec_reactiva { get { return _st_fec_reactiva; } set { _st_fec_reactiva = value; } }


        DateTime? _st_ult_act;
        public DateTime? st_ult_act { get { return _st_ult_act; } set { _st_ult_act = value; } }


        String _st_hora_act;
        [StringLength(6)]
        public String st_hora_act { get { return _st_hora_act; } set { _st_hora_act = value; } }


        String _st_usuario_act;
        [StringLength(12)]
        public String st_usuario_act { get { return _st_usuario_act; } set { _st_usuario_act = value; } }


        String _st_campos_act;
        [StringLength(100)]
        public String st_campos_act { get { return _st_campos_act; } set { _st_campos_act = value; } }
    }
}