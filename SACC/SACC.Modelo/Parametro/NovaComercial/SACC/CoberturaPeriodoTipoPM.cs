using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class CoberturaPeriodoTipoPM : ModeloBasePM
    {
        public CoberturaPeriodoTipoPM()
        {
            _CoberturaPeriodoTipoId          = 0;
            _CoberturaPeriodoTipoDescripcion = String.Empty;
        }


        Int32 _CoberturaPeriodoTipoId;
        public Int32 CoberturaPeriodoTipoId { get { return _CoberturaPeriodoTipoId; } set { _CoberturaPeriodoTipoId = value; } }

        String _CoberturaPeriodoTipoDescripcion;
        [StringLength(200)]
        public String CoberturaPeriodoTipoDescripcion { get { return _CoberturaPeriodoTipoDescripcion; } set { _CoberturaPeriodoTipoDescripcion = value; } }
    }
}