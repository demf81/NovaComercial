using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.VentaMotivoCancelacionTipo
{
    public class DtoComboVentaMotivoCancelacionTipo
    {
        public DtoComboVentaMotivoCancelacionTipo()
        {
            _VentaMotivoCancelacionTipoDescripcion = String.Empty;
        }


        Int16 _VentaMotivoCancelacionTipoId;
        public Int16 VentaMotivoCancelacionTipoId { get { return _VentaMotivoCancelacionTipoId; } set { _VentaMotivoCancelacionTipoId = value; } }

        String _VentaMotivoCancelacionTipoDescripcion;
        [StringLength(200)]
        public String VentaMotivoCancelacionTipoDescripcion { get { return _VentaMotivoCancelacionTipoDescripcion; } set { _VentaMotivoCancelacionTipoDescripcion = value; } }
    }
}