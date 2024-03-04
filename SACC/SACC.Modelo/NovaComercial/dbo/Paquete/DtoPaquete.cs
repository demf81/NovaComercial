using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Paquete
{
    public class DtoPaquete : ModeloBase
    {
        public DtoPaquete()
        {
            _PaqueteDescripcion = string.Empty;
            _Codigo             = string.Empty;
        }


        Int32 _PaqueteId;
        public Int32 PaqueteId { get { return _PaqueteId; } set { _PaqueteId = value; } }

        String _PaqueteDescripcion;
        [StringLength(250)]
        public String PaqueteDescripcion { get { return _PaqueteDescripcion; } set { _PaqueteDescripcion = value; } }

        Int32 _AreaNegocioId;
        public Int32 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }

        Int16 _PaqueteTipoId;
        public Int16 PaqueteTipoId { get { return _PaqueteTipoId; } set { _PaqueteTipoId = value; } }

        String _Codigo;
        [StringLength(100)]
        public String Codigo { get { return _Codigo; } set { _Codigo = value; } }

        Decimal _PrecioLista;
        public Decimal PrecioLista { get { return _PrecioLista; } set { _PrecioLista = value; } }

        Decimal _PrecioVenta;
        public Decimal PrecioVenta { get { return _PrecioVenta; } set { _PrecioVenta = value; } }

        Int16 _GeneroId;
        public Int16 GeneroId { get { return _GeneroId; } set { _GeneroId = value; } }

        Int16 _EdadDesde;
        public Int16 EdadDesde { get { return _EdadDesde; } set { _EdadDesde = value; } }

        Int16 _EdadHasta;
        public Int16 EdadHasta { get { return _EdadHasta; } set { _EdadHasta = value; } }
    }
}