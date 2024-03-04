using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Municipio
{
    public class DtoComboMunicipio
    {
        public DtoComboMunicipio()
        {
            _MunicipioDescripcion = String.Empty;
        }


        Int32 _MunicipioId;
        public Int32 MunicipioId { get { return _MunicipioId; } set { _MunicipioId = value; } }

        String _MunicipioDescripcion;
        [StringLength(200)]
        public String MunicipioDescripcion { get { return _MunicipioDescripcion; } set { _MunicipioDescripcion = value; } }
    }
}