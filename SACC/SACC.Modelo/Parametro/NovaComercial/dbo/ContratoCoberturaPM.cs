using System;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class ContratoCoberturaPM : ModeloBasePM
    {
        public ContratoCoberturaPM()
        {
            _ContratoCoberturaId = 0;
            _ContratoId          = 0;
        }


        Int32 _ContratoCoberturaId;
        public Int32 ContratoCoberturaId { get { return _ContratoCoberturaId; } set { _ContratoCoberturaId = value; } }

        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        String _ContratoCoberturaDescripcion;
        public String ContratoCoberturaDescripcion { get { return _ContratoCoberturaDescripcion; } set { _ContratoCoberturaDescripcion = value; } }
    }
}