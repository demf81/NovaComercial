using System;


namespace SACC.Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion
{
    public class DtoContratoCoberturaPaqueteCondicion
    {
        public DtoContratoCoberturaPaqueteCondicion()
        {

        }


        Int32 _ContratoCoberturaPaqueteCondicionId;
        public Int32 ContratoCoberturaPaqueteCondicionId { get { return _ContratoCoberturaPaqueteCondicionId; } set { _ContratoCoberturaPaqueteCondicionId = value; } }

        Int32 _ContratoCoberturaPaqueteId;
        public Int32 ContratoCoberturaPaqueteId { get { return _ContratoCoberturaPaqueteId; } set { _ContratoCoberturaPaqueteId = value; } }

        Int16 _CoberturaCondicionTipoId;
        public Int16 CoberturaCondicionTipoId { get { return _CoberturaCondicionTipoId; } set { _CoberturaCondicionTipoId = value; } }

        Int16 _CoberturaPeriodoTipoId;
        public Int16 CoberturaPeriodoTipoId { get { return _CoberturaPeriodoTipoId; } set { _CoberturaPeriodoTipoId = value; } }

        Int16 __CoberturaCantidadTipoId;
        public Int16 CoberturaCantidadTipoId { get { return __CoberturaCantidadTipoId; } set { __CoberturaCantidadTipoId = value; } }

        Decimal _Cantidad;
        public Decimal Cantidad { get { return _Cantidad; } set { _Cantidad = value; } }

        Int16 _CoberturaCopagoTipoId;
        public Int16 CoberturaCopagoTipoId { get { return _CoberturaCopagoTipoId; } set { _CoberturaCopagoTipoId = value; } }

        Decimal _Copago;
        public Decimal Copago { get { return _Copago; } set { _Copago = value; } }
    }
}