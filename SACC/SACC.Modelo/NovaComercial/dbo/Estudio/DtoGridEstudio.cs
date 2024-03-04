using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Estudio
{
    public class DtoGridEstudio
    {
        public DtoGridEstudio()
        { }
        
        Int32 _EstudioId;
        public Int32 EstudioId { get { return _EstudioId; } set { _EstudioId = value; } }
        
        String _EstudioDescripcion;
        [StringLength(100)]
        public String EstudioDescripcion { get { return _EstudioDescripcion; } set { _EstudioDescripcion = value; } }
        
        Decimal _Costo;
        public Decimal Costo { get { return _Costo; } set { _Costo = value; } }
        
        private Boolean _Baja;
        public Boolean Baja { get { return _Baja; } set { _Baja = value; } }
    }
}