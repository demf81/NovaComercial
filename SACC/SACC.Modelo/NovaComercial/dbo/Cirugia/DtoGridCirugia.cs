using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Cirugia
{
    public class DtoGridCirugia 
    {
        public DtoGridCirugia()
        { }
        
        Int32 _CirugiaId;
        public Int32 CirugiaId { get { return _CirugiaId; } set { _CirugiaId = value; } }
        
        String _CirugiaDescripcion;
        [StringLength(250)]
        public String CirugiaDescripcion { get { return _CirugiaDescripcion; } set { _CirugiaDescripcion = value; } }
        
        Int32? _Duracion;
        public Int32? Duracion { get { return _Duracion; } set { _Duracion = value; } }
        
        Decimal? _Costo;
        public Decimal? Costo { get { return _Costo; } set { _Costo = value; } }
        
        private Boolean _Baja;
        public Boolean Baja { get { return _Baja; } set { _Baja = value; } }
    }
}