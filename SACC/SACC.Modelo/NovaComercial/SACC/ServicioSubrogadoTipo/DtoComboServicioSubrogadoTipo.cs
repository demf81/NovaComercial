using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.ServicioSubrogadoTipo
{
    public class DtoComboServicioSubrogadoTipo
    {
        public DtoComboServicioSubrogadoTipo()
        {

        }
        

        Int32 _ServicioSubrogadoTipoId;
        public Int32 ServicioSubrogadoTipoId { get { return _ServicioSubrogadoTipoId; } set { _ServicioSubrogadoTipoId = value; } }
        
        String _ServicioSubrogadoTipoDescripcion;
        [StringLength(200)]
        public String ServicioSubrogadoTipoDescripcion { get { return _ServicioSubrogadoTipoDescripcion; } set { _ServicioSubrogadoTipoDescripcion = value; } }
    }
}