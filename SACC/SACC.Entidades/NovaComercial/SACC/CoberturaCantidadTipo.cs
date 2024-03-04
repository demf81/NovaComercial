using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class CoberturaCantidadTipo : EntidadBase
    {
        public CoberturaCantidadTipo()
        {
            _CoberturaCantidadTipoDescripcion = string.Empty;
        }


        Int16 _CoberturaCantidadTipoId;
        public Int16 CoberturaCantidadTipoId { get { return _CoberturaCantidadTipoId; } set { _CoberturaCantidadTipoId = value; } }

        String _CoberturaCantidadTipoDescripcion;
        [StringLength(200)]
        public String CoberturaCantidadTipoDescripcion { get { return _CoberturaCantidadTipoDescripcion; } set { _CoberturaCantidadTipoDescripcion = value; } }
    }
}