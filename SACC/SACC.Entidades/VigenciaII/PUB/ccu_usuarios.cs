using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class ccu_usuarios
    {
        public ccu_usuarios()
        {
            _ccu_campos_act  = String.Empty;
            _ccu_contrato_id = 0;
            _ccu_contrat_id  = 0;
            _ccu_cvefam      = 0;
            _ccu_desc_nomina = 0;
            _ccu_hora_act    = String.Empty;
            _ccu_orig_vigen  = String.Empty;
            _ccu_socio_id    = 0;
            _ccu_tipocont    = String.Empty;
            _ccu_usuario_act = String.Empty;
            _ccu_vigencia    = String.Empty;
        }


        Int32 _ccu_contrat_id;
        public Int32 ccu_contrat_id { get { return _ccu_contrat_id; } set { _ccu_contrat_id = value; } }

        Int32 _ccu_contrato_id;
        public Int32 ccu_contrato_id { get { return _ccu_contrato_id; } set { _ccu_contrato_id = value; } }

        Int32 _ccu_socio_id;
        public Int32 ccu_socio_id { get { return _ccu_socio_id; } set { _ccu_socio_id = value; } }

        Int32 _ccu_cvefam;
        public Int32 ccu_cvefam { get { return _ccu_cvefam; } set { _ccu_cvefam = value; } }

        DateTime? _ccu_fec_alta;
        public DateTime? ccu_fec_alta { get { return _ccu_fec_alta; } set { _ccu_fec_alta = value; } }

        DateTime? _ccu_fec_baja;
        public DateTime? ccu_fec_baja { get { return _ccu_fec_baja; } set { _ccu_fec_baja = value; } }

        DateTime? _ccu_fec_reactiva;
        public DateTime? ccu_fec_reactiva { get { return _ccu_fec_reactiva; } set { _ccu_fec_reactiva = value; } }

        String _ccu_vigencia;
        [StringLength(2)]
        public String ccu_vigencia { get { return _ccu_vigencia; } set { _ccu_vigencia = value; } }

        String _ccu_orig_vigen;
        [StringLength(2)]
        public String ccu_orig_vigen { get { return _ccu_orig_vigen; } set { _ccu_orig_vigen = value; } }

        String _ccu_tipocont;
        [StringLength(2)]
        public String ccu_tipocont { get { return _ccu_tipocont; } set { _ccu_tipocont = value; } }

        Int32 _ccu_desc_nomina;
        public Int32 ccu_desc_nomina { get { return _ccu_desc_nomina; } set { _ccu_desc_nomina = value; } }

        DateTime? _ccu_ult_act;
        public DateTime? ccu_ult_act { get { return _ccu_ult_act; } set { _ccu_ult_act = value; } }

        String _ccu_hora_act;
        [StringLength(6)]
        public String ccu_hora_act { get { return _ccu_hora_act; } set { _ccu_hora_act = value; } }

        String _ccu_usuario_act;
        [StringLength(12)]
        public String ccu_usuario_act { get { return _ccu_usuario_act; } set { _ccu_usuario_act = value; } }

        String _ccu_campos_act;
        [StringLength(100)]
        public String ccu_campos_act { get { return _ccu_campos_act; } set { _ccu_campos_act = value; } }
    }
}