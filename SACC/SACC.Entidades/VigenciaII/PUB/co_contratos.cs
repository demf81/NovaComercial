using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class co_contratos
    {
        public co_contratos()
        {
            _co_campos_act  = String.Empty;
            _co_cliente_sap = String.Empty;
            _co_contrato_id = 0;
            _co_contrat_id  = 0;
            _co_desc        = String.Empty;
            _co_empresa_id  = String.Empty;
            _co_hora_act    = String.Empty;
            _co_orig_vigen  = String.Empty;
            _co_paquete_id  = String.Empty;
            _co_planta_id   = String.Empty;
            _co_tipocont    = String.Empty;
            _co_tipo_enlace = String.Empty;
            _co_usuario_act = String.Empty;
            _co_vigencia    = String.Empty;
        }


        String _co_campos_act;
        [StringLength(200)]
        public String co_campos_act { get { return _co_campos_act; } set { _co_campos_act = value; } }

        String _co_cliente_sap;
        public String co_cliente_sap { get { return _co_cliente_sap; } set { _co_cliente_sap = value; } }

        Int32 _co_contrato_id;
        public Int32 co_contrato_id { get { return _co_contrato_id; } set { _co_contrato_id = value; } }

        Int32 _co_contrat_id;
        public Int32 co_contrat_id { get { return _co_contrat_id; } set { _co_contrat_id = value; } }

        String _co_desc;
        [StringLength(48)]
        public String co_desc { get { return _co_desc; } set { _co_desc = value; } }

        String _co_empresa_id;
        [StringLength(6)]
        public String co_empresa_id { get { return _co_empresa_id; } set { _co_empresa_id = value; } }

        DateTime? _co_fec_alta;
        public DateTime? co_fec_alta { get { return _co_fec_alta; } set { _co_fec_alta = value; } }

        DateTime? _co_fec_baja;
        public DateTime? co_fec_baja { get { return _co_fec_baja; } set { _co_fec_baja = value; } }

        DateTime? _co_fec_reactiva;
        public DateTime? co_fec_reactiva { get { return _co_fec_reactiva; } set { _co_fec_reactiva = value; } }

        String _co_hora_act;
        [StringLength(4)]
        public String co_hora_act { get { return _co_hora_act; } set { _co_hora_act = value; } }

        String _co_orig_vigen;
        [StringLength(4)]
        public String co_orig_vigen { get { return _co_orig_vigen; } set { _co_orig_vigen = value; } }

        String _co_paquete_id;
        [StringLength(4)]
        public String co_paquete_id { get { return _co_paquete_id; } set { _co_paquete_id = value; } }

        System.String _co_planta_id;
        [StringLength(6)]
        public System.String co_planta_id { get { return _co_planta_id; } set { _co_planta_id = value; } }

        String _co_tipocont;
        [StringLength(4)]
        public String co_tipocont { get { return _co_tipocont; } set { _co_tipocont = value; } }

        String _co_tipo_enlace;
        [StringLength(4)]
        public String co_tipo_enlace { get { return _co_tipo_enlace; } set { _co_tipo_enlace = value; } }

        DateTime? _co_ult_act;
        public DateTime? co_ult_act { get { return _co_ult_act; } set { _co_ult_act = value; } }

        String _co_usuario_act;
        [StringLength(24)]
        public String co_usuario_act { get { return _co_usuario_act; } set { _co_usuario_act = value; } }

        String _co_vigencia;
        [StringLength(4)]
        public String co_vigencia { get { return _co_vigencia; } set { _co_vigencia = value; } }
    }
}