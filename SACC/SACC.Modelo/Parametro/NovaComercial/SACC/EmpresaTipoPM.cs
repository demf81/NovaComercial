using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class EmpresaTipoPM : ModeloBasePM
    {
        public EmpresaTipoPM()
        {
            _EmpresaTipoId          = 0;
            _EmpresaTipoDescripcion = String.Empty;
        }


        Int32 _EmpresaTipoId;
        public Int32 EmpresaTipoId { get { return _EmpresaTipoId; } set { _EmpresaTipoId = value; } }

        String _EmpresaTipoDescripcion;
        [StringLength(200)]
        public String EmpresaTipoDescripcion { get { return _EmpresaTipoDescripcion; } set { _EmpresaTipoDescripcion = value; } }
    }
}