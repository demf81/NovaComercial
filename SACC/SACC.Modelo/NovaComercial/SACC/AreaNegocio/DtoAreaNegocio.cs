using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.AreaNegocio
{
    public class DtoAreaNegocio : ModeloBase
    {
        public DtoAreaNegocio()
        {
            _AreaNegocioDescripcion = String.Empty;
        }


        Int16 _AreaNegocioId;
        public Int16 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }

        String _AreaNegocioDescripcion;
        [StringLength(200)]
        public String AreaNegocioDescripcion { get { return _AreaNegocioDescripcion; } set { _AreaNegocioDescripcion = value; } }

        Int16 _NivelAfectacion;
        public Int16 NivelAfectacion { get { return _NivelAfectacion; } set { _NivelAfectacion = value; } }
    }
}