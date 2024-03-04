using System;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class CotizacionProcedimientoDetallePM : ModeloBasePM
    {
        public CotizacionProcedimientoDetallePM()
        {
            _CotizacionDetalleId = -1;
            _CotizacionId        = -1;
        }


        Int32? _CotizacionDetalleId;
        public Int32? CotizacionDetalleId { get { return _CotizacionDetalleId; } set { _CotizacionDetalleId = value; } }

        Int32? _CotizacionId;
        public Int32? CotizacionId { get { return _CotizacionId; } set { _CotizacionId = value; } }
    }
}