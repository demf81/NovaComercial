using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Cotizacion
{
    public class DtoCotizacion : ModeloBase
    {
        public DtoCotizacion()
        {
            _CotizacionDescripcion = string.Empty;
            _PersonaId             = -1;
            _PersonaNombre         = string.Empty;
            _EmpresaNombre         = string.Empty;
            _Contacto              = string.Empty;
            _EmpresaId             = -1;
        }


        Int32 _CotizacionId;
        public Int32 CotizacionId { get { return _CotizacionId; } set { _CotizacionId = value; } }

        String _CotizacionDescripcion;
        [StringLength(200)]
        public String CotizacionDescripcion { get { return _CotizacionDescripcion; } set { _CotizacionDescripcion = value; } }

        DateTime _Fecha;
        public DateTime Fecha { get { return _Fecha; } set { _Fecha = value; } }

        Int16 _CotizacionTipoId;
        public Int16 CotizacionTipoId { get { return _CotizacionTipoId; } set { _CotizacionTipoId = value; } }

        Int32 _PersonaId;
        public Int32 PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }

        String _PersonaNombre;
        [StringLength(100)]
        public String PersonaNombre { get { return _PersonaNombre; } set { _PersonaNombre = value; } }

        String _NumSocio;
        [StringLength(100)]
        public String NumSocio { get { return _NumSocio; } set { _NumSocio = value; } }

        String _Telefono;
        public String Telefono { get { return _Telefono; } set { _Telefono = value; } }

        String _CorreoElectronico;
        public String CorreoElectronico { get { return _CorreoElectronico; } set { _CorreoElectronico = value; } }

        String _EmpresaNombre;
        [StringLength(100)]
        public String EmpresaNombre { get { return _EmpresaNombre; } set { _EmpresaNombre = value; } }

        String _Contacto;
        [StringLength(100)]
        public String Contacto { get { return _Contacto; } set { _Contacto = value; } }

        Int32 _EmpresaId;
        public Int32 EmpresaId { get { return _EmpresaId; } set { _EmpresaId = value; } }

        Decimal _SubTotal;
        public Decimal SubTotal { get { return _SubTotal; } set { _SubTotal = value; } }

        Decimal? _Descuento;
        public Decimal? Descuento { get { return _Descuento; } set { _Descuento = value; } }

        Int32? _CampaniaId;
        public Int32? CampaniaId { get { return _CampaniaId; } set { _CampaniaId = value; } }

        Decimal _Iva;
        public Decimal Iva { get { return _Iva; } set { _Iva = value; } }

        Decimal _Total;
        public Decimal Total { get { return _Total; } set { _Total = value; } }

        Int16 _CotizacionEstatusId;
        public Int16 CotizacionEstatusId { get { return _CotizacionEstatusId; } set { _CotizacionEstatusId = value; } }
    }
}