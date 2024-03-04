using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Empresa
{
    public class DtoGridEmpresa
    {
        public DtoGridEmpresa()
        {
            _EmpresaDescripcion = string.Empty;
        }
        

        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }
        
        String _EmpresaDescripcion;
        [StringLength(200)]
        public String EmpresaDescripcion { get { return _EmpresaDescripcion; } set { _EmpresaDescripcion = value; } }

        String _RFC;
        [StringLength(20)]
        public String RFC { get { return _RFC; } set { _RFC = value; } }

        Int32 _Telefono;
        public Int32 Telefono { get { return _Telefono; } set { _Telefono = value; } }

        String _CorreoElectronico;
        [StringLength(100)]
        public String CorreoElectronico { get { return _CorreoElectronico; } set { _CorreoElectronico = value; } }

        Int32 _Poblacion;
        public Int32 Poblacion { get { return _Poblacion; } set { _Poblacion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}