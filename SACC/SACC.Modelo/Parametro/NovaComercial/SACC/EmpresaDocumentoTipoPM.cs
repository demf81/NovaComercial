using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class EmpresaDocumentoTipoPM : ModeloBasePM
    {
        public EmpresaDocumentoTipoPM()
        {
            _EmpresaDocumentoTipoId          = 0;
            _EmpresaDocumentoTipoDescripcion = String.Empty;
        }


        Int32 _EmpresaDocumentoTipoId;
        public Int32 EmpresaDocumentoTipoId { get { return _EmpresaDocumentoTipoId; } set { _EmpresaDocumentoTipoId = value; } }

        String _EmpresaDocumentoTipoDescripcion;
        [StringLength(200)]
        public String EmpresaDocumentoTipoDescripcion { get { return _EmpresaDocumentoTipoDescripcion; } set { _EmpresaDocumentoTipoDescripcion = value; } }
    }
}