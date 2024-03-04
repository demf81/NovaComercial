using System;


namespace SACC.Modelo.NovaComercial.SACC.MembresiaPersona
{
    public class DtoGridMembresiaPersona
    {
        public DtoGridMembresiaPersona()
        {

        }


        Int32 _MembresiaPersonaId;
        public Int32 MembresiaPersonaId { get { return _MembresiaPersonaId; } set { _MembresiaPersonaId = value; } }

        Int32 _MembresiaId;
        public Int32 MembresiaId { get { return _MembresiaId; } set { _MembresiaId = value; } }

        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        String _NumSocio;
        public String NumSocio { get { return _NumSocio; } set { _NumSocio = value; } }

        String _NombreCompleto;
        public String NombreCompleto { get { return _NombreCompleto; } set { _NombreCompleto = value; } }

        Int16 _Edad;
        public Int16 Edad { get { return _Edad; } set { _Edad = value; } }

        Int32 _ParentescoId;
        public Int32 ParentescoId { get { return _ParentescoId; } set { _ParentescoId = value; } }

        String _ParentescoDescripcion;
        public String ParentescoDescripcion { get { return _ParentescoDescripcion; } set { _ParentescoDescripcion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}