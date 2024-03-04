using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Medicamento
{
    public class DtoMedicamento : ModeloBase
    {
        public DtoMedicamento()
        {
            _MedicamentoDescripcion = String.Empty;
        }
        
        Int32 _MedicamentoId;
        public Int32 MedicamentoId { get { return _MedicamentoId; } set { _MedicamentoId = value; } }
        
        String _MedicamentoDescripcion;
        [StringLength(100)]
        public String MedicamentoDescripcion { get { return _MedicamentoDescripcion; } set { _MedicamentoDescripcion = value; } }
        
        Int32? _MedicamentoCuadroTipoId;
        public Int32? MedicamentoCuadroTipoId { get { return _MedicamentoCuadroTipoId; } set { _MedicamentoCuadroTipoId = value; } }
        
        String _Presentacion;
        [StringLength(20)]
        public String Presentacion { get { return _Presentacion; } set { _Presentacion = value; } }
        
        Boolean? _Solucion;
        public Boolean? Solucion { get { return _Solucion; } set { _Solucion = value; } }
        
        Boolean? _Contrlado;
        public Boolean? Contrlado { get { return _Contrlado; } set { _Contrlado = value; } }
        
        Boolean? _FormulaLactea;
        public Boolean? FormulaLactea { get { return _FormulaLactea; } set { _FormulaLactea = value; } }
        
        Boolean? _Refrigerado;
        public Boolean? Refrigerado { get { return _Refrigerado; } set { _Refrigerado = value; } }
        
        Decimal? _Costo;
        public Decimal? Costo { get { return _Costo; } set { _Costo = value; } }
        
        Int32? _UnidadMedidaId;
        public Int32? UnidadMedidaId { get { return _UnidadMedidaId; } set { _UnidadMedidaId = value; } }
    }
}