using System;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class ContratoCoberturaPaqueteCondicionPM : ModeloBasePM
    {
        public ContratoCoberturaPaqueteCondicionPM()
        {
            _ContratoCoberturaPaqueteCondicionId = 0;
            _ContratoCoberturaPaqueteId          = -1;
        }


        Int32 _ContratoCoberturaPaqueteCondicionId;
        public Int32 ContratoCoberturaPaqueteCondicionId { get { return _ContratoCoberturaPaqueteCondicionId; } set { _ContratoCoberturaPaqueteCondicionId = value; } }

        Int32 _ContratoCoberturaPaqueteId;
        public Int32 ContratoCoberturaPaqueteId { get { return _ContratoCoberturaPaqueteId; } set { _ContratoCoberturaPaqueteId = value; } }
    }
}