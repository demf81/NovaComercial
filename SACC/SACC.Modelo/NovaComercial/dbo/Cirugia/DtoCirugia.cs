using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Cirugia
{
    public class DtoCirugia : ModeloBase
    {
        public DtoCirugia()
        {
            _CirugiaDescripcion = String.Empty;
        }

        Int32 _CirugiaId;
        public Int32 CirugiaId { get { return _CirugiaId; } set { _CirugiaId = value; } }
        
        String _CirugiaDescripcion;
        [StringLength(250)]
        public String CirugiaDescripcion { get { return _CirugiaDescripcion; } set { _CirugiaDescripcion = value; } }
        
        Decimal _PrecioVentaPublico;
        public Decimal PrecioVentaPublico { get { return _PrecioVentaPublico; } set { _PrecioVentaPublico = value; } }
    }
}