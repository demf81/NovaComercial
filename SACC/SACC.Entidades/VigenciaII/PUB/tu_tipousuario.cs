using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class tu_tipousuario
    {
        public tu_tipousuario()
        {
            _tu_cvefam_fin = string.Empty;
            _tu_cvefam_ini = string.Empty;
            _tu_desc       = string.Empty;
            _tu_edocivil   = string.Empty;
            _tu_sexo       = string.Empty;
            _tu_tipous_id  = string.Empty;
        }


        Boolean _tu_afec_gpofam;
        public Boolean tu_afec_gpofam { get { return _tu_afec_gpofam; } set { _tu_afec_gpofam = value; } }


        String _tu_cvefam_fin;
        [StringLength(4)]
        public String tu_cvefam_fin { get { return _tu_cvefam_fin; } set { _tu_cvefam_fin = value; } }


        String _tu_cvefam_ini;
        [StringLength(4)]
        public String tu_cvefam_ini { get { return _tu_cvefam_ini; } set { _tu_cvefam_ini = value; } }


        String _tu_desc;
        [StringLength(24)]
        public String tu_desc { get { return _tu_desc; } set { _tu_desc = value; } }


        String _tu_edocivil;
        [StringLength(2)]
        public String tu_edocivil { get { return _tu_edocivil; } set { _tu_edocivil = value; } }


        Boolean _tu_heredacto;
        public Boolean tu_heredacto { get { return _tu_heredacto; } set { _tu_heredacto = value; } }


        Boolean _tu_pareja_tit;
        public Boolean tu_pareja_tit { get { return _tu_pareja_tit; } set { _tu_pareja_tit = value; } }


        String _tu_sexo;
        [StringLength(2)]
        public String tu_sexo { get { return _tu_sexo; } set { _tu_sexo = value; } }


        String _tu_tipous_id;
        [StringLength(4)]
        public String tu_tipous_id { get { return _tu_tipous_id; } set { _tu_tipous_id = value; } }
    }
}