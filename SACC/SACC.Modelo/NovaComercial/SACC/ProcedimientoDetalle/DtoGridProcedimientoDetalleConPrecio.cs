using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.ProcedimientoDetalle
{
    public class DtoGridProcedimientoDetalleConPrecio
    {
        public DtoGridProcedimientoDetalleConPrecio()
        {
            _ProcedimientoDetalleDescripcion = String.Empty;
        }


        Int32 _ProcedimientoDetalleId;
        public Int32 ProcedimientoDetalleId { get { return _ProcedimientoDetalleId; } set { _ProcedimientoDetalleId = value; } }

        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        String _ServicioPartidaId;
        [StringLength(10)]
        public String ServicioPartidaId { get { return _ServicioPartidaId; } set { _ServicioPartidaId = value; } }

        String _ProcedimientoDetalleDescripcion;
        [StringLength(200)]
        public String ProcedimientoDetalleDescripcion { get { return _ProcedimientoDetalleDescripcion; } set { _ProcedimientoDetalleDescripcion = value; } }

        Int16 _Posicion;
        public Int16 Posicion { get { return _Posicion; } set { _Posicion = value; } }

        String _ClaseOperacion;
        [StringLength(20)]
        public String ClaseOperacion { get { return _ClaseOperacion; } set { _ClaseOperacion = value; } }

        String _ElementoId;
        [StringLength(50)]
        public String ElementoId { get { return _ElementoId; } set { _ElementoId = value; } }

        Decimal _CantidadOriginal;
        public Decimal CantidadOriginal { get { return _CantidadOriginal; } set { _CantidadOriginal = value; } }

        Decimal _Cantidad;
        public Decimal Cantidad { get { return _Cantidad; } set { _Cantidad = value; } }

        String _Unidad;
        [StringLength(50)]
        public String Unidad { get { return _Unidad; } set { _Unidad = value; } }

        Decimal _CantidadBase;
        public Decimal CantidadBase { get { return _CantidadBase; } set { _CantidadBase = value; } }

        Decimal _Tarifa;
        public Decimal Tarifa { get { return _Tarifa; } set { _Tarifa = value; } }

        Int32 _TarifaId;
        public Int32 TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }

        Decimal _Costo;
        public Decimal Costo { get { return _Costo; } set { _Costo = value; } }

        Decimal _Precio;
        public Decimal Precio { get { return _Precio; } set { _Precio = value; } }

        Decimal _PrecioConIva;
        public Decimal PrecioConIva { get { return _PrecioConIva; } set { _PrecioConIva = value; } }

        Decimal _Iva;
        public Decimal Iva { get { return _Iva; } set { _Iva = value; } }

        Decimal _SubTotal;
        public Decimal SubTotal { get { return _SubTotal; } set { _SubTotal = value; } }

        Decimal _SubTotalConIva;
        public Decimal SubTotalConIva { get { return _SubTotalConIva; } set { _SubTotalConIva = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }

        Boolean _Seleccionado;
        public Boolean Seleccionado { get { return _Seleccionado; } set { _Seleccionado = value; } }
    }
}