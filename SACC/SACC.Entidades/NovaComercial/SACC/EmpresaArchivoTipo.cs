using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class EmpresaArchivoTipo : EntidadBase
    {
        public EmpresaArchivoTipo()
        {
            _EmpresaArchivoTipoDescripcion = string.Empty;
        }


        Int16 _EmpresaArchivoTipoId;
        public Int16 EmpresaArchivoTipoId { get { return _EmpresaArchivoTipoId; } set { _EmpresaArchivoTipoId = value; } }

        String _EmpresaArchivoTipoDescripcion;
        [StringLength(200)]
        public String EmpresaArchivoTipoDescripcion { get { return _EmpresaArchivoTipoDescripcion; } set { _EmpresaArchivoTipoDescripcion = value; } }
    }
}