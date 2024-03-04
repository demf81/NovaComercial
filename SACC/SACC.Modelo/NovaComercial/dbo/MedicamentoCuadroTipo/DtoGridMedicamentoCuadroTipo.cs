using System;
using System.ComponentModel.DataAnnotations;


namespace SACC.Modelo.NovaComercial.dbo.MedicamentoCuadroTipo
{
    public class DtoGridMedicamentoCuadroTipo
    {
        public DtoGridMedicamentoCuadroTipo()
        { }
        
        Int32 _MedicamentoCuadroTipoId;
        public Int32 MedicamentoCuadroTipoId { get { return _MedicamentoCuadroTipoId; } set { _MedicamentoCuadroTipoId = value; } }
        
        String _MedicamentoCuadroTipoDescripcion;
        [StringLength(150)]
        public String MedicamentoCuadroTipoDescripcion { get { return _MedicamentoCuadroTipoDescripcion; } set { _MedicamentoCuadroTipoDescripcion = value; } }
        
        private Boolean? _Baja;
        public Boolean? Baja { get { return _Baja; } set { _Baja = value; } }
    }
}