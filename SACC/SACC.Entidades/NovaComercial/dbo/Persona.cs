using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class Persona : EntidadBase
    {
        public Persona()
        {
            _Nombre          = string.Empty;
            _Genero          = null;
            _FechaNacimiento = DateTime.Now;
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

        Boolean? _Genero;
        public Boolean? Genero { get { return _Genero; } set { _Genero = value; } }

        DateTime? _FechaNacimiento;
        public DateTime? FechaNacimiento { get { return _FechaNacimiento; } set { _FechaNacimiento = value; } }

        Boolean? _RN;
        public Boolean? RN { get { return _RN; } set { _RN = value; } }

        Boolean? _Extranjero;
        public Boolean? Extranjero { get { return _Extranjero; } set { _Extranjero = value; } }

        String _CURP;
        [StringLength(18)]
        public String CURP { get { return _CURP; } set { _CURP = value; } }
    }
}