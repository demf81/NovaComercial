using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.EmpresaContacto
{
    public class DtoGridEmpresaContacto
    {
        public DtoGridEmpresaContacto()
        {
            _NombreContacto          = string.Empty;
            _DepartamentoDescripcion = string.Empty;
            _CorreoElectronico       = string.Empty;
        }


        Int32 _EmpresaContactoId;
        public Int32 EmpresaContactoId { get { return _EmpresaContactoId; } set { _EmpresaContactoId = value; } }

        String _NombreContacto;
        [StringLength(200)]
        public String NombreContacto { get { return _NombreContacto; } set { _NombreContacto = value; } }

        String _DepartamentoDescripcion;
        [StringLength(100)]
        public String DepartamentoDescripcion { get { return _DepartamentoDescripcion; } set { _DepartamentoDescripcion = value; } }

        Int32 _Telefono;
        public Int32 Telefono { get { return _Telefono; } set { _Telefono = value; } }

        String _ContactoTipo;
        [StringLength(100)]
        public String ContactoTipo { get { return _ContactoTipo; } set { _ContactoTipo = value; } }

        Int16 _Extension;
        public Int16 Extension { get { return _Extension; } set { _Extension = value; } }

        String _CorreoElectronico;
        [StringLength(100)]
        public String CorreoElectronico { get { return _CorreoElectronico; } set { _CorreoElectronico = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}