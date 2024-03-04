using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.CoberturaCondicionTipo
{
    public class DtoComboCoberturaCondicionTipo
    {
        public DtoComboCoberturaCondicionTipo()
        {
            _CoberturaCondicionTipoDescripcion = String.Empty;
        }


        Int16 _CoberturaCondicionTipoId;
        public Int16 CoberturaCondicionTipoId { get { return _CoberturaCondicionTipoId; } set { _CoberturaCondicionTipoId = value; } }

        String _CoberturaCondicionTipoDescripcion;
        [StringLength(200)]
        public String CoberturaCondicionTipoDescripcion { get { return _CoberturaCondicionTipoDescripcion; } set { _CoberturaCondicionTipoDescripcion = value; } }
    }
}