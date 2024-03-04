using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.EmpresaDocumento
{
    public class DtoGridEmpresaDocumento
    {
        public DtoGridEmpresaDocumento()
        {
            
        }


        Int32 _EmpresaDocumentoId;
        public Int32 EmpresaDocumentoId { get { return _EmpresaDocumentoId; } set { _EmpresaDocumentoId = value; } }

        String _EmpresaDocumentoTipoDescripcion;
        public String EmpresaDocumentoTipoDescripcion { get { return _EmpresaDocumentoTipoDescripcion; } set { _EmpresaDocumentoTipoDescripcion = value; } }

        String _EmpresaArchivoTipoDescripcion;
        public String EmpresaArchivoTipoDescripcion { get { return _EmpresaArchivoTipoDescripcion; } set { _EmpresaArchivoTipoDescripcion = value; } }

        String _NombreArchivo;
        public String NombreArchivo { get { return _NombreArchivo; } set { _NombreArchivo = value; } }

        //bool _Activo;
        //public bool Activo { get { return _Activo; } set { _Activo = value; } }

        String _FechaCreacion;
        public String FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}