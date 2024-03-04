using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class Servicio : EntidadBase
    {
        public Servicio()
        {
            _ServicioDescripcion = string.Empty;
            _CodigoAlterno       = string.Empty;
            _DescAmbPart         = string.Empty;
        }
        
        Int32 _ServicioId;
        public Int32 ServicioId { get { return _ServicioId; } set { _ServicioId = value; } }
        
        String _ServicioDescripcion;
        [StringLength(100)]
        public String ServicioDescripcion { get { return _ServicioDescripcion; } set { _ServicioDescripcion = value; } }
        
        Int32? _ServicioTipoId;
        public Int32? ServicioTipoId { get { return _ServicioTipoId; } set { _ServicioTipoId = value; } }
        
        Int32? _Codigo;
        public Int32? Codigo { get { return _Codigo; } set { _Codigo = value; } }
        
        String _CodigoAlterno;
        [StringLength(20)]
        public String CodigoAlterno { get { return _CodigoAlterno; } set { _CodigoAlterno = value; } }
        
        Boolean? _Especial;
        public Boolean? Especial { get { return _Especial; } set { _Especial = value; } }
        
        Boolean? _MostrarHospitalizacion;
        public Boolean? MostrarHospitalizacion { get { return _MostrarHospitalizacion; } set { _MostrarHospitalizacion = value; } }
        
        Decimal? _Adquisicion;
        public Decimal? Adquisicion { get { return _Adquisicion; } set { _Adquisicion = value; } }
        
        Decimal? _PrecioLista;
        public Decimal? PrecioLista { get { return _PrecioLista; } set { _PrecioLista = value; } }
        
        Decimal? _PrecioVentaPublico;
        public Decimal? PrecioVentaPublico { get { return _PrecioVentaPublico; } set { _PrecioVentaPublico = value; } }
        
        Decimal? _PrecioVenta;
        public Decimal? PrecioVenta { get { return _PrecioVenta; } set { _PrecioVenta = value; } }
        
        Decimal? _DescuentoPuntaVenta;
        public Decimal? DescuentoPuntaVenta { get { return _DescuentoPuntaVenta; } set { _DescuentoPuntaVenta = value; } }
        
        Int32? _PacienteTipoId;
        public Int32? PacienteTipoId { get { return _PacienteTipoId; } set { _PacienteTipoId = value; } }
        
        String _DescAmbPart;
        [StringLength(100)]
        public String DescAmbPart { get { return _DescAmbPart; } set { _DescAmbPart = value; } }
        
        Int32? _Iva;
        public Int32? Iva { get { return _Iva; } set { _Iva = value; } }
        
        Int32? _Jubilados;
        public Int32? Jubilados { get { return _Jubilados; } set { _Jubilados = value; } }
        
        Int32? _UnidadMedidaId;
        public Int32? UnidadMedidaId { get { return _UnidadMedidaId; } set { _UnidadMedidaId = value; } }
    }
}