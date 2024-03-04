using System;


namespace SACC.Modelo.NovaComercial.SACC.MembresiaRenovacion
{
    public class DtoMembresiaRenovacion : ModeloBase
    {
        public DtoMembresiaRenovacion()
        {

        }


        Int32 _MembresiaRenovacionId;
        public Int32 MembresiaRenovacionId { get { return _MembresiaRenovacionId; } set { _MembresiaRenovacionId = value; } }

        Int32 _MembresiaId;
        public Int32 MembresiaId { get { return _MembresiaId; } set { _MembresiaId = value; } }

        DateTime _Fecha;
        public DateTime Fecha { get { return _Fecha; } set { _Fecha = value; } }

        Int64 _NumPedido;
        public Int64 NumPedido { get { return _NumPedido; } set { _NumPedido = value; } }

        Int64 _NumRecibo;
        public Int64 NumRecibo { get { return _NumRecibo; } set { _NumRecibo = value; } }
    }
}