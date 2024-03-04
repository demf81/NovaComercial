using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Persona
{
    public class DtoGridPersona
    {
        public DtoGridPersona()
        {
            _NombreCompleto    = String.Empty;
            _GeneroDescripcion = String.Empty;
        }


        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        String _NombreCompleto;
        [StringLength(50)]
        public String NombreCompleto { get { return _NombreCompleto; } set { _NombreCompleto = value; } }

        String _CURP;
        [StringLength(18)]
        public String CURP { get { return _CURP; } set { _CURP = value; } }

        String _GeneroDescripcion;
        public String GeneroDescripcion { get { return _GeneroDescripcion; } set { _GeneroDescripcion = value; } }

        Int32 _Edad;
        public Int32 Edad { get { return _Edad; } set { _Edad = value; } }

        String _NumSocio;
        public String NumSocio { get { return _NumSocio; } set { _NumSocio = value; } }

        String _CoberturaDefault;
        public String CoberturaDefault { get { return _CoberturaDefault; } set { _CoberturaDefault = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}