using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.FrecuenciaPago
{
    public class DtoComboFrecuenciaPago
    {
        public DtoComboFrecuenciaPago()
        {
            _FrecuenciaPagoDescripcion = String.Empty;
        }


        Int16 _FrecuenciaPagoId;
        public Int16 FrecuenciaPagoId { get { return _FrecuenciaPagoId; } set { _FrecuenciaPagoId = value; } }

        String _FrecuenciaPagoDescripcion;
        [StringLength(200)]
        public String FrecuenciaPagoDescripcion { get { return _FrecuenciaPagoDescripcion; } set { _FrecuenciaPagoDescripcion = value; } }
    }
}