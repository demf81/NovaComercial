using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.AreaNegocio
{
    public class DtoGridAreaNegocio
    {
        public DtoGridAreaNegocio()
        {
            _AreaNegocioDescripcion = String.Empty;
        }


        Int32 _AreaNegocioId;
        public Int32 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }

        String _AreaNegocioDescripcion;
        [StringLength(200)]
        public String AreaNegocioDescripcion { get { return _AreaNegocioDescripcion; } set { _AreaNegocioDescripcion = value; } }

        String _NivelAfectacionDescripcion;
        [StringLength(100)]
        public String NivelAfectacionDescripcion { get { return _NivelAfectacionDescripcion; } set { _NivelAfectacionDescripcion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}