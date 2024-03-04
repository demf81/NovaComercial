using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class mvsu_movigserccu
    {
        public mvsu_movigserccu()
        {
            _mvsu_contrato_id = 0;
            _mvsu_contrat_id  = 0;
            _mvsu_cvefam      = 0;
            _mvsu_hora_mov    = string.Empty;
            _mvsu_motivo_id   = 0;
            _mvsu_mot_post    = 0;
            _mvsu_orig_vigen  = string.Empty;
            _mvsu_servicio_id = 0;
            _mvsu_socio_id    = 0;
            _mvsu_usuario     = string.Empty;
            _mvsu_vigencia    = string.Empty;
        }


        Int32 _mvsu_contrat_id;
        public Int32 mvsu_contrat_id { get { return _mvsu_contrat_id; } set { _mvsu_contrat_id = value; } }


        Int32 _mvsu_contrato_id;
        public Int32 mvsu_contrato_id { get { return _mvsu_contrato_id; } set { _mvsu_contrato_id = value; } }


        Int32 _mvsu_socio_id;
        public Int32 mvsu_socio_id { get { return _mvsu_socio_id; } set { _mvsu_socio_id = value; } }


        Int32 _mvsu_cvefam;
        public Int32 mvsu_cvefam { get { return _mvsu_cvefam; } set { _mvsu_cvefam = value; } }


        Int32 _mvsu_servicio_id;
        public Int32 mvsu_servicio_id { get { return _mvsu_servicio_id; } set { _mvsu_servicio_id = value; } }


        String _mvsu_vigencia;
        [StringLength(2)]
        public String mvsu_vigencia { get { return _mvsu_vigencia; } set { _mvsu_vigencia = value; } }


        Int32 _mvsu_motivo_id;
        public Int32 mvsu_motivo_id { get { return _mvsu_motivo_id; } set { _mvsu_motivo_id = value; } }


        DateTime? _mvsu_fec_mov;
        public DateTime? mvsu_fec_mov { get { return _mvsu_fec_mov; } set { _mvsu_fec_mov = value; } }


        String _mvsu_hora_mov;
        [StringLength(6)]
        public String mvsu_hora_mov { get { return _mvsu_hora_mov; } set { _mvsu_hora_mov = value; } }


        String _mvsu_usuario;
        [StringLength(12)]
        public String mvsu_usuario { get { return _mvsu_usuario; } set { _mvsu_usuario = value; } }


        String _mvsu_orig_vigen;
        [StringLength(2)]
        public String mvsu_orig_vigen { get { return _mvsu_orig_vigen; } set { _mvsu_orig_vigen = value; } }


        Int32 _mvsu_mot_post;
        public Int32 mvsu_mot_post { get { return _mvsu_mot_post; } set { _mvsu_mot_post = value; } }
    }
}