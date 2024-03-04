using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class ContratoCobertura : EntidadBase
    {
        public ContratoCobertura()
        {
            _ContratoCoberturaDescripcion = string.Empty;
            _TodoMedicamento              = null;
            _TodoMaterial                 = null;
            _TodoCirugia                  = null;
            _TodoEstudio                  = null;
            _TodoServicio                 = null;
            _VigenciaDesde                = DateTime.Now;
            _VigenciaHasta                = DateTime.Now;
        }


        Int32 _ContratoCoberturaId;
        public Int32 ContratoCoberturaId { get { return _ContratoCoberturaId; } set { _ContratoCoberturaId = value; } }

        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        String _ContratoCoberturaDescripcion;
        [StringLength(100)]
        public String ContratoCoberturaDescripcion { get { return _ContratoCoberturaDescripcion; } set { _ContratoCoberturaDescripcion = value; } }

        Boolean? _TodoMedicamento;
        public Boolean? TodoMedicamento { get { return _TodoMedicamento; } set { _TodoMedicamento = value; } }

        Boolean? _TodoMaterial;
        public Boolean? TodoMaterial { get { return _TodoMaterial; } set { _TodoMaterial = value; } }

        Boolean? _TodoCirugia;
        public Boolean? TodoCirugia { get { return _TodoCirugia; } set { _TodoCirugia = value; } }

        Boolean? _TodoEstudio;
        public Boolean? TodoEstudio { get { return _TodoEstudio; } set { _TodoEstudio = value; } }

        Boolean? _TodoServicio;
        public Boolean? TodoServicio { get { return _TodoServicio; } set { _TodoServicio = value; } }

        Int32 _ContratoCoberturaTipoId;
        public Int32 ContratoCoberturaTipoId { get { return _ContratoCoberturaTipoId; } set { _ContratoCoberturaTipoId = value; } }

        DateTime _VigenciaDesde;
        public DateTime VigenciaDesde { get { return _VigenciaDesde; } set { _VigenciaDesde = value; } }

        DateTime _VigenciaHasta;
        public DateTime VigenciaHasta { get { return _VigenciaHasta; } set { _VigenciaHasta = value; } }

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