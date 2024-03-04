using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class sc_servdecto
    {
        public sc_servdecto()
        {
            _sc_contrato_id = string.Empty;
            _sc_contrat_id = string.Empty;
        }


        String _sc_contrato_id;
        [StringLength(4)]
        public String sc_contrato_id { get { return _sc_contrato_id; } set { _sc_contrato_id = value; } }


        String _sc_contrat_id;
        [StringLength(4)]
        public String sc_contrat_id { get { return _sc_contrat_id; } set { _sc_contrat_id = value; } }
    }
}