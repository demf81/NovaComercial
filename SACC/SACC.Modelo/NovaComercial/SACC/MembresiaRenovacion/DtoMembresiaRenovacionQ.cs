using System;


namespace SACC.Modelo.NovaComercial.SACC.MembresiaRenovacion
{
    public class DtoMembresiaRenovacionQ
    {
        public DtoMembresiaRenovacionQ()
        {

        }


        Int32 _MembresiaId;
        public Int32 MembresiaId { get { return _MembresiaId; } set { _MembresiaId = value; } }

        Int16 _MembresiaTipoId;
        public Int16 MembresiaTipoId { get { return _MembresiaTipoId; } set { _MembresiaTipoId = value; } }

        DateTime _FechaContrato;
        public DateTime FechaContrato { get { return _FechaContrato; } set { _FechaContrato = value; } }

        String _Contratante;
        public String Contratante { get { return _Contratante; } set { _Contratante = value; } }
        
        DateTime _FechaVigencia;
        public DateTime FechaVigencia { get { return _FechaVigencia; } set { _FechaVigencia = value; } }

        Int64 _CantidadAfiliados;
        public Int64 CantidadAfiliados { get { return _CantidadAfiliados; } set { _CantidadAfiliados = value; } }

        Int64 _CantidadAdicionales;
        public Int64 CantidadAdicionales { get { return _CantidadAdicionales; } set { _CantidadAdicionales = value; } }
    }
}