using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class EmpresaDocumento : EntidadBase
    {
        public EmpresaDocumento()
        {
            _NombreArchivo = String.Empty;
            _Extension     = String.Empty;
        }


        Int32 _EmpresaDocumentoId;
        public Int32 EmpresaDocumentoId { get { return _EmpresaDocumentoId; } set { _EmpresaDocumentoId = value; } }

        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }

        Int32 _EmpresaDocumentoTipoId;
        public Int32 EmpresaDocumentoTipoId { get { return _EmpresaDocumentoTipoId; } set { _EmpresaDocumentoTipoId = value; } }

        Int32 _EmpresaArchivoTipoId;
        public Int32 EmpresaArchivoTipoId { get { return _EmpresaArchivoTipoId; } set { _EmpresaArchivoTipoId = value; } }

        Byte[] _Archivo;
        public Byte[] Archivo { get { return _Archivo; } set { _Archivo = value; } }

        String _NombreArchivo;
        [StringLength(150)]
        public String NombreArchivo { get { return _NombreArchivo; } set { _NombreArchivo = value; } }

        String _Extension;
        [StringLength(10)]
        public String Extension { get { return _Extension; } set { _Extension = value; } }
    }
}