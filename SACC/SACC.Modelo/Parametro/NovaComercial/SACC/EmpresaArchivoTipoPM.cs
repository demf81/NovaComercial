using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class EmpresaArchivoTipoPM : ModeloBasePM
    {
        public EmpresaArchivoTipoPM()
        {
            _EmpresaArchivoTipoId          = 0;
            _EmpresaArchivoTipoDescripcion = String.Empty;
        }


        Int32 _EmpresaArchivoTipoId;
        public Int32 EmpresaArchivoTipoId { get { return _EmpresaArchivoTipoId; } set { _EmpresaArchivoTipoId = value; } }

        String _EmpresaArchivoTipoDescripcion;
        [StringLength(200)]
        public String EmpresaArchivoTipoDescripcion { get { return _EmpresaArchivoTipoDescripcion; } set { _EmpresaArchivoTipoDescripcion = value; } }
    }
}