using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Contrato
{
    public class DtoComboContrato
    {
        public DtoComboContrato()
        {
            _ContratoDescripcion = String.Empty;
        }


        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        String _ContratoDescripcion;
        [StringLength(200)]
        public String ContratoDescripcion { get { return _ContratoDescripcion; } set { _ContratoDescripcion = value; } }
    }
}