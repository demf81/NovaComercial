using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Procedimiento
{
    public class DtoProcedimiento : ModeloBase
    {
        public DtoProcedimiento()
        {
            _ProcedimientoDescripcion = string.Empty;
        }


        Int32 _ProcedimientoId;
        public Int32 ProcedimientoId { get { return _ProcedimientoId; } set { _ProcedimientoId = value; } }

        String _ProcedimientoDescripcion;
        [StringLength(200)]
        public String ProcedimientoDescripcion { get { return _ProcedimientoDescripcion; } set { _ProcedimientoDescripcion = value; } }

        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        Decimal _Costo;
        public Decimal Costo { get { return _Costo; } set { _Costo = value; } }

        Decimal _PorcentajeAnticipo;
        public Decimal PorcentajeAnticipo { get { return _PorcentajeAnticipo; } set { _PorcentajeAnticipo = value; } }
    }
}