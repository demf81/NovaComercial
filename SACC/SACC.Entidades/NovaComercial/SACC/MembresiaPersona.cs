using System;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class MembresiaPersona : EntidadBase
    {
        public MembresiaPersona()
        {

        }


        Int32 _MembresiaPersonaId;
        public Int32 MembresiaPersonaId { get { return _MembresiaPersonaId; } set { _MembresiaPersonaId = value; } }

        Int32 _MembresiaId;
        public Int32 MembresiaId { get { return _MembresiaId; } set { _MembresiaId = value; } }

        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        Boolean _EsTitular;
        public Boolean EsTitular { get { return _EsTitular; } set { _EsTitular = value; } }

        Boolean _EsAdicional;
        public Boolean EsAdicional { get { return _EsAdicional; } set { _EsAdicional = value; } }

        Int32 _ParentescoId;
        public Int32 ParentescoId { get { return _ParentescoId; } set { _ParentescoId = value; } }
    }
}