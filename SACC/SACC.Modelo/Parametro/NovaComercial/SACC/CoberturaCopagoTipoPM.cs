using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class CoberturaCopagoTipoPM : ModeloBasePM
    {
        public CoberturaCopagoTipoPM()
        {
            _CoberturaCopagoTipoId          = 0;
            _CoberturaCopagoTipoDescripcion = String.Empty;
        }


        Int32 _CoberturaCopagoTipoId;
        public Int32 CoberturaCopagoTipoId { get { return _CoberturaCopagoTipoId; } set { _CoberturaCopagoTipoId = value; } }

        String _CoberturaCopagoTipoDescripcion;
        [StringLength(200)]
        public String CoberturaCopagoTipoDescripcion { get { return _CoberturaCopagoTipoDescripcion; } set { _CoberturaCopagoTipoDescripcion = value; } }
    }
}