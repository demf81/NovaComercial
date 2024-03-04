using System;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class PersonaNumeroSocio : EntidadBase
    {
        public PersonaNumeroSocio()
        {

        }


        Int32 _NumeroSocioId;
        public Int32 NumeroSocioId { get { return _NumeroSocioId; } set { if (value >= 0) _NumeroSocioId = value; } }


        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { if (value >= 0) _PersonaId = value; } }
    }
}