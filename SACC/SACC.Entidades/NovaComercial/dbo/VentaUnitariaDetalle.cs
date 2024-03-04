using System;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class VentaUnitariaDetalle : EntidadBase
    {
        public VentaUnitariaDetalle()
        {

        }


        Int32 _VentaUnitariaDetalleId;
        public Int32 VentaUnitariaDetalleId { get { return _VentaUnitariaDetalleId; } set { _VentaUnitariaDetalleId = value; } }


        Int32 _VentaUnitariaId;
        public Int32 VentaUnitariaId { get { return _VentaUnitariaId; } set { _VentaUnitariaId = value; } }


        Int32 _VentaUnitariaDetalleTipoId;
        public Int32 VentaUnitariaDetalleTipoId { get { return _VentaUnitariaDetalleTipoId; } set { _VentaUnitariaDetalleTipoId = value; } }


        Int32? _ContratoId;
        public Int32? ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }
        
            
        Int32? _ContratoCondicionId;
        public Int32? ContratoCondicionId { get { return _ContratoCondicionId; } set { _ContratoCondicionId = value; } }


        Int32? _PaqueteCoberturaId;
        public Int32? PaqueteCoberturaId { get { return _PaqueteCoberturaId; } set { _PaqueteCoberturaId = value; } }


        Boolean? _Amparado;
        public Boolean? Amparado { get { return _Amparado; } set { _Amparado = value; } }


        Boolean? _EsquemaPrePago;
        public Boolean? EsquemaPrePago { get { return _EsquemaPrePago; } set { _EsquemaPrePago = value; } }


        Boolean? _CobroAnticipado;
        public Boolean? CobroAnticipado { get { return _CobroAnticipado; } set { _CobroAnticipado = value; } }


        Int32? _TarifaId;
        public Int32? TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }


        Decimal? _PorcentajeUtilidadSobreTarifa;
        public Decimal? PorcentajeUtilidadSobreTarifa { get { return _PorcentajeUtilidadSobreTarifa; } set { _PorcentajeUtilidadSobreTarifa = value; } }


        Decimal? _PorcentajeCopagoContratante;
        public Decimal? PorcentajeCopagoContratante { get { return _PorcentajeCopagoContratante; } set { _PorcentajeCopagoContratante = value; } }


        Decimal? _PorcentajeDescuentoSobreTarifa;
        public Decimal? PorcentajeDescuentoSobreTarifa { get { return _TarifaId; } set { _PorcentajeDescuentoSobreTarifa = value; } }


        Int32 _itemId;
        public Int32 itemId { get { return _itemId; } set { _itemId = value; } }


        Decimal _Cantidad;
        public Decimal Cantidad { get { return _Cantidad; } set { _Cantidad = value; } }


        Decimal _Costo;
        public Decimal Costo { get { return _Costo; } set { _Costo = value; } }


        Int16 _VentaTipoPrecioId;
        public Int16 VentaTipoPrecioId { get { return _VentaTipoPrecioId; } set { _VentaTipoPrecioId = value; } }


        Int16 _VentaTipoPrecioModeloId;
        public Int16 VentaTipoPrecioModeloId { get { return _VentaTipoPrecioModeloId; } set { _VentaTipoPrecioModeloId = value; } }


        Decimal _VentaTipoPrecioValor;
        public Decimal VentaTipoPrecioValor { get { return _VentaTipoPrecioValor; } set { _VentaTipoPrecioValor = value; } }


        Decimal _Precio;
        public Decimal Precio { get { return _Precio; } set { _Precio = value; } }


        Decimal _Subtotal;
        public Decimal Subtotal { get { return _Subtotal; } set { _Subtotal = value; } }
    }
}