using System;


namespace SACC.Modelo.NovaComercial.dbo.EmpresaContrato
{
    public class DtoGridEmpresaContrato
    {
        public DtoGridEmpresaContrato()
        {

        }


        Int32 _EmpresaContratoId;
        public Int32 EmpresaContratoId { get { return _EmpresaContratoId; } set { _EmpresaContratoId = value; } }

        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }

        String _EmpresaDescripcion;
        public String EmpresaDescripcion { get { return _EmpresaDescripcion; } set { _EmpresaDescripcion = value; } }

        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        String _ContratoDescripcion;
        public String ContratoDescripcion { get { return _ContratoDescripcion; } set { _ContratoDescripcion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}