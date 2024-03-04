using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.ServicioTipo
{
    public class DtoGridServicioTipo
    {
        public DtoGridServicioTipo()
        {
            _ServicioTipoDescripcion = String.Empty;
        }
        
        Int32 _ServicioTipoId;
        public Int32 ServicioTipoId { get { return _ServicioTipoId; } set { _ServicioTipoId = value; } }
        
        String _ServicioTipoDescripcion;
        [StringLength(100)]
        public String ServicioTipoDescripcion { get { return _ServicioTipoDescripcion; } set { _ServicioTipoDescripcion = value; } }
        
        Boolean? _Baja;
        public Boolean? Baja { get { return _Baja; } set { _Baja = value; } }
    }
}