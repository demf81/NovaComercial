using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.ContratoTipo
{
    public class DtoComboContratoTipo
    {
        public DtoComboContratoTipo()
        {
            _ContratoTipoDescripcion = String.Empty;
        }


        Int32 _ContratoTipoId;
        public Int32 ContratoTipoId { get { return _ContratoTipoId; } set { _ContratoTipoId = value; } }

        String _ContratoTipoDescripcion;
        [StringLength(200)]
        public String ContratoTipoDescripcion { get { return _ContratoTipoDescripcion; } set { _ContratoTipoDescripcion = value; } }
    }
}