using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.ProcedimientoDetalle
{
    public class DtoGridProcedimientoDetalle
    {
        public DtoGridProcedimientoDetalle()
        {
            _ProcedimientoDetalleDescripcion = String.Empty;
        }


        Int32 _ProcedimientoDetalleId;
        public Int32 ProcedimientoDetalleId { get { return _ProcedimientoDetalleId; } set { _ProcedimientoDetalleId = value; } }

        Int16 _Posicion;
        public Int16 Posicion { get { return _Posicion; } set { _Posicion = value; } }

        String _ClaseOperacion;
        [StringLength(20)]
        public String ClaseOperacion { get { return _ClaseOperacion; } set { _ClaseOperacion = value; } }

        String _ElementoId;
        [StringLength(50)]
        public String ElementoId { get { return _ElementoId; } set { _ElementoId = value; } }

        String _ProcedimientoDetalleDescripcion;
        [StringLength(200)]
        public String ProcedimientoDetalleDescripcion { get { return _ProcedimientoDetalleDescripcion; } set { _ProcedimientoDetalleDescripcion = value; } }

        Decimal _Cantidad;
        public Decimal Cantidad { get { return _Cantidad; } set { _Cantidad = value; } }

        String _Unidad;
        [StringLength(50)]
        public String Unidad { get { return _Unidad; } set { _Unidad = value; } }

        Decimal _Costo;
        public Decimal Costo { get { return _Costo; } set { _Costo = value; } }

        Decimal _SubTotal;
        public Decimal SubTotal { get { return _SubTotal; } set { _SubTotal = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}