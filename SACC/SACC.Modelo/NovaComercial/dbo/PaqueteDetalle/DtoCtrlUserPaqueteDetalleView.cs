using System;


namespace SACC.Modelo.NovaComercial.dbo.PaqueteDetalle
{
    public class DtoCtrlUserPaqueteDetalleView
    {
        public DtoCtrlUserPaqueteDetalleView()
        {

        }

        Int32 _PaqueteDetalleId;
        public Int32 PaqueteDetalleId { get { return _PaqueteDetalleId; } set { _PaqueteDetalleId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        String _PaqueteDescripcion;
        public String PaqueteDescripcion { get { return _PaqueteDescripcion; } set { _PaqueteDescripcion = value; } }

        Int32 _CodigoServiciosMedicos;
        public Int32 CodigoServiciosMedicos { get { return _CodigoServiciosMedicos; } set { _CodigoServiciosMedicos = value; } }

        Int32 _ItemId;
        public Int32 ItemId { get { return _ItemId; } set { _ItemId = value; } }

        String _ItemDescripcion;
        public String ItemDescripcion { get { return _ItemDescripcion; } set { _ItemDescripcion = value; } }

        Int32 _ItemTipoId;
        public Int32 ItemTipoId { get { return _ItemTipoId; } set { _ItemTipoId = value; } }

        String _ItemTipoDescripcion;
        public String ItemTipoDescripcion { get { return _ItemTipoDescripcion; } set { _ItemTipoDescripcion = value; } }

        String _EstudioRelacionado;
        public String EstudioRelacionado { get { return _EstudioRelacionado; } set { _EstudioRelacionado = value; } }
    }
}