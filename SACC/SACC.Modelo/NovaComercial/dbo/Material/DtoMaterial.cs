using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Material
{
    public class DtoMaterial  : ModeloBase
    {
        public DtoMaterial()
        {
            _MaterialDescripcion    = String.Empty;
            _CodigoServiciosMedicos = String.Empty;
            _Ssa                    = String.Empty;
            _Presentacion           = String.Empty;
            _ComentarioEliminar     = String.Empty;
            _CodigoBarras           = String.Empty;
        }

        Int32 _MaterialId;
        public Int32 MaterialId { get { return _MaterialId; } set { _MaterialId = value; } }

        String _MaterialDescripcion;
        [StringLength(100)]
        public String MaterialDescripcion { get { return _MaterialDescripcion; } set { _MaterialDescripcion = value; } }
        
        Int32? _Codigo;
        public Int32? Codigo { get { return _Codigo; } set { _Codigo = value; } }
        
        long _CodigoAlterno;
        public long CodigoAlterno { get { return _CodigoAlterno; } set { _CodigoAlterno = value; } }
        
        String _CodigoServiciosMedicos;
        [StringLength(10)]
        public String CodigoServiciosMedicos { get { return _CodigoServiciosMedicos; } set { _CodigoServiciosMedicos = value; } }
        
        Int32? _ProveedorId;
        public Int32? ProveedorId { get { return _ProveedorId; } set { _ProveedorId = value; } }
        
        Boolean? _CateterSonda;
        public Boolean? CateterSonda { get { return _CateterSonda; } set { _CateterSonda = value; } }
        
        Int32? _CateterTipoId;
        public Int32? CateterTipoId { get { return _CateterTipoId; } set { _CateterTipoId = value; } }
        
        String _Ssa;
        [StringLength(20)]
        public String Ssa { get { return _Ssa; } set { _Ssa = value; } }
        
        String _Presentacion;
        [StringLength(20)]
        public String Presentacion { get { return _Presentacion; } set { _Presentacion = value; } }
        
        Boolean? _ReaprovisionMultiplos;
        public Boolean? ReaprovisionMultiplos { get { return _ReaprovisionMultiplos; } set { _ReaprovisionMultiplos = value; } }
        
        Decimal? _PrecioLista;
        public Decimal? PrecioLista { get { return _PrecioLista; } set { _PrecioLista = value; } }
        
        Decimal? _PrecioMaximo;
        public Decimal? PrecioMaximo { get { return _PrecioMaximo; } set { _PrecioMaximo = value; } }
        
        Decimal? _Iva;
        public Decimal? Iva { get { return _Iva; } set { _Iva = value; } }

        Decimal? _Costo;
        public Decimal? Costo { get { return _Costo; } set { _Costo = value; } }
        
        Decimal? _PrecioMinimo;
        public Decimal? PrecioMinimo { get { return _PrecioMinimo; } set { _PrecioMinimo = value; } }
        
        Int32? _UnidadMedidaId;
        public Int32? UnidadMedidaId { get { return _UnidadMedidaId; } set { _UnidadMedidaId = value; } }
        
        Int32? _Reorden;
        public Int32? Reorden { get { return _Reorden; } set { _Reorden = value; } }
        
        Int32? _Conversion;
        public Int32? Conversion { get { return _Conversion; } set { _Conversion = value; } }
        
        Decimal? _PrecioVentaPublico;
        public Decimal? PrecioVentaPublico { get { return _PrecioVentaPublico; } set { _PrecioVentaPublico = value; } }
        
        Decimal? _DescClubSalud;
        public Decimal? DescClubSalud { get { return _DescClubSalud; } set { _DescClubSalud = value; } }
        
        Int32? _ConversionCompras;
        public Int32? ConversionCompras { get { return _ConversionCompras; } set { _ConversionCompras = value; } }
        
        Int32? _CantidadUnidades;
        public Int32? CantidadUnidades { get { return _CantidadUnidades; } set { _CantidadUnidades = value; } }
        
        String _ComentarioEliminar;
        [StringLength(1000)]
        public String ComentarioEliminar { get { return _ComentarioEliminar; } set { _ComentarioEliminar = value; } }
        
        Boolean? _Sisoc;
        public Boolean? Sisoc { get { return _Sisoc; } set { _Sisoc = value; } }
        
        String _CodigoBarras;
        [StringLength(20)]
        public String CodigoBarras { get { return _CodigoBarras; } set { _CodigoBarras = value; } }
        
        Int32 _MaterialManejoId;
        public Int32 MaterialManejoId { get { return _MaterialManejoId; } set { _MaterialManejoId = value; } }
    }
}