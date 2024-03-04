using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class CotizacionDetalle : EntidadBase
    {
        public CotizacionDetalle()
        {

        }


        Int32 _CotizacionDetalleId;
        public Int32 CotizacionDetalleId { get { return _CotizacionDetalleId; } set { _CotizacionDetalleId = value; } }

        Int32 _CotizacionId;
        public Int32 CotizacionId { get { return _CotizacionId; } set { _CotizacionId = value; } }

        Int32 _AreaNegocioId;
        public Int32 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }

        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        Int32 _ItemId;
        public Int32 ItemId { get { return _ItemId; } set { _ItemId = value; } }

        String _ItemDescripcion;
        [StringLength(200)]
        public String ItemDescripcion { get { return _ItemDescripcion; } set { _ItemDescripcion = value; } }

        Int32 _ItemTipoId;
        public Int32 ItemTipoId { get { return _ItemTipoId; } set { _ItemTipoId = value; } }

        String _ItemTipoDescripcion;
        [StringLength(200)]
        public String ItemTipoDescripcion { get { return _ItemTipoDescripcion; } set { _ItemTipoDescripcion = value; } }

        Int32 _Cantidad;
        public Int32 Cantidad { get { return _Cantidad; } set { _Cantidad= value; } }

        Decimal _Costo;
        public Decimal Costo { get { return _Costo; } set { _Costo = value; } }

        Decimal _Precio;
        public Decimal Precio { get { return _Precio; } set { _Precio = value; } }

        Decimal _Descuento;
        public Decimal Descuento { get { return _Descuento; } set { _Descuento = value; } }

        Int32 _CampaniaId;
        public Int32 CampaniaId { get { return _CampaniaId; } set { _CampaniaId = value; } }

        Int32 _TarifaId;
        public Int32 TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }

        Boolean _Amparada;
        public Boolean Amparada { get { return _Amparada; } set { _Amparada = value; } }

        Decimal _Iva;
        public Decimal Iva { get { return _Iva; } set { _Iva = value; } }

        Decimal _SubTotal;
        public Decimal SubTotal { get { return _SubTotal; } set { _SubTotal= value; } }
    }
}