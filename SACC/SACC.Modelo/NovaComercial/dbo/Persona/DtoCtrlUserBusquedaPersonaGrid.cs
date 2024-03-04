using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Persona
{
    public class DtoCtrlUserBusquedaPersonaGrid
    {
        public DtoCtrlUserBusquedaPersonaGrid()
        {

        }


        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        String _NombreCompleto;
        [StringLength(200)]
        public String NombreCompleto { get { return _NombreCompleto; } set { _NombreCompleto = value; } }

        String _NumSocio;
        [StringLength(20)]
        public String NumSocio { get { return _NumSocio; } set { _NumSocio = value; } }

        String _Genero;
        [StringLength(50)]
        public String Genero { get { return _Genero; } set { _Genero = value; } }

        String _CURP;
        [StringLength(200)]
        public String CURP { get { return _CURP; } set { _CURP = value; } }

        Int16 _Edad;
        public Int16 Edad { get   {return _Edad;} set { _Edad = value; } }
    }
}