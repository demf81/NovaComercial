using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class Municipio : EntidadBase
    {
        public Municipio()
        {
            _MunicipioDescripcion = string.Empty;
        }


        Int32 _MunicipioId;
        public Int32 MunicipioId { get { return _MunicipioId; } set { _MunicipioId = value; } }

        Int32 _EstadoId;
        public Int32 EstadoId { get { return _EstadoId; } set { _EstadoId = value; } }

        Int32 _PaisId;
        public Int32 PaisId { get { return _PaisId; } set { _PaisId = value; } }

        String _MunicipioDescripcion;
        [StringLength(200)]
        public String MunicipioDescripcion { get { return _MunicipioDescripcion; } set { _MunicipioDescripcion = value; } }

        String _Codigo;
        [StringLength(10)]
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }
    }
}