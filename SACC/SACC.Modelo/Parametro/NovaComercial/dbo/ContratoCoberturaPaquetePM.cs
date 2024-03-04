using System;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class ContratoCoberturaPaquetePM : ModeloBasePM
    {
        public ContratoCoberturaPaquetePM()
        {
            _ContratoCoberturaPaqueteId = 0;
            _ContratoCoberturaId        = 0;
            _ContratoId                 = -1;
            _PaqueteId                  = -1;
        }


        Int32 _ContratoCoberturaPaqueteId;
        public Int32 ContratoCoberturaPaqueteId { get { return _ContratoCoberturaPaqueteId; } set { _ContratoCoberturaPaqueteId = value; } }

        Int32 _ContratoCoberturaId;
        public Int32 ContratoCoberturaId { get { return _ContratoCoberturaId; } set { _ContratoCoberturaId = value; } }

        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }
    }
}