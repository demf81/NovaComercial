using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class FrecuenciaPago : EntidadBase
    {
        public FrecuenciaPago()
        {
            _FrecuenciaPagoDescripcion = string.Empty;
        }


        Int16 _FrecuenciaPagoId;
        public Int16 FrecuenciaPagoId { get { return _FrecuenciaPagoId; } set { _FrecuenciaPagoId = value; } }

        String _FrecuenciaPagoDescripcion;
        [StringLength(200)]
        public String FrecuenciaPagoDescripcion { get { return _FrecuenciaPagoDescripcion; } set { _FrecuenciaPagoDescripcion = value; } }
    }
}