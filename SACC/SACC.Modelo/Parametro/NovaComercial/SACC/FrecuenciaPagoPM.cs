using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class FrecuenciaPagoPM : ModeloBasePM
    {
        public FrecuenciaPagoPM()
        {
            _FrecuenciaPagoId          = 0;
            _FrecuenciaPagoDescripcion = String.Empty;
        }


        Int32 _FrecuenciaPagoId;
        public Int32 FrecuenciaPagoId { get { return _FrecuenciaPagoId; } set { _FrecuenciaPagoId = value; } }

        String _FrecuenciaPagoDescripcion;
        [StringLength(200)]
        public String FrecuenciaPagoDescripcion { get { return _FrecuenciaPagoDescripcion; } set { _FrecuenciaPagoDescripcion = value; } }
    }
}