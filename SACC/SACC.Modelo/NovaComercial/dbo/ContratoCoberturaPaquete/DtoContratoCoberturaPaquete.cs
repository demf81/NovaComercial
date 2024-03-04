using System;


namespace SACC.Modelo.NovaComercial.dbo.ContratoCoberturaPaquete
{
    public class DtoContratoCoberturaPaquete : ModeloBase
    {
        public DtoContratoCoberturaPaquete()
        {

        }


        Int32 _ContratoCoberturaPaqueteId;
        public Int32 ContratoCoberturaPaqueteId { get { return _ContratoCoberturaPaqueteId; } set { _ContratoCoberturaPaqueteId = value; } }

        Int32 _ContratoCoberturaId;
        public Int32 ContratoCoberturaId { get { return _ContratoCoberturaId; } set { _ContratoCoberturaId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { if (value >= 0) _PaqueteId = value; } }
    }
}