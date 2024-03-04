using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.FormaPago
{
    public class DtoComboFormaPago
    {
        public DtoComboFormaPago()
        {
            _FormaPagoDescripcion = String.Empty;
        }


        Int16 _FormaPagoId;
        public Int16 FormaPagoId { get { return _FormaPagoId; } set { _FormaPagoId = value; } }

        String _FormaPagoDescripcion;
        [StringLength(200)]
        public String FormaPagoDescripcion { get { return _FormaPagoDescripcion; } set { _FormaPagoDescripcion = value; } }
    }
}