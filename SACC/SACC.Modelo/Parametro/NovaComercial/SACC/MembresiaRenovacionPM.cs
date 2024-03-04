using System;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class MembresiaRenovacionPM : ModeloBasePM
    {
        public MembresiaRenovacionPM()
        {
            _MembresiaRenovacionId = 0;
            _MembresiaId           = 0;
            _MembresiaTipoId       = -1;
        }


        Int32 _MembresiaRenovacionId;
        public Int32 MembresiaRenovacionId { get { return _MembresiaRenovacionId; } set { _MembresiaRenovacionId = value; } }

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

        Int64? _NumPedido;
        public Int64? NumPedido { get { return _NumPedido; } set { _NumPedido = value; } }

        Int64? _NumRecibo;
        public Int64? NumRecibo { get { return _NumRecibo; } set { _NumRecibo = value; } }

        Int32 _MembresiaTipoId;
        public Int32 MembresiaTipoId { get { return _MembresiaTipoId; } set { _MembresiaTipoId = value; } }

        String _Numsocio;
        public String NumSocio { get { return _Numsocio; } set { _Numsocio = value; } }
    }
}