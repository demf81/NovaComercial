using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class pa_pais
    {
        public pa_pais()
        {
            _pa_nombre = string.Empty;
            _pa_nombrecorto = string.Empty;
            _pa_pais_id = string.Empty;
        }


        String _pa_nombre;
        [StringLength(60)]
        public String pa_nombre { get { return _pa_nombre; } set { _pa_nombre = value; } }


        String _pa_nombrecorto;
        [StringLength(6)]
        public String pa_nombrecorto { get { return _pa_nombrecorto; } set { _pa_nombrecorto = value; } }


        String _pa_pais_id;
        [StringLength(4)]
        public String pa_pais_id { get { return _pa_pais_id; } set { _pa_pais_id = value; } }
    }
}