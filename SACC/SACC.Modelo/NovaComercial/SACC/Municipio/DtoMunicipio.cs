using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Municipio
{
    public class DtoMunicipio : ModeloBase
    {
        public DtoMunicipio()
        {
            _MunicipioDescripcion = String.Empty;
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
    }
}