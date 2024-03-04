using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class mvt_movigcct
    {
        public mvt_movigcct()
        {
            _mvt_contrato_id = 0;
            _mvt_contrat_id  = 0;
            _mvt_hora_mov    = string.Empty;
            _mvt_motivo_id   = 0;
            _mvt_mot_post    = 0;
            _mvt_orig_vigen  = string.Empty;
            _mvt_socio_id    = 0;
            _mvt_usuario     = string.Empty;
            _mvt_vigencia    = string.Empty;
        }


        Int32 _mvt_contrat_id;
        public Int32 mvt_contrat_id { get { return _mvt_contrat_id; } set { _mvt_contrat_id = value; } }


        Int32 _mvt_contrato_id;
        public Int32 mvt_contrato_id { get { return _mvt_contrato_id; } set { _mvt_contrato_id = value; } }


        Int32 _mvt_socio_id;
        public Int32 mvt_socio_id { get { return _mvt_socio_id; } set { _mvt_socio_id = value; } }


        String _mvt_vigencia;
        [StringLength(2)]
        public String mvt_vigencia { get { return _mvt_vigencia; } set { _mvt_vigencia = value; } }


        String _mvt_orig_vigen;
        [StringLength(2)]
        public String mvt_orig_vigen { get { return _mvt_orig_vigen; } set { _mvt_orig_vigen = value; } }


        Int32 _mvt_motivo_id;
        public Int32 mvt_motivo_id { get { return _mvt_motivo_id; } set { _mvt_motivo_id = value; } }


        DateTime? _mvt_fec_mov;
        public DateTime? mvt_fec_mov { get { return _mvt_fec_mov; } set { _mvt_fec_mov = value; } }


        String _mvt_hora_mov;
        [StringLength(6)]
        public String mvt_hora_mov { get { return _mvt_hora_mov; } set { _mvt_hora_mov = value; } }


        String _mvt_usuario;
        [StringLength(12)]
        public String mvt_usuario { get { return _mvt_usuario; } set { _mvt_usuario = value; } }


        Int32 _mvt_mot_post;
        public Int32 mvt_mot_post { get { return _mvt_mot_post; } set { _mvt_mot_post = value; } }
    }
}