using System;


namespace SACC.Modelo.NovaComercial.dbo.PersonaContrato
{
    public class DtoGridPersonaContrato
    {
        public DtoGridPersonaContrato()
        {
            
        }


        Int32 _PersonaContratoId;
        public Int32 PersonaContratoId { get { return _PersonaContratoId; } set { _PersonaContratoId = value; } }

        String _ContratoDescripcion;
        public String ContratoDescripcion { get { return _ContratoDescripcion; } set { _ContratoDescripcion = value; } }

        String _ContratoCoberturaDescripcion;
        public String ContratoCoberturaDescripcion { get { return _ContratoCoberturaDescripcion; } set { _ContratoCoberturaDescripcion = value; } }

        String _PaqueteDescripcion;
        public String PaqueteDescripcion { get { return _PaqueteDescripcion; } set { _PaqueteDescripcion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}