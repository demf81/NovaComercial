using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Municipio
{
    public class DtoGridMunicipio
    {
        public DtoGridMunicipio()
        {
            _MunicipioDescripcion = String.Empty;
        }


        Int32 _MunicipioId;
        public Int32 MunicipioId { get { return _MunicipioId; } set { _MunicipioId = value; } }

        String _PaisDescripcion;
        [StringLength(200)]
        public String PaisDescripcion { get { return _PaisDescripcion; } set { _PaisDescripcion = value; } }

        String _EstasoDescripcion;
        [StringLength(200)]
        public String EstasoDescripcion { get { return _EstasoDescripcion; } set { _EstasoDescripcion = value; } }

        String _MunicipioDescripcion;
        [StringLength(200)]
        public String MunicipioDescripcion { get { return _MunicipioDescripcion; } set { _MunicipioDescripcion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}