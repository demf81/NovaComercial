using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.EmpresaTipo
{
    public class DtoComboEmpresaTipo
    {
        public DtoComboEmpresaTipo()
        {
            _EmpresaTipoDescripcion = String.Empty;
        }


        Int16 _EmpresaTipoId;
        public Int16 EmpresaTipoId { get { return _EmpresaTipoId; } set { _EmpresaTipoId = value; } }

        String _EmpresaTipoDescripcion;
        [StringLength(200)]
        public String EmpresaTipoDescripcion { get { return _EmpresaTipoDescripcion; } set { _EmpresaTipoDescripcion = value; } }
    }
}