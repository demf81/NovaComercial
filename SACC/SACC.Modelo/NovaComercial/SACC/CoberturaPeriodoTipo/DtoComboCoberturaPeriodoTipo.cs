using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.CoberturaPeriodoTipo
{
    public class DtoComboCoberturaPeriodoTipo
    {
        public DtoComboCoberturaPeriodoTipo()
        {
            _CoberturaPeriodoTipoDescripcion = String.Empty;
        }


        Int16 _CoberturaPeriodoTipoId;
        public Int16 CoberturaPeriodoTipoId { get { return _CoberturaPeriodoTipoId; } set { _CoberturaPeriodoTipoId = value; } }

        String _CoberturaPeriodoTipoDescripcion;
        [StringLength(200)]
        public String CoberturaPeriodoTipoDescripcion { get { return _CoberturaPeriodoTipoDescripcion; } set { _CoberturaPeriodoTipoDescripcion = value; } }
    }
}