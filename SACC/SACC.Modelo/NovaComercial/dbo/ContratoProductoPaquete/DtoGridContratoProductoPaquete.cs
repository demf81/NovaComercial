using System;


namespace SACC.Modelo.NovaComercial.dbo.ContratoProductoPaquete
{
    public class DtoGridContratoProductoPaquete
    {
        public DtoGridContratoProductoPaquete()
        {

        }


        Int32 _ContratoProductoPaqueteId;
        public Int32 ContratoProductoPaqueteId { get { return _ContratoProductoPaqueteId; } set { _ContratoProductoPaqueteId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        String _PaqueteDescripcion;
        public String PaqueteDescripcion { get { return _PaqueteDescripcion; } set { _PaqueteDescripcion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}