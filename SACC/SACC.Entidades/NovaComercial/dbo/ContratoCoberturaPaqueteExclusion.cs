using System;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class ContratoCoberturaPaqueteExclusion : EntidadBase
    {
        public ContratoCoberturaPaqueteExclusion()
        {

        }


        Int32 _ContratoCoberturaPaqueteExclusionId;
        public Int32 ContratoCoberturaPaqueteExclusionId { get { return _ContratoCoberturaPaqueteExclusionId; } set { _ContratoCoberturaPaqueteExclusionId = value; } }

        Int32 _ContratoCoberturaPaqueteId;
        public Int32 ContratoCoberturaPaqueteId { get { return _ContratoCoberturaPaqueteId; } set { _ContratoCoberturaPaqueteId = value; } }

        Int32 _ContratoCoberturaId;
        public Int32 ContratoCoberturaId { get { return _ContratoCoberturaId; } set { _ContratoCoberturaId = value; } }

        Int32 _ContratoId;
        public Int32 ContratoId { get { return _ContratoId; } set { _ContratoId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        Int32 _PaqueteDetalleId;
        public Int32 PaqueteDetalleId { get { return _PaqueteDetalleId; } set { _PaqueteDetalleId = value; } }

        Int32 _ItemTipoId;
        public Int32 ItemTipoId { get { return _ItemTipoId; } set { _ItemTipoId = value; } }

        Int32 _ItemId;
        public Int32 ItemId { get { return _ItemId; } set { _ItemId = value; } }

        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }
    }
}