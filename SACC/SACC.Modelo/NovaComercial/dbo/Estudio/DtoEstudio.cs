using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Estudio
{
    public class DtoEstudio : ModeloBase
    {
        public DtoEstudio()
        {
            _EstudioDescripcion = String.Empty;
        }
        
        Int32 _EstudioId;
        public Int32 EstudioId { get { return _EstudioId; } set { _EstudioId = value; } }
        
        String _EstudioDescripcion;
        [StringLength(100)]
        public String EstudioDescripcion { get { return _EstudioDescripcion; } set { _EstudioDescripcion = value; } }
                
        Decimal _PrecioVentaPublico;
        public Decimal PrecioVentaPublico { get { return _PrecioVentaPublico; } set { _PrecioVentaPublico = value; } }
        
        Int32? _ServicioId;
        public Int32? ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }
    }
}