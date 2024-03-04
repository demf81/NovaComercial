using System;
using System.ComponentModel.DataAnnotations;

namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class PersonaPM : ModeloBasePM
    {
        public PersonaPM()
        {
            _Nombre          = String.Empty;
            _Paterno         = String.Empty;
            _Materno         = String.Empty;
            _Genero          = null;
            _FechaNacimiento = null;
            _CURP            = String.Empty;
        }


        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        String _Nombre;
        [StringLength(50)]
        public String Nombre { get { return _Nombre; } set { _Nombre = value; } }

        String _Paterno;
        [StringLength(50)]
        public String Paterno { get { return _Paterno; } set { _Paterno = value; } }

        String _Materno;
        [StringLength(50)]
        public String Materno { get { return _Materno; } set { _Materno = value; } }

        Int32 _NumSocio;
        public Int32 NumSocio { get { return _NumSocio; } set { _NumSocio = value; } }

        String _ClaveFamiliar;
        public String ClaveFamiliar { get { return _ClaveFamiliar; } set { _ClaveFamiliar = value; } }

        Boolean? _Genero;
        public Boolean? Genero { get { return _Genero; } set { _Genero = value; } }

        DateTime? _FechaNacimiento;
        public DateTime? FechaNacimiento { get { return _FechaNacimiento; } set { _FechaNacimiento = value; } }

        String _CURP;
        [StringLength(18)]
        public String CURP { get { return _CURP; } set { _CURP = value; } }

        Boolean? _Baja;
        public Boolean? Baja { get { return _Baja; } set { _Baja = value; } }

        Boolean? _BajaAsociado;
        public Boolean? BajaAsociado { get { return _BajaAsociado; } set { _BajaAsociado = value; } }
    }
}