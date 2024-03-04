using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class EmpresaDocumentoTipo : EntidadBase
    {
        public EmpresaDocumentoTipo()
        {
            _EmpresaDocumentoTipoDescripcion = string.Empty;
        }


        Int16 _EmpresaDocumentoTipoId;
        public Int16 EmpresaDocumentoTipoId { get { return _EmpresaDocumentoTipoId; } set { _EmpresaDocumentoTipoId = value; } }

        String _EmpresaDocumentoTipoDescripcion;
        [StringLength(200)]
        public String EmpresaDocumentoTipoDescripcion { get { return _EmpresaDocumentoTipoDescripcion; } set { _EmpresaDocumentoTipoDescripcion = value; } }
    }
}