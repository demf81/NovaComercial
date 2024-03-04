using System;


namespace SACC.Modelo.NovaComercial.SACC.Membresia
{
    public class DtoMembresia : ModeloBase
    {
        public DtoMembresia()
        {

        }


        Int32 _MembresiaId;
        public Int32 MembresiaId { get { return _MembresiaId; } set { _MembresiaId = value; } }

        DateTime _Fecha;
        public DateTime Fecha { get { return _Fecha; } set { _Fecha = value; } }

        DateTime _Vigencia;
        public DateTime Vigencia { get { return _Vigencia; } set { _Vigencia = value; } }

        Int16 _MembresiaTipoId;
        public Int16 MembresiaTipoId { get { return _MembresiaTipoId; } set { _MembresiaTipoId = value; } }

        Int32 _ContratanteId;
        public Int32 ContratanteId { get { return _ContratanteId; } set { _ContratanteId = value; } }

        Int32 _CantidadAfiliados;
        public Int32 CantidadAfiliados { get { return _CantidadAfiliados; } set { _CantidadAfiliados = value; } }

        Int32 _CantidadAdicionales;
        public Int32 CantidadAdicionales { get { return _CantidadAdicionales; } set { _CantidadAdicionales = value; } }

        Int32 _NumPedido;
        public Int32 NumPedido { get { return _NumPedido; } set { _NumPedido = value; } }

        Int32 _NumRecibo;
        public Int32 NumRecibo { get { return _NumRecibo; } set { _NumRecibo = value; } }
    }
}