using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.helper
{
    public class Articulo
    {
        public Articulo()
        {
            _ArticuloDescripcion = string.Empty;
        }


        Int32 _VentaUnitariaDetalleId;
        public Int32 VentaUnitariaDetalleId { get { return _VentaUnitariaDetalleId; } set { _VentaUnitariaDetalleId = value; } }


        Int32 _VentaUnitariaId;
        public Int32 VentaUnitariaId { get { return _VentaUnitariaId; } set { _VentaUnitariaId = value; } }


        Int32 _VentaUnitariaDetalleTipoId;
        public Int32 VentaUnitariaDetalleTipoId { get { return _VentaUnitariaDetalleTipoId; } set { _VentaUnitariaDetalleTipoId = value; } }


        Int32 _ItemId;
        public Int32 ItemId { get { return _ItemId; } set { _ItemId = value; } }


        Int32 _Cantidad;
        public Int32 Cantidad { get { return _Cantidad; } set { _Cantidad = value; } }


        String _ArticuloDescripcion;
        [StringLength(250)]
        public String ArticuloDescripcion { get { return _ArticuloDescripcion; } set { _ArticuloDescripcion = value; } }


        String _ArticuloTipoDescripcion;
        [StringLength(250)]
        public String ArticuloTipoDescripcion { get { return _ArticuloTipoDescripcion; } set { _ArticuloTipoDescripcion = value; } }


        Decimal? _Precio;
        public Decimal? Precio { get { return _Precio; } set { _Precio = value; } }


        Decimal? _Subtotal;
        public Decimal? Subtotal { get { return _Subtotal; } set { _Subtotal = value; } }


        Boolean _Amparado;
        public Boolean Amparado { get { return _Amparado; } set { _Amparado = value; } }
    }
}