using System;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class PaqueteDetalle : EntidadBase
    {
        public PaqueteDetalle()
        {

        }


        Int32 _PaqueteDetalleId;
        public Int32 PaqueteDetalleId { get { return _PaqueteDetalleId; } set { _PaqueteDetalleId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        Boolean _Exclusion;
        public Boolean Exclusion { get { return _Exclusion; } set { _Exclusion = value; } }

        Int32 _ItemTipoId;
        public Int32 ItemTipoId { get { return _ItemTipoId; } set { _ItemTipoId = value; } }

        Int32 _ItemId;
        public Int32 ItemId { get { return _ItemId; } set { _ItemId = value; } }
    }
}