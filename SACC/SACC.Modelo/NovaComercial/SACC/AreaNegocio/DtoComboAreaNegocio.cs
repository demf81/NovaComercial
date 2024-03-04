using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.AreaNegocio
{
    public class DtoComboAreaNegocio
    {
        public DtoComboAreaNegocio()
        { }


        Int32 _AreaNegocioId;
        public Int32 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }

        String _AreaNegocioDescripcion;
        [StringLength(200)]
        public String AreaNegocioDescripcion { get { return _AreaNegocioDescripcion; } set { _AreaNegocioDescripcion = value; } }
    }
}