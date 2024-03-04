using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.EmpresaArchivoTipo
{
    public class DtoEmpresaArchivoTipo : ModeloBase
    {
        public DtoEmpresaArchivoTipo()
        {
            _EmpresaArchivoTipoDescripcion = String.Empty;
        }


        Int16 _EmpresaArchivoTipoId;
        public Int16 EmpresaArchivoTipoId { get { return _EmpresaArchivoTipoId; } set { _EmpresaArchivoTipoId = value; } }

        String _EmpresaArchivoTipoDescripcion;
        [StringLength(200)]
        public String EmpresaArchivoTipoDescripcion { get { return _EmpresaArchivoTipoDescripcion; } set { _EmpresaArchivoTipoDescripcion = value; } }
    }
}