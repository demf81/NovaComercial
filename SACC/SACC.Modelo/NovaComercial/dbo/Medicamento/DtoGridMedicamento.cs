using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.Medicamento
{
    public class DtoGridMedicamento
    {
        public DtoGridMedicamento()
        { }
        
        Int32 _MedicamentoId;
        public Int32 MedicamentoId { get { return _MedicamentoId; } set { _MedicamentoId = value; } }
        
        String _MedicamentoDescripcion;
        [StringLength(100)]
        public String MedicamentoDescripcion { get { return _MedicamentoDescripcion; } set { _MedicamentoDescripcion = value; } }
        
        Int32? _MedicamentoCuadroTipoId;
        public Int32? MedicamentoCuadroTipoId { get { return _MedicamentoCuadroTipoId; } set { _MedicamentoCuadroTipoId = value; } }
        
        String _MedicamentoCuadroTipoDescripcion;
        [StringLength(100)]
        public String MedicamentoCuadroTipoDescripcion { get { return _MedicamentoCuadroTipoDescripcion; } set { _MedicamentoCuadroTipoDescripcion = value; } }
        
        Decimal? _Costo;
        public Decimal? Costo { get { return _Costo; } set { _Costo = value; } }
        
        private Boolean _Baja;
        public Boolean Baja { get { return _Baja; } set { _Baja = value; } }
    }
}