using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.CoberturaCopagoTipo
{
    public class DtoComboCoberturaCopagoTipo
    {
        public DtoComboCoberturaCopagoTipo()
        {
            _CoberturaCopagoTipoDescripcion = String.Empty;
        }


        Int16 _CoberturaCopagoTipoId;
        public Int16 CoberturaCopagoTipoId { get { return _CoberturaCopagoTipoId; } set { _CoberturaCopagoTipoId = value; } }

        string _CoberturaCopagoTipoDescripcion;
        [StringLength(200)]
        public String CoberturaCopagoTipoDescripcion { get { return _CoberturaCopagoTipoDescripcion; } set { _CoberturaCopagoTipoDescripcion = value; } }
    }
}