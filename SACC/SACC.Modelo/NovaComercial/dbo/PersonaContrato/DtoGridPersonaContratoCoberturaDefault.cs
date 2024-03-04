using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SACC.Modelo.NovaComercial.dbo.PersonaContrato
{
    public class DtoGridPersonaContratoCoberturaDefault
    {
        public DtoGridPersonaContratoCoberturaDefault()
        {

        }


        Boolean _Seleccionado;
        public Boolean Seleccionado { get { return _Seleccionado; } set { _Seleccionado = value; } }

        Int32 _PersonaContratoId;
        public Int32 PersonaContratoId { get { return _PersonaContratoId; } set { _PersonaContratoId = value; } }

        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        String _NombreCompleto;
        public String NombreCompleto { get { return _NombreCompleto; } set { _NombreCompleto = value; } }

        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        String _ContratoDescripcion;
        public String ContratoDescripcion { get { return _ContratoDescripcion; } set { _ContratoDescripcion = value; } }

        Int32 _ContratoCoberturaId;
        public Int32 ContratoCoberturaId { get { return _ContratoCoberturaId; } set { _ContratoCoberturaId = value; } }

        String _ContratoCoberturaDescripcion;
        public String ContratoCoberturaDescripcion { get { return _ContratoCoberturaDescripcion; } set { _ContratoCoberturaDescripcion = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        String _PaqueteDescripcion;
        public String PaqueteDescripcion { get { return _PaqueteDescripcion; } set { _PaqueteDescripcion = value; } }
    }
}