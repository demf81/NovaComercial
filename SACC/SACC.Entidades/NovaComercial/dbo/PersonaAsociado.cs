using System;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class PersonaAsociado : EntidadBase
    {
        Int32 _PersonaAsociadoId;
        public Int32 PersonaAsociadoId { get { return _PersonaAsociadoId; } set { _PersonaAsociadoId = value; } }


        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }


        Int32 _AsociadoId;
        public Int32 AsociadoId { get { return _AsociadoId; } set { _AsociadoId = value; } }
    }
}