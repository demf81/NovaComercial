using System;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class ContratoProductoPaquete : EntidadBase
    {
        public ContratoProductoPaquete()
        {

        }


        Int32 _ContratoProductoPaqueteId;
        public Int32 ContratoProductoPaqueteId { get { return _ContratoProductoPaqueteId; } set { _ContratoProductoPaqueteId = value; } }

        Int32 _ContratoProductoId;
        public Int32 ContratoProductoId { get { return _ContratoProductoId; } set { _ContratoProductoId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }
    }
}