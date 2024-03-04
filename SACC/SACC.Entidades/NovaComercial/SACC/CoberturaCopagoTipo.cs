using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class CoberturaCopagoTipo : EntidadBase
    {
        public CoberturaCopagoTipo()
        {
            _CoberturaCopagoTipoDescripcion = string.Empty;
        }


        Int16 _CoberturaCopagoTipoId;
        public Int16 CoberturaCopagoTipoId { get { return _CoberturaCopagoTipoId; } set { _CoberturaCopagoTipoId = value; } }

        String _CoberturaCopagoTipoDescripcion;
        [StringLength(200)]
        public String CoberturaCopagoTipoDescripcion { get { return _CoberturaCopagoTipoDescripcion; } set { _CoberturaCopagoTipoDescripcion = value; } }
    }
}