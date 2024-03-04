using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class VentaUnitariaDetalleTipo : EntidadBase
    {
        public VentaUnitariaDetalleTipo()
        {
            _VentaUnitariaDetalleTipoDescripcion = string.Empty;
        }


        Int32 _VentaUnitariaDetalleTipoId;
        public Int32 VentaUnitariaDetalleTipoId { get { return _VentaUnitariaDetalleTipoId; } set { _VentaUnitariaDetalleTipoId = value; } }


        String _VentaUnitariaDetalleTipoDescripcion;
        [StringLength(100)]
        public String VentaUnitariaDetalleTipoDescripcion { get { return _VentaUnitariaDetalleTipoDescripcion; } set { _VentaUnitariaDetalleTipoDescripcion = value; } }
    }
}