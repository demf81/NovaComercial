using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Tarifa
{
    public class DtoGridTarifa
    {
        public DtoGridTarifa()
        {
            _TarifaDescripcion = String.Empty;
        }
        

        Int32 _TarifaId;
        public Int32 TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }
        
        String _TarifaDescripcion;
        [StringLength(200)]
        public String TarifaDescripcion { get { return _TarifaDescripcion; } set { _TarifaDescripcion = value; } }

        String _AreaNegocioDescripcion;
        [StringLength(200)]
        public String AreaNegocioDescripcion { get { return _AreaNegocioDescripcion; } set { _AreaNegocioDescripcion = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}
