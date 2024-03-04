using System;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class MembresiaContratoPM : ModeloBasePM
    {
        public MembresiaContratoPM()
        {
            _MembresiaContratoId = 0;
            _MembresiaId         = -1;
            _ContratoId          = -1;
        }
        

        Int32 _MembresiaContratoId;
        public Int32 MembresiaContratoId { get { return _MembresiaContratoId; } set { _MembresiaContratoId = value; } }
        
        Int32 _MembresiaId;
        public Int32 MembresiaId { get { return _MembresiaId; } set { _MembresiaId = value; } }
        
        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }
    }
}