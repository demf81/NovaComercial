﻿using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.CotizacionProcedimientoDetalle
{
    public class DtoGridCotizacionProcedimientoDetalle
    {
        public DtoGridCotizacionProcedimientoDetalle()
        {
            _CotizacionProcedimientoDetalleId = 0;
            _CotizacionDetalleId              = 0;
            _CotizacionId                     = 0;
            _ServicioId                       = 0;
            _Posicion                         = 0;
            _CantidadOriginal                 = 0;
            _Cantidad                         = 0;
            _CantidadBase                     = 0;
            _Tarifa                           = 0;
            _Costo                            = 0;
            _Precio                           = 0;
            _Iva                              = 0;
            _TarifaId                         = 0;
            _SubTotal                         = 0;
        }


        Int32 _CotizacionProcedimientoDetalleId;
        public Int32 CotizacionProcedimientoDetalleId { get { return _CotizacionProcedimientoDetalleId; } set { _CotizacionProcedimientoDetalleId = value; } }

        Int32 _CotizacionDetalleId;
        public Int32 CotizacionDetalleId { get { return _CotizacionDetalleId; } set { _CotizacionDetalleId = value; } }

        Int32 _CotizacionId;
        public Int32 CotizacionId { get { return _CotizacionId; } set { _CotizacionId = value; } }

        Int32 _ProcedimientoId;
        public Int32 ProcedimientoId { get { return _ProcedimientoId; } set { _ProcedimientoId = value; } }

        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        String _ServicioPartidaId;
        [StringLength(20)]
        public String ServicioPartidaId { get { return _ServicioPartidaId; } set { _ServicioPartidaId = value; } }

        String _ProcedimientoDetalleDescripcion;
        [StringLength(200)]
        public String ProcedimientoDetalleDescripcion { get { return _ProcedimientoDetalleDescripcion; } set { _ProcedimientoDetalleDescripcion = value; } }

        Int32 _Posicion;
        public Int32 Posicion { get { return _Posicion; } set { _Posicion = value; } }

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
        [StringLength(20)]
        public String Unidad { get { return _Unidad; } set { _Unidad = value; } }

        Decimal _CantidadBase;
        public Decimal CantidadBase { get { return _CantidadBase; } set { _CantidadBase = value; } }

        Decimal _Tarifa;
        public Decimal Tarifa { get { return _Tarifa; } set { _Tarifa = value; } }

        Decimal _Costo;
        public Decimal Costo { get { return _Costo; } set { _Costo = value; } }

        Decimal _Precio;
        public Decimal Precio { get { return _Precio; } set { _Precio = value; } }

        Decimal _Iva;
        public Decimal Iva { get { return _Iva; } set { _Iva = value; } }

        Int32 _TarifaId;
        public Int32 TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }

        Decimal _SubTotal;
        public Decimal SubTotal { get { return _SubTotal; } set { _SubTotal = value; } }

        Boolean _Seleccionado;
        public Boolean Seleccionado { get { return _Seleccionado; } set { _Seleccionado = value; } }
    }
}