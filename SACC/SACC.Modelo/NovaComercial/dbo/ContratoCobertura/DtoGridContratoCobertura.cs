using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SACC.Modelo.NovaComercial.dbo.ContratoCobertura
{
    public class DtoGridContratoCobertura
    {
        public DtoGridContratoCobertura()
        {
            
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

        Decimal _PorcentajeUtilidadSobreTarifa;
        public Decimal PorcentajeUtilidadSobreTarifa { get { return _PorcentajeUtilidadSobreTarifa; } set { _PorcentajeUtilidadSobreTarifa = value; } }

        Decimal _PorcentajeCopagoContratante;
        public Decimal PorcentajeCopagoContratante { get { return _PorcentajeCopagoContratante; } set { _PorcentajeCopagoContratante = value; } }

        Decimal _PorcentajeDescuentoSobreTarifa;
        public Decimal PorcentajeDescuentoSobreTarifa { get { return _PorcentajeDescuentoSobreTarifa; } set { _PorcentajeDescuentoSobreTarifa = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}