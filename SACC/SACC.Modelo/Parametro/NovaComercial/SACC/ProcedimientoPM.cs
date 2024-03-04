using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class ProcedimientoPM : ModeloBasePM
    {
        public ProcedimientoPM()
        {
            _ProcedimientoId          = 0;
            _ProcedimientoDescripcion = String.Empty;

        }


        Int32 _ProcedimientoId;
        public Int32 ProcedimientoId { get { return _ProcedimientoId; } set { _ProcedimientoId = value; } }

        String _ProcedimientoDescripcion;
        [StringLength(200)]
        public String ProcedimientoDescripcion { get { return _ProcedimientoDescripcion; } set { _ProcedimientoDescripcion = value; } }
    }
}