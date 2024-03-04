using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class cct_titulares
    {
        public cct_titulares()
        {
            _cct_campos_act  = string.Empty;
            _cct_contrato_id = 0;
            _cct_contrat_id  = 0;
            _cct_hora_act    = string.Empty;
            _cct_orig_vigen  = string.Empty;
            _cct_socio_id    = 0;
            _cct_tipocont    = string.Empty;
            _cct_usuario_act = string.Empty;
            _cct_vigencia    = string.Empty;
        }


        Int32 _cct_contrat_id;
        public Int32 cct_contrat_id { get { return _cct_contrat_id; } set { _cct_contrat_id = value; } }


        Int32 _cct_contrato_id;
        public Int32 cct_contrato_id { get { return _cct_contrato_id; } set { _cct_contrato_id = value; } }


        Int32 _cct_socio_id;
        public Int32 cct_socio_id { get { return _cct_socio_id; } set { _cct_socio_id = value; } }


        String _cct_vigencia;
        [StringLength(2)]
        public String cct_vigencia { get { return _cct_vigencia; } set { _cct_vigencia = value; } }


        DateTime? _cct_fec_alta;
        public DateTime? cct_fec_alta { get { return _cct_fec_alta; } set { _cct_fec_alta = value; } }


        DateTime? _cct_fec_baja;
        public DateTime? cct_fec_baja { get { return _cct_fec_baja; } set { _cct_fec_baja = value; } }


        DateTime? _cct_fec_reactiva;
        public DateTime? cct_fec_reactiva { get { return _cct_fec_reactiva; } set { _cct_fec_reactiva = value; } }


        String _cct_tipocont;
        [StringLength(2)]
        public String cct_tipocont { get { return _cct_tipocont; } set { _cct_tipocont = value; } }


        String _cct_orig_vigen;
        [StringLength(2)]
        public String cct_orig_vigen { get { return _cct_orig_vigen; } set { _cct_orig_vigen = value; } }


        DateTime? _cct_ult_act;
        public DateTime? cct_ult_act { get { return _cct_ult_act; } set { _cct_ult_act = value; } }


        String _cct_hora_act;
        [StringLength(6)]
        public String cct_hora_act { get { return _cct_hora_act; } set { _cct_hora_act = value; } }


        String _cct_usuario_act;
        [StringLength(12)]
        public String cct_usuario_act { get { return _cct_usuario_act; } set { _cct_usuario_act = value; } }


        String _cct_campos_act;
        [StringLength(100)]
        public String cct_campos_act { get { return _cct_campos_act; } set { _cct_campos_act = value; } }
    }
}