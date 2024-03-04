using System;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class ContratoProductoPaquetePM : ModeloBasePM
    {
        public ContratoProductoPaquetePM()
        {
            _ContratoProductoPaqueteId = 0;
            _ContratoProductoId        = 0;
            _ContratoId                = 0;
            _PaqueteId                 = 0;
        }


        Int32 _ContratoProductoPaqueteId;
        public Int32 ContratoProductoPaqueteId { get { return _ContratoProductoPaqueteId; } set { _ContratoProductoPaqueteId = value; } }

        Int32 _ContratoProductoId;
        public Int32 ContratoProductoId { get { return _ContratoProductoId; } set { _ContratoProductoId = value; } }

        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }
    }
}