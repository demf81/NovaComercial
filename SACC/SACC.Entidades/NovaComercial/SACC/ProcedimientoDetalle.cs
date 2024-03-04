using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class ProcedimientoDetalle : EntidadBase
    {
        public ProcedimientoDetalle()
        {
            _ProcedimientoDetalleDescripcion = string.Empty;
        }


        Int32 _ProcedimientoDetalleId;
        public Int32 ProcedimientoDetalleId { get { return _ProcedimientoDetalleId; } set { _ProcedimientoDetalleId = value; } }

        Int32 _ProcedimientoId;
        public Int32 ProcedimientoId { get { return _ProcedimientoId; } set { _ProcedimientoId = value; } }

        Int16 _ServicioId;
        public Int16 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        Int16 _ServicioPartidaId;
        public Int16 ServicioPartidaId { get { return _ServicioPartidaId; } set { _ServicioPartidaId = value; } }

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

        Decimal _Cantidad;
        public Decimal Cantidad { get { return _Cantidad; } set { _Cantidad = value; } }

        String _Unidad;
        [StringLength(20)]
        public String Unidad { get { return _Unidad; } set { _Unidad = value; } }

        Int16 _CantidadBase;
        public Int16 CantidadBase { get { return _CantidadBase; } set { _CantidadBase = value; } }

        Decimal _Tarifa;
        public Decimal Tarifa { get { return _Tarifa; } set { _Tarifa = value; } }

        Decimal _Subtotal;
        public Decimal Subtotal { get { return _Subtotal; } set { _Subtotal = value; } }
    }
}