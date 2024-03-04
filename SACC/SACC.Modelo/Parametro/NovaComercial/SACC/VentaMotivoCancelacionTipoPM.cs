using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class VentaMotivoCancelacionTipoPM : ModeloBasePM
    {
        public VentaMotivoCancelacionTipoPM()
        {
            _VentaMotivoCancelacionTipoId          = 0;
            _VentaMotivoCancelacionTipoDescripcion = String.Empty;
        }


        Int32 _VentaMotivoCancelacionTipoId;
        public Int32 VentaMotivoCancelacionTipoId { get { return _VentaMotivoCancelacionTipoId; } set { _VentaMotivoCancelacionTipoId = value; } }

        String _VentaMotivoCancelacionTipoDescripcion;
        [StringLength(200)]
        public String VentaMotivoCancelacionTipoDescripcion { get { return _VentaMotivoCancelacionTipoDescripcion; } set { _VentaMotivoCancelacionTipoDescripcion = value; } }
    }
}