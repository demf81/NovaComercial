using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class FormaPagoPM : ModeloBasePM
    {
        public FormaPagoPM()
        {
            _FormaPagoId          = 0;
            _FormaPagoDescripcion = String.Empty;
        }


        Int32 _FormaPagoId;
        public Int32 FormaPagoId { get { return _FormaPagoId; } set { _FormaPagoId = value; } }

        String _FormaPagoDescripcion;
        [StringLength(200)]
        public String FormaPagoDescripcion { get { return _FormaPagoDescripcion; } set { _FormaPagoDescripcion = value; } }
    }
}