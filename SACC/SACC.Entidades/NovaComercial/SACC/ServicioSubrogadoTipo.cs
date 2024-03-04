using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class ServicioSubrogadoTipo : EntidadBase
    {
        public ServicioSubrogadoTipo()
        {
            _ServicioSubrogadoTipoDescripcion = string.Empty;
        }
        

        Int32 _ServicioSubrogadoTipoId;
        public Int32 ServicioSubrogadoTipoId { get { return _ServicioSubrogadoTipoId; } set { _ServicioSubrogadoTipoId = value; } }
        
        String _ServicioSubrogadoTipoDescripcion;
        [StringLength(200)]
        public String ServicioSubrogadoTipoDescripcion { get { return _ServicioSubrogadoTipoDescripcion; } set { _ServicioSubrogadoTipoDescripcion = value; } }
    }
}