using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class VentaPM : ModeloBasePM
    {
        public VentaPM()
        {
            _VentaId          = 0;
            _CotizacionId     = 0;
            _VentaDescripcion = String.Empty;
        }


        Int32? _VentaId;
        public Int32? VentaId { get { return _VentaId; } set { _VentaId = value; } }

        Int32? _CotizacionId;
        public Int32? CotizacionId { get { return _CotizacionId; } set { _CotizacionId = value; } }

        String _VentaDescripcion;
        [StringLength(200)]
        public String VentaDescripcion { get { return _VentaDescripcion; } set { _VentaDescripcion = value; } }

        DateTime? _FechaInicio;
        public DateTime? FechaInicio { get { return _FechaInicio; } set { _FechaInicio = value; } }

        DateTime? _FechaFin;
        public DateTime? FechaFin { get { return _FechaFin; } set { _FechaFin = value; } }

        Int16 _VentaTipoId;
        public Int16 VentaTipoId { get { return _VentaTipoId; } set { _VentaTipoId = value; } }
    }
}