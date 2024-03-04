using System;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class CotizacionDetallePM : ModeloBasePM
    {
        public CotizacionDetallePM()
        {
            _CotizacionDetalleId = -1;
            _CotizacionId        = -1;
        }


        Int64? _CotizacionDetalleId;
        public Int64? CotizacionDetalleId { get { return _CotizacionDetalleId; } set { _CotizacionDetalleId = value; } }

        Int64? _CotizacionId;
        public Int64? CotizacionId { get { return _CotizacionId; } set { _CotizacionId = value; } }
    }
}