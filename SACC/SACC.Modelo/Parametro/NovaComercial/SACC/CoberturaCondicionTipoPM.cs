using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class CoberturaCondicionTipoPM : ModeloBasePM
    {
        public CoberturaCondicionTipoPM()
        {
            _CoberturaCondicionTipoId          = 0;
            _CoberturaCondicionTipoDescripcion = String.Empty;
        }


        Int32 _CoberturaCondicionTipoId;
        public Int32 CoberturaCondicionTipoId { get { return _CoberturaCondicionTipoId; } set { _CoberturaCondicionTipoId = value; } }

        String _CoberturaCondicionTipoDescripcion;
        [StringLength(200)]
        public String CoberturaCondicionTipoDescripcion { get { return _CoberturaCondicionTipoDescripcion; } set { _CoberturaCondicionTipoDescripcion = value; } }
    }
}