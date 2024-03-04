using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class ed_estados
    {
        public ed_estados()
        {
            _ed_edo_id    = string.Empty;
            _ed_nombre    = string.Empty;
            _ed_Pais_id   = string.Empty;
            _ed_relcodigo = string.Empty;
            _ed_relcurp   = string.Empty;
            _ed_reltabla  = string.Empty;
        }


        String _ed_edo_id;
        [StringLength(4)]
        public String ed_edo_id { get { return _ed_edo_id; } set { _ed_edo_id = value; } }


        String _ed_nombre;
        [StringLength(80)]
        public String ed_nombre { get { return _ed_nombre; } set { _ed_nombre = value; } }


        String _ed_Pais_id;
        [StringLength(4)]
        public String ed_Pais_id { get { return _ed_Pais_id; } set { _ed_Pais_id = value; } }


        String _ed_relcodigo;
        [StringLength(4)]
        public String ed_relcodigo { get { return _ed_relcodigo; } set { _ed_relcodigo = value; } }


        String _ed_relcurp;
        [StringLength(4)]
        public String ed_relcurp { get { return _ed_relcurp; } set { _ed_relcurp = value; } }


        String _ed_reltabla;
        [StringLength(4)]
        public String ed_reltabla { get { return _ed_reltabla; } set { _ed_reltabla = value; } }
    }
}