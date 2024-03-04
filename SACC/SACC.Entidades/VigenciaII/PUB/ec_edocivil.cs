using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class ec_edocivil
    {
        public ec_edocivil()
        {
            _ec_descripcion = string.Empty;
            _ec_edocivil    = string.Empty;
        }


        String _ec_descripcion;
        [StringLength(30)]
        public String ec_descripcion { get { return _ec_descripcion; } set { _ec_descripcion = value; } }


        String _ec_edocivil;
        [StringLength(2)]
        public String ec_edocivil_id { get { return _ec_edocivil; } set { _ec_edocivil = value; } }
    }
}