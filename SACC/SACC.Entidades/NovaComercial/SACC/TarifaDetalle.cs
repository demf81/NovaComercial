﻿using System;


namespace SACC.Entidades.NovaComercial.SACC
{
    public class TarifaDetalle : EntidadBase
    {
        public TarifaDetalle()
        {

        }


        Int32 _TarifaDetalleId;
        public Int32 TarifaDetalleId { get { return _TarifaDetalleId; } set { _TarifaDetalleId = value; } }

        Int32 _TarifaId;
        public Int32 TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }

        Int16 _AreaNegocioId;
        public Int16 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }

        Int16 _ServicioId;
        public Int16 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        Decimal _Porcentaje;
        public Decimal Porcentaje { get { return _Porcentaje; } set { _Porcentaje = value; } }

        Boolean _AplicaAjuste;
        public Boolean AplicaAjuste { get { return _AplicaAjuste; } set { _AplicaAjuste = value; } }

        Decimal _Ajuste;
        public Decimal Ajuste { get { return _Ajuste; } set { _Ajuste = value; } }
    }
}