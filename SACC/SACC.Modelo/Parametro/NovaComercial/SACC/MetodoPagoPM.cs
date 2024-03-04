using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class MetodoPagoPM : ModeloBasePM
    {
        public MetodoPagoPM()
        {
            _MetodoPagoId          = 0;
            _MetodoPagoDescripcion = String.Empty;
        }


        Int32 _MetodoPagoId;
        public Int32 MetodoPagoId { get { return _MetodoPagoId; } set { _MetodoPagoId = value; } }

        String _MetodoPagoDescripcion;
        [StringLength(200)]
        public String MetodoPagoDescripcion { get { return _MetodoPagoDescripcion; } set { _MetodoPagoDescripcion = value; } }
    }
}