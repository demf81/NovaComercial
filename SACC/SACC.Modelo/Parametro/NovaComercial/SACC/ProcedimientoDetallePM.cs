using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class ProcedimientoDetallePM : ModeloBasePM
    {
        public ProcedimientoDetallePM()
        {
            _ProcedimientoDetalleId          = 0;
            _ProcedimientoDetalleDescripcion = String.Empty;

        }


        Int32 _ProcedimientoDetalleId;
        public Int32 ProcedimientoDetalleId { get { return _ProcedimientoDetalleId; } set { _ProcedimientoDetalleId = value; } }

        Int32 _ProcedimientoId;
        public Int32 ProcedimientoId { get { return _ProcedimientoId; } set { _ProcedimientoId = value; } }

        String _ProcedimientoDetalleDescripcion;
        [StringLength(200)]
        public String ProcedimientoDetalleDescripcion { get { return _ProcedimientoDetalleDescripcion; } set { _ProcedimientoDetalleDescripcion = value; } }
    }
}