using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    class MetodoPago : EntidadBase
    {
        public MetodoPago()
        {
            _MetodoPagoDescripcion = string.Empty;
        }


        Int16 _MetodoPagoId;
        public Int16 MetodoPagoId { get { return _MetodoPagoId; } set { _MetodoPagoId = value; } }

        String _MetodoPagoDescripcion;
        [StringLength(200)]
        public String MetodoPagoDescripcion { get { return _MetodoPagoDescripcion; } set { _MetodoPagoDescripcion = value; } }
    }
}