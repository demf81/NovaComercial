using System;


namespace SACC.Modelo.NovaComercial.dbo.EmpresaContrato
{
    public class DtoEmpresaContrato : ModeloBasePM
    {
        public DtoEmpresaContrato()
        {

        }


        Int32 _EmpresaContratoId;
        public Int32 EmpresaContratoId { get { return _EmpresaContratoId; } set { _EmpresaContratoId = value; } }
        
        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }
        
        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }
    }
}