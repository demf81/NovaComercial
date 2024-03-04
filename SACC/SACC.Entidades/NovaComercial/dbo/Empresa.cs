using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class Empresa : EntidadBase
    {
        public Empresa()
        {
            _EmpresaDescripcion = string.Empty;
        }


        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }

        String _EmpresaDescripcion;
        [StringLength(200)]
        public String EmpresaDescripcion { get { return _EmpresaDescripcion; } set { _EmpresaDescripcion = value; } }
    }
}