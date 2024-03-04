using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class ContratoProducto : EntidadBase
    {
        public ContratoProducto()
        {
            _ContratoProductoDescripcion = string.Empty;
        }


        Int32 _ContratoProductoId;
        public Int32 ContratoProductoId { get { return _ContratoProductoId; } set { _ContratoProductoId = value; } }

        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        String _ContratoProductoDescripcion;
        [StringLength(100)]
        public String ContratoProductoDescripcion { get { return _ContratoProductoDescripcion; } set { _ContratoProductoDescripcion = value; } }

        Boolean? _EsquemaPrePago;
        public Boolean? EsquemaPrePago { get { return _EsquemaPrePago; } set { _EsquemaPrePago = value; } }

        Boolean? _CobroAnticipado;
        public Boolean? CobroAnticipado { get { return _CobroAnticipado; } set { _CobroAnticipado = value; } }

        Int32 _TarifaId;
        public Int32 TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }

        Decimal _PorcentajeUtilidadSobreTarifa;
        public Decimal PorcentajeUtilidadSobreTarifa { get { return _PorcentajeUtilidadSobreTarifa; } set { _PorcentajeUtilidadSobreTarifa = value; } }

        Decimal _PorcentajeCopagoContratante;
        public Decimal PorcentajeCopagoContratante { get { return _PorcentajeCopagoContratante; } set { _PorcentajeCopagoContratante = value; } }

        Decimal _PorcentajeDescuentoSobreTarifa;
        public Decimal PorcentajeDescuentoSobreTarifa { get { return _PorcentajeDescuentoSobreTarifa; } set { _PorcentajeDescuentoSobreTarifa = value; } }
    }
}