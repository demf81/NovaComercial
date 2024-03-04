using System;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class MembresiaPersonaPM : ModeloBasePM
    {
        public MembresiaPersonaPM()
        {
            _MembresiaId = 0;
        }


        Int32 _MembresiaId;
        public Int32 MembresiaId { get { return _MembresiaId; } set { _MembresiaId = value; } }

        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        Int32 _ParentescoId;
        public Int32 ParentescoId { get { return _ParentescoId; } set { _ParentescoId = value; } }
    }
}