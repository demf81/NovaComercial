using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class ContratoTipo : EntidadBase
    {
        public ContratoTipo()
        {
            _ContratoTipoDescripcion = string.Empty;
        }


        Int32 _ContratoTipoId;
        public Int32 ContratoTipoId { get { return _ContratoTipoId; } set { _ContratoTipoId = value; } }

        String _ContratoTipoDescripcion;
        [StringLength(200)]
        public String ContratoTipoDescripcion { get { return _ContratoTipoDescripcion; } set { _ContratoTipoDescripcion = value; } }
    }
}