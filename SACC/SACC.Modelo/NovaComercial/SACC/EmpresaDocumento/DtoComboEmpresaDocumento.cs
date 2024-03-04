using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.EmpresaDocumento
{
    public class DtoComboEmpresaDocumento
    {
        public DtoComboEmpresaDocumento()
        {

        }


        Int32 _EmpresaDocumentoId;
        public Int32 EmpresaDocumentoId { get { return _EmpresaDocumentoId; } set { _EmpresaDocumentoId = value; } }

        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }

        String _EmpresaDescripcion;
        [StringLength(200)]
        public String EmpresaDescripcion { get { return _EmpresaDescripcion; } set { _EmpresaDescripcion = value; } }


        Int32 _DocumentoTipoId;
        public Int32 DocumentoTipoId { get { return _DocumentoTipoId; } set { _DocumentoTipoId = value; } }

        Int32 _ArchivoTipoId;
        public Int32 ArchivoTipoId { get { return _ArchivoTipoId; } set { _ArchivoTipoId = value; } }

        Byte _Archivo;
        public Byte Archivo { get { return _Archivo; } set { _Archivo = value; } }
    }
}