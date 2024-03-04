using System;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class PersonaPaquete : EntidadBase
    {
        public PersonaPaquete()
        {

        }


        Int32 _PersonaPaqueteId;
        public Int32 PersonaPaqueteId { get { return _PersonaPaqueteId; } set { _PersonaPaqueteId = value; } }


        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }


        Int32 _ContratoProductoId;
        public Int32 ContratoProductoId { get { return _ContratoProductoId; } set { _ContratoProductoId = value; } }


        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }


        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }
    }
}