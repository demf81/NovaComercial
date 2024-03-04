using System;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class PersonaContrato : EntidadBase
    {
        public PersonaContrato()
        {

        }


        Int32 _PersonaContratoId;
        public Int32 PersonaContratoId { get { return _PersonaContratoId; } set { _PersonaContratoId = value; } }

        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        Int32 _ContratoCoberturaId;
        public Int32 ContratoCoberturaId { get { return _ContratoCoberturaId; } set { _ContratoCoberturaId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }
    }
}