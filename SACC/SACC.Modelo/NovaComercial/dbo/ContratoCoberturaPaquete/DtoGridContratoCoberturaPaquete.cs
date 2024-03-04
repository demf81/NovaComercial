using System;


namespace SACC.Modelo.NovaComercial.dbo.ContratoCoberturaPaquete
{
    public class DtoGridContratoCoberturaPaquete
    {
        public DtoGridContratoCoberturaPaquete()
        {

        }


        Int32 _ContratoCoberturaPaqueteId;
        public Int32 ContratoCoberturaPaqueteId { get { return _ContratoCoberturaPaqueteId; } set { _ContratoCoberturaPaqueteId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        String _PaqueteDescripcion;
        public String PaqueteDescripcion { get { return _PaqueteDescripcion; } set { _PaqueteDescripcion = value; } }

        Boolean? _TieneCondicion;
        public Boolean? TieneCondicion { get { return _TieneCondicion; } set { _TieneCondicion = value; } }

        Boolean? _TieneExclusion;
        public Boolean? TieneExclusion { get { return _TieneExclusion; } set { _TieneExclusion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}