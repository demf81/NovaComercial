using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class FormaPago : EntidadBase
    {
        public FormaPago()
        {
            _FormaPagoDescripcion = string.Empty;
        }


        Int16 _FormaPagoId;
        public Int16 FormaPagoId { get { return _FormaPagoId; } set { _FormaPagoId = value; } }

        String _FormaPagoDescripcion;
        [StringLength(200)]
        public String FormaPagoDescripcion { get { return _FormaPagoDescripcion; } set { _FormaPagoDescripcion = value; } }
    }
}