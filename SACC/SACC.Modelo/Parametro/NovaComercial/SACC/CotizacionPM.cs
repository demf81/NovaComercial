using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class CotizacionPM : ModeloBasePM
    {
        public CotizacionPM()
        {
            _CotizacionId          = 0;
            _CotizacionDescripcion = String.Empty;
        }


        Int64? _CotizacionId;
        public Int64? CotizacionId { get { return _CotizacionId; } set { _CotizacionId = value; } }

        String _CotizacionDescripcion;
        [StringLength(200)]
        public String CotizacionDescripcion { get { return _CotizacionDescripcion; } set { _CotizacionDescripcion = value; } }

        DateTime? _FechaInicio;
        public DateTime? FechaInicio { get { return _FechaInicio; } set { _FechaInicio = value; } }

        DateTime? _FechaFin;
        public DateTime? FechaFin { get { return _FechaFin; } set { _FechaFin = value; } }

        Int16 _CotizacionTipoId;
        public Int16 CotizacionTipoId { get { return _CotizacionTipoId; } set { _CotizacionTipoId = value; } }

        Int16 _CotizacionEstatusId;
        public Int16 CotizacionEstatusId { get { return _CotizacionEstatusId; } set { _CotizacionEstatusId = value; } }
    }
}