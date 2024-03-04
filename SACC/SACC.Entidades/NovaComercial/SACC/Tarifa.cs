using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class Tarifa : EntidadBase
    {
        public Tarifa()
        {
            _TarifaDescripcion = string.Empty;
        }
        

        Int32 _TarifaId;
        public Int32 TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }
        
        String _TarifaDescripcion;
        [StringLength(200)]
        public String TarifaDescripcion { get { return _TarifaDescripcion; } set { _TarifaDescripcion = value; } }

        Int16 _AreaNegocioId;
        public Int16 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }
    }
}