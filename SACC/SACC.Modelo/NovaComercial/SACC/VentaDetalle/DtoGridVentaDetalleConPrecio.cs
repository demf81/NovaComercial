using System;


namespace SACC.Modelo.NovaComercial.SACC.VentaDetalle
{
    public class DtoGridVentaDetalleConPrecio : DtoGridVentaDetalle
    {
        public DtoGridVentaDetalleConPrecio()
        {

        }


        //Int32 _VentaDetalleId;
        //public Int32 VentaDetalleId { get { return _VentaDetalleId; } set { _VentaDetalleId = value; } }

        //Int32 _VentaId;
        //public Int32 VentaId { get { return _VentaId; } set { _VentaId = value; } }

        //Int32 _AreaNegocioId;
        //public Int32 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }

        //Int32 _ServicioId;
        //public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        //Int32 _ItemId;
        //public Int32 ItemId { get { return _ItemId; } set { _ItemId = value; } }

        //String _ItemDescripcion;
        //[StringLength(200)]
        //public String ItemDescripcion { get { return _ItemDescripcion; } set { _ItemDescripcion = value; } }

        //Int32 _ItemTipoId;
        //public Int32 ItemTipoId { get { return _ItemTipoId; } set { _ItemTipoId = value; } }

        //String _ItemTipoDescripcion;
        //[StringLength(200)]
        //public String ItemTipoDescripcion { get { return _ItemTipoDescripcion; } set { _ItemTipoDescripcion = value; } }

        //Int32 _Cantidad;
        //public Int32 Cantidad { get { return _Cantidad; } set { _Cantidad = value; } }

        //Decimal _Costo;
        //public Decimal Costo { get { return _Costo; } set { _Costo = value; } }

        //Decimal _Precio;
        //public Decimal Precio { get { return _Precio; } set { _Precio = value; } }

        //Decimal _PrecioConIva;
        //public Decimal PrecioConIva { get { return _PrecioConIva; } set { _PrecioConIva = value; } }

        //Decimal _Descuento;
        //public Decimal Descuento { get { return _Descuento; } set { _Descuento = value; } }

        //Int32 _CampaniaId;
        //public Int32 CampaniaId { get { return _CampaniaId; } set { _CampaniaId = value; } }

        //Int32 _TarifaId;
        //public Int32 TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }

        //Boolean _Amparada;
        //public Boolean Amparada { get { return _Amparada; } set { _Amparada = value; } }

        //Decimal _Iva;
        //public Decimal Iva { get { return _Iva; } set { _Iva = value; } }

        //Decimal _SubTotal;
        //public Decimal SubTotal { get { return _SubTotal; } set { _SubTotal = value; } }

        Decimal _PrecioConIva;
        public Decimal PrecioConIva { get { return _PrecioConIva; } set { _PrecioConIva = value; } }

        Decimal _SubTotalConIva;
        public Decimal SubTotalConIva { get { return _SubTotalConIva; } set { _SubTotalConIva = value; } }

        Decimal _Total;
        public Decimal Total { get { return _Total; } set { _Total = value; } }
    }
}