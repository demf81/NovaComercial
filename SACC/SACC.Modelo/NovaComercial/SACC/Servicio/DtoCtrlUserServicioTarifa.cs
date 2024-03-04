using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Servicio
{
    public class DtoCtrlUserServicioTarifa
    {
        public DtoCtrlUserServicioTarifa()
        {

        }
        

        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        String _ServicioDescripcion;
        [StringLength(200)]
        public String ServicioDescripcion { get { return _ServicioDescripcion; } set { _ServicioDescripcion = value; } }
        
        Decimal _Porcentaje;
        public Decimal Porcentaje { get { return _Porcentaje; } set { _Porcentaje = value; } }

        Boolean _AplicaAjuste;
        public Boolean AplicaAjuste { get { return _AplicaAjuste; } set { _AplicaAjuste = value; } }

        Decimal _Ajuste;
        public Decimal Ajuste { get { return _Ajuste; } set { _Ajuste = value; } }
    }
}