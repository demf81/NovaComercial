using System;


namespace SACC.Modelo.NovaComercial.SACC.MembresiaContrato
{
    public class DtoMembresiaContrato : ModeloBase
    {
        public DtoMembresiaContrato()
        {

        }
        

        Int32 _MembresiaContratoId;
        public Int32 MembresiaContratoId { get { return _MembresiaContratoId; } set { _MembresiaContratoId = value; } }
        
        Int32 _MembresiaId;
        public Int32 MembresiaId { get { return _MembresiaId; } set { _MembresiaId = value; } }
        
        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }
    }
}