using System;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class MembresiaPM : ModeloBasePM
    {
        public MembresiaPM()
        {
            _MembresiaId     = 0;
            _MembresiaTipoId = -1;
        }
        

        Int32 _MembresiaId;
        public Int32 MembresiaId { get { return _MembresiaId; } set { _MembresiaId = value; } }
        
        DateTime? _FechaInicio;
        public DateTime? FechaInicio { get { return _FechaInicio; } set { _FechaInicio = value; } }
        
        DateTime? _FechaFin;
        public DateTime? FechaFin { get { return _FechaFin; } set { _FechaFin = value; } }

        DateTime? _VigenciaInicio;
        public DateTime? VigenciaInicio { get { return _VigenciaInicio; } set { _VigenciaInicio = value; } }

        DateTime? _VigenciaFin;
        public DateTime? VigenciaFin { get { return _VigenciaFin; } set { _VigenciaFin = value; } }

        Int32 _MembresiaTipoId;
        public Int32 MembresiaTipoId { get { return _MembresiaTipoId; } set { _MembresiaTipoId = value; } }

        String _Nombre;
        public String Nombre { get { return _Nombre; } set { _Nombre = value; } }

        Int32 _Numsocio;
        public Int32 NumSocio { get { return _Numsocio; } set { _Numsocio = value; } }

        Int16 _ClaveFamiliar;
        public Int16 ClaveFamiliar { get { return _ClaveFamiliar; } set { _ClaveFamiliar = value; } }

        Int32 _NumRecibo;
        public Int32 NumRecibo { get { return _NumRecibo; } set { _NumRecibo = value; } }
    }
}