using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class mvu_movigccu
    {
        public mvu_movigccu()
        {
            _mvu_contrato_id = 0;
            _mvu_contrat_id  = 0;
            _mvu_cvefam      = 0;
            _mvu_hora_mov    = String.Empty;
            _mvu_motivo_id   = 0;
            _mvu_mot_post    = 0;
            _mvu_orig_vigen  = String.Empty;
            _mvu_socio_id    = 0;
            _mvu_usuario     = String.Empty;
            _mvu_vigencia    = String.Empty;
        }


        Int32 _mvu_contrat_id;
        public Int32 mvu_contrat_id { get { return _mvu_contrat_id; } set { _mvu_contrat_id = value; } }

        Int32 _mvu_contrato_id;
        public Int32 mvu_contrato_id { get { return _mvu_contrato_id; } set { _mvu_contrato_id = value; } }

        Int32 _mvu_socio_id;
        public Int32 mvu_socio_id { get { return _mvu_socio_id; } set { _mvu_socio_id = value; } }

        Int32 _mvu_cvefam;
        public Int32 mvu_cvefam { get { return _mvu_cvefam; } set { _mvu_cvefam = value; } }

        String _mvu_vigencia;
        [StringLength(2)]
        public String mvu_vigencia { get { return _mvu_vigencia; } set { _mvu_vigencia = value; } }

        String _mvu_orig_vigen;
        [StringLength(2)]
        public String mvu_orig_vigen { get { return _mvu_orig_vigen; } set { _mvu_orig_vigen = value; } }

        Int32 _mvu_motivo_id;
        public Int32 mvu_motivo_id { get { return _mvu_motivo_id; } set { _mvu_motivo_id = value; } }

        DateTime? _mvu_fec_mov;
        public DateTime? mvu_fec_mov { get { return _mvu_fec_mov; } set { _mvu_fec_mov = value; } }

        String _mvu_hora_mov;
        [StringLength(6)]
        public String mvu_hora_mov { get { return _mvu_hora_mov; } set { _mvu_hora_mov = value; } }

        String _mvu_usuario;
        [StringLength(12)]
        public String mvu_usuario { get { return _mvu_usuario; } set { _mvu_usuario = value; } }

        Int32 _mvu_mot_post;
        public Int32 mvu_mot_post { get { return _mvu_mot_post; } set { _mvu_mot_post = value; } }
    }
}