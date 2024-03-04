using System;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class VentaDetallePM : ModeloBasePM
    {
        public VentaDetallePM()
        {
            _VentaDetalleId = -1;
            _VentaId        = -1;
        }


        Int32? _VentaDetalleId;
        public Int32? VentaDetalleId { get { return _VentaDetalleId; } set { _VentaDetalleId = value; } }

        Int32? _VentaId;
        public Int32? VentaId { get { return _VentaId; } set { _VentaId = value; } }
    }
}