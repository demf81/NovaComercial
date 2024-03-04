using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.ContratoTipo
{
    public class DtoContratoTipo : ModeloBase
    {
        public DtoContratoTipo()
        {
            _ContratoTipoDescripcion = String.Empty;
        }


        Int16 _ContratoTipoId;
        public Int16 ContratoTipoId { get { return _ContratoTipoId; } set { _ContratoTipoId = value; } }

        String _ContratoTipoDescripcion;
        [StringLength(200)]
        public String ContratoTipoDescripcion { get { return _ContratoTipoDescripcion; } set { _ContratoTipoDescripcion = value; } }
    }
}