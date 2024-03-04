using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Cotizacion
{
    public class DtoGridCotizacion : ModeloBase
    {
        public DtoGridCotizacion()
        {
            _CotizacionId = 0;
            _CotizacionDescripcion = String.Empty;

        }


        Int32? _CotizacionId;
        public Int32? CotizacionId { get { return _CotizacionId; } set { _CotizacionId = value; } }

        String _CotizacionDescripcion;
        [StringLength(200)]
        public String CotizacionDescripcion { get { return _CotizacionDescripcion; } set { _CotizacionDescripcion = value; } }

        String _Fecha;
        public String Fecha { get { return _Fecha; } set { _Fecha = value; } }

        Int16 _CotizacionTipoId;
        public Int16 CotizacionTipoId { get { return _CotizacionTipoId; } set { _CotizacionTipoId = value; } }

        String _CotizacionTipoDescripcion;
        public String CotizacionTipoDescripcion { get { return _CotizacionTipoDescripcion; } set { _CotizacionTipoDescripcion = value; } }

        Int32? _PersonaId;
        public Int32? PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        String _PersonaNombre;
        public String PersonaNombre { get { return _PersonaNombre; } set { _PersonaNombre = value; } }

        Int32? _EmpresaId;
        public Int32? EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }

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

        Int16 _CotizacionEstatusId;
        public Int16 CotizacionEstatusId { get { return _CotizacionEstatusId; } set { _CotizacionEstatusId = value; } }
    }
}