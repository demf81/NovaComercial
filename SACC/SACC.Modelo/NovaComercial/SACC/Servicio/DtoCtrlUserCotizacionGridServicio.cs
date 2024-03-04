using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.SACC.Servicio
{
    public class DtoCtrlUserCotizacionGridServicio
    {
        public DtoCtrlUserCotizacionGridServicio()
        {
            _ItemDescripcion = string.Empty;
        }
        

        Int32 _AreaNegocioId;
        public Int32 AreaNegocioId { get { return _AreaNegocioId; } set { _AreaNegocioId = value; } }

        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }

        Int32 _ItemId;
        public Int32 ItemId { get { return _ItemId; } set { _ItemId = value; } }

        String _ItemDescripcion;
        [StringLength(200)]
        public String ItemDescripcion { get { return _ItemDescripcion; } set { _ItemDescripcion = value; } }

        Int32 _ItemTipoId;
        public Int32 ItemTipoId { get { return _ItemTipoId; } set { _ItemTipoId = value; } }

        String _ItemTipoDescripcion;
        [StringLength(250)]
        public String ItemTipoDescripcion { get { return _ItemTipoDescripcion; } set { _ItemTipoDescripcion = value; } }

        Decimal _Costo;
        public Decimal Costo { get { return _Costo; } set { _Costo = value; } }

        Decimal _Precio;
        public Decimal Precio { get { return _Precio; } set { _Precio = value; } }

        Decimal _PrecioConIva;
        public Decimal PrecioConIva { get { return _PrecioConIva; } set { _PrecioConIva = value; } }

        Decimal _Anticipo;
        public Decimal Anticipo { get { return _Anticipo; } set { _Anticipo = value; } }

        Decimal _Iva;
        public Decimal Iva { get { return _Iva; } set { _Iva = value; } }

        Int32 _TarifaId;
        public Int32 TarifaId { get { return _TarifaId; } set { _TarifaId = value; } }

        Int32 _CampaniaId;
        public Int32 CampaniaId { get { return _CampaniaId; } set { _CampaniaId = value; } }
    }
}