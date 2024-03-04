using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class EmpresaTipo : EntidadBase
    {
        public EmpresaTipo()
        {
            _EmpresaTipoDescripcion = string.Empty;
        }


        Int16 _EmpresaTipoId;
        public Int16 EmpresaTipoId { get { return _EmpresaTipoId; } set { _EmpresaTipoId = value; } }

        String _EmpresaTipoDescripcion;
        [StringLength(200)]
        public String EmpresaTipoDescripcion { get { return _EmpresaTipoDescripcion; } set { _EmpresaTipoDescripcion = value; } }
    }
}