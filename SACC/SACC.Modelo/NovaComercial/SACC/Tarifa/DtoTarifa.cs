using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Tarifa
{
    public class DtoTarifa : ModeloBase
    {
        public DtoTarifa()
        {
            _TarifaDescripcion = String.Empty;
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