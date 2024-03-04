using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class Venta : EntidadBase
    {
        public Venta()
        {
            _VentaDescripcion = string.Empty;
        }


        Int32 _VentaId;
        public Int32 VentaId { get { return _VentaId; } set { _VentaId = value; } }


        Int32 _CotizacionId;
        public Int32 CotizacionId { get { return _CotizacionId; } set { _CotizacionId = value; } }


        String _VentaDescripcion;
        [StringLength(250)]
        public String VentaDescripcion { get { return _VentaDescripcion; } set { _VentaDescripcion = value; } }


        Int32 _ContratanteId;
        public Int32 ContratanteId { get { return _ContratanteId; } set { _ContratanteId = value; } }


        Int32? _TitularId;
        public Int32? TitularId { get { return _TitularId; } set { _TitularId = value; } }


        Int32? _PersonaId;
        public Int32? PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }


        Boolean _PublicoGeneral;
        public Boolean PublicoGeneral { get { return _PublicoGeneral; } set { _PublicoGeneral = value; } }


        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }


        DateTime? _Fecha;
        public DateTime? Fecha { get { return _Fecha; } set { _Fecha = value; } }


        Int32? _AutorizacionId;
        public Int32? AutorizacionId { get { return _AutorizacionId; } set { _AutorizacionId = value; } }


        Decimal? _SubTotal;
        public Decimal? SubTotal { get { return _SubTotal; } set { _SubTotal = value; } }


        Decimal? _Iva;
        public Decimal? Iva { get { return _Iva; } set { _Iva = value; } }


        Decimal? _Total;
        public Decimal? Total { get { return _Total; } set { _Total = value; } }


        Int32 _EstatusId;
        public Int32 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}