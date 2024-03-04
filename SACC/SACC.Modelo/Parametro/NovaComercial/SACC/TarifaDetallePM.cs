using System;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class TarifaDetallePM : ModeloBasePM
    {
        public TarifaDetallePM()
        {
            _TarifaDetalleId = 0;
            _TarifaId        = 0;
        }


        Int32 _TarifaDetalleId;
        public Int32 TarifaDetalleId { get { return _TarifaDetalleId; } set { _TarifaDetalleId = value; } }

        Int32 _TarifaId;
        public Int32 TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }

        Int16 _AreaNegocioId;
        public Int16 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }
    }
}