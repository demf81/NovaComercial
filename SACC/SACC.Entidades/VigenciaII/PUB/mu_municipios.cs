using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class mu_municipios
    {
        public mu_municipios()
        {
            _mu_Edo_id      = string.Empty;
            _mu_inegi       = string.Empty;
            _mu_muni_id     = string.Empty;
            _mu_nombre      = string.Empty;
            _mu_prefijoarea = string.Empty;
            _mu_relcodigo   = string.Empty;
            _mu_reltabla    = string.Empty;
        }


        String _mu_Edo_id;
        [StringLength(4)]
        public String mu_Edo_id { get { return _mu_Edo_id; } set { _mu_Edo_id = value; } }


        String _mu_inegi;
        [StringLength(24)]
        public String mu_inegi { get { return _mu_inegi; } set { _mu_inegi = value; } }


        String _mu_muni_id;
        [StringLength(4)]
        public String mu_muni_id { get { return _mu_muni_id; } set { _mu_muni_id = value; } }


        String _mu_nombre;
        [StringLength(28)]
        public String mu_nombre { get { return _mu_nombre; } set { _mu_nombre = value; } }


        String _mu_prefijoarea;
        [StringLength(4)]
        public String mu_prefijoarea { get { return _mu_prefijoarea; } set { _mu_prefijoarea = value; } }


        String _mu_relcodigo;
        [StringLength(4)]
        public String mu_relcodigo { get { return _mu_relcodigo; } set { _mu_relcodigo = value; } }


        String _mu_reltabla;
        [StringLength(4)]
        public String mu_reltabla { get { return _mu_reltabla; } set { _mu_reltabla = value; } }
    }
}