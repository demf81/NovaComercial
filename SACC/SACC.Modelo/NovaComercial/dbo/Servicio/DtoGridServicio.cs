using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Servicio
{
    public class DtoGridServicio
    {
        public DtoGridServicio()
        { }
        
        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }
        
        String _ServicioDescripcion;
        [StringLength(100)]
        public String ServicioDescripcion { get { return _ServicioDescripcion; } set { _ServicioDescripcion = value; } }
        
        Int32? _ServicioTipoId;
        public Int32? ServicioTipoId { get { return _ServicioTipoId; } set { _ServicioTipoId = value; } }
        
        String _ServicioTipoDescripcion;
        [StringLength(100)]
        public String ServicioTipoDescripcion { get { return _ServicioTipoDescripcion; } set { _ServicioTipoDescripcion = value; } }
        
        Decimal? _Costo;
        public Decimal? Costo { get { return _Costo; } set { _Costo = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}