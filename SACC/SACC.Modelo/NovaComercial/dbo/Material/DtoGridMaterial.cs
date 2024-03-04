using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Material
{
    public class DtoGridMaterial
    {
        public DtoGridMaterial()
        { }
        
        Int32 _MaterialId;
        public Int32 MaterialId { get { return _MaterialId; } set { _MaterialId = value; } }
        
        String _MaterialDescripcion;
        [StringLength(100)]
        public String MaterialDescripcion { get { return _MaterialDescripcion; } set { _MaterialDescripcion = value; } }
        
        String _Presentacion;
        [StringLength(20)]
        public String Presentacion { get { return _Presentacion; } set { _Presentacion = value; } }
        
        Decimal? _Costo;
        public Decimal? Costo { get { return _Costo; } set { _Costo = value; } }
        
        Int32? _UnidadMedidaId;
        public Int32? UnidadMedidaId { get { return _UnidadMedidaId; } set { _UnidadMedidaId = value; } }
        
        private Boolean _Baja;
        public Boolean Baja { get { return _Baja; } set { _Baja = value; } }
    }
}