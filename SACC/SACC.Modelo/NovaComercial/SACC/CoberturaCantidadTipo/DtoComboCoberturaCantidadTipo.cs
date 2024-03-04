using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.CoberturaCantidadTipo
{
    public class DtoComboCoberturaCantidadTipo
    {
        public DtoComboCoberturaCantidadTipo()
        {
            _CoberturaCantidadTipoDescripcion = String.Empty;
        }


        Int16 _CoberturaCantidadTipoId;
        public Int16 CoberturaCantidadTipoId { get { return _CoberturaCantidadTipoId; } set { _CoberturaCantidadTipoId = value; } }

        String _CoberturaCantidadTipoDescripcion;
        [StringLength(200)]
        public String CoberturaCantidadTipoDescripcion { get { return _CoberturaCantidadTipoDescripcion; } set { _CoberturaCantidadTipoDescripcion = value; } }
    }
}