using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.Parametro.NovaComercial.SACC
{
    public class TarifaPM : ModeloBasePM
    {
        public TarifaPM()
        {
            _TarifaId          = 0;
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