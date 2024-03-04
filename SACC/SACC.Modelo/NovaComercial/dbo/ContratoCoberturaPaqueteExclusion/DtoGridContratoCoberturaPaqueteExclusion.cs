using System;


namespace SACC.Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion
{
    public class DtoGridContratoCoberturaPaqueteExclusion
    {
        public DtoGridContratoCoberturaPaqueteExclusion()
        {

        }


        Int32 _ContratoCoberturaPaqueteExclusionId;
        public Int32 ContratoCoberturaPaqueteExclusionId { get { return _ContratoCoberturaPaqueteExclusionId; } set { _ContratoCoberturaPaqueteExclusionId = value; } }

        //Int32 _ContratoCoberturaPaqueteId;
        //public Int32 ContratoCoberturaPaqueteId { get { return _ContratoCoberturaPaqueteId; } set { _ContratoCoberturaPaqueteId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        Int32 _PaqueteDetalleId;
        public Int32 PaqueteDetalleId { get { return _PaqueteDetalleId; } set { _PaqueteDetalleId = value; } }

        Int32 _ItemId;
        public Int32 ItemId { get { return _ItemId; } set { _ItemId = value; } }

        Int32 _ItemTipoId;
        public Int32 ItemTipoId { get { return _ItemTipoId; } set { _ItemTipoId = value; } }

        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        String _ItemTipoDescripcion;
        public String ItemTipoDescripcion { get { return _ItemTipoDescripcion; } set { _ItemTipoDescripcion = value; } }

        String _ServicioDescripcion;
        public String ServicioDescripcion { get { return _ServicioDescripcion; } set { _ServicioDescripcion = value; } }

        String _ServicioTipoDescripcion;
        public String ServicioTipoDescripcion { get { return _ServicioTipoDescripcion; } set { _ServicioTipoDescripcion = value; } }

        Boolean _EstatusExcluido;
        public Boolean EstatusExcluido { get { return _EstatusExcluido; } set { _EstatusExcluido = value; } }

        Boolean _Excluido;
        public Boolean Excluido { get { return _Excluido; } set { _Excluido = value; } }
    }
}