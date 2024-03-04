using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Tarifa
{
    public class DtoComboTarifa
    {
        public DtoComboTarifa()
        {

        }


        Int32 _TarifaId;
        public Int32 TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }
        
        String _TarifaDescripcion;
        [StringLength(200)]
        public String TarifaDescripcion { get { return _TarifaDescripcion; } set { _TarifaDescripcion = value; } }
    }
}