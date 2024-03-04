using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    class VentaMotivoCancelacionTipo
    {
        public VentaMotivoCancelacionTipo()
        {
            _VentaMotivoCancelacionTipoDescripcion = string.Empty;
        }


        Int16 _VentaMotivoCancelacionTipoId;
        public Int16 VentaMotivoCancelacionTipoId { get { return _VentaMotivoCancelacionTipoId; } set { _VentaMotivoCancelacionTipoId = value; } }

        String _VentaMotivoCancelacionTipoDescripcion;
        [StringLength(150)]
        public String VentaMotivoCancelacionTipoDescripcion { get { return _VentaMotivoCancelacionTipoDescripcion; } set { _VentaMotivoCancelacionTipoDescripcion = value; } }
    }
}