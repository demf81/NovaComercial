using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class VentaUnitaria : EntidadBase
    {
        public VentaUnitaria()
        {
            _VentaUnitariaDescripcion = string.Empty;
        }


        Int32 _VentaUnitariaId;
        public Int32 VentaUnitariaId { get { return _VentaUnitariaId; } set { _VentaUnitariaId = value; } }


        String _VentaUnitariaDescripcion;
        [StringLength(250)]
        public String VentaUnitariaDescripcion { get { return _VentaUnitariaDescripcion; } set { _VentaUnitariaDescripcion = value; } }


        Int32 _VentaTipoId;
        public Int32 VentaTipoId { get { return _VentaTipoId; } set { _VentaTipoId = value; } }


        Int32 _ContratanteId;
        public Int32 ContratanteId { get { return _ContratanteId; } set { _ContratanteId = value; } }


        Int32? _TitularId;
        public Int32? TitularId { get { return _TitularId; } set { _TitularId = value; } }


        Int32? _PersonaId;
        public Int32? PersonaId { get { return _PersonaId; } set { _PersonaId = value; } }


        Int32? _AsociadoId;
        public Int32? AsociadoId { get { return _AsociadoId; } set { _AsociadoId = value; } }


        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }


        DateTime? _VigenciaInicio;
        public DateTime? VigenciaInicio { get { return _VigenciaInicio; } set { _VigenciaInicio = value; } }


        DateTime? _VigenciaTermino;
        public DateTime? VigenciaTermino { get { return _VigenciaTermino; } set { _VigenciaTermino = value; } }


        Int32? _AutorizacionId;
        public Int32? AutorizacionId { get { return _AutorizacionId; } set { _AutorizacionId = value; } }


        Boolean _EsquemaPrePago;
        public Boolean EsquemaPrePago { get { return _EsquemaPrePago; } set { _EsquemaPrePago = value; } }


        Boolean _CobroAnticipado;
        public Boolean CobroAnticipado { get { return _CobroAnticipado; } set { _CobroAnticipado = value; } }


        Decimal _CobroAnticipadoMonto;
        public Decimal CobroAnticipadoMonto { get { return _CobroAnticipadoMonto; } set { _CobroAnticipadoMonto = value; } }


        Decimal _MontoLimite;
        public Decimal MontoLimite { get { return _MontoLimite; } set { _MontoLimite = value; } }


        Boolean _PrecioCobertura;
        public Boolean PrecioCobertura { get { return _PrecioCobertura; } set { _PrecioCobertura = value; } }


        Decimal _PorcentajeUtilidad;
        public Decimal PorcentajeUtilidad { get { return _PorcentajeUtilidad; } set { _PorcentajeUtilidad = value; } }


        Int32? _CopagoTipoId;
        public Int32? CopagoTipoId { get { return _CopagoTipoId; } set { _CopagoTipoId = value; } }


        Decimal? _PorcentajeCoPago;
        public Decimal? PorcentajeCoPago { get { return _PorcentajeCoPago; } set { _PorcentajeCoPago = value; } }


        Decimal? _PorcentajeDescuento;
        public Decimal? PorcentajeDescuento { get { return _PorcentajeDescuento; } set { _PorcentajeDescuento = value; } }


        Decimal? _Total;
        public Decimal? Total { get { return _Total; } set { _Total = value; } }


        Int32 _EstatusId;
        public Int32 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }


        Boolean _ManejaPrecioLista;
        public Boolean ManejaPrecioLista { get { return _ManejaPrecioLista; } set { _ManejaPrecioLista = value; } }
    }
}