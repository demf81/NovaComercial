using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class EmpresaContacto : EntidadBase
    {
        public EmpresaContacto()
        {
            _Nombre                  = String.Empty;
            _Paterno                 = String.Empty;
            _Materno                 = String.Empty;
            _DepartamentoDescripcion = String.Empty;
            _CorreoElectronico       = String.Empty;
        }


        Int32 _EmpresaContactoId;
        public Int32 EmpresaContactoId { get { return _EmpresaContactoId; } set { _EmpresaContactoId = value; } }

        Int32 _ContactoTipoId;
        public Int32 ContactoTipoId { get { return _ContactoTipoId; } set { _ContactoTipoId = value; } }

        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }

        String _Nombre;
        [StringLength(50)]
        public String Nombre { get { return _Nombre; } set { _Nombre = value; } }

        String _Paterno;
        [StringLength(50)]
        public String Paterno { get { return _Paterno; } set { _Paterno = value; } }

        String _Materno;
        [StringLength(50)]
        public String Materno { get { return _Materno; } set { _Materno = value; } }

        String _DepartamentoDescripcion;
        [StringLength(100)]
        public String DepartamentoDescripcion { get { return _DepartamentoDescripcion; } set { _DepartamentoDescripcion = value; } }

        Int64 _Telefono;
        public Int64 Telefono { get { return _Telefono; } set { _Telefono = value; } }

        Int16 _Extension;
        public Int16 Extension { get { return _Extension; } set { _Extension = value; } }

        String _CorreoElectronico;
        [StringLength(100)]
        public String CorreoElectronico { get { return _CorreoElectronico; } set { _CorreoElectronico = value; } }
    }
}