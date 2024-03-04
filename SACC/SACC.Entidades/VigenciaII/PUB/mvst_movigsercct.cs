using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class mvst_movigsercct
    {
        public mvst_movigsercct()
        {
            _mvst_contrato_id = 0;
            _mvst_contrat_id  = 0;
            _mvst_hora_mov    = string.Empty;
            _mvst_motivo_id   = 0;
            _mvst_mot_post    = 0;
            _mvst_orig_vigen  = string.Empty;
            _mvst_servicio_id = 0;
            _mvst_socio_id    = 0;
            _mvst_usuario     = string.Empty;
            _mvst_vigencia    = string.Empty;
        }


        Int32 _mvst_contrat_id;
        public Int32 mvst_contrat_id { get { return _mvst_contrat_id; } set { _mvst_contrat_id = value; } }


        Int32 _mvst_contrato_id;
        public Int32 mvst_contrato_id { get { return _mvst_contrato_id; } set { _mvst_contrato_id = value; } }


        Int32 _mvst_socio_id;
        public Int32 mvst_socio_id { get { return _mvst_socio_id; } set { _mvst_socio_id = value; } }


        Int32 _mvst_servicio_id;
        public Int32 mvst_servicio_id { get { return _mvst_servicio_id; } set { _mvst_servicio_id = value; } }


        String _mvst_vigencia;
        [StringLength(2)]
        public String mvst_vigencia { get { return _mvst_vigencia; } set { _mvst_vigencia = value; } }


        Int32 _mvst_motivo_id;
        public Int32 mvst_motivo_id { get { return _mvst_motivo_id; } set { _mvst_motivo_id = value; } }


        DateTime? _mvst_fec_mov;
        public DateTime? mvst_fec_mov { get { return _mvst_fec_mov; } set { _mvst_fec_mov = value; } }


        String _mvst_hora_mov;
        [StringLength(6)]
        public String mvst_hora_mov { get { return _mvst_hora_mov; } set { _mvst_hora_mov = value; } }


        String _mvst_usuario;
        [StringLength(12)]
        public String mvst_usuario { get { return _mvst_usuario; } set { _mvst_usuario = value; } }


        String _mvst_orig_vigen;
        [StringLength(2)]
        public String mvst_orig_vigen { get { return _mvst_orig_vigen; } set { _mvst_orig_vigen = value; } }


        Int32 _mvst_mot_post;
        public Int32 mvst_mot_post { get { return _mvst_mot_post; } set { _mvst_mot_post = value; } }
    }
}