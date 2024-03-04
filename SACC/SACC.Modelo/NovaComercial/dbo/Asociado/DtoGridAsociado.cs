using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Asociado
{
    public class DtoGridAsociado : ModeloBase
    {
        public DtoGridAsociado()
        {
            _Curp            = String.Empty;
            _Nombre          = String.Empty;
            _ApellidoPaterno = String.Empty;
            _ApellidoMaterno = String.Empty;
            _Contratante     = String.Empty;
        }


        Int32 _AsociadoId;
        public Int32 AsociadoId { get { return _AsociadoId; } set { _AsociadoId = value; } }

        String _NumSocio;
        [StringLength(100)]
        public String NumSocio { get { return _NumSocio; } set { _NumSocio = value; } }

        String _Genero;
        [StringLength(100)]
        public String Genero { get { return _Genero; } set { _Genero = value; } }
     

        String _Curp;
        [StringLength(100)]
        public String Curp { get { return _Curp; } set { _Curp = value; } }


        String _Nombre;
        [StringLength(100)]
        public String Nombre { get { return _Nombre; } set { _Nombre = value; } }


        String _ApellidoPaterno;
        [StringLength(100)]
        public String ApellidoPaterno { get { return _ApellidoPaterno; } set { _ApellidoPaterno = value; } }


        String _ApellidoMaterno;
        [StringLength(100)]
        public String ApellidoMaterno { get { return _ApellidoMaterno; } set { _ApellidoMaterno = value; } }

        String _Contratante;
        [StringLength(100)]
        public String Contratante { get { return _Contratante; } set { _Contratante = value; } }

        Int32? _TitularId;
        public Int32? TitularId { get { return _TitularId; } set { _TitularId = value; } }

        String _FechaNacimiento;
        public String FechaNacimiento { get { return _FechaNacimiento; } set { _FechaNacimiento = value; } }


        Boolean? _ServicioSuspendido;
        public Boolean? ServicioSuspendido { get { return _ServicioSuspendido; } set { _ServicioSuspendido = value; } }

    }
}
