using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class CoberturaCantidadTipoPM : ModeloBasePM
    {
        public CoberturaCantidadTipoPM()
        {
            _CoberturaCantidadTipoId          = 0;
            _CoberturaCantidadTipoDescripcion = String.Empty;
        }


        Int32 _CoberturaCantidadTipoId;
        public Int32 CoberturaCantidadTipoId { get { return _CoberturaCantidadTipoId; } set { _CoberturaCantidadTipoId = value; } }

        String _CoberturaCantidadTipoDescripcion;
        [StringLength(200)]
        public String CoberturaCantidadTipoDescripcion { get { return _CoberturaCantidadTipoDescripcion; } set { _CoberturaCantidadTipoDescripcion = value; } }
    }
}