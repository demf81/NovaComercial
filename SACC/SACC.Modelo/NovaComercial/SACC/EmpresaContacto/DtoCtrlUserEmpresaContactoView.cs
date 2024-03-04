using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.EmpresaContacto
{
    public class DtoCtrlUserEmpresaContactoView
    {
        public DtoCtrlUserEmpresaContactoView()
        {
            _NombreCompleto          = String.Empty;
            _ContactoTipoDescripcion = String.Empty;
            _DepartamentoDescripcion = String.Empty;
            _CorreoElectronico       = String.Empty;
        }


        Int32 _EmpresaContactoId;
        public Int32 EmpresaContactoId { get { return _EmpresaContactoId; } set { _EmpresaContactoId = value; } }

        String _NombreCompleto;
        [StringLength(200)]
        public String NombreCompleto { get { return _NombreCompleto; } set { _NombreCompleto = value; } }

        Int64 _Telefono;
        public Int64 Telefono { get { return _Telefono; } set { _Telefono = value; } }

        Int16 _Extensionn;
        public Int16 Extension { get { return _Extensionn; } set { _Extensionn = value; } }

        String _DepartamentoDescripcion;
        [StringLength(100)]
        public String DepartamentoDescripcion { get { return _DepartamentoDescripcion; } set { _DepartamentoDescripcion = value; } }

        String _ContactoTipoDescripcion;
        [StringLength(100)]
        public String ContactoTipoDescripcion { get { return _ContactoTipoDescripcion; } set { _ContactoTipoDescripcion = value; } }

        String _CorreoElectronico;
        [StringLength(100)]
        public String CorreoElectronico { get { return _CorreoElectronico; } set { _CorreoElectronico = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}