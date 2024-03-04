using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Entidades.NovaComercial.dbo
{
    public class Medicamento : EntidadBase
    {
        public Medicamento()
        {
            _MedicamentoDescripcion = string.Empty;
            _CodigoServiciosMedicos = string.Empty;
            _Presentacion           = string.Empty;
            _CodigoBarras           = string.Empty;
        }
        
        Int32 _MedicamentoId;
        public Int32 MedicamentoId { get { return _MedicamentoId; } set {    _MedicamentoId = value; } }
        
        String _MedicamentoDescripcion;
        [StringLength(100)]
        public String MedicamentoDescripcion { get { return _MedicamentoDescripcion; } set { _MedicamentoDescripcion = value; } }
        
        Int32? _Codigo;
        public Int32? Codigo { get { return _Codigo; } set { _Codigo = value; } }
        
        Int64 _CodigoAlterno;
        public Int64 CodigoAlterno { get { return _CodigoAlterno; } set { _CodigoAlterno = value; } }
        
        String _CodigoServiciosMedicos;
        [StringLength(10)]
        public String CodigoServiciosMedicos { get { return _CodigoServiciosMedicos; } set { _CodigoServiciosMedicos = value; } }
        
        Int32? _ProveedorId;
        public Int32? ProveedorId { get { return _ProveedorId; } set { _ProveedorId = value; } }
        
        Int32? _MedicamentoCuadroTipoId;
        public Int32? MedicamentoCuadroTipoId { get { return _MedicamentoCuadroTipoId; } set { _MedicamentoCuadroTipoId = value; } }
        
        String _Presentacion;
        [StringLength(20)]
        public String Presentacion { get { return _Presentacion; } set { _Presentacion = value; } }
        
        Boolean? _Solucion;
        public Boolean? Solucion { get { return _Solucion; } set { _Solucion = value; } }
        
        Int64? _Inmunizacion;
        public Int64? Inmunizacion { get { return _Inmunizacion; } set { _Inmunizacion = value; } }
        
        Boolean? _Contrlado;
        public Boolean? Contrlado { get { return _Contrlado; } set { _Contrlado = value; } }
        
        Boolean? _Oxitonito;
        public Boolean? Oxitonito { get { return _Oxitonito; } set { _Oxitonito = value; } }
        
        Boolean? _ReaprovisionMultiplos;
        public Boolean? ReaprovisionMultiplos { get { return _ReaprovisionMultiplos; } set { _ReaprovisionMultiplos = value; } }
        
        Boolean? _FormulaLactea;
        public Boolean? FormulaLactea { get { return _FormulaLactea; } set { _FormulaLactea = value; } }
        
        Boolean? _Refrigerado;
        public Boolean? Refrigerado { get { return _Refrigerado; } set { _Refrigerado = value; } }
        
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
        
        Decimal? _PrecioVentaPublico;
        public Decimal? PrecioVentaPublico { get { return _PrecioVentaPublico; } set { _PrecioVentaPublico = value; } }

        Decimal? _DescClubSalud;
        public Decimal? DescClubSalud { get { return _DescClubSalud; } set { _DescClubSalud = value; } }
        
        Int32? _CantidadUnidades;
        public Int32? CantidadUnidades { get { return _CantidadUnidades; } set { _CantidadUnidades = value; } }
        
        String _CodigoBarras;
        [StringLength(20)]
        public String CodigoBarras { get { return _CodigoBarras; } set { _CodigoBarras = value; } }
    }
}