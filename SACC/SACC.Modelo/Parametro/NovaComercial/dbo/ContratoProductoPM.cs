using System;


namespace SACC.Modelo.Parametro.NovaComercial.dbo
{
    public class ContratoProductoPM : ModeloBasePM
    {
        public ContratoProductoPM()
        {
            _ContratoProductoId = 0;
            _ContratoId         = 0;
        }


        Int32 _ContratoProductoId;
        public Int32 ContratoProductoId { get { return _ContratoProductoId; } set { _ContratoProductoId = value; } }

        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        String _ContratoProductoDescripcion;
        public String ContratoProductoDescripcion { get { return _ContratoProductoDescripcion; } set { _ContratoProductoDescripcion = value; } }
    }
}