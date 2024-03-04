using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.ServicioSubrogadoTipo
{
    public class DtoServicioSubrogadoTipo : ModeloBase
    {
        public DtoServicioSubrogadoTipo()
        {
            _ServicioSubrogadoTipoDescripcion = String.Empty;
        }
        

        Int16 _ServicioSubrogadoTipoId;
        public Int16 ServicioSubrogadoTipoId { get { return _ServicioSubrogadoTipoId; } set { _ServicioSubrogadoTipoId = value; } }
        
        String _ServicioSubrogadoTipoDescripcion;
        [StringLength(200)]
        public String ServicioSubrogadoTipoDescripcion { get { return _ServicioSubrogadoTipoDescripcion; } set { _ServicioSubrogadoTipoDescripcion = value; } }
    }
}