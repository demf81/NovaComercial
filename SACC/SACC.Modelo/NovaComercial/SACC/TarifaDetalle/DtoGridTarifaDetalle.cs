using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.TarifaDetalle
{
    public class DtoGridTarifaDetalle
    {
        public DtoGridTarifaDetalle()
        {
            
        }


        Int32 _TarifaDetalleId;
        public Int32 TarifaDetalleId { get { return _TarifaDetalleId; } set { _TarifaDetalleId = value; } }

        Int32 _TarifaId;
        public Int32 TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }

        Int16 _AreaNegocioId;
        public Int16 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }

        String _AreaNegocioDescripcion;
        [StringLength(200)]
        public String AreaNegocioDescripcion { get { return _AreaNegocioDescripcion; } set { _AreaNegocioDescripcion = value; } }

        Int16 _ServicioId;
        public Int16 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        String _ServicioDescripcion;
        [StringLength(200)]
        public String ServicioDescripcion { get { return _ServicioDescripcion; } set { _ServicioDescripcion = value; } }

        Decimal _Porcentaje;
        public Decimal Porcentaje { get { return _Porcentaje; } set { _Porcentaje = value; } }

        Boolean _AplicaAjuste;
        public Boolean AplicaAjuste { get { return _AplicaAjuste; } set { _AplicaAjuste = value; } }

        Decimal _Ajuste;
        public Decimal Ajuste { get { return _Ajuste; } set { _Ajuste = value; } }

        Int16 _EstatusId;
        public Int16 EstatusId { get { return _EstatusId; } set { _EstatusId = value; } }
    }
}