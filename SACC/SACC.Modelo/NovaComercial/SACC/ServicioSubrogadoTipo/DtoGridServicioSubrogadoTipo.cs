using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.ServicioSubrogadoTipo
{
    public class DtoGridServicioSubrogadoTipo
    {
        public DtoGridServicioSubrogadoTipo()
        {
            _ServicioSubrogadoTipoDescripcion = String.Empty;
        }
        

        Int32 _ServicioSubrogadoTipoId;
        public Int32 ServicioSubrogadoTipoId { get { return _ServicioSubrogadoTipoId; } set { _ServicioSubrogadoTipoId = value; } }
        
        String _ServicioSubrogadoTipoDescripcion;
        [StringLength(100)]
        public String ServicioSubrogadoTipoDescripcion { get { return _ServicioSubrogadoTipoDescripcion; } set { _ServicioSubrogadoTipoDescripcion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}