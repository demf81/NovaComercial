using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SACC.Modelo.NovaComercial.dbo.PaqueteDetalle
{
    public class DtoCtrlUserPaqueteDetalleAllServicioView
    {
        public DtoCtrlUserPaqueteDetalleAllServicioView()
        {

        }


        Int32 _PaqueteDetalleId;
        public Int32 PaqueteDetalleId { get { return _PaqueteDetalleId; } set { _PaqueteDetalleId = value; } }

        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        String _PaqueteDescripcion;
        public String PaqueteDescripcion { get { return _PaqueteDescripcion; } set { _PaqueteDescripcion = value; } }

        Int32 _ItemId;
        public Int32 ItemId { get { return _ItemId; } set { _ItemId = value; } }

        String _ItemDescripcion;
        public String ItemDescripcion { get { return _ItemDescripcion; } set { _ItemDescripcion = value; } }

        Int32 _ItemTipoId;
        public Int32 ItemTipoId { get { return _ItemTipoId; } set { _ItemTipoId = value; } }

        String _ItemTipoDescripcion;
        public String ItemTipoDescripcion { get { return _ItemTipoDescripcion; } set { _ItemTipoDescripcion = value; } }

        Int32 _Cantidad;
        public Int32 Cantidad { get { return _Cantidad; } set { _Cantidad = value; } }

        Boolean _Amparado;
        public Boolean Amparado { get { return _Amparado; } set { _Amparado = value; } }

        Int32 _PaqueteCoberturaId;
        public Int32 PaqueteCoberturaId { get { return _PaqueteCoberturaId; } set { _PaqueteCoberturaId = value; }  }
    }
}