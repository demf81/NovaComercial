using System;


namespace SACC.Modelo.NovaComercial.dbo.PaqueteDetalle
{
    public class DtoPaqueteDetalle : ModeloBase
    {
        public DtoPaqueteDetalle()
        {

        }


        Int32 _PaqueteDetalleId;
        public Int32 PaqueteDetalleId { get { return _PaqueteDetalleId; } set { _PaqueteDetalleId = value; } }


        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }


        Int32 _ItemTipoId;
        public Int32 ItemTipoId { get { return _ItemTipoId; } set { _ItemTipoId = value; } }


        Int32 _ItemId;
        public Int32 ItemId { get { return _ItemId; } set { _ItemId = value; } }
    }
}