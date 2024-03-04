using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Venta
{
    public class DtoGridVenta : ModeloBase
    {
        public DtoGridVenta()
        {
            _VentaId          = 0;
            _CotizacionId     = 0;
            _VentaDescripcion = String.Empty;
        }


        Int32? _VentaId;
        public Int32? VentaId { get { return _VentaId; } set { _VentaId = value; } }

        Int32? _CotizacionId;
        public Int32? CotizacionId { get { return _CotizacionId; } set { _CotizacionId = value; } }

        String _VentaDescripcion;
        [StringLength(200)]
        public String VentaDescripcion { get { return _VentaDescripcion; } set { _VentaDescripcion = value; } }

        String _Fecha;
        public String Fecha { get { return _Fecha; } set { _Fecha = value; } }

        Int16 _VentaTipoId;
        public Int16 VentaTipoId { get { return _VentaTipoId; } set { _VentaTipoId = value; } }

        String _VentaTipoDescripcion;
        public String VentaTipoDescripcion { get { return _VentaTipoDescripcion; } set { _VentaTipoDescripcion = value; } }

        String _PersonaNombre;
        public String PersonaNombre { get { return _PersonaNombre; } set { _PersonaNombre = value; } }

        String _EmpresaNombre;
        public String EmpresaNombre { get { return _EmpresaNombre; } set { _EmpresaNombre = value; } }

        Decimal _SubTotal;
        public Decimal SubTotal { get { return _SubTotal; } set { _SubTotal = value; } }

        Decimal _Descuento;
        public Decimal Descuento { get { return _Descuento; } set { _Descuento = value; } }

        Decimal _Iva;
        public Decimal Iva { get { return _Iva; } set { _Iva = value; } }

        Decimal _Total;
        public Decimal Total { get { return _Total; } set { _Total = value; } }

        Decimal _Anticipo;
        public Decimal Anticipo { get { return _Anticipo; } set { _Anticipo = value; } }

        Int16 _VentaEstatusId;
        public Int16 VentaEstatusId { get { return _VentaEstatusId; } set { _VentaEstatusId = value; } }
    }
}