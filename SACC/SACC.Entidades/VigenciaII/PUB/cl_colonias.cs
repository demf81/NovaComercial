using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.VigenciaII.PUB
{
    public class cl_colonias
    {
        public cl_colonias()
        {
            _cl_codigopost = string.Empty;
            _cl_colonia_id = string.Empty;
            _cl_muni_id    = string.Empty;
            _cl_nombre     = string.Empty;
            _cl_zona_id    = string.Empty;
            _colonia_ant   = string.Empty;
        }


        String _cl_codigopost;
        [StringLength(10)]
        public String cl_codigopost { get { return _cl_codigopost; } set { _cl_codigopost = value; } }


        String _cl_colonia_id;
        [StringLength(4)]
        public String cl_colonia_id { get { return _cl_colonia_id; } set { _cl_colonia_id = value; } }


        String _cl_muni_id;
        [StringLength(4)]
        public String cl_muni_id { get { return _cl_muni_id; } set { _cl_muni_id = value; } }


        String _cl_nombre;
        [StringLength(70)]
        public String cl_nombre { get { return _cl_nombre; } set { _cl_nombre = value; } }


        String _cl_zona_id;
        [StringLength(4)]
        public String cl_zona_id { get { return _cl_zona_id; } set { _cl_zona_id = value; } }


        String _colonia_ant;
        [StringLength(4)]
        public String colonia_ant { get { return _colonia_ant; } set { _colonia_ant = value; } }
    }
}