using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class ps_paqserv
    {
        public ps_paqserv()
        {
            _ps_paqnombre  = string.Empty;
            _ps_paquete_id = string.Empty;
        }


        Boolean _ps_hereda;
        public Boolean ps_hereda { get { return _ps_hereda; } set { _ps_hereda = value; } }


        String _ps_paqnombre;
        [StringLength(40)]
        public String ps_paqnombre { get { return _ps_paqnombre; } set { _ps_paqnombre = value; } }


        String _ps_paquete_id;
        [StringLength(4)]
        public String ps_paquete_id { get { return _ps_paquete_id; } set { _ps_paquete_id = value; } }
    }
}