using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.EmpresaDocumentoTipo
{
    public class DtoGridEmpresaDocumentoTipo
    {
        public DtoGridEmpresaDocumentoTipo()
        {
            _EmpresaDocumentoTipoDescripcion = String.Empty;
        }


        Int32 _EmpresaDocumentoTipoId;
        public Int32 EmpresaDocumentoTipoId { get { return _EmpresaDocumentoTipoId; } set { _EmpresaDocumentoTipoId = value; } }

        String _EmpresaDocumentoTipoDescripcion;
        [StringLength(200)]
        public String EmpresaDocumentoTipoDescripcion { get { return _EmpresaDocumentoTipoDescripcion; } set { _EmpresaDocumentoTipoDescripcion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}