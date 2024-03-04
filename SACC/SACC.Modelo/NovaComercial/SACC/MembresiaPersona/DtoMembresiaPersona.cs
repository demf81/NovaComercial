using System;


namespace SACC.Modelo.NovaComercial.SACC.MembresiaPersona
{
    public class DtoMembresiaPersona : ModeloBase
    {
        public DtoMembresiaPersona()
        {

        }
        

        Int32 _MembresiaPersonaId;
        public Int32 MembresiaPersonaId { get { return _MembresiaPersonaId; } set { _MembresiaPersonaId = value; } }
        
        Int32 _MembresiaId;
        public Int32 MembresiaId { get { return _MembresiaId; } set { _MembresiaId = value; } }

        String _NumSocio;
        public String NumSocio { get { return _NumSocio; } set { _NumSocio = value; } }

        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        Boolean _EsTitular;
        public Boolean EsTitular { get { return _EsTitular; } set { _EsTitular = value; } }

        Boolean _EsAdicional;
        public Boolean EsAdicional { get { return _EsAdicional; } set { _EsAdicional = value; } }
    }
}