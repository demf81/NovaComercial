using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.EmpresaDocumentoTipo
{
    public class DtoEmpresaDocumentoTipo : ModeloBase
    {
        public DtoEmpresaDocumentoTipo()
        {
            _EmpresaDocumentoTipoDescripcion = String.Empty;
        }


        Int16 _EmpresaDocumentoTipoId;
        public Int16 EmpresaDocumentoTipoId { get { return _EmpresaDocumentoTipoId; } set { _EmpresaDocumentoTipoId = value; } }

        String _EmpresaDocumentoTipoDescripcion;
        [StringLength(200)]
        public String EmpresaDocumentoTipoDescripcion { get { return _EmpresaDocumentoTipoDescripcion; } set { _EmpresaDocumentoTipoDescripcion = value; } }
    }
}