using System;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class PersonaContratoPM : ModeloBasePM
    {
        public PersonaContratoPM()
        {
            _PersonaContratoId   = 0;
            _PersonaId           = 0;
            _ContratoId          = 0;
            _ContratoCoberturaId = 0;
        }


        Int32 _PersonaContratoId;
        public Int32 PersonaContratoId { get { return _PersonaContratoId; } set { _PersonaContratoId = value; } }

        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        Int32 _ContratoCoberturaId;
        public Int32 ContratoCoberturaId { get { return _ContratoCoberturaId; } set { _ContratoCoberturaId = value; } }
    }
}