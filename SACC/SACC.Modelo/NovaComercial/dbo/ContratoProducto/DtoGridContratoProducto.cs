using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.ContratoProducto
{
    public class DtoGridContratoProducto
    {
        public DtoGridContratoProducto()
        {

        }


        Int32 _ContratoProductoId;
        public Int32 ContratoProductoId { get { return _ContratoProductoId; } set { _ContratoProductoId = value; } }

        //Int32 _ContratoId;
        //public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        String _ContratoProductoDescripcion;
        [StringLength(100)]
        public String ContratoProductoDescripcion { get { return _ContratoProductoDescripcion; } set { _ContratoProductoDescripcion = value; } }

        //Int32 _ContratoProductoTipoId;
        //public Int32 ContratoProductoTipoId { get { return _ContratoProductoTipoId; } set { _ContratoProductoTipoId = value; } }

        //DateTime _VigenciaDesde;
        //public DateTime VigenciaDesde { get { return _VigenciaDesde; } set { _VigenciaDesde = value; } }

        //DateTime _VigenciaHasta;
        //public DateTime VigenciaHasta { get { return _VigenciaHasta; } set { _VigenciaHasta = value; } }

        //Decimal _PorcentajeUtilidadSobreTarifa;
        //public Decimal PorcentajeUtilidadSobreTarifa { get { return _PorcentajeUtilidadSobreTarifa; } set { _PorcentajeUtilidadSobreTarifa = value; } }

        //Decimal _PorcentajeCopagoContratante;
        //public Decimal PorcentajeCopagoContratante { get { return _PorcentajeCopagoContratante; } set { _PorcentajeCopagoContratante = value; } }

        //Decimal _PorcentajeDescuentoSobreTarifa;
        //public Decimal PorcentajeDescuentoSobreTarifa { get { return _PorcentajeDescuentoSobreTarifa; } set { _PorcentajeDescuentoSobreTarifa = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}